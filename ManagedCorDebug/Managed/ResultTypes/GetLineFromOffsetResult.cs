namespace ManagedCorDebug
{
    public struct GetLineFromOffsetResult
    {
        public int Pline { get; }

        public int Pcolumn { get; }

        public int PendLine { get; }

        public int PendColumn { get; }

        public int PdwStartOffset { get; }

        public GetLineFromOffsetResult(int pline, int pcolumn, int pendLine, int pendColumn, int pdwStartOffset)
        {
            Pline = pline;
            Pcolumn = pcolumn;
            PendLine = pendLine;
            PendColumn = pendColumn;
            PdwStartOffset = pdwStartOffset;
        }
    }
}