namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that describe a portable executable (PE) file, as returned from a call to <see cref="IMetaDataImport2.GetPEKind"/>.
    /// </summary>
    /// <remarks>
    /// These values can be used in bitwise combinations.
    /// </remarks>
    public enum CorPEKind
    {
        /// <summary>
        /// Indicates that this is not a PE file.
        /// </summary>
        peNot = 0x00000000,   // not a PE file

        /// <summary>
        /// Indicates that this PE file contains only managed code.
        /// </summary>
        peILonly = 0x00000001,   // flag IL_ONLY is set in COR header

        /// <summary>
        /// Indicates that this PE file makes Win32 calls.
        /// </summary>
        pe32BitRequired = 0x00000002,  // flag 32BITREQUIRED is set and 32BITPREFERRED is clear in COR header

        /// <summary>
        /// Indicates that this PE file runs on a 64-bit platform.
        /// </summary>
        pe32Plus = 0x00000004,   // PE32+ file (64 bit)

        /// <summary>
        /// Indicates that this PE file is native code.
        /// </summary>
        pe32Unmanaged = 0x00000008,    // PE32 without COR header

        /// <summary>
        /// Indicates that this PE file is platform-neutral and prefers to be loaded in a 32-bit environment.
        /// </summary>
        pe32BitPreferred = 0x00000010  // flags 32BITREQUIRED and 32BITPREFERRED are set in COR header
    }
}