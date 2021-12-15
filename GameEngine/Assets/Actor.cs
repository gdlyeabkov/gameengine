using System;
using GameEngine;
using System.Speech.Synthesis;
using System.Windows.Media.Media3D;
using System.Windows.Controls;

class Actor : CrapBehaviour
{

	public bool isHero = true;
	public int experience = 50;

	public Actor(int id, string name, Viewport3D viewport) : base(id, name, viewport)
	{
	
	}

    public override void Start()
	{
		this.localDebugger = new SpeechSynthesizer();
		/*this.localDebugger.Speak("Actor Started as " + id);*/
		/*Morph.Move(viewport, id, new Vector3D(5, 0, 0));*/
		/*Morph.Twist(viewport, id, new Vector3D(1, 1, 1), 45);*/
		/*Morph.Ratio(viewport, id, new Vector3D(0.2, 0.2, 0.2));*/
	}

	public override void Update()
	{
        /*this.localDebugger.Speak("Actor was updated");*/
        this.localDebugger.Speak("Actor experience is " + experience.ToString());
        this.localDebugger.Speak("Actor isHero is " + isHero.ToString());
        // new Vector3D(Morph.GetLocation(viewport, id).X + 0.1, Morph.GetLocation(viewport, id).Y + 0.1, Morph.GetLocation(viewport, id).Z + 0.1)
        // Morph.Move(viewport, id, new Vector3D(3, 0, 0));
    }

	public override void Destroy()
	{
		localDebugger.Speak("Actor Destroy");
	}

}