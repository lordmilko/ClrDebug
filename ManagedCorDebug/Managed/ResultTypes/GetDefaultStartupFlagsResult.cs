namespace ManagedCorDebug
{
    public struct GetDefaultStartupFlagsResult
    {
        public int PdwStartupFlags { get; }

        public string PwzHostConfigFile { get; }

        public GetDefaultStartupFlagsResult(int pdwStartupFlags, string pwzHostConfigFile)
        {
            PdwStartupFlags = pdwStartupFlags;
            PwzHostConfigFile = pwzHostConfigFile;
        }
    }
}