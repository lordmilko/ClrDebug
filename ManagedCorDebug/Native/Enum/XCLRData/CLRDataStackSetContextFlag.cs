using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum CLRDataStackSetContextFlag : uint
	{
		CLRDATA_STACK_SET_UNWIND_CONTEXT = 0x00000000,
		CLRDATA_STACK_SET_CURRENT_CONTEXT = 0x00000001,
	}
}
