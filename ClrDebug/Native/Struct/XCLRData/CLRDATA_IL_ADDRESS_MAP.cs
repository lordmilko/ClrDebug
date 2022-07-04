using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Defines an IL to address mapping.
    /// </summary>
    /// <remarks>
    /// This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define
    /// the structure as specified above, where CLRDATA_ADDRESS is a 64-bit unsigned integer.
    /// </remarks>
    [DebuggerDisplay("ILOffset = {ILOffset}, StartAddress = {StartAddress.ToString(),nq}, EndAddress = {EndAddress.ToString(),nq}, Type = {Type.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct CLRDATA_IL_ADDRESS_MAP
    {
        public int ILOffset;
        public CLRDATA_ADDRESS StartAddress;
        public CLRDATA_ADDRESS EndAddress;
        public CLRDataSourceType Type;
    }
}
