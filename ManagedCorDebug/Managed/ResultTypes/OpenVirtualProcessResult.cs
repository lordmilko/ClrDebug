namespace ManagedCorDebug
{
    public struct OpenVirtualProcessResult
    {
        public object PpProcess { get; }

        public CLR_DEBUGGING_VERSION PVersion { get; }

        public CLR_DEBUGGING_PROCESS_FLAGS PdwFlags { get; }

        public OpenVirtualProcessResult(object ppProcess, CLR_DEBUGGING_VERSION pVersion, CLR_DEBUGGING_PROCESS_FLAGS pdwFlags)
        {
            PpProcess = ppProcess;
            PVersion = pVersion;
            PdwFlags = pdwFlags;
        }
    }
}