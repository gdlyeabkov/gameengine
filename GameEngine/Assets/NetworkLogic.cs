using System;
using System.IO;
using GameEngine;
using System.Speech.Synthesis;
using System.Windows.Controls;

class NetworkLogic: CrapBehaviour
{

	public int bps = 0;

	public NetworkLogic(int id, string name, Viewport3D viewport) : base(id, name, viewport)
	{
	
	}

	public override void Start()
	{
		this.localDebugger = new SpeechSynthesizer();
		this.localDebugger.Speak("NetworkLogic Start as " + id);
	}

	public override void Update()
	{
		/*this.localDebugger.Speak("NetworkLogic was updated");*/
		this.localDebugger.Speak("NetworkLogic bps is " + bps.ToString());
	}

}