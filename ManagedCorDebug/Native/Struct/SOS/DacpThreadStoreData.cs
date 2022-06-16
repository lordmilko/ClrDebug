using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
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
		public int fHostConfig;

        public HRESULT Request(ISOSDacInterface sos)
        {
            return sos.GetThreadStoreData(out this);
        }
    }
}
