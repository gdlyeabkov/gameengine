using System;
using GameEngine;
using System.Speech.Synthesis;
using System.Windows.Media.Media3D;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

class Actor : CrapBehaviour
{

	public bool isHero = true;
	public int experience = 50;

	public Actor(int id, string name, Viewport3D viewport, List<Dictionary<String, Object>> components, bool graphicMode, MainWindow app) : base(id, name, viewport, components, graphicMode, app)
	{
	
	}

    public override void Start()
	{
		this.localDebugger = new SpeechSynthesizer();
		/*this.localDebugger.Speak("Actor Started as " + id);*/
		/*Morph.Move(viewport, id, new Vector3D(5, 0, 0));*/
		/*Morph.Twist(viewport, id, new Vector3D(1, 1, 1), 45);*/
		/*Morph.Ratio(viewport, id, new Vector3D(0.2, 0.2, 0.2));*/
		Paint.AssignColour(viewport, id, System.Windows.Media.Brushes.White);
	}

	public override void Update()
	{
        /*this.localDebugger.Speak("Actor was updated");*/
        /*this.localDebugger.Speak("Actor experience is " + experience.ToString());
        this.localDebugger.Speak("Actor isHero is " + isHero.ToString());*/
        // Morph.Move(viewport, id, new Vector3D(Morph.GetLocation(viewport, id).X + 0.1, Morph.GetLocation(viewport, id).Y, Morph.GetLocation(viewport, id).Z));
        // Morph.Move(viewport, id, new Vector3D(3, 0, 0));
        // this.localDebugger.Speak("Actor experience is " + FetchComponent<NetworkLogic>().bps.ToString());
        /*try {
			this.localDebugger.Speak("Actor experience is " + Morph.GetLocation(viewport, id).X.ToString());
		} catch(Exception e)
        {
			this.localDebugger.Speak("ошибка: " + e.ToString());
		}*/
        // Morph.Twist(viewport, id, new Vector3D(Morph.GetSpin(viewport, id) + 0.1, Morph.GetSpin(viewport, id) + 0.1, Morph.GetSpin(viewport, id) + 0.1), 45);
        // Morph.Ratio(viewport, id, new Vector3D(Morph.GetSize(viewport, id).X + 0.001, Morph.GetSize(viewport, id).Y + 0.001, Morph.GetSize(viewport, id).Z + 0.001));
        // GameEngine.Camera.Move(viewport, new Point3D(new Random(5).Next(), 0, 5), graphicMode);
        /*if (GameEngine.Control.IsKeyUp(Key.Enter))
        {
			this.localDebugger.Speak(" лавиша Enter была нажата");
		} else
        {
			this.localDebugger.Speak(" лавиша Enter не нажата");
		}*/
        /*if (GameEngine.Control.IsKeyFree(Key.Left))
        {
            Morph.Move(viewport, id, new Vector3D(Morph.GetLocation(viewport, id).X - 0.1, Morph.GetLocation(viewport, id).Y, Morph.GetLocation(viewport, id).Z));
        }
        else if (GameEngine.Control.IsKeyFree(Key.Right))
        {
            Morph.Move(viewport, id, new Vector3D(Morph.GetLocation(viewport, id).X + 0.1, Morph.GetLocation(viewport, id).Y, Morph.GetLocation(viewport, id).Z));
        }*/

        /*if (GameEngine.Control.IsKeyHolded(Key.Left))
        {
            Morph.Move(viewport, id, new Vector3D(Morph.GetLocation(viewport, id).X - 0.1, Morph.GetLocation(viewport, id).Y, Morph.GetLocation(viewport, id).Z));
        }
        else if (GameEngine.Control.IsKeyHolded(Key.Right))
        {
            Morph.Move(viewport, id, new Vector3D(Morph.GetLocation(viewport, id).X + 0.1, Morph.GetLocation(viewport, id).Y, Morph.GetLocation(viewport, id).Z));
        }*/

        if (GameEngine.Control.IsMouseBtn("left", false))
        {
            this.localDebugger.Speak("лева€ клавиша мыши была нажата");
        }
        else if (GameEngine.Control.IsMouseBtn("middle", false))
        {
            this.localDebugger.Speak("средн€€  лавиша мыши нажата");
        }
        else if (GameEngine.Control.IsMouseBtn("right", false))
        {
            this.localDebugger.Speak("права€  лавиша мыши нажата");
        }
        else
        {
            this.localDebugger.Speak(" лавиша мыши не нажата");
        }
        /*if (GameEngine.Control.IsMouseBtn("left"))
        {
            Morph.Move(viewport, id, new Vector3D(Morph.GetLocation(viewport, id).X - 0.1, Morph.GetLocation(viewport, id).Y, Morph.GetLocation(viewport, id).Z));
        }
        else if (GameEngine.Control.IsMouseBtn("right"))
        {
            Morph.Move(viewport, id, new Vector3D(Morph.GetLocation(viewport, id).X + 0.1, Morph.GetLocation(viewport, id).Y, Morph.GetLocation(viewport, id).Z));
        }
        else if (GameEngine.Control.IsMouseBtn("middle"))
        {
            Morph.Move(viewport, id, new Vector3D(Morph.GetLocation(viewport, id).X + 0.1, Morph.GetLocation(viewport, id).Y, Morph.GetLocation(viewport, id).Z));
        }*/

    }

	public override void Destroy()
	{
		localDebugger.Speak("Actor Destroy");
	}

}