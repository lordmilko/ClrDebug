namespace ManagedCorDebug
{
    public struct GetColumnInfoResult
    {
        public uint PoCol { get; }

        public uint PcbCol { get; }

        public uint PType { get; }

        public GetColumnInfoResult(uint poCol, uint pcbCol, uint pType)
        {
            PoCol = poCol;
            PcbCol = pcbCol;
            PType = pType;
        }
    }
}