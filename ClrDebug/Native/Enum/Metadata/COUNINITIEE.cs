namespace ClrDebug
{
    /// <summary>
    /// Specifies constants used by CoUninitializeEE when initializing the common language runtime.
    /// </summary>
    public enum COUNINITIEE
    {
        /// <summary>
        /// Indicates default uninitialization mode.
        /// </summary>
        COUNINITEE_DEFAULT = 0x0,          // Default uninitialization mode.

        /// <summary>
        /// Indicates uninitialization mode for unloading an assembly.
        /// </summary>
        COUNINITEE_DLL = 0x1           // Uninitialization mode for unloading DLL. 
    }
}