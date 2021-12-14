using System;
using System.IO;
using GameEngine;
using System.Speech.Synthesis;
class Actor : CrapBehaviour
{
	public SpeechSynthesizer localDebugger;

	public override void Start()
	{
		this.localDebugger = new SpeechSynthesizer();
		this.localDebugger.Speak("Actor Start");
	}

}