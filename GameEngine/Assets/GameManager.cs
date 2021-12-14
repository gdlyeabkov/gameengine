using System;
using System.IO;
using GameEngine;
using System.Speech.Synthesis;
using System.Windows.Controls;

class GameManager : CrapBehaviour
{
	public SpeechSynthesizer localDebugger;

	public GameManager(int id, string name, Viewport3D viewport) : base(id, name, viewport)
	{
	
	}

	public override void Start()
	{
		this.localDebugger = new SpeechSynthesizer();
		this.localDebugger.Speak("GameManager Start as " + id);
	}

}