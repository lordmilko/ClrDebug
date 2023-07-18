using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    [DebuggerDisplay("allocData = {allocData}")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DacpGenerationAllocData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DAC_NUMBERGENERATIONS)]
        public DacpAllocData[] allocData;
    }
}
