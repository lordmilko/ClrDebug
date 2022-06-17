using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("Base = {Base.ToString(),nq}, Length = {Length}, Type = {Type.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct CLRDATA_MODULE_EXTENT
    {
        public CLRDATA_ADDRESS Base;
        public int Length;
        public CLRDataModuleExtentType Type;
    }
}
