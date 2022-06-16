using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpThreadLocalModuleData
	{
		public CLRDATA_ADDRESS threadAddr;
		public long ModuleIndex;
		public CLRDATA_ADDRESS pClassData;
		public CLRDATA_ADDRESS pDynamicClassTable;
		public CLRDATA_ADDRESS pGCStaticDataStart;
		public CLRDATA_ADDRESS pNonGCStaticDataStart;
	}
}
