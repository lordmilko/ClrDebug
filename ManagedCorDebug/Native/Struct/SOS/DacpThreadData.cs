using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpThreadData
	{
		public int corThreadId;
		public int osThreadId;
		public int state;
		public int preemptiveGCDisabled;
		public CLRDATA_ADDRESS allocContextPtr;
		public CLRDATA_ADDRESS allocContextLimit;
		public CLRDATA_ADDRESS context;
		public CLRDATA_ADDRESS domain;
		public CLRDATA_ADDRESS pFrame;
		public int lockCount;
		public CLRDATA_ADDRESS firstNestedException;
		public CLRDATA_ADDRESS teb;
		public CLRDATA_ADDRESS fiberData;
		public CLRDATA_ADDRESS lastThrownObjectHandle;
		public CLRDATA_ADDRESS nextThread;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetThreadData(addr, out this);
        }
    }
}
