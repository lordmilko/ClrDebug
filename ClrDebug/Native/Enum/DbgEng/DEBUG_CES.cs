using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// ChangeEngineState flags.
    /// </summary>
    [Flags]
    public enum DEBUG_CES : uint
    {
        /// <summary>
        /// The engine state has changed generally.<para/>
        /// Argument is zero.
        /// </summary>
        ALL = 0xffffffff,

        /// <summary>
        /// Current thread changed. This may imply a change of system and process also.<para/>
        /// Argument is the ID of the new current thread or <see cref="DbgEngExtensions.DEBUG_ANY_ID"/> if no thread is current.
        /// </summary>
        CURRENT_THREAD = 1,

        /// <summary>
        /// Effective processor changed.<para/>
        /// Argument is the new processor type.
        /// </summary>
        EFFECTIVE_PROCESSOR = 2,

        /// <summary>
        /// Breakpoints changed.<para/>
        /// If only a single breakpoint changed, argument is the ID of the breakpoint.
        /// Otherwise it is <see cref="DbgEngExtensions.DEBUG_ANY_ID"/>.
        /// </summary>
        BREAKPOINTS = 4,

        /// <summary>
        /// Code interpretation level changed.<para/>
        /// Argument is the new level.
        /// </summary>
        CODE_LEVEL = 8,

        /// <summary>
        /// Execution status changed.<para/>
        /// Argument is the new execution status.
        /// </summary>
        EXECUTION_STATUS = 0x10,

        /// <summary>
        /// Engine options have changed.<para/>
        /// Argument is the new options value.
        /// </summary>
        ENGINE_OPTIONS = 0x20,

        /// <summary>
        /// Log file information has changed.<para/>
        /// Argument is TRUE if a log file was opened and FALSE if a log file was closed.
        /// </summary>
        LOG_FILE = 0x40,

        /// <summary>
        /// Default number radix has changed.<para/>
        /// Argument is the new radix.
        /// </summary>
        RADIX = 0x80,

        /// <summary>
        /// Event filters changed.<para/>
        /// If only a single filter changed the argument is the filter's index,
        /// otherwise it is <see cref="DbgEngExtensions.DEBUG_ANY_ID"/>.
        /// </summary>
        EVENT_FILTERS = 0x100,

        /// <summary>
        /// Process options have changed.<para/>
        /// Argument is the new options value.
        /// </summary>
        PROCESS_OPTIONS = 0x200,

        /// <summary>
        /// Extensions have been added or removed.
        /// </summary>
        EXTENSIONS = 0x400,

        /// <summary>
        /// Systems have been added or removed.<para/>
        /// The argument is the system ID. Systems, unlike processes and threads, may be created
        /// at any time and not just during WaitForEvent.
        /// </summary>
        SYSTEMS = 0x800,

        /// <summary>
        /// Assembly/disassembly options have changed.<para/>
        /// Argument is the new options value.
        /// </summary>
        ASSEMBLY_OPTIONS = 0x1000,

        /// <summary>
        /// Expression syntax has changed.<para/>
        /// Argument is the new syntax value.
        /// </summary>
        EXPRESSION_SYNTAX = 0x2000,

        /// <summary>
        /// Text replacements have changed.
        /// </summary>
        TEXT_REPLACEMENTS = 0x4000,
    }
}
