namespace ManagedCorDebug
{
    public struct GetInstrumentedILMapResult
    {
        public int PcMap { get; }

        public COR_IL_MAP[] Map { get; }

        public GetInstrumentedILMapResult(int pcMap, COR_IL_MAP[] map)
        {
            PcMap = pcMap;
            Map = map;
        }
    }
}