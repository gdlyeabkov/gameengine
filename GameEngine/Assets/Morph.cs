using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace GameEngine
{
    class Morph
    {
        public static void Move(Viewport3D space, int gameObjectIndex, Vector3D vector)
        {
            ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex]));
            Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
            Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
            TranslateTransform3D currentMeshTransformTranslate = ((TranslateTransform3D)(currentMeshTransform.Children[0]));
            currentMeshTransformTranslate.OffsetX = vector.X;
            currentMeshTransformTranslate.OffsetY = vector.Y;
            currentMeshTransformTranslate.OffsetZ = vector.Z;
        }

        public static void Twist(Viewport3D space, int gameObjectIndex, Vector3D axes, int angle)
        {
            ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex]));
            Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
            Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
            RotateTransform3D currentMeshTransformRotate = ((RotateTransform3D)(currentMeshTransform.Children[2]));
            currentMeshTransformRotate.Rotation = new AxisAngleRotation3D(axes, angle);
        }

        public static void Ratio(Viewport3D space, int gameObjectIndex, Vector3D ratios)
        {
            ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex]));
            Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
            Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
            ScaleTransform3D currentMeshTransformRotate = ((ScaleTransform3D)(currentMeshTransform.Children[1]));
            currentMeshTransformRotate.ScaleX = ratios.X;
            currentMeshTransformRotate.ScaleY = ratios.Y;
            currentMeshTransformRotate.ScaleZ = ratios.Z;
        }

        public static Vector3D GetLocation(Viewport3D space, int gameObjectIndex)
        {
            ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex]));
            Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
            Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
            TranslateTransform3D currentMeshTransformTranslate = ((TranslateTransform3D)(currentMeshTransform.Children[0]));
            return new Vector3D(currentMeshTransformTranslate.OffsetX, currentMeshTransformTranslate.OffsetY, currentMeshTransformTranslate.OffsetZ);
        }

    }
}
