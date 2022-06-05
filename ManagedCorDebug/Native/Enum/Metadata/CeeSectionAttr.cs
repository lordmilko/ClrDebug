namespace ManagedCorDebug
{
    internal enum IMAGE_SCN : uint
    {
        CNT_CODE = 0x00000020,
        CNT_INITIALIZED_DATA = 0x00000040,
        MEM_EXECUTE = 0x20000000,
        MEM_READ = 0x40000000,
        MEM_WRITE = 0x80000000
    }

    /// <summary>
    /// Provides values that specify attributes of a section for use by the <see cref="ICeeGen"/> interface.
    /// </summary>
    public enum CeeSectionAttr : uint
    {
        /// <summary>
        /// Section has no attributes.
        /// </summary>
        sdNone = 0,

        /// <summary>
        /// Section contains initialized data that can be only read, not updated.
        /// </summary>
        sdReadOnly = IMAGE_SCN.MEM_READ | IMAGE_SCN.CNT_INITIALIZED_DATA,

        /// <summary>
        /// Section contains initialized data that can be read or updated.
        /// </summary>
        sdReadWrite = sdReadOnly | IMAGE_SCN.MEM_WRITE,

        /// <summary>
        /// Section contains executable code that is allowed to be read and executed.
        /// </summary>
        sdExecute = IMAGE_SCN.MEM_READ | IMAGE_SCN.CNT_CODE | IMAGE_SCN.MEM_EXECUTE
    }
}