using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace GameEngine
{
    class Camera
    {
        public static void Move(Viewport3D space, Point3D vector, bool graphicMode)
        {
            if (graphicMode) {
                ((OrthographicCamera)(space.Camera)).Position = vector;
            } 
            else if (!graphicMode)
            {
                ((PerspectiveCamera)(space.Camera)).Position = vector;
            }
        }

    }
}
