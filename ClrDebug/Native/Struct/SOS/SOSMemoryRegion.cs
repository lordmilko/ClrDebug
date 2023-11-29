using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("Start = {Start.ToString(),nq}, Size = {Size.ToString(),nq}, ExtraData = {ExtraData.ToString(),nq}, Heap = {Heap}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SOSMemoryRegion
    {
        public CLRDATA_ADDRESS Start;
        public CLRDATA_ADDRESS Size;
        public CLRDATA_ADDRESS ExtraData;
        public int Heap;
    }
}
