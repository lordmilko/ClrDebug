using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("threadAddr = {threadAddr.ToString(),nq}, ModuleIndex = {ModuleIndex}, pClassData = {pClassData.ToString(),nq}, pDynamicClassTable = {pDynamicClassTable.ToString(),nq}, pGCStaticDataStart = {pGCStaticDataStart.ToString(),nq}, pNonGCStaticDataStart = {pNonGCStaticDataStart.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpThreadLocalModuleData
    {
        public CLRDATA_ADDRESS threadAddr;
        public long ModuleIndex;
        public CLRDATA_ADDRESS pClassData;
        public CLRDATA_ADDRESS pDynamicClassTable;
        public CLRDATA_ADDRESS pGCStaticDataStart;
        public CLRDATA_ADDRESS pNonGCStaticDataStart;
    }
}
