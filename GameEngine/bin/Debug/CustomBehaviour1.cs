using System;
using GameEngine;
using System.Speech.Synthesis;
class CustomBehaviour1 : CrapBehaviour
{
public SpeechSynthesizer localDebugger;

public override void Start()
{
this.localDebugger = new SpeechSynthesizer();
this.localDebugger.Speak("Actor Started as " + name);
}
}
