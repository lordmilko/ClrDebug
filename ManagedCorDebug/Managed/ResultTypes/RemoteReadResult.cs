namespace ManagedCorDebug
{
    public struct RemoteReadResult
    {
        public byte Pv { get; }

        public uint PcbRead { get; }

        public RemoteReadResult(byte pv, uint pcbRead)
        {
            Pv = pv;
            PcbRead = pcbRead;
        }
    }
}