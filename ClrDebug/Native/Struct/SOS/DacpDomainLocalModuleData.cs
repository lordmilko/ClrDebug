using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("appDomainAddr = {appDomainAddr.ToString(),nq}, ModuleID = {ModuleID}, pClassData = {pClassData.ToString(),nq}, pDynamicClassTable = {pDynamicClassTable.ToString(),nq}, pGCStaticDataStart = {pGCStaticDataStart.ToString(),nq}, pNonGCStaticDataStart = {pNonGCStaticDataStart.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpDomainLocalModuleData
    {
        public CLRDATA_ADDRESS appDomainAddr;
        public long ModuleID;
        public CLRDATA_ADDRESS pClassData;
        public CLRDATA_ADDRESS pDynamicClassTable;
        public CLRDATA_ADDRESS pGCStaticDataStart;
        public CLRDATA_ADDRESS pNonGCStaticDataStart;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetDomainLocalModuleData(addr, out this);
        }
    }
}
