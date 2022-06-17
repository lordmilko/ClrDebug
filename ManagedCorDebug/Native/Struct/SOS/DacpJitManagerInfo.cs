using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("managerAddr = {managerAddr.ToString(),nq}, codeType = {codeType}, ptrHeapList = {ptrHeapList.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpJitManagerInfo
    {
        public CLRDATA_ADDRESS managerAddr;
        public int codeType;
        public CLRDATA_ADDRESS ptrHeapList;
    }
}
