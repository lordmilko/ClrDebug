using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum CodeHeapType : uint
	{
		CODEHEAP_LOADER,
		CODEHEAP_HOST,
		CODEHEAP_UNKNOWN,
	}
}
