namespace ClrDebug
{
    /// <summary>
    /// Indicates whether a particular range of native instructions, represented by an instance of the COR_DEBUG_IL_TO_NATIVE_MAP structure, corresponds to a special code region.
    /// </summary>
    public enum CorDebugIlToNativeMappingTypes
    {
        /// <summary>
        /// The range of native instructions corresponds to the epilog.
        /// </summary>
        EPILOG = -3, // 0xFFFFFFFD

        /// <summary>
        /// The range of native instructions corresponds to the prolog.
        /// </summary>
        PROLOG = -2, // 0xFFFFFFFE

        /// <summary>
        /// The range of native instructions does not correspond to any special code region.
        /// </summary>
        NO_MAPPING = -1, // 0xFFFFFFFF
    }
}
