using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("bHasNativeCode = {bHasNativeCode}, bIsDynamic = {bIsDynamic}, wSlotNumber = {wSlotNumber}, NativeCodeAddr = {NativeCodeAddr.ToString(),nq}, AddressOfNativeCodeSlot = {AddressOfNativeCodeSlot.ToString(),nq}, MethodDescPtr = {MethodDescPtr.ToString(),nq}, MethodTablePtr = {MethodTablePtr.ToString(),nq}, ModulePtr = {ModulePtr.ToString(),nq}, MDToken = {MDToken.ToString(),nq}, GCInfo = {GCInfo.ToString(),nq}, GCStressCodeCopy = {GCStressCodeCopy.ToString(),nq}, managedDynamicMethodObject = {managedDynamicMethodObject.ToString(),nq}, requestedIP = {requestedIP.ToString(),nq}, rejitDataCurrent = {rejitDataCurrent.ToString(),nq}, rejitDataRequested = {rejitDataRequested.ToString(),nq}, cJittedRejitVersions = {cJittedRejitVersions}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpMethodDescData
    {
        public bool bHasNativeCode;
        public bool bIsDynamic;
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
