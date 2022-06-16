using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum SOSStackSourceType : uint
	{
		SOS_StackSourceIP,
		SOS_StackSourceFrame,
	}
}
