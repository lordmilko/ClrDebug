using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRRuntimeInfo.IsStarted"/> property.
    /// </summary>
    [DebuggerDisplay("pbStarted = {pbStarted}, pdwStartupFlags = {pdwStartupFlags}")]
    public struct IsStartedResult
    {
        /// <summary>
        /// true if this runtime is started; otherwise, false.
        /// </summary>
        public int pbStarted { get; }

        /// <summary>
        /// Returns the flags that were used to start the runtime.
        /// </summary>
        public int pdwStartupFlags { get; }

        public IsStartedResult(int pbStarted, int pdwStartupFlags)
        {
            this.pbStarted = pbStarted;
            this.pdwStartupFlags = pdwStartupFlags;
        }
    }
}