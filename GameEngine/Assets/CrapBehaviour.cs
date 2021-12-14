using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Speech.Synthesis;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Controls;

namespace GameEngine
{
    public class CrapBehaviour
    {
        public SpeechSynthesizer localDebugger;
        public int id;
        public string name;
        public Viewport3D viewport;
        public virtual void Start()
        {
            localDebugger.Speak("CrapBehaviour Start");
        }

        public CrapBehaviour(int id, string name, Viewport3D viewport)
        {
            this.localDebugger = new SpeechSynthesizer();
            localDebugger.Speak("CrapBehaviour Constructor");
            this.id = id;
            this.name = name;
            this.viewport = viewport;
            this.Start();
        }
        public CrapBehaviour()
        {
            this.localDebugger = new SpeechSynthesizer();
            localDebugger.Speak("CrapBehaviour Constructor");
            this.Start();
        }
    }
}
