using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum CLRDataGetNameFlag : uint
	{
		CLRDATA_GETNAME_DEFAULT = 0x00000000,
		CLRDATA_GETNAME_NO_NAMESPACES = 0x00000001,
		CLRDATA_GETNAME_NO_PARAMETERS = 0x00000002,
	}
}
