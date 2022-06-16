using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpGenerationAllocData
	{
        private const int DAC_NUMBERGENERATIONS = 4;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DAC_NUMBERGENERATIONS)]
        public DacpAllocData[] allocData;
	}
}
