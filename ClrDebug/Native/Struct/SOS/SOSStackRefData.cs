using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("HasRegisterInformation = {HasRegisterInformation}, Register = {Register}, Offset = {Offset}, Address = {Address.ToString(),nq}, Object = {Object.ToString(),nq}, Flags = {Flags}, SourceType = {SourceType.ToString(),nq}, Source = {Source.ToString(),nq}, StackPointer = {StackPointer.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SOSStackRefData
    {
        public int HasRegisterInformation;
        public int Register;
        public int Offset;
        public CLRDATA_ADDRESS Address;
        public CLRDATA_ADDRESS Object;
        public int Flags;
        public SOSStackSourceType SourceType;
        public CLRDATA_ADDRESS Source;
        public CLRDATA_ADDRESS StackPointer;
    }
}
