using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace GameEngine
{
    static class Period
    {
        public static SpeechSynthesizer localDebugger;
        public static int elapsedTime = 0;
        public static async Task SetInterval(Action action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);

            action();

            SetInterval(action, timeout);
        }
        public static void StartCountdown(Action updateHook)
        {
            localDebugger = new SpeechSynthesizer();
            SetInterval(() => {
                elapsedTime++;
                /*localDebugger.Speak("прошло секунд: " + elapsedTime.ToString());*/
                updateHook();
            }, TimeSpan.FromSeconds(1));
        }
    }
}
