using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct CLRDATA_ADDRESS_RANGE
	{
		public CLRDATA_ADDRESS StartAddress;
		public CLRDATA_ADDRESS EndAddress;
	}
}
