namespace ManagedCorDebug
{
    public struct GetDefaultStartupFlagsResult
    {
        public uint PdwStartupFlags { get; }

        public string PwzHostConfigFile { get; }

        public GetDefaultStartupFlagsResult(uint pdwStartupFlags, string pwzHostConfigFile)
        {
            PdwStartupFlags = pdwStartupFlags;
            PwzHostConfigFile = pwzHostConfigFile;
        }
    }
}