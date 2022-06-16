using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpOomData
	{
		public int Reason;
		public long alloc_size;
		public long available_pagefile_mb;
		public long gc_index;
		public int fgm;
		public long size;
		public int loh_p;

        public HRESULT Request(ISOSDacInterface sos)
        {
            return sos.GetOOMStaticData(out this);
        }

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetOOMData(addr, out this);
        }
    }
}
