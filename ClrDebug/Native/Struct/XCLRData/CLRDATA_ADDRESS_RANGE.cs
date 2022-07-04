using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Defines an address range.
    /// </summary>
    /// <remarks>
    /// This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define
    /// the structure as specified above, where CLRDATA_ADDRESS is a 64-bit unsigned integer.
    /// </remarks>
    [DebuggerDisplay("StartAddress = {StartAddress.ToString(),nq}, EndAddress = {EndAddress.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct CLRDATA_ADDRESS_RANGE
    {
        public CLRDATA_ADDRESS StartAddress;
        public CLRDATA_ADDRESS EndAddress;
    }
}
