using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugModelQueryVtbl
    {
        public readonly IntPtr QueryModel;
        public readonly IntPtr QueryModelForCompletion;
        public readonly IntPtr WriteModel;
    }
}
