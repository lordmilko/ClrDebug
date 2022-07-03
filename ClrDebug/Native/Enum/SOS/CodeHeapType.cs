using System;

namespace ClrDebug
{
    [Flags]
    public enum CodeHeapType : uint
    {
        CODEHEAP_LOADER,
        CODEHEAP_HOST,
        CODEHEAP_UNKNOWN,
    }
}
