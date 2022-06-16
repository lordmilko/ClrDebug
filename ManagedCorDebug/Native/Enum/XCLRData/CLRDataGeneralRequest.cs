using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum CLRDataGeneralRequest : uint
	{
		CLRDATA_REQUEST_REVISION = 0xe0000000,
	}
}
