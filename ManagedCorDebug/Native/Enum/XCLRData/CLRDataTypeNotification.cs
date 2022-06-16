using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum CLRDataTypeNotification : uint
	{
		CLRDATA_TYPENOTIFY_NONE = 0x00000000,
		CLRDATA_TYPENOTIFY_LOADED = 0x00000001,
		CLRDATA_TYPENOTIFY_UNLOADED = 0x00000002,
	}
}
