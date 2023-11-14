using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    [DebuggerDisplay("ulKind = {ulKind.ToString(),nq}, propid = {propid}, lpwstr = {lpwstr.ToString(),nq}")]
    [StructLayout(LayoutKind.Explicit, Pack = 4)]
    public struct PROPSPEC
    {
        [FieldOffset(0)]
        public PRSPEC ulKind;

        [FieldOffset(4)]
        public int propid;

        [FieldOffset(4)]
        public IntPtr lpwstr;
    }
}
