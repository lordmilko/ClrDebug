using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct SOSHandleData
	{
		public CLRDATA_ADDRESS AppDomain;
		public CLRDATA_ADDRESS Handle;
		public CLRDATA_ADDRESS Secondary;
		public int Type;
		public int StrongReference;
		public int RefCount;
		public int JupiterRefCount;
		public int IsPegged;
	}
}
