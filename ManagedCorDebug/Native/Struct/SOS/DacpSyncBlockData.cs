using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("Object = {Object.ToString(),nq}, bFree = {bFree}, SyncBlockPointer = {SyncBlockPointer.ToString(),nq}, COMFlags = {COMFlags.ToString(),nq}, MonitorHeld = {MonitorHeld}, Recursion = {Recursion}, HoldingThread = {HoldingThread.ToString(),nq}, AdditionalThreadCount = {AdditionalThreadCount}, AppDomainPtr = {AppDomainPtr.ToString(),nq}, SyncBlockCount = {SyncBlockCount}")]
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
