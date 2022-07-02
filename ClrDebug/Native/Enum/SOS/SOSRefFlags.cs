using System;

namespace ClrDebug
{
    [Flags]
	public enum SOSRefFlags : uint
	{
		SOSRefInterior = 1,
		SOSRefPinned = 2,
	}
}
