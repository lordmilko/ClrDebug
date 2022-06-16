using System;

namespace ManagedCorDebug
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
