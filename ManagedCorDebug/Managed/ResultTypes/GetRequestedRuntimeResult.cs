namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRMetaHostPolicy.GetRequestedRuntime"/> method.
    /// </summary>
    public struct GetRequestedRuntimeResult
    {
        public string pwzVersion { get; }

        public string pwzImageVersion { get; }

        public METAHOST_CONFIG_FLAGS pdwConfigFlags { get; }

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