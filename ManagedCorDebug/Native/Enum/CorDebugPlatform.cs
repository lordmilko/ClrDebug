namespace ManagedCorDebug
{
    /// <summary>
    /// Provides target platform values that are used by the <see cref="ICorDebugDataTarget.GetPlatform"/> method.
    /// </summary>
    public enum CorDebugPlatform
    {
        /// <summary>
        /// The target platform is Windows running on Intel x86 hardware.
        /// </summary>
        CORDB_PLATFORM_WINDOWS_X86,

        /// <summary>
        /// The target platform is 64 bit Windows running on AMD64 or Intel EM64T hardware.
        /// </summary>
        CORDB_PLATFORM_WINDOWS_AMD64,

        /// <summary>
        /// The target platform is 32 bit Windows running on Intel IA-64 hardware.
        /// </summary>
        CORDB_PLATFORM_WINDOWS_IA64,

        /// <summary>
        /// The target platform is the Macintosh operating system running on PowerPC hardware.
        /// </summary>
        CORDB_PLATFORM_MAC_PPC,

        /// <summary>
        /// The target platform is the Macintosh operating system running on Intel x86 hardware.
        /// </summary>
        CORDB_PLATFORM_MAC_X86,

        /// <summary>
        /// The target platform is the Macintosh operating system running on Windows ARM hardware.
        /// </summary>
        CORDB_PLATFORM_WINDOWS_ARM,

        /// <summary>
        /// The target platform is the Macintosh operating system running on AMD64 hardware.
        /// </summary>
        CORDB_PLATFORM_MAC_AMD64,

        /// <summary>
        /// The target platform is the Macintosh operating system running on Windows ARM hardware.
        /// </summary>
        CORDB_PLATFORM_WINDOWS_ARM64
    }
}