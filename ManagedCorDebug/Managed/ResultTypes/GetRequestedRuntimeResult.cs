namespace ManagedCorDebug
{
    public struct GetRequestedRuntimeResult
    {
        public string PwzVersion { get; }

        public string PwzImageVersion { get; }

        public METAHOST_CONFIG_FLAGS PdwConfigFlags { get; }

        public object PpRuntime { get; }

        public GetRequestedRuntimeResult(string pwzVersion, string pwzImageVersion, METAHOST_CONFIG_FLAGS pdwConfigFlags, object ppRuntime)
        {
            PwzVersion = pwzVersion;
            PwzImageVersion = pwzImageVersion;
            PdwConfigFlags = pdwConfigFlags;
            PpRuntime = ppRuntime;
        }
    }
}