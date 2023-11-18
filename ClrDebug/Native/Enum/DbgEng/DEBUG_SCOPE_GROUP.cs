using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_SCOPE_GROUP : uint
    {
        /// <summary>
        /// Scope arguments are function arguments and thus only change when the scope crosses functions.
        /// </summary>
        ARGUMENTS = 1,

        /// <summary>
        /// Scope locals are locals declared in a particular scope and are only defined within that scope.
        /// </summary>
        LOCALS = 2,

        /// <summary>
        /// All symbols in the scope.
        /// </summary>
        ALL = 3,

        /// <summary>
        /// Get Debug Symbols by using Data Model engine
        /// </summary>
        BY_DATAMODEL = 4,

        /// <summary>
        /// Valid flags for the set of DEBUG_SCOPE_GROUP
        /// </summary>
        VALID_FLAGS = ALL | BY_DATAMODEL
    }
}
