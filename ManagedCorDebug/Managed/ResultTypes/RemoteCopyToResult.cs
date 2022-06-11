namespace ManagedCorDebug
{
    public struct RemoteCopyToResult
    {
        public ULARGE_INTEGER PcbRead { get; }

        public ULARGE_INTEGER PcbWritten { get; }

        public RemoteCopyToResult(ULARGE_INTEGER pcbRead, ULARGE_INTEGER pcbWritten)
        {
            PcbRead = pcbRead;
            PcbWritten = pcbWritten;
        }
    }
}