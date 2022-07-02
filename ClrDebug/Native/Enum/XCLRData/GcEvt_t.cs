using System;

namespace ClrDebug
{
    [Flags]
	public enum GcEvt_t : uint
	{
		GC_MARK_END = 1,
		GC_EVENT_TYPE_MAX,
	}
}
