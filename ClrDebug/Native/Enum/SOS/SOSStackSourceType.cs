using System;

namespace ClrDebug
{
    [Flags]
	public enum SOSStackSourceType : uint
	{
		SOS_StackSourceIP,
		SOS_StackSourceFrame,
	}
}
