using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugPlmClient3Vtbl
    {
        public readonly IntPtr LaunchPlmPackageForDebugWide;
        public readonly IntPtr LaunchPlmBgTaskForDebugWide;
        public readonly IntPtr QueryPlmPackageWide;
        public readonly IntPtr QueryPlmPackageList;
        public readonly IntPtr EnablePlmPackageDebugWide;
        public readonly IntPtr DisablePlmPackageDebugWide;
        public readonly IntPtr SuspendPlmPackageWide;
        public readonly IntPtr ResumePlmPackageWide;
        public readonly IntPtr TerminatePlmPackageWide;
        public readonly IntPtr LaunchAndDebugPlmAppWide;
        public readonly IntPtr ActivateAndDebugPlmBgTaskWide;
    }
}
