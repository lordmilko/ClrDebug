namespace ManagedCorDebug
{
    public struct GetILToNativeMappingResult
    {
        public uint PcMap { get; }

        public COR_DEBUG_IL_TO_NATIVE_MAP[] Map { get; }

        public GetILToNativeMappingResult(uint pcMap, COR_DEBUG_IL_TO_NATIVE_MAP[] map)
        {
            PcMap = pcMap;
            Map = map;
        }
    }
}