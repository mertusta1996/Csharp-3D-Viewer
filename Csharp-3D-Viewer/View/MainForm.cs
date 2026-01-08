using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Csharp3DViewer.Controller;
using Csharp_3D_Viewer.Common;

namespace Csharp3DViewer.View
{
    public partial class MainForm : Form
    {
        MainControl control;

        private Point _lastMousePos;
        private bool _isSuppressingInput = false;

        #region Set Form Properties Methods

        public MainForm()
        {
            InitializeComponent();
        }

        public void SetControl(MainControl control)
        {
            this.control = control;
        }

        #endregion

        #region UI Command Handlers

        private async void Load_Model_Button_Click(object sender, EventArgs e)
        {
            float zoomAndPanSensitivity = GetZoomAndPanSensitivityMultiplier();
            using 
            (
                OpenFileDialog ofd = new OpenFileDialog 
                { 
                    Filter = "3D Models|*.obj;*.fbx;*.stl",
                    InitialDirectory = DefaultParameters.defaultExamplesPath
                }
            )
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pnlLoading.Visible = true;
                        pnlLoading.BringToFront();
                        this.Cursor = Cursors.WaitCursor;

                        string path = ofd.FileName;
                        await Task.Run(() => control.LoadModel(path, zoomAndPanSensitivity));

                        _isSuppressingInput = true;
                        glControl1.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        pnlLoading.Visible = false;
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void Load_Texture_Button_Click(object sender, EventArgs e)
        {
            if (!control.GetModelIsLoaded())
            {
                MessageBox.Show("Please load a model first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using 
            (
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "Images|*.jpg;*.png;*.bmp",
                    InitialDirectory = DefaultParameters.defaultExamplesPath
                }
            )
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        control.LoadTexture(ofd.FileName);
                        _isSuppressingInput = true;
                        glControl1.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        #endregion

        #region OpenGL Rendering Pipeline

        private void GlControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!control.GetModelIsLoaded()) return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            ApplyViewportMatrices();
            SetupLighting();
            RenderActiveModel();

            glControl1.SwapBuffers();
        }

        private void ApplyViewportMatrices()
        {
            float aspectRatio = glControl1.Width / (float)glControl1.Height;
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), aspectRatio, 0.01f, 50000.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.MatrixMode(MatrixMode.Modelview);
            Matrix4 translation = Matrix4.CreateTranslation(control.GetModelPositionVector());
            Matrix4 view = Matrix4.CreateTranslation(0, 0, control.GetModelZoom());
            Matrix4 modelView = control.GetModelRotationMatrix() * translation * view;
            GL.LoadMatrix(ref modelView);
        }

        private void SetupLighting()
        {
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.ColorMaterial);
            GL.Enable(EnableCap.Normalize);

            float[] ambientLight = { 1.0f, 1.0f, 1.0f, 1.0f };
            GL.Light(LightName.Light0, LightParameter.Ambient, ambientLight);

            float[] diffuseLight = { 0.0f, 0.0f, 0.0f, 1.0f };
            GL.Light(LightName.Light0, LightParameter.Diffuse, diffuseLight);
        }

        private void RenderActiveModel()
        {
            if (control.GetModelTextureId() != -1)
            {
                GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, control.GetModelTextureId());
            }

            foreach (var mesh in control.GetModelActiveSceneMeshes())
            {
                GL.Begin(PrimitiveType.Triangles);
                foreach (var face in mesh.Faces)
                {
                    foreach (var index in face.Indices)
                    {
                        if (mesh.HasTextureCoords(0))
                        {
                            var uv = mesh.TextureCoordinateChannels[0][index];
                            GL.TexCoord2(uv.X, uv.Y);
                        }
                        if (mesh.HasNormals)
                        {
                            var norm = mesh.Normals[index];
                            GL.Normal3(norm.X, norm.Y, norm.Z);
                        }
                        var vert = mesh.Vertices[index];
                        GL.Vertex3(vert.X, vert.Y, vert.Z);
                    }
                }
                GL.End();
            }
        }

        #endregion

        #region User Interaction

        private float GetZoomAndPanSensitivityMultiplier()
        {
            return (float)Math.Pow(10, (tbSensitivity.Value - 20) / 20.0);
        }

        private void GlControl1_MouseDown(object sender, MouseEventArgs e)
        {
            _lastMousePos = e.Location;
        }

        private void GlControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isSuppressingInput)
            {
                if (e.Button == MouseButtons.None) _isSuppressingInput = false;
                _lastMousePos = e.Location;
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                control.HandleRotation((e.X - _lastMousePos.X) * 0.5f, (e.Y - _lastMousePos.Y) * 0.5f);
            }
            else if (e.Button == MouseButtons.Right)
            {
                control.HandlePanning((e.X - _lastMousePos.X) * 0.05f, (e.Y - _lastMousePos.Y) * 0.05f, GetZoomAndPanSensitivityMultiplier());
            }

            _lastMousePos = e.Location;
            glControl1.Invalidate();
        }

        private void GlControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            control.HandleZoom(e.Delta > 0, GetZoomAndPanSensitivityMultiplier());
            glControl1.Invalidate();
        }

        private void GlControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);

            pnlLoading.Left = (this.ClientSize.Width - pnlLoading.Width) / 2;
            pnlLoading.Top = (this.ClientSize.Height - pnlLoading.Height) / 2;

            glControl1.Invalidate();
        }

        #endregion
    }
}