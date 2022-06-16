using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpJitManagerInfo
	{
		public CLRDATA_ADDRESS managerAddr;
		public int codeType;
		public CLRDATA_ADDRESS ptrHeapList;
    }
}
