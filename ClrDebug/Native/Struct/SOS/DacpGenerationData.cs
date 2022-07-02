using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("start_segment = {start_segment.ToString(),nq}, allocation_start = {allocation_start.ToString(),nq}, allocContextPtr = {allocContextPtr.ToString(),nq}, allocContextLimit = {allocContextLimit.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpGenerationData
    {
        public CLRDATA_ADDRESS start_segment;
        public CLRDATA_ADDRESS allocation_start;
        public CLRDATA_ADDRESS allocContextPtr;
        public CLRDATA_ADDRESS allocContextLimit;
    }
}
