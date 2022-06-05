namespace ManagedCorDebug
{
    /// <summary>
    /// Indicates which memory regions a call to the <see cref="ICLRDataEnumMemoryRegions.EnumMemoryRegions"/> method should include.
    /// </summary>
    public enum CLRDataEnumMemoryFlags
    {
        /// <summary>
        /// A minidump, that is, a sparse memory dump.
        /// </summary>
        CLRDATA_ENUM_MEM_DEFAULT = 0,
        CLRDATA_ENUM_MEM_MINI = 0,

        /// <summary>
        /// A full heap dump.
        /// </summary>
        CLRDATA_ENUM_MEM_HEAP = 1,
        CLRDATA_ENUM_MEM_TRIAGE = 2
    }
}