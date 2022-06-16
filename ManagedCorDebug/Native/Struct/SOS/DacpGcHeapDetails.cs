using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpGcHeapDetails
	{
		public CLRDATA_ADDRESS heapAddr;
		public CLRDATA_ADDRESS alloc_allocated;
		public CLRDATA_ADDRESS mark_array;
		public CLRDATA_ADDRESS current_c_gc_state;
		public CLRDATA_ADDRESS next_sweep_obj;
		public CLRDATA_ADDRESS saved_sweep_ephemeral_seg;
		public CLRDATA_ADDRESS saved_sweep_ephemeral_start;
		public CLRDATA_ADDRESS background_saved_lowest_address;
		public CLRDATA_ADDRESS background_saved_highest_address;
		public DacpGenerationData generation_table_0;
		public DacpGenerationData generation_table_1;
		public DacpGenerationData generation_table_2;
		public DacpGenerationData generation_table_3;
		public CLRDATA_ADDRESS ephemeral_heap_segment;
		public CLRDATA_ADDRESS finalization_fill_pointers_0;
		public CLRDATA_ADDRESS finalization_fill_pointers_1;
		public CLRDATA_ADDRESS finalization_fill_pointers_2;
		public CLRDATA_ADDRESS finalization_fill_pointers_3;
		public CLRDATA_ADDRESS finalization_fill_pointers_4;
		public CLRDATA_ADDRESS finalization_fill_pointers_5;
		public CLRDATA_ADDRESS finalization_fill_pointers_6;
		public CLRDATA_ADDRESS lowest_address;
		public CLRDATA_ADDRESS highest_address;
		public CLRDATA_ADDRESS card_table;

        public HRESULT Request(ISOSDacInterface sos)
        {
            return sos.GetGCHeapStaticData(out this);
        }

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetGCHeapDetails(addr, out this);
        }
    }
}
