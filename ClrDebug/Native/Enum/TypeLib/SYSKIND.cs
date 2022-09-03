namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Identifies the target operating system platform.
    /// </summary>
    public enum SYSKIND
    {
        /// <summary>
        /// The target operating system for the type library is 16-bit Windows systems. By default, data fields are packed.
        /// </summary>
        SYS_WIN16,

        /// <summary>
        /// The target operating system for the type library is 32-bit Windows systems. By default, data fields are naturally aligned (for example, 2-byte integers are aligned on even-byte boundaries; 4-byte integers are aligned on quad-word boundaries, and so on).
        /// </summary>
        SYS_WIN32,

        /// <summary>
        /// The target operating system for the type library is Apple Macintosh. By default, all data fields are aligned on even-byte boundaries.
        /// </summary>
        SYS_MAC,

        /// <summary>
        /// The target operating system for the type library is 64-bit Windows systems.
        /// </summary>
        SYS_WIN64,
    }
}
