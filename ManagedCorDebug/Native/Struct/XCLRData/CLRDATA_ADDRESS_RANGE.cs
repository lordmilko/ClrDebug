using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("StartAddress = {StartAddress.ToString(),nq}, EndAddress = {EndAddress.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct CLRDATA_ADDRESS_RANGE
    {
        public CLRDATA_ADDRESS StartAddress;
        public CLRDATA_ADDRESS EndAddress;
    }
}
