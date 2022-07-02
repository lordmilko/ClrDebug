using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("heapAddr = {heapAddr.ToString(),nq}, alloc_allocated = {alloc_allocated.ToString(),nq}, mark_array = {mark_array.ToString(),nq}, current_c_gc_state = {current_c_gc_state.ToString(),nq}, next_sweep_obj = {next_sweep_obj.ToString(),nq}, saved_sweep_ephemeral_seg = {saved_sweep_ephemeral_seg.ToString(),nq}, saved_sweep_ephemeral_start = {saved_sweep_ephemeral_start.ToString(),nq}, background_saved_lowest_address = {background_saved_lowest_address.ToString(),nq}, background_saved_highest_address = {background_saved_highest_address.ToString(),nq}, generation_table_0 = {generation_table_0.ToString(),nq}, generation_table_1 = {generation_table_1.ToString(),nq}, generation_table_2 = {generation_table_2.ToString(),nq}, generation_table_3 = {generation_table_3.ToString(),nq}, ephemeral_heap_segment = {ephemeral_heap_segment.ToString(),nq}, finalization_fill_pointers_0 = {finalization_fill_pointers_0.ToString(),nq}, finalization_fill_pointers_1 = {finalization_fill_pointers_1.ToString(),nq}, finalization_fill_pointers_2 = {finalization_fill_pointers_2.ToString(),nq}, finalization_fill_pointers_3 = {finalization_fill_pointers_3.ToString(),nq}, finalization_fill_pointers_4 = {finalization_fill_pointers_4.ToString(),nq}, finalization_fill_pointers_5 = {finalization_fill_pointers_5.ToString(),nq}, finalization_fill_pointers_6 = {finalization_fill_pointers_6.ToString(),nq}, lowest_address = {lowest_address.ToString(),nq}, highest_address = {highest_address.ToString(),nq}, card_table = {card_table.ToString(),nq}")]
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
