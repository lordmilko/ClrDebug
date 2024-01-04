using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcOSKernelInfrastructure.GetExecutionState"/> method.
    /// </summary>
    [DebuggerDisplay("ppExecutingThread = {ppExecutingThread?.ToString(),nq}, ppExecutingProcess = {ppExecutingProcess?.ToString(),nq}")]
    public struct GetExecutionStateResult
    {
        public SvcThread ppExecutingThread { get; }

        public SvcProcess ppExecutingProcess { get; }

        public GetExecutionStateResult(SvcThread ppExecutingThread, SvcProcess ppExecutingProcess)
        {
            this.ppExecutingThread = ppExecutingThread;
            this.ppExecutingProcess = ppExecutingProcess;
        }
    }
}
