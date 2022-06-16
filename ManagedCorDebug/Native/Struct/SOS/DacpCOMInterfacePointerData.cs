using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpCOMInterfacePointerData
	{
		public CLRDATA_ADDRESS methodTable;
		public CLRDATA_ADDRESS interfacePtr;
		public CLRDATA_ADDRESS comContext;
	}
}
