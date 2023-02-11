namespace ClrDebug
{
    /// <summary>
    /// Flags for use with the verify routines.
    /// </summary>
    public enum SN_INFLAG : uint
    {
        /// <summary>
        /// Forces verification even if it is necessary to override registry settings.
        /// </summary>
        SN_INFLAG_FORCE_VER = 0x00000001,

        /// <summary>
        /// Specifies that this is the first time the manifest is verified.
        /// </summary>
        SN_INFLAG_INSTALL = 0x00000002,

        /// <summary>
        /// Specifies that the cache will allow access only to users who have administrative privileges.
        /// </summary>
        SN_INFLAG_ADMIN_ACCESS = 0x00000004,

        /// <summary>
        /// Specifies that the assembly will be accessible only to the current user.
        /// </summary>
        SN_INFLAG_USER_ACCESS = 0x00000008,

        /// <summary>
        /// Specifies that the cache will provide no guarantees of access restriction.
        /// </summary>
        SN_INFLAG_ALL_ACCESS = 0x00000010,

        /// <summary>
        /// Reserved for internal debugging.
        /// </summary>
        SN_INFLAG_RUNTIME = 0x80000000
    }
}