namespace ManagedCorDebug
{
    /// <summary>
    /// Provides the details of how the value of the instruction pointer (IP) was obtained.
    /// </summary>
    /// <remarks>
    /// You can use the <see cref="ICorDebugILFrame.GetIP"/> method to obtain the value of the instruction pointer.
    /// </remarks>
    public enum CorDebugMappingResult
    {
        /// <summary>
        /// The native code is in the prolog, so the value of the IP is 0.
        /// </summary>
        MAPPING_PROLOG = 1,

        /// <summary>
        /// The native code is in an epilog, so the value of the IP is the address of the last instruction of the method.
        /// </summary>
        MAPPING_EPILOG = 2,

        /// <summary>
        /// No mapping information is available for the method, so the value of the IP is 0.
        /// </summary>
        MAPPING_NO_INFO = 4,

        /// <summary>
        /// Although there is mapping information for the method, the current address cannot be mapped to Microsoft intermediate language (MSIL) code. The value of the IP is 0.
        /// </summary>
        MAPPING_UNMAPPED_ADDRESS = 8,

        /// <summary>
        /// Either the method maps exactly to MSIL code or the frame has been interpreted, so the value of the IP is accurate.
        /// </summary>
        MAPPING_EXACT = 16, // 0x00000010

        /// <summary>
        /// The method was successfully mapped, but the value of the IP may be approximate.
        /// </summary>
        MAPPING_APPROXIMATE = 32 // 0x00000020
    }
}