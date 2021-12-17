using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Speech.Synthesis;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Controls;
using System.Windows;

namespace GameEngine
{
    public class CrapBehaviour
    {
        protected SpeechSynthesizer localDebugger;
        protected int id;
        protected string name;
        protected Viewport3D viewport;
        protected List<Dictionary<String, Object>> components;
        protected bool graphicMode;
        protected MainWindow app;
        static Control controlSingltone;
        protected MediaElement player;
        static SoundTrack soundTrackSingltone;

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

        public Component FetchComponent<Component>()
        {
            Component newComponent = ((Component)(Activator.CreateInstance(typeof(Component))));
            if (components.Where(component => component["name"].ToString() == typeof(Component).Name).Count() >= 1)
            {

            }
            else
            {
                // logs
                localDebugger.Speak("добавляю в Логи");
            }
            return newComponent;
        }

        public CrapBehaviour(int id, string name, Viewport3D viewport, List<Dictionary<String, Object>> components, bool graphicMode, MainWindow app, MediaElement player)
        {
            this.localDebugger = new SpeechSynthesizer();
            localDebugger.Speak("CrapBehaviour Constructor");
            this.id = id;
            this.name = name;
            this.viewport = viewport;
            this.components = components;
            this.graphicMode = graphicMode;
            this.app = app;
            controlSingltone = new Control(app);
            this.player = player;
            soundTrackSingltone = new SoundTrack(player);
            this.Start();
            Period.StartCountdown(() => this.Update());
        }
        public CrapBehaviour()
        {
            this.localDebugger = new SpeechSynthesizer();
            localDebugger.Speak("CrapBehaviour Constructor");
            this.Start();
        }

        public static implicit operator CrapBehaviour((CrapBehaviour, Window app) v)
        {
            throw new NotImplementedException();
        }
    }
}
