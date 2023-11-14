using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    [DebuggerDisplay("cElems = {cElems}, pElems = {pElems}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct CADBL
    {
        public int cElems;
        public double* pElems;
    }
}
