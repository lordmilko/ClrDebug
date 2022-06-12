namespace ManagedCorDebug
{
    public struct GetTableInfoResult
    {
        public int PcbRow { get; }

        public int PcRows { get; }

        public int PcCols { get; }

        public int PiKey { get; }

        public GetTableInfoResult(int pcbRow, int pcRows, int pcCols, int piKey)
        {
            PcbRow = pcbRow;
            PcRows = pcRows;
            PcCols = pcCols;
            PiKey = piKey;
        }
    }
}