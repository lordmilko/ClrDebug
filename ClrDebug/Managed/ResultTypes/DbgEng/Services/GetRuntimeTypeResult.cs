using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolSetRuntimeTypeInformation.GetRuntimeType"/> method.
    /// </summary>
    [DebuggerDisplay("runtimeObjectOffset = {runtimeObjectOffset}, runtimeObjectType = {runtimeObjectType?.ToString(),nq}")]
    public struct GetRuntimeTypeResult
    {
        public long runtimeObjectOffset { get; }

        public SvcSymbolType runtimeObjectType { get; }

        public GetRuntimeTypeResult(long runtimeObjectOffset, SvcSymbolType runtimeObjectType)
        {
            this.runtimeObjectOffset = runtimeObjectOffset;
            this.runtimeObjectType = runtimeObjectType;
        }
    }
}
