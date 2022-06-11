namespace ManagedCorDebug
{
    public struct GetVirtualMethodAndTypeResult
    {
        public CorDebugFunction PpFunction { get; }

        public CorDebugType PpType { get; }

        public GetVirtualMethodAndTypeResult(CorDebugFunction ppFunction, CorDebugType ppType)
        {
            PpFunction = ppFunction;
            PpType = ppType;
        }
    }
}