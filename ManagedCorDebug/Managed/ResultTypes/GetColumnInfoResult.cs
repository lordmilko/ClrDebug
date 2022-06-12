namespace ManagedCorDebug
{
    public struct GetColumnInfoResult
    {
        public int PoCol { get; }

        public int PcbCol { get; }

        public int PType { get; }

        public GetColumnInfoResult(int poCol, int pcbCol, int pType)
        {
            PoCol = poCol;
            PcbCol = pcbCol;
            PType = pType;
        }
    }
}