using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcEventArgumentExecutionStateChange.ChangeEffects"/> property.
    /// </summary>
    [DebuggerDisplay("process = {process?.ToString(),nq}, executionUnit = {executionUnit?.ToString(),nq}")]
    public struct GetChangeEffectsResult
    {
        public SvcProcess process { get; }

        public SvcExecutionUnit executionUnit { get; }

        public GetChangeEffectsResult(SvcProcess process, SvcExecutionUnit executionUnit)
        {
            this.process = process;
            this.executionUnit = executionUnit;
        }
    }
}
