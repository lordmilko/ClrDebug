using System;

namespace ClrDebug
{
    [Flags]
	public enum EHClauseType : uint
	{
		EHFault,
		EHFinally,
		EHFilter,
		EHTyped,
		EHUnknown,
	}
}
