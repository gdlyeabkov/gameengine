using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace GameEngine
{
    class Illumination
    {
        
        public static void SetHorizont(Viewport3D viewport, Vector3D horizont)
        {
            ModelVisual3D currentMesh = ((ModelVisual3D)(viewport.Children[0]));
            DirectionalLight light = ((DirectionalLight)(currentMesh.Content));
            light.Direction = horizont;
        }

        public static void SetDiffraction(Viewport3D viewport, Color diffraction)
        {
            ModelVisual3D currentMesh = ((ModelVisual3D)(viewport.Children[0]));
            DirectionalLight light = ((DirectionalLight)(currentMesh.Content));
            light.Color = diffraction;
        }


    }
}
