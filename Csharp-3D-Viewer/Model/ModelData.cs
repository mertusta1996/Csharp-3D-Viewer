using Assimp;
using OpenTK;

namespace Csharp3DViewer.Model
{
    /// <summary>
    /// Represents the data state of the 3D application, including 
    /// the 3D mesh data, scene, texture id, and transformation vectors.
    /// </summary>
    public class ModelData
    {
        public Scene ActiveScene { get; set; }
        public int TextureId { get; set; } = -1;
        public bool IsLoaded => ActiveScene != null;

        // Transformation State
        public Matrix4 RotationMatrix { get; set; } = Matrix4.Identity;
        public Vector3 PositionVector { get; set; } = Vector3.Zero;
        public float Zoom { get; set; } = -5.0f;

        #region Reset Transformations Methods

        /// <summary>
        /// Resets transformation variables to default values.
        /// </summary>
        public void ResetTransformations(float sensitivity)
        {
            RotationMatrix = Matrix4.Identity;
            PositionVector = Vector3.Zero;
            Zoom = -5.0f * sensitivity;
        }

        #endregion

    }
}