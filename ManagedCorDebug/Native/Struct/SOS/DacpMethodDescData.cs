using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpMethodDescData
	{
		public int bHasNativeCode;
		public int bIsDynamic;
		public ushort wSlotNumber;
		public CLRDATA_ADDRESS NativeCodeAddr;
		public CLRDATA_ADDRESS AddressOfNativeCodeSlot;
		public CLRDATA_ADDRESS MethodDescPtr;
		public CLRDATA_ADDRESS MethodTablePtr;
		public CLRDATA_ADDRESS ModulePtr;
		public mdToken MDToken;
		public CLRDATA_ADDRESS GCInfo;
		public CLRDATA_ADDRESS GCStressCodeCopy;
		public CLRDATA_ADDRESS managedDynamicMethodObject;
		public CLRDATA_ADDRESS requestedIP;
		public DacpReJitData rejitDataCurrent;
		public DacpReJitData rejitDataRequested;
		public int cJittedRejitVersions;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            int pcNeededRevertedRejitData;
            return sos.GetMethodDescData(
                addr,
                0,
                out this,
                0,
                null,
                out pcNeededRevertedRejitData
            );
        }
    }
}
