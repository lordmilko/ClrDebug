using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("Reason = {Reason}, alloc_size = {alloc_size}, available_pagefile_mb = {available_pagefile_mb}, gc_index = {gc_index}, fgm = {fgm}, size = {size}, loh_p = {loh_p}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpOomData
    {
        public oom_reason Reason;
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
