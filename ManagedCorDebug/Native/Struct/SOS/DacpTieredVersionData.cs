using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpTieredVersionData
	{
		public CLRDATA_ADDRESS NativeCodeAddr;
		public OptimizationTier OptimizationTier;
		public CLRDATA_ADDRESS NativeCodeVersionNodePtr;
	}
}
