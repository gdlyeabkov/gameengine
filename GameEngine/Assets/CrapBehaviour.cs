using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace GameEngine
{
    class CrapBehaviour
    {
        public SpeechSynthesizer localDebugger;
        public virtual void Start()
        {
            localDebugger.Speak("b");
        }

        public CrapBehaviour()
        {
            this.localDebugger = new SpeechSynthesizer();
            localDebugger.Speak("a");
            this.Start();
        }
    }
}
