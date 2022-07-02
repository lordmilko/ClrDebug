using System;

namespace ClrDebug
{
    [Flags]
	public enum CLRDataGeneralRequest : uint
	{
		CLRDATA_REQUEST_REVISION = 0xe0000000,
	}
}
