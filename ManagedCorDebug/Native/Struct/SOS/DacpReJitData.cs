using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpReJitData
	{
		public CLRDATA_ADDRESS rejitID;
		public DacpReJitDataFlags flags;
		public CLRDATA_ADDRESS NativeCodeAddr;
	}
}
