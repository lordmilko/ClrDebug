using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
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
