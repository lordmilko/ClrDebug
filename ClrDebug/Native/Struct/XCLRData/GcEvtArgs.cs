using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("Typ = {Typ.ToString(),nq}, CondemnedGeneration = {CondemnedGeneration}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct GcEvtArgs
    {
        public GcEvt_t Typ;
        public int CondemnedGeneration;
    }
}
