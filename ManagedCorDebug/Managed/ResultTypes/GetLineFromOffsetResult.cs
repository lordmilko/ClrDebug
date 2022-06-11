namespace ManagedCorDebug
{
    public struct GetLineFromOffsetResult
    {
        public uint Pline { get; }

        public uint Pcolumn { get; }

        public uint PendLine { get; }

        public uint PendColumn { get; }

        public uint PdwStartOffset { get; }

        public GetLineFromOffsetResult(uint pline, uint pcolumn, uint pendLine, uint pendColumn, uint pdwStartOffset)
        {
            Pline = pline;
            Pcolumn = pcolumn;
            PendLine = pendLine;
            PendColumn = pendColumn;
            PdwStartOffset = pdwStartOffset;
        }
    }
}