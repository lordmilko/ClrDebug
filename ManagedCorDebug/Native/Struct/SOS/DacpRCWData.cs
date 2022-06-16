using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
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
		public int isJupiterObject;
		public int supportsIInspectable;
		public int isAggregated;
		public int isContained;
		public int isFreeThreaded;
		public int isDisconnected;

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

            int result;
            var hr = pSOS2.IsRCWDCOMProxy(rcw, out result);
            isDCOMProxy = result == 1;
            return hr;
        }
    }
}
