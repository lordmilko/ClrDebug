using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct CLRDATA_MODULE_EXTENT
	{
		public CLRDATA_ADDRESS Base;
		public int Length;
		public CLRDataModuleExtentType Type;
	}
}
