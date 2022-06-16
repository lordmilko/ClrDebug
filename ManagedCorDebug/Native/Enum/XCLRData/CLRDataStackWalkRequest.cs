using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum CLRDataStackWalkRequest : uint
	{
		CLRDATA_STACK_WALK_REQUEST_SET_FIRST_FRAME = 0xe1000000,
	}
}
