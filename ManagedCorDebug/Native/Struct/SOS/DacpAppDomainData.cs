using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
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
