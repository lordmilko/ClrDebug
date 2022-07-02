namespace ClrDebug
{
    public enum OptimizationTier : uint
	{
        Unknown,
        MinOptJitted,
        Optimized,
        QuickJitted,
        OptimizedTier1,
        ReadyToRun,
        OptimizedTier1OSR,
    }
}
