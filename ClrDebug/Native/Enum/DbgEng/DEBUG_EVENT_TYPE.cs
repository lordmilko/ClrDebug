using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents DEBUG_EVENT_XXX flags that can be used as an interest mask in DbgEng event callback interfaces.
    /// </summary>
    [Flags]
    public enum DEBUG_EVENT_TYPE : uint
    {
        NONE = 0,

        /// <summary>
        /// A breakpoint exception occurred in the target.
        /// </summary>
        BREAKPOINT = 1,

        /// <summary>
        /// An exception debugging event occurred in the target.
        /// </summary>
        EXCEPTION = 2,

        /// <summary>
        /// A create-thread debugging event occurred in the target.
        /// </summary>
        CREATE_THREAD = 4,

        /// <summary>
        /// An exit-thread debugging event occurred in the target.
        /// </summary>
        EXIT_THREAD = 8,

        /// <summary>
        /// A create-process debugging event occurred in the target.
        /// </summary>
        CREATE_PROCESS = 0x10,

        /// <summary>
        /// An exit-process debugging event occurred in the target.
        /// </summary>
        EXIT_PROCESS = 0x20,

        /// <summary>
        /// A module-load debugging event occurred in the target.
        /// </summary>
        LOAD_MODULE = 0x40,

        /// <summary>
        /// A module-unload debugging event occurred in the target.
        /// </summary>
        UNLOAD_MODULE = 0x80,

        /// <summary>
        /// A system error occurred in the target.
        /// </summary>
        SYSTEM_ERROR = 0x100,

        /// <summary>
        /// A change has occurred in the session status.
        /// </summary>
        SESSION_STATUS = 0x200,

        /// <summary>
        /// The engine has made or detected a change in the target status.
        /// </summary>
        CHANGE_DEBUGGEE_STATE = 0x400,

        /// <summary>
        /// The engine state has changed.
        /// </summary>
        CHANGE_ENGINE_STATE = 0x800,

        /// <summary>
        /// The symbol state has changed.
        /// </summary>
        CHANGE_SYMBOL_STATE = 0x1000,

        /// <summary>
        /// All <see cref="DEBUG_EVENT_TYPE"/> flags. This is a helper flag and does not have a corresponding
        /// value in the original set of DbgEng DEBUG_STATUS_XXX constants.
        /// </summary>
        ALL = BREAKPOINT | EXCEPTION | CREATE_THREAD | EXIT_THREAD |
              CREATE_PROCESS | EXIT_PROCESS | LOAD_MODULE | UNLOAD_MODULE |
              SYSTEM_ERROR | SESSION_STATUS | CHANGE_DEBUGGEE_STATE |
              CHANGE_ENGINE_STATE | CHANGE_SYMBOL_STATE
    }
}
