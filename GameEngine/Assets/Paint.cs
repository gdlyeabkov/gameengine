using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace GameEngine
{
    class Paint
    {
        public static void AssignColour(Viewport3D space, int gameObjectIndex, System.Windows.Media.Brush colour)
        {
            ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex]));
            GeometryModel3D currentMeshModel = ((GeometryModel3D)(currentMesh.Content));
            MaterialGroup currentMeshMaterialGroup = ((MaterialGroup)(currentMeshModel.Material));
            DiffuseMaterial currentMeshMaterial = new DiffuseMaterial();
            currentMeshMaterial.Brush = colour;
            currentMeshMaterialGroup.Children.Add(currentMeshMaterial);
        }
    }
}
