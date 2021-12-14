using System;
using System.IO;
using GameEngine;
using System.Speech.Synthesis;
using System.Windows.Controls;

class NetworkLogic: CrapBehaviour
{
	public SpeechSynthesizer localDebugger;

	public NetworkLogic(int id, string name, Viewport3D viewport) : base(id, name, viewport)
	{
	
	}

	public override void Start()
	{
		this.localDebugger = new SpeechSynthesizer();
		this.localDebugger.Speak("NetworkLogic Start as " + id);
	}
	
}