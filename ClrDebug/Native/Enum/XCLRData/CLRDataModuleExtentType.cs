using System;

namespace ClrDebug
{
    [Flags]
	public enum CLRDataModuleExtentType : uint
	{
		CLRDATA_MODULE_PE_FILE,
		CLRDATA_MODULE_PREJIT_FILE,
		CLRDATA_MODULE_MEMORY_STREAM,
		CLRDATA_MODULE_OTHER,
	}
}
