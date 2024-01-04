namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Flags to GetRawValue/EnumerateRawValues.
    /// </summary>
    public enum RawSearchFlags : uint
    {
        /// <summary>
        /// There are no search flags. RawSearchNone = 0x00000000,
        /// </summary>
        RawSearchNone = 0x00000000,

        /// <summary>
        /// Indicates that the search should not recurse to base children (e.g.: base classes). Only names/typeswhich are in the object itself should be returned.<para/>
        /// RawSearchNoBases = 0x00000001,
        /// </summary>
        RawSearchNoBases = 0x00000001
    }
}
