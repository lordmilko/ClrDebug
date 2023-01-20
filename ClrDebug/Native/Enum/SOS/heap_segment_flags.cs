namespace ClrDebug
{
    public enum heap_segment_flags
    {
        heap_segment_flags_readonly = 1,
        heap_segment_flags_inrange = 2,
        heap_segment_flags_loh = 8,

        heap_segment_flags_swept = 16,
        heap_segment_flags_decommitted = 32,
        heap_segment_flags_ma_committed = 64,
        heap_segment_flags_ma_pcommitted = 128,
        heap_segment_flags_uoh_delete = 256,
        heap_segment_flags_poh = 512,

        heap_segment_flags_overflow = 1024,
        heap_segment_flags_demoted = 2048
    }
}
