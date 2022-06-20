using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRDebugging.OpenVirtualProcess"/> method.
    /// </summary>
    [DebuggerDisplay("ppProcess = {ppProcess}, pdwFlags = {pdwFlags.ToString(),nq}")]
    public struct OpenVirtualProcessResult
    {
        /// <summary>
        /// A pointer to the COM interface that is identified by riidProcess.
        /// </summary>
        public object ppProcess { get; }

        /// <summary>
        /// Informational flags about the specified runtime. See the <see cref="CLR_DEBUGGING_PROCESS_FLAGS"/> topic for a description of the flags.
        /// </summary>
        public CLR_DEBUGGING_PROCESS_FLAGS pdwFlags { get; }

        public OpenVirtualProcessResult(object ppProcess, CLR_DEBUGGING_PROCESS_FLAGS pdwFlags)
        {
            this.ppProcess = ppProcess;
            this.pdwFlags = pdwFlags;
        }
    }
}