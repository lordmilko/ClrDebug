namespace ManagedCorDebug
{
    public struct GetSymbolSearchInfoResult
    {
        public uint PcSearchInfo { get; }

        public SymUnmanagedSymbolSearchInfo RgpSearchInfo { get; }

        public GetSymbolSearchInfoResult(uint pcSearchInfo, SymUnmanagedSymbolSearchInfo rgpSearchInfo)
        {
            PcSearchInfo = pcSearchInfo;
            RgpSearchInfo = rgpSearchInfo;
        }
    }
}