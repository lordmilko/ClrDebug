using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("StartAddress = {StartAddress.ToString(),nq}, EndAddress = {EndAddress.ToString(),nq}, EnCVersion = {EnCVersion}, Type = {Type.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct CLRDATA_METHDEF_EXTENT
    {
        public CLRDATA_ADDRESS StartAddress;
        public CLRDATA_ADDRESS EndAddress;
        public int EnCVersion;
        public CLRDataMethodDefinitionExtentType Type;
    }
}
