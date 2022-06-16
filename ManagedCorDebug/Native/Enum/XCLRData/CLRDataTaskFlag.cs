using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum CLRDataTaskFlag : uint
	{
		CLRDATA_TASK_DEFAULT = 0x00000000,
		CLRDATA_TASK_WAITING_FOR_GC = 0x00000001,
	}
}
