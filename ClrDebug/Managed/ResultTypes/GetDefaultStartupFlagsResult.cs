using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRRuntimeInfo.DefaultStartupFlags"/> property.
    /// </summary>
    [DebuggerDisplay("pdwStartupFlags = {pdwStartupFlags.ToString(),nq}, pwzHostConfigFile = {pwzHostConfigFile}")]
    public struct GetDefaultStartupFlagsResult
    {
        /// <summary>
        /// A pointer to the host startup flags that are currently set.
        /// </summary>
        public STARTUP_FLAGS pdwStartupFlags { get; }

        /// <summary>
        /// A pointer to the directory path of the current host configuration file.
        /// </summary>
        public string pwzHostConfigFile { get; }

        public GetDefaultStartupFlagsResult(STARTUP_FLAGS pdwStartupFlags, string pwzHostConfigFile)
        {
            this.pdwStartupFlags = pdwStartupFlags;
            this.pwzHostConfigFile = pwzHostConfigFile;
        }
    }
}
