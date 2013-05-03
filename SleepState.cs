using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace SimplePlayer
{
    public static class SleepState
    {
        private static System.Security.SecureString _password()
        {
            System.Security.SecureString retval = new System.Security.SecureString();

            char[] chars = "s4fl9j??".ToCharArray();
            for (int n = 0; n < chars.Length; n++) retval.AppendChar(chars[n]);

            return retval;
        }

        private const string username = "HELLO";
        private static readonly System.Security.SecureString password = _password();

        private static bool? _cansleep;
        public static void set(bool cansleep)
        {
            if (_cansleep != null && _cansleep.Value == cansleep) return;

            _cansleep = cansleep;

            if (System.Diagnostics.Debugger.IsAttached) return;

            ProcessStartInfo info = new ProcessStartInfo(@"c:\windows\system32\powercfg.exe", "-requestsoverride PROCESS SimplePlayer.exe" + (cansleep ? " Display" : ""));
            info.Verb = "runas";
            Process.Start(info).WaitForExit();
        }

        /*
        [FlagsAttribute]
        private enum EXECUTION_STATE : uint
        {
            ES_SYSTEM_REQUIRED = 0x00000001,
            ES_DISPLAY_REQUIRED = 0x00000002,
            // Legacy flag, should not be used.
            // ES_USER_PRESENT   = 0x00000004,
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        public static void set(bool cansleep)
        {
            Debug.print("██ set cansleep = " + cansleep);
            if (cansleep)
            {
                SleepState.SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS); //Windows < Vista, forget away mode
            }
            else
            {
                SleepState.SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS
                        | EXECUTION_STATE.ES_DISPLAY_REQUIRED
                        | EXECUTION_STATE.ES_SYSTEM_REQUIRED
                        | EXECUTION_STATE.ES_AWAYMODE_REQUIRED); //Windows < Vista, forget away mode
            }
        }
        */
    }
}
