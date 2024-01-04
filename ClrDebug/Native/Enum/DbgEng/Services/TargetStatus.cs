namespace ClrDebug.DbgEng
{
    public enum TargetStatus : uint
    {
        TargetRunPending,
        TargetRunning,
        TargetHaltPending,
        TargetHalted,
        TargetFaulted
    }
}
