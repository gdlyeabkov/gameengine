using System;
using GameEngine;
using System.Speech.Synthesis;
using System.Windows.Media.Media3D;
using System.Windows.Controls;

class Actor : CrapBehaviour
{
	public SpeechSynthesizer localDebugger;

    public Actor(int id, string name, Viewport3D viewport) : base(id, name, viewport)
	{
	
	}

    public override void Start()
	{
		this.localDebugger = new SpeechSynthesizer();
		/*this.localDebugger.Speak("Actor Started as " + id);*/
		/*Morph.Move(viewport, id, new Vector3D(5, 0, 0));*/
		/*Morph.Twist(viewport, id, new Vector3D(1, 1, 1), 45);*/
		Morph.Ratio(viewport, id, new Vector3D(2, 2, 2));
	}

}