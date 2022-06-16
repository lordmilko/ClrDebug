using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum SOSRefFlags : uint
	{
		SOSRefInterior = 1,
		SOSRefPinned = 2,
	}
}
