namespace ClrDebug
{
    public enum DacpModuleDataTransientFlags : uint
    {
        // These are the values set in m_dwTransientFlags.
        // Note that none of these flags survive a prejit save/restore.

        /// <summary>
        /// Set once we know for sure the Module will not be freed until the appdomain itself exits
        /// </summary>
        MODULE_IS_TENURED = 0x00000001,
        // unused                   = 0x00000002,

        CLASSES_FREED = 0x00000004,

        /// <summary>
        /// Is EnC Enabled for this module
        /// </summary>
        IS_EDIT_AND_CONTINUE = 0x00000008,

        IS_PROFILER_NOTIFIED = 0x00000010,
        IS_ETW_NOTIFIED = 0x00000020,

        /// <summary>
        /// Note: the order of these must match the order defined in
        /// cordbpriv.h for DebuggerAssemblyControlFlags. The three
        /// values below should match the values defined in
        /// DebuggerAssemblyControlFlags when shifted right
        /// DEBUGGER_INFO_SHIFT bits.
        /// </summary>
        DEBUGGER_USER_OVERRIDE_PRIV = 0x00000400,
        DEBUGGER_ALLOW_JIT_OPTS_PRIV = 0x00000800,
        DEBUGGER_TRACK_JIT_INFO_PRIV = 0x00001000,

        /// <summary>
        /// This is what was attempted to be set.  IS_EDIT_AND_CONTINUE is actual result.
        /// </summary>
        DEBUGGER_ENC_ENABLED_PRIV = 0x00002000,
        DEBUGGER_PDBS_COPIED = 0x00004000,
        DEBUGGER_IGNORE_PDBS = 0x00008000,
        DEBUGGER_INFO_MASK_PRIV = 0x0000Fc00,
        DEBUGGER_INFO_SHIFT_PRIV = 10,

        /// <summary>
        /// Used to indicate that this module has had it's IJW fixups properly installed.
        /// </summary>
        IS_IJW_FIXED_UP = 0x00080000,
        IS_BEING_UNLOADED = 0x00100000,

        /// <summary>
        /// Used to indicate that the module is loaded sufficiently for generic candidate instantiations to work
        /// </summary>
        MODULE_READY_FOR_TYPELOAD = 0x00200000,

        /// <summary>
        /// Used during NGen only
        /// </summary>
        TYPESPECS_TRIAGED = 0x40000000,
        MODULE_SAVED = 0x80000000,
    }
}
