namespace ClrDebug
{
    /// <summary>
    /// Provides flag values used by the linker when linking native code.
    /// </summary>
    public enum CorNativeLinkFlags : byte
    {
        /// <summary>
        /// Indicates no flags.
        /// </summary>
        nlfNone = 0x00,     // no flags 

        /// <summary>
        /// Indicates a setLastError keyword.
        /// </summary>
        nlfLastError = 0x01,     // setLastError keyword specified

        /// <summary>
        /// Indicates a nomangle keyword.
        /// </summary>
        nlfNoMangle = 0x02,     // nomangle keyword specified

        /// <summary>
        /// Not used.
        /// </summary>
        nlfMaxValue = 0x03,     // used so we can assert how many bits are required for this enum
    }
}