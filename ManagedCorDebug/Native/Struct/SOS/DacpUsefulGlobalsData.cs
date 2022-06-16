using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpUsefulGlobalsData
	{
		public CLRDATA_ADDRESS ArrayMethodTable;
		public CLRDATA_ADDRESS StringMethodTable;
		public CLRDATA_ADDRESS ObjectMethodTable;
		public CLRDATA_ADDRESS ExceptionMethodTable;
		public CLRDATA_ADDRESS FreeMethodTable;
    }
}
