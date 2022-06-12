namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugObjectValue.GetVirtualMethodAndType"/> method.
    /// </summary>
    public struct GetVirtualMethodAndTypeResult
    {
        public CorDebugFunction ppFunction { get; }

        public CorDebugType ppType { get; }

        public GetVirtualMethodAndTypeResult(CorDebugFunction ppFunction, CorDebugType ppType)
        {
            this.ppFunction = ppFunction;
            this.ppType = ppType;
        }
    }
}