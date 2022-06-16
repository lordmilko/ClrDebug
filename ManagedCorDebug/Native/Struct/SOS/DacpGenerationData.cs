using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpGenerationData
	{
		public CLRDATA_ADDRESS start_segment;
		public CLRDATA_ADDRESS allocation_start;
		public CLRDATA_ADDRESS allocContextPtr;
		public CLRDATA_ADDRESS allocContextLimit;
	}
}
