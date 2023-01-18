using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("outerIUnknown = {outerIUnknown.ToString(),nq}, managedObject = {managedObject.ToString(),nq}, handle = {handle.ToString(),nq}, ccwAddress = {ccwAddress.ToString(),nq}, refCount = {refCount}, interfaceCount = {interfaceCount}, isNeutered = {isNeutered}, jupiterRefCount = {jupiterRefCount}, isPegged = {isPegged}, isGlobalPegged = {isGlobalPegged}, hasStrongRef = {hasStrongRef}, isExtendsCOMObject = {isExtendsCOMObject}, isAggregated = {isAggregated}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpCCWData
    {
        public CLRDATA_ADDRESS outerIUnknown;
        public CLRDATA_ADDRESS managedObject;
        public CLRDATA_ADDRESS handle;
        public CLRDATA_ADDRESS ccwAddress;
        public int refCount;
        public int interfaceCount;
        public bool isNeutered;
        public int jupiterRefCount;
        public bool isPegged;
        public bool isGlobalPegged;
        public bool hasStrongRef;
        public bool isExtendsCOMObject;
        public bool isAggregated;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS ccw)
        {
            return sos.GetCCWData(ccw, out this);
        }
    }
}
