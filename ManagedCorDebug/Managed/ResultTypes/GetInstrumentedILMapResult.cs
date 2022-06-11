namespace ManagedCorDebug
{
    public struct GetInstrumentedILMapResult
    {
        public uint PcMap { get; }

        public COR_IL_MAP[] Map { get; }

        public GetInstrumentedILMapResult(uint pcMap, COR_IL_MAP[] map)
        {
            PcMap = pcMap;
            Map = map;
        }
    }
}