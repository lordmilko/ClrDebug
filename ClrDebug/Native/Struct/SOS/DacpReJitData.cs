using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("rejitID = {rejitID.ToString(),nq}, flags = {flags.ToString(),nq}, NativeCodeAddr = {NativeCodeAddr.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpReJitData
    {
        public CLRDATA_ADDRESS rejitID;
        public DacpReJitDataFlags flags;
        public CLRDATA_ADDRESS NativeCodeAddr;
    }
}
