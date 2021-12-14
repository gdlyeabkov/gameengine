using System;
using GameEngine;
using System.Speech.Synthesis;

class NetworkLogic: CrapBehaviour
{
	public SpeechSynthesizer localDebugger;

	public NetworkLogic()
    {
		this.localDebugger = new SpeechSynthesizer();
	}
	static int MainC(string[] args)
	{
		return 1;
	}
	public override void Start()
    {
		localDebugger.Speak("c");
	}
	
}