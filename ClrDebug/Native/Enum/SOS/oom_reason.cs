namespace ClrDebug
{
    public enum oom_reason
    {
        oom_no_failure = 0,
        oom_budget = 1,
        oom_cant_commit = 2,
        oom_cant_reserve = 3,
        oom_loh = 4,
        oom_low_mem = 5,
        oom_unproductive_full_gc = 6
    }
}