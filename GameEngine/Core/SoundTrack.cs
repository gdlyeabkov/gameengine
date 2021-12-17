using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameEngine
{
    class SoundTrack
    {

        static public MediaElement player;
        
        public static void ShutUp()
        {
            player.Stop();
        }

        public SoundTrack (MediaElement player)
        {
            SoundTrack.player = player;
        }

    }
}
