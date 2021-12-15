using System;
using System.IO;
using GameEngine;
using System.Speech.Synthesis;
using System.Windows.Controls;

class GameManager : CrapBehaviour
{

	public string genre = "action";
	public GameManager(int id, string name, Viewport3D viewport) : base(id, name, viewport)
	{
	
	}

	public override void Start()
	{
		this.localDebugger = new SpeechSynthesizer();
		this.localDebugger.Speak("GameManager Start as " + id);
	}

	public override void Update()
	{
		/*this.localDebugger.Speak("GameManager was updated");*/
		this.localDebugger.Speak("GameManager genre is " + genre.ToString());
	}

}