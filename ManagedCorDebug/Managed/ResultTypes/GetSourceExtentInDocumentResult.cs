namespace ManagedCorDebug
{
    public struct GetSourceExtentInDocumentResult
    {
        public int PstartLine { get; }

        public int PendLine { get; }

        public GetSourceExtentInDocumentResult(int pstartLine, int pendLine)
        {
            PstartLine = pstartLine;
            PendLine = pendLine;
        }
    }
}