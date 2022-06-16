using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpReJitData2
	{
		public int rejitID;
		public DacpReJitDataFlags flags;
		public CLRDATA_ADDRESS il;
		public CLRDATA_ADDRESS ilCodeVersionNodePtr;
	}
}
