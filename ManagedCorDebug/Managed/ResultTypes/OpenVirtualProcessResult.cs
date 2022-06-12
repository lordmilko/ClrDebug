using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRDebugging.OpenVirtualProcess"/> method.
    /// </summary>
    [DebuggerDisplay("ppProcess = {ppProcess}, pVersion = {pVersion}, pdwFlags = {pdwFlags}")]
    public struct OpenVirtualProcessResult
    {
        /// <summary>
        /// [out] A pointer to the COM interface that is identified by riidProcess.
        /// </summary>
        public object ppProcess { get; }

        /// <summary>
        /// [in, out] The version of the CLR. On input, this value can be null. It can also point to a <see cref="CLR_DEBUGGING_VERSION"/> structure, in which case the structure's wStructVersion field must be initialized to 0 (zero).<para/>
        /// On output, the returned <see cref="CLR_DEBUGGING_VERSION"/> structure will be filled in with the version information for the CLR.
        /// </summary>
        public CLR_DEBUGGING_VERSION pVersion { get; }

        /// <summary>
        /// [out] Informational flags about the specified runtime. See the <see cref="CLR_DEBUGGING_PROCESS_FLAGS"/> topic for a description of the flags.
        /// </summary>
        public CLR_DEBUGGING_PROCESS_FLAGS pdwFlags { get; }

        public OpenVirtualProcessResult(object ppProcess, CLR_DEBUGGING_VERSION pVersion, CLR_DEBUGGING_PROCESS_FLAGS pdwFlags)
        {
            this.ppProcess = ppProcess;
            this.pVersion = pVersion;
            this.pdwFlags = pdwFlags;
        }
    }
}