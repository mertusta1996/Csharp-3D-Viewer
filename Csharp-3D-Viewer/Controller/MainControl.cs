using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using Assimp;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using Csharp3DViewer.Model;

namespace Csharp3DViewer.Controller
{
    /// <summary>
    /// The MainControl class serves as the primary orchestrator in the MVC pattern.
    /// It manages the state of the ModelData and executes business logic for 
    /// 3D asset processing and camera transformations.
    /// </summary>
    public class MainControl
    {
        ModelData model;

        #region Set Control Properties Methods

        public void SetModel(ModelData model)
        {
            this.model = model;
        }

        #endregion

        #region Get Model Properties Methods

        public bool GetModelIsLoaded()
        {
            return model.IsLoaded;
        }

        public int GetModelTextureId()
        {
            return model.TextureId;
        }

        public Matrix4 GetModelRotationMatrix()
        {
            return model.RotationMatrix;
        }

        public Vector3 GetModelPositionVector()
        {
            return model.PositionVector;
        }

        public float GetModelZoom()
        {
            return model.Zoom;
        }

        public List<Assimp.Mesh> GetModelActiveSceneMeshes()
        {
            return model.ActiveScene.Meshes;
        }

        #endregion

        #region Load Model/Texture Methods

        /// <summary>
        /// Loads a 3D model file and resets the camera viewport.
        /// </summary>
        /// <param name="path">The system file path to the 3D model.</param>
        public void LoadModel(string path, float sensitivity)
        {
            AssimpContext importer = new AssimpContext();

            // Post-processing: Triangulate faces, flip UVs for OpenGL, and center the pivot
            model.ActiveScene = importer.ImportFile(path,
                PostProcessSteps.Triangulate |
                PostProcessSteps.FlipUVs |
                PostProcessSteps.GenerateSmoothNormals |
                PostProcessSteps.PreTransformVertices);

            model.ResetTransformations(sensitivity);
        }

        /// <summary>
        /// Processes and binds an image file to an OpenGL Texture unit.
        /// </summary>
        /// <param name="path">The system file path to the image.</param>
        public void LoadTexture(string path)
        {
            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            using (Bitmap bmp = new Bitmap(path))
            {
                BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                    data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                    PixelType.UnsignedByte, data.Scan0);

                bmp.UnlockBits(data);
            }

            // Set filtering parameters for smooth scaling
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            model.TextureId = id;
        }

        #endregion

        #region Handle Rotation/Panning/Zoom Methods

        /// <summary>
        /// Modifies the model's rotation matrix based on user mouse movement.
        /// </summary>
        public void HandleRotation(float deltaX, float deltaY)
        {
            model.RotationMatrix *= OpenTK.Matrix4.CreateRotationY(OpenTK.MathHelper.DegreesToRadians(deltaX));
            model.RotationMatrix *= OpenTK.Matrix4.CreateRotationX(OpenTK.MathHelper.DegreesToRadians(deltaY));
        }

        /// <summary>
        /// Adjusts the model's spatial position (panning).
        /// </summary>
        public void HandlePanning(float deltaX, float deltaY, float sensitivity)
        {
            var pos = model.PositionVector;
            pos.X += deltaX * sensitivity;
            pos.Y -= deltaY * sensitivity;
            model.PositionVector = pos;
        }

        /// <summary>
        /// Updates the zoom level based on mouse wheel input.
        /// </summary>
        public void HandleZoom(bool zoomIn, float sensitivity)
        {
            model.Zoom += zoomIn ? 1.0f * sensitivity : -1.0f * sensitivity;
        }

        #endregion

    }
}