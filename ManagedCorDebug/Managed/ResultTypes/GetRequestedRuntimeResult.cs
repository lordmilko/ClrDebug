using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRMetaHostPolicy.GetRequestedRuntime"/> method.
    /// </summary>
    [DebuggerDisplay("pwzVersion = {pwzVersion}, pwzImageVersion = {pwzImageVersion}, pdwConfigFlags = {pdwConfigFlags.ToString(),nq}, ppRuntime = {ppRuntime}")]
    public struct GetRequestedRuntimeResult
    {
        /// <summary>
        /// Optional. Specifies or returns the preferred CLR version to be loaded.
        /// </summary>
        public string pwzVersion { get; }

        /// <summary>
        /// Optional. When GetRequestedRuntime returns, contains the CLR version corresponding to the <see cref="ICLRRuntimeInfo"/> interface that is returned.
        /// </summary>
        public string pwzImageVersion { get; }

        /// <summary>	[out] Optional. If GetRequestedRuntime uses a configuration file during the binding process, when it returns, pdwConfigFlags contains
        /// a <see cref="METAHOST_CONFIG_FLAGS"/> value that indicates whether the &lt;startup&gt; element has the useLegacyV2RuntimeActivationPolicy attribute set, and the value of the attribute.<para/>
        /// Apply the <see cref="METAHOST_CONFIG_FLAGS.LEGACY_V2_ACTIVATION_POLICY_MASK"/> mask to pdwConfigFlags to get the values relevant to useLegacyV2RuntimeActivationPolicy.
        /// </summary>
        public METAHOST_CONFIG_FLAGS pdwConfigFlags { get; }

        /// <summary>
        /// When GetRequestedRuntime returns, contains a pointer to the corresponding ICLRRuntimeInfo interface.
        /// </summary>
        public object ppRuntime { get; }

        public GetRequestedRuntimeResult(string pwzVersion, string pwzImageVersion, METAHOST_CONFIG_FLAGS pdwConfigFlags, object ppRuntime)
        {
            this.pwzVersion = pwzVersion;
            this.pwzImageVersion = pwzImageVersion;
            this.pdwConfigFlags = pdwConfigFlags;
            this.ppRuntime = ppRuntime;
        }
    }
}