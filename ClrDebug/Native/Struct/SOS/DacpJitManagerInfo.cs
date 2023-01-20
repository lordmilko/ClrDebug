using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("managerAddr = {managerAddr.ToString(),nq}, codeType = {codeType}, ptrHeapList = {ptrHeapList.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpJitManagerInfo
    {
        public CLRDATA_ADDRESS managerAddr;
        public CodeHeapType codeType;
        public CLRDATA_ADDRESS ptrHeapList;
    }
}
