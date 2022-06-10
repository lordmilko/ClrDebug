namespace ManagedCorDebug
{
    /// <summary>
    /// Provides additional information about debug events on the Windows platform.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugProcess6.DecodeEvent"/> method includes a dwFlags parameter that provides additional information
    /// about a debug event and whose value is dependent on the target architecture. The <see cref="CorDebugDecodeEventFlagsWindows"/>
    /// enumeration can be used with debug events on the Windows platform.
    /// </remarks>
    public enum CorDebugDecodeEventFlagsWindows
    {
        /// <summary>
        /// Indicates that the debug event is a first-chance exception.
        /// </summary>
        IS_FIRST_CHANCE = 1,
    }
}