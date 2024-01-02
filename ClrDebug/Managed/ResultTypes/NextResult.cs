using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaEnumStackFrames.Next"/> method.
    /// </summary>
    [DebuggerDisplay("rgelt = {rgelt?.ToString(),nq}, pceltFetched = {pceltFetched}")]
    public struct NextResult
    {
        /// <summary>
        /// An array that is to be filled in with the requested IDiaStackFrame objects.
        /// </summary>
        public DiaStackFrame rgelt { get; }

        /// <summary>
        /// Returns the number of stack frame elements in the fetched enumerator.
        /// </summary>
        public int pceltFetched { get; }

        public NextResult(DiaStackFrame rgelt, int pceltFetched)
        {
            this.rgelt = rgelt;
            this.pceltFetched = pceltFetched;
        }
    }
}
