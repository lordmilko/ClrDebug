using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum CLRDataBaseExceptionType : uint
	{
		CLRDATA_EXBASE_EXCEPTION,
		CLRDATA_EXBASE_OUT_OF_MEMORY,
		CLRDATA_EXBASE_INVALID_ARGUMENT,
	}
}
