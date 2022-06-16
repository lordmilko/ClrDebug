using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpGcHeapAnalyzeData
	{
		public CLRDATA_ADDRESS heapAddr;
		public CLRDATA_ADDRESS internal_root_array;
		public long internal_root_array_index;
		public int heap_analyze_success;

        public HRESULT Request(ISOSDacInterface sos)
        {
            return sos.GetHeapAnalyzeStaticData(out this);
        }

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetHeapAnalyzeData(addr, out this);
        }
    }
}
