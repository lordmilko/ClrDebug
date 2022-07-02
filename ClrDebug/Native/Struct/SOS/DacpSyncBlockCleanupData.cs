using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("SyncBlockPointer = {SyncBlockPointer.ToString(),nq}, nextSyncBlock = {nextSyncBlock.ToString(),nq}, blockRCW = {blockRCW.ToString(),nq}, blockClassFactory = {blockClassFactory.ToString(),nq}, blockCCW = {blockCCW.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpSyncBlockCleanupData
    {
        public CLRDATA_ADDRESS SyncBlockPointer;
        public CLRDATA_ADDRESS nextSyncBlock;
        public CLRDATA_ADDRESS blockRCW;
        public CLRDATA_ADDRESS blockClassFactory;
        public CLRDATA_ADDRESS blockCCW;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS psyncBlock)
        {
            return sos.GetSyncBlockCleanupData(psyncBlock, out this);
        }
    }
}
