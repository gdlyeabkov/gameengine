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

        public static Point3D GetShootLocation(Viewport3D space, bool graphicMode)
        {
            Point3D shootLocation = new Point3D(0, 0, 5);
            if (graphicMode)
            {
                shootLocation = ((OrthographicCamera)(space.Camera)).Position;
            }
            else if (!graphicMode)
            {
                shootLocation = ((PerspectiveCamera)(space.Camera)).Position;
            }
            return shootLocation;
        }

    }
}
