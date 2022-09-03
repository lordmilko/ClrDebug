namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Identifies the calling convention used by a method described in a METHODDATA structure.
    /// </summary>
    public enum CALLCONV
    {
        /// <summary>
        /// Indicates that the C declaration (CDECL) calling convention is used for a method.
        /// </summary>
        CC_CDECL = 1,

        /// <summary>
        /// Indicates that the MSC Pascal (MSCPASCAL) calling convention is used for a method.
        /// </summary>
        CC_MSCPASCAL = 2,

        /// <summary>
        /// Indicates that the Pascal calling convention is used for a method.
        /// </summary>
        CC_PASCAL = 2,

        /// <summary>
        /// Indicates that the Macintosh Pascal (MACPASCAL) calling convention is used for a method.
        /// </summary>
        CC_MACPASCAL = 3,

        /// <summary>
        /// Indicates that the standard calling convention (STDCALL) is used for a method.
        /// </summary>
        CC_STDCALL = 4,

        /// <summary>
        /// This value is reserved for future use.
        /// </summary>
        CC_RESERVED = 5,

        /// <summary>
        /// Indicates that the standard SYSCALL calling convention is used for a method.
        /// </summary>
        CC_SYSCALL = 6,

        /// <summary>
        /// Indicates that the Macintosh Programmers' Workbench (MPW) CDECL calling convention is used for a method.
        /// </summary>
        CC_MPWCDECL = 7,

        /// <summary>
        /// Indicates that the Macintosh Programmers' Workbench (MPW) PASCAL calling convention is used for a method.
        /// </summary>
        CC_MPWPASCAL = 8,

        /// <summary>
        /// Indicates the end of the <see cref="CALLCONV"/> enumeration.
        /// </summary>
        CC_MAX = 9,
    }
}
