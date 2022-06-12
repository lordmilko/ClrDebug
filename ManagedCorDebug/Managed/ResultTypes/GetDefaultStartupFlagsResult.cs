using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRRuntimeInfo.GetDefaultStartupFlags"/> method.
    /// </summary>
    [DebuggerDisplay("pdwStartupFlags = {pdwStartupFlags}, pwzHostConfigFile = {pwzHostConfigFile}")]
    public struct GetDefaultStartupFlagsResult
    {
        /// <summary>
        /// [out] A pointer to the host startup flags that are currently set.
        /// </summary>
        public int pdwStartupFlags { get; }

        /// <summary>
        /// [out] A pointer to the directory path of the current host configuration file.
        /// </summary>
        public string pwzHostConfigFile { get; }

        public GetDefaultStartupFlagsResult(int pdwStartupFlags, string pwzHostConfigFile)
        {
            this.pdwStartupFlags = pdwStartupFlags;
            this.pwzHostConfigFile = pwzHostConfigFile;
        }
    }
}