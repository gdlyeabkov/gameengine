using System;
using GameEngine;
using System.Speech.Synthesis;
using System.Windows.Media.Media3D;
using System.Windows.Controls;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
class CustomBehaviour1 : CrapBehaviour
{
	public CustomBehaviour1(int id, string name, Viewport3D viewport, List<Dictionary<String, Object>> components, bool graphicMode, MainWindow app, MediaElement player) : base(id, name, viewport, components, graphicMode, app, player)
	{
	
	}

	public CustomBehaviour1() : base()
	{
	
	}

	public override void Start()
	{
		this.localDebugger = new SpeechSynthesizer();
		this.localDebugger.Speak("CustomBehaviour1 Started as " + name);
	}

	public override void Update()
	{
		this.localDebugger.Speak("CustomBehaviour1 was updated");
	}

}