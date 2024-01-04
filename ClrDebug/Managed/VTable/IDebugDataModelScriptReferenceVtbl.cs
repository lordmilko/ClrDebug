using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugDataModelScriptReferenceVtbl
    {
        public readonly IntPtr Populate;
        public readonly IntPtr Execute;
        public readonly IntPtr Unlink;
        public readonly IntPtr InvokeMain;
        public readonly IntPtr Rename;
    }
}
