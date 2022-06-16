using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpCCWData
	{
		public CLRDATA_ADDRESS outerIUnknown;
		public CLRDATA_ADDRESS managedObject;
		public CLRDATA_ADDRESS handle;
		public CLRDATA_ADDRESS ccwAddress;
		public int refCount;
		public int interfaceCount;
		public int isNeutered;
		public int jupiterRefCount;
		public int isPegged;
		public int isGlobalPegged;
		public int hasStrongRef;
		public int isExtendsCOMObject;
		public int isAggregated;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS ccw)
        {
            return sos.GetCCWData(ccw, out this);
        }
    }
}
