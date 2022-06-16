using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct CLRDATA_IL_ADDRESS_MAP
	{
		public int ILOffset;
		public CLRDATA_ADDRESS StartAddress;
		public CLRDATA_ADDRESS EndAddress;
		public CLRDataSourceType Type;
	}
}
