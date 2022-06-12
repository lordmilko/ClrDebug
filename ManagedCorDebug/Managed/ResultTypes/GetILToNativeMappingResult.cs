namespace ManagedCorDebug
{
    public struct GetILToNativeMappingResult
    {
        public int PcMap { get; }

        public COR_DEBUG_IL_TO_NATIVE_MAP[] Map { get; }

        public GetILToNativeMappingResult(int pcMap, COR_DEBUG_IL_TO_NATIVE_MAP[] map)
        {
            PcMap = pcMap;
            Map = map;
        }
    }
}