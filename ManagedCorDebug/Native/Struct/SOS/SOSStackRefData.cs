using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
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
