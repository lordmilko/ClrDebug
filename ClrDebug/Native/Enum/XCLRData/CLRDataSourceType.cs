using System;

namespace ClrDebug
{
    /// <summary>
    /// Provides values that are used by the CLRDATA_IL_ADDRESS_MAP structure.
    /// </summary>
    /// <remarks>
    /// This enumeration lives inside the runtime and is not exposed through any headers or library files. To use it, define
    /// an enumeration as defined above in your code. This is also aliased to CLRDATA_ENUM as mentioned in Common Data
    /// Types.
    /// </remarks>
    [Flags]
    public enum CLRDataSourceType : uint
    {
        /// <summary>
        /// To indicate that nothing else applies
        /// </summary>
        CLRDATA_SOURCE_TYPE_INVALID = 0x00,
    }
}
