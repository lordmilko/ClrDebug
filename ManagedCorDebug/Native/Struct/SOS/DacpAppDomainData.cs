using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("AppDomainPtr = {AppDomainPtr.ToString(),nq}, AppSecDesc = {AppSecDesc.ToString(),nq}, pLowFrequencyHeap = {pLowFrequencyHeap.ToString(),nq}, pHighFrequencyHeap = {pHighFrequencyHeap.ToString(),nq}, pStubHeap = {pStubHeap.ToString(),nq}, DomainLocalBlock = {DomainLocalBlock.ToString(),nq}, pDomainLocalModules = {pDomainLocalModules.ToString(),nq}, dwId = {dwId}, AssemblyCount = {AssemblyCount}, FailedAssemblyCount = {FailedAssemblyCount}, AppDomainStage = {AppDomainStage.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpAppDomainData
    {
        public CLRDATA_ADDRESS AppDomainPtr;
        public CLRDATA_ADDRESS AppSecDesc;
        public CLRDATA_ADDRESS pLowFrequencyHeap;
        public CLRDATA_ADDRESS pHighFrequencyHeap;
        public CLRDATA_ADDRESS pStubHeap;
        public CLRDATA_ADDRESS DomainLocalBlock;
        public CLRDATA_ADDRESS pDomainLocalModules;
        public int dwId;
        public int AssemblyCount;
        public int FailedAssemblyCount;
        public DacpAppDomainDataStage AppDomainStage;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetAppDomainData(addr, out this);
        }
    }
}
