namespace ManagedCorDebug
{
    public struct GetTableInfoResult
    {
        public uint PcbRow { get; }

        public uint PcRows { get; }

        public uint PcCols { get; }

        public uint PiKey { get; }

        public GetTableInfoResult(uint pcbRow, uint pcRows, uint pcCols, uint piKey)
        {
            PcbRow = pcbRow;
            PcRows = pcRows;
            PcCols = pcCols;
            PiKey = piKey;
        }
    }
}