using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct CLRDATA_METHDEF_EXTENT
	{
		public CLRDATA_ADDRESS StartAddress;
		public CLRDATA_ADDRESS EndAddress;
		public int EnCVersion;
		public CLRDataMethodDefinitionExtentType Type;
	}
}
