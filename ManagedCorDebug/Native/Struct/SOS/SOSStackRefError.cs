using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct SOSStackRefError
	{
		public SOSStackSourceType SourceType;
		public CLRDATA_ADDRESS Source;
		public CLRDATA_ADDRESS StackPointer;
	}
}
