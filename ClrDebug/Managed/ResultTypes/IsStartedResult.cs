using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRRuntimeInfo.IsStarted"/> property.
    /// </summary>
    [DebuggerDisplay("pbStarted = {pbStarted}, pdwStartupFlags = {pdwStartupFlags.ToString(),nq}")]
    public struct IsStartedResult
    {
        /// <summary>
        /// true if this runtime is started; otherwise, false.
        /// </summary>
        public bool pbStarted { get; }

        /// <summary>
        /// Returns the flags that were used to start the runtime.
        /// </summary>
        public STARTUP_FLAGS pdwStartupFlags { get; }

        public IsStartedResult(bool pbStarted, STARTUP_FLAGS pdwStartupFlags)
        {
            this.pbStarted = pbStarted;
            this.pdwStartupFlags = pdwStartupFlags;
        }
    }
}
