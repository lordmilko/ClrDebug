namespace ClrDebug
{
    /// <summary>
    /// Provides a value that determines whether a debugger loads native (NGen) images from the native image cache.
    /// </summary>
    /// <remarks>
    /// The <see cref="CorDebugNGenPolicy"/> enumeration is used by the <see cref="ICorDebugProcess5.EnableNGENPolicy"/> method. Disabling
    /// the use of images from the local native image cache provides for a consistent debugging experience by ensuring
    /// that the debugger loads debuggable JIT-compiled images instead of optimized native images.
    /// </remarks>
    public enum CorDebugNGenPolicy
    {
        /// <summary>
        /// In a Windows 8.x Store app, the use of images from the local native image cache is disabled. In a desktop app, this setting has no effect.
        /// </summary>
        DISABLE_LOCAL_NIC = 1
    }
}