using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    [DebuggerDisplay("cElems = {cElems}, pElems = {pElems.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct CADATE
    {
        public int cElems;
        public IntPtr pElems;
    }
}
