using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// GetModuleBy* flags.
    /// </summary>
    [Flags]
    public enum DEBUG_GETMOD : uint
    {
        /// <summary>
        /// Scan all modules, loaded and unloaded.
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        /// Do not scan loaded modules.
        /// </summary>
        NO_LOADED_MODULES = 1,

        /// <summary>
        /// Do not scan unloaded modules.
        /// </summary>
        NO_UNLOADED_MODULES = 2,
    }
}
