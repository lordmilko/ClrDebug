namespace ManagedCorDebug
{
    public struct GetSourceExtentInDocumentResult
    {
        public uint PstartLine { get; }

        public uint PendLine { get; }

        public GetSourceExtentInDocumentResult(uint pstartLine, uint pendLine)
        {
            PstartLine = pstartLine;
            PendLine = pendLine;
        }
    }
}