using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugProcess.Filter"/> method.
    /// </summary>
    [DebuggerDisplay("ppEvent = {ppEvent}, pContinueStatus = {pContinueStatus}")]
    public struct FilterResult
    {
        public CorDebugDebugEvent ppEvent { get; }

        public int pContinueStatus { get; }

        public FilterResult(CorDebugDebugEvent ppEvent, int pContinueStatus)
        {
            this.ppEvent = ppEvent;
            this.pContinueStatus = pContinueStatus;
        }
    }
}