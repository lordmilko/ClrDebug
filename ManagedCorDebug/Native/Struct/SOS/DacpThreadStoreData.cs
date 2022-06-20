using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("threadCount = {threadCount}, unstartedThreadCount = {unstartedThreadCount}, backgroundThreadCount = {backgroundThreadCount}, pendingThreadCount = {pendingThreadCount}, deadThreadCount = {deadThreadCount}, firstThread = {firstThread.ToString(),nq}, finalizerThread = {finalizerThread.ToString(),nq}, gcThread = {gcThread.ToString(),nq}, fHostConfig = {fHostConfig}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpThreadStoreData
    {
        public int threadCount;
        public int unstartedThreadCount;
        public int backgroundThreadCount;
        public int pendingThreadCount;
        public int deadThreadCount;
        public CLRDATA_ADDRESS firstThread;
        public CLRDATA_ADDRESS finalizerThread;
        public CLRDATA_ADDRESS gcThread;
        public bool fHostConfig;

        public HRESULT Request(ISOSDacInterface sos)
        {
            return sos.GetThreadStoreData(out this);
        }
    }
}
