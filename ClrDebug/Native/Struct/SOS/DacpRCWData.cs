using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("identityPointer = {identityPointer.ToString(),nq}, unknownPointer = {unknownPointer.ToString(),nq}, managedObject = {managedObject.ToString(),nq}, jupiterObject = {jupiterObject.ToString(),nq}, vtablePtr = {vtablePtr.ToString(),nq}, creatorThread = {creatorThread.ToString(),nq}, ctxCookie = {ctxCookie.ToString(),nq}, refCount = {refCount}, interfaceCount = {interfaceCount}, isJupiterObject = {isJupiterObject}, supportsIInspectable = {supportsIInspectable}, isAggregated = {isAggregated}, isContained = {isContained}, isFreeThreaded = {isFreeThreaded}, isDisconnected = {isDisconnected}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpRCWData
    {
        public CLRDATA_ADDRESS identityPointer;
        public CLRDATA_ADDRESS unknownPointer;
        public CLRDATA_ADDRESS managedObject;
        public CLRDATA_ADDRESS jupiterObject;
        public CLRDATA_ADDRESS vtablePtr;
        public CLRDATA_ADDRESS creatorThread;
        public CLRDATA_ADDRESS ctxCookie;
        public int refCount;
        public int interfaceCount;
        public bool isJupiterObject;
        public bool supportsIInspectable;
        public bool isAggregated;
        public bool isContained;
        public bool isFreeThreaded;
        public bool isDisconnected;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS rcw)
        {
            return sos.GetRCWData(rcw, out this);
        }

        public HRESULT IsDCOMProxy(ISOSDacInterface sos, CLRDATA_ADDRESS rcw, out bool isDCOMProxy)
        {
            var pSOS2 = sos as ISOSDacInterface2;

            if (pSOS2 == null)
            {
                isDCOMProxy = false;

                return HRESULT.E_NOINTERFACE;
            }

            var hr = pSOS2.IsRCWDCOMProxy(rcw, out isDCOMProxy);
            return hr;
        }
    }
}
