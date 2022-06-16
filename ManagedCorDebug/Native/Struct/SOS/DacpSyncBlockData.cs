using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpSyncBlockData
	{
		public CLRDATA_ADDRESS Object;
		public int bFree;
		public CLRDATA_ADDRESS SyncBlockPointer;
		public SYNCBLOCKDATA_COMFLAGS COMFlags;
		public int MonitorHeld;
		public int Recursion;
		public CLRDATA_ADDRESS HoldingThread;
		public int AdditionalThreadCount;
		public CLRDATA_ADDRESS AppDomainPtr;
        public int SyncBlockCount;

        public HRESULT Request(ISOSDacInterface sos, int SyncBlockNumber)
        {
            return sos.GetSyncBlockData(SyncBlockNumber, out this);
        }
    }
}
