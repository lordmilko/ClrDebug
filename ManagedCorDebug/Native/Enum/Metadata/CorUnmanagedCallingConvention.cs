namespace ManagedCorDebug
{
    /// <summary>
    /// Specifies the calling conventions for unmanaged code.
    /// </summary>
    /// <remarks>
    /// The CLR does not support the "fast" calling convention in the .NET Framework version 1.0.
    /// </remarks>
    public enum CorUnmanagedCallingConvention
    {
        /// <summary>
        /// The C language calling convention.
        /// </summary>
        IMAGE_CEE_UNMANAGED_CALLCONV_C = 0x1,

        /// <summary>
        /// The standard calling convention.
        /// </summary>
        IMAGE_CEE_UNMANAGED_CALLCONV_STDCALL = 0x2,

        /// <summary>
        /// The "this" calling convention.
        /// </summary>
        IMAGE_CEE_UNMANAGED_CALLCONV_THISCALL = 0x3,

        /// <summary>
        /// The "fast" calling convention.
        /// </summary>
        IMAGE_CEE_UNMANAGED_CALLCONV_FASTCALL = 0x4,

        /// <summary>
        /// Not used.
        /// </summary>
        IMAGE_CEE_CS_CALLCONV_C = IMAGE_CEE_UNMANAGED_CALLCONV_C,

        /// <summary>
        /// Not used.
        /// </summary>
        IMAGE_CEE_CS_CALLCONV_STDCALL = IMAGE_CEE_UNMANAGED_CALLCONV_STDCALL,

        /// <summary>
        /// Not used.
        /// </summary>
        IMAGE_CEE_CS_CALLCONV_THISCALL = IMAGE_CEE_UNMANAGED_CALLCONV_THISCALL,

        /// <summary>
        /// Not used.
        /// </summary>
        IMAGE_CEE_CS_CALLCONV_FASTCALL = IMAGE_CEE_UNMANAGED_CALLCONV_FASTCALL,

    }
}