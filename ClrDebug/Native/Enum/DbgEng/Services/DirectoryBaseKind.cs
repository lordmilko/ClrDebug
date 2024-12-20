namespace ClrDebug.DbgEng
{
    /// <summary>
    /// For architectures which allow for multiple page directories, (e.g.: ARM64 TTBR0/TTBR1), this defines which page directory a given query refers to.
    /// </summary>
    public enum DirectoryBaseKind : uint
    {
        /// <summary>
        /// DirectoryBaseDefault The "default" page directory for the type of target. If the target is generally debugging a hardware oriented view (e.g.: kernel, JTAG, etc...), this would refer to a kernel page directory; otherwise, it would refer to the user page directory.
        /// </summary>
        DirectoryBaseDefault,

        /// <summary>
        /// DirectoryBaseUser Refers to the user page directory.
        /// </summary>
        DirectoryBaseUser,

        /// <summary>
        /// DirectoryBaseKernel refers to the kernel page directory.
        /// </summary>
        DirectoryBaseKernel
    }
}
