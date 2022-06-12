namespace ManagedCorDebug
{
    public struct GetSymbolSearchInfoResult
    {
        public int PcSearchInfo { get; }

        public SymUnmanagedSymbolSearchInfo RgpSearchInfo { get; }

        public GetSymbolSearchInfoResult(int pcSearchInfo, SymUnmanagedSymbolSearchInfo rgpSearchInfo)
        {
            PcSearchInfo = pcSearchInfo;
            RgpSearchInfo = rgpSearchInfo;
        }
    }
}