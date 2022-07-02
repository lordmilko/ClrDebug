using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("SourceType = {SourceType.ToString(),nq}, Source = {Source.ToString(),nq}, StackPointer = {StackPointer.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SOSStackRefError
    {
        public SOSStackSourceType SourceType;
        public CLRDATA_ADDRESS Source;
        public CLRDATA_ADDRESS StackPointer;
    }
}
