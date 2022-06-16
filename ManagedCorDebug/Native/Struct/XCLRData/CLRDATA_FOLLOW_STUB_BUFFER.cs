using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct CLRDATA_FOLLOW_STUB_BUFFER
	{
		public fixed ulong Data[8];
	}
}
