namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Indicates the form in which some object is memory mapped.
    /// </summary>
    public enum SvcMappingForm : uint
    {
        /// <summary>
        /// SvcMappingUnknown Indicates that no determination can be made.
        /// </summary>
        SvcMappingUnknown,

        /// <summary>
        /// SvcMappingLoaded Indicates that the object is loaded. This usually indicates something like a PE image or an ELF image was mapped into memory the way a PE or ELF loader would map it.
        /// </summary>
        SvcMappingLoaded,

        /// <summary>
        /// SvcMappingFlat Indicates that the object is mapped flat. This indicates pages of memory correspond 1:1 to pages of the object.<para/>
        /// This would be a regular memory mapped file. For something like a PE image or an ELF image that was mapped into memory, it would indicate it was mapped as if any other file and not placing image pages according to section header addresses or program header addresses.
        /// </summary>
        SvcMappingFlat
    }
}
