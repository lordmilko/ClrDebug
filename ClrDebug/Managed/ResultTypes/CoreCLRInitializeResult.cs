using System;

namespace ClrDebug
{
    public class CoreCLRInitializeResult
    {
        public IntPtr HostHandle;
        public int DomainId;

        public CoreCLRInitializeResult(IntPtr hostHandle, int domainId)
        {
            HostHandle = hostHandle;
            DomainId = domainId;
        }
    }
}
