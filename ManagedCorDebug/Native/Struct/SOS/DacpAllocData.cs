using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpAllocData
	{
		public CLRDATA_ADDRESS allocBytes;
		public CLRDATA_ADDRESS allocBytesLoh;
	}
}
