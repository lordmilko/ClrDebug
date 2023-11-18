using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// ChangeSymbolState flags.
    /// </summary>
    [Flags]
    public enum DEBUG_CSS : uint
    {
        /// <summary>
        /// Symbol state has changed generally, such as after reload operations.<para/>
        /// Argument is zero.
        /// </summary>
        ALL = 0xffffffff,

        /// <summary>
        /// Modules have been loaded.<para/>
        /// If only a single module changed, argument is the base address of the module.
        /// Otherwise it is zero.
        /// </summary>
        LOADS = 1,

        /// <summary>
        /// Modules have been unloaded.<para/>
        /// If only a single module changed, argument is the base address of the module.
        /// Otherwise it is zero.
        /// </summary>
        UNLOADS = 2,

        /// <summary>
        /// Current symbol scope changed.
        /// </summary>
        SCOPE = 4,

        /// <summary>
        /// Paths have changed.
        /// </summary>
        PATHS = 8,

        /// <summary>
        /// Symbol options have changed.<para/>
        /// Argument is the new options value.
        /// </summary>
        SYMBOL_OPTIONS = 0x10,

        /// <summary>
        /// Type options have changed.<para/>
        /// Argument is the new options value.
        /// </summary>
        TYPE_OPTIONS = 0x20,

        /// <summary>
        /// Inform that the current Scope Symbol format has been changed, so the client needs to update
        /// the symbols on Locals/Watch/.. and the engine will collapse any expanded child
        /// </summary>
        COLLAPSE_CHILDREN = 0x40
    }
}
