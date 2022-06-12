namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugCode.GetILToNativeMapping"/> method.
    /// </summary>
    public struct GetILToNativeMappingResult
    {
        /// <summary>
        /// [out] A pointer to the actual number of elements returned in the map array.
        /// </summary>
        public int pcMap { get; }

        /// <summary>
        /// [out] An array of <see cref="COR_DEBUG_IL_TO_NATIVE_MAP"/> structures, each of which represents a mapping from an MSIL offset to a native offset.<para/>
        /// There is no ordering to the array of elements returned.
        /// </summary>
        public COR_DEBUG_IL_TO_NATIVE_MAP[] map { get; }

        public GetILToNativeMappingResult(int pcMap, COR_DEBUG_IL_TO_NATIVE_MAP[] map)
        {
            this.pcMap = pcMap;
            this.map = map;
        }
    }
}