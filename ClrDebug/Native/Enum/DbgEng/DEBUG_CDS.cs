using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// ChangeDebuggeeState flags.
    /// </summary>
    [Flags]
    public enum DEBUG_CDS : uint
    {
        /// <summary>
        /// The debuggees state has changed generally, such as when the debuggee has been executing.<para/>
        /// Argument is zero.
        /// </summary>
        ALL = 0xffffffff,

        /// <summary>
        /// Registers have changed.<para/>
        /// If only a single register changed, argument is the index of the
        /// register. Otherwise it is <see cref="DbgEngExtensions.DEBUG_ANY_ID"/>.
        /// </summary>
        REGISTERS = 1,

        /// <summary>
        /// Data spaces have changed.<para/>
        /// If only a single space was affected, argument is the data space.
        /// Otherwise it is <see cref="DbgEngExtensions.DEBUG_ANY_ID"/>.
        /// </summary>
        DATA = 2,

        /// <summary>
        /// Inform the GUI clients to refresh debugger windows.
        /// </summary>
        REFRESH = 4,
    }
}
