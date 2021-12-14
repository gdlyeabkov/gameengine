using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Speech.Synthesis;
using System.IO;
using System.Speech.Synthesis;

namespace GameEngine
{
    public class CrapBehaviour
    {
        public SpeechSynthesizer localDebugger;
        public virtual void Start()
        {
            localDebugger.Speak("CrapBehaviour Start");
        }

        public CrapBehaviour()
        {
            this.localDebugger = new SpeechSynthesizer();
            localDebugger.Speak("CrapBehaviour Constructor");
            this.Start();
        }
    }
}
