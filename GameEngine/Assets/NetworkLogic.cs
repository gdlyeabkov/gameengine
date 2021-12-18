using System;
using System.IO;
using GameEngine;
using System.Speech.Synthesis;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;

class NetworkLogic: CrapBehaviour
{

	public int bps = 0;

	public NetworkLogic(int id, string name, Viewport3D viewport, List<Dictionary<String, Object>> components, bool graphicMode, MainWindow app, MediaElement player) : base(id, name, viewport, components, graphicMode, app, player)
	{
	
	}

	public NetworkLogic() : base()
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