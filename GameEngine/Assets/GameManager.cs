using System;
using System.IO;
using GameEngine;
using System.Speech.Synthesis;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;

class GameManager : CrapBehaviour
{

	public string genre = "action";
	public GameManager(int id, string name, Viewport3D viewport, List<Dictionary<String, Object>> components, bool graphicMode, MainWindow app, MediaElement player) : base(id, name, viewport, components, graphicMode, app, player)
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