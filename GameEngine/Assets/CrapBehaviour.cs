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
        protected SpeechSynthesizer localDebugger;
        protected int id;
        protected string name;
        protected Viewport3D viewport;
        public virtual void Start()
        {
            localDebugger.Speak("CrapBehaviour Start");
        }

        public virtual void Update()
        {
            localDebugger.Speak("CrapBehaviour Update");
        }

        public virtual void Destroy()
        {
            localDebugger.Speak("CrapBehaviour Destroy");
        }

        public CrapBehaviour(int id, string name, Viewport3D viewport)
        {
            this.localDebugger = new SpeechSynthesizer();
            localDebugger.Speak("CrapBehaviour Constructor");
            this.id = id;
            this.name = name;
            this.viewport = viewport;
            this.Start();
            Period.StartCountdown(() => this.Update());
        }
        public CrapBehaviour()
        {
            this.localDebugger = new SpeechSynthesizer();
            localDebugger.Speak("CrapBehaviour Constructor");
            this.Start();
        }
    }
}
