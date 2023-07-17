using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Defines a transport buffer for a method's runtime information.
    /// </summary>
    /// <remarks>
    /// This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define
    /// the structure as specified above.
    /// </remarks>
    [DebuggerDisplay("bHasNativeCode = {bHasNativeCode}, bIsDynamic = {bIsDynamic}, wSlotNumber = {wSlotNumber}, NativeCodeAddr = {NativeCodeAddr.ToString(),nq}, AddressOfNativeCodeSlot = {AddressOfNativeCodeSlot.ToString(),nq}, MethodDescPtr = {MethodDescPtr.ToString(),nq}, MethodTablePtr = {MethodTablePtr.ToString(),nq}, ModulePtr = {ModulePtr.ToString(),nq}, MDToken = {MDToken.ToString(),nq}, GCInfo = {GCInfo.ToString(),nq}, GCStressCodeCopy = {GCStressCodeCopy.ToString(),nq}, managedDynamicMethodObject = {managedDynamicMethodObject.ToString(),nq}, requestedIP = {requestedIP.ToString(),nq}, rejitDataCurrent = {rejitDataCurrent.ToString(),nq}, rejitDataRequested = {rejitDataRequested.ToString(),nq}, cJittedRejitVersions = {cJittedRejitVersions}")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DacpMethodDescData
    {
        /// <summary>
        /// Indicates if the runtime has native code available for the given instantiation of the method.
        /// </summary>
        public bool bHasNativeCode;

        /// <summary>
        /// Indicates if the method is generated dynamically through lightweight code generation.
        /// </summary>
        public bool bIsDynamic;

        /// <summary>
        /// The method's slot number in the method table.
        /// </summary>
        public ushort wSlotNumber;

        /// <summary>
        /// The method's initial native address.
        /// </summary>
        public CLRDATA_ADDRESS NativeCodeAddr;
        public CLRDATA_ADDRESS AddressOfNativeCodeSlot;

        /// <summary>
        /// Pointer to the MethodDesc in the runtime.
        /// </summary>
        public CLRDATA_ADDRESS MethodDescPtr;
        public CLRDATA_ADDRESS MethodTablePtr;
        public CLRDATA_ADDRESS ModulePtr;

        /// <summary>
        /// Token associated with the given method.
        /// </summary>
        public mdToken MDToken;
        public CLRDATA_ADDRESS GCInfo;
        public CLRDATA_ADDRESS GCStressCodeCopy;

        /// <summary>
        /// If the method is dynamic, the runtime uses this buffer internally for information tracking.
        /// </summary>
        public CLRDATA_ADDRESS managedDynamicMethodObject;

        /// <summary>
        /// Used to populate the structure per request when given a native code address.
        /// </summary>
        public CLRDATA_ADDRESS requestedIP;

        /// <summary>
        /// Information about the latest instrumented version of the method.
        /// </summary>
        public DacpReJitData rejitDataCurrent;

        /// <summary>
        /// Rejit information for the requested native address.
        /// </summary>
        public DacpReJitData rejitDataRequested;

        /// <summary>
        /// Number of times the method has been rejitted through instrumentation.
        /// </summary>
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
