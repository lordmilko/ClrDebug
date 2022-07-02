using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("allocBytes = {allocBytes.ToString(),nq}, allocBytesLoh = {allocBytesLoh.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpAllocData
    {
        public CLRDATA_ADDRESS allocBytes;
        public CLRDATA_ADDRESS allocBytesLoh;
    }
}
