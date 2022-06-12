namespace ManagedCorDebug
{
    public struct RemoteReadResult
    {
        public byte Pv { get; }

        public int PcbRead { get; }

        public RemoteReadResult(byte pv, int pcbRead)
        {
            Pv = pv;
            PcbRead = pcbRead;
        }
    }
}