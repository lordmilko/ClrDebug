using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
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
