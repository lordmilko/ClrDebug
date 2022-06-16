using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpProfilerILData
	{
		public ModificationType Type;
		public CLRDATA_ADDRESS il;
		public int rejitID;
	}
}
