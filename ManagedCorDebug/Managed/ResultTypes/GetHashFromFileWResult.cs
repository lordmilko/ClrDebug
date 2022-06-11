namespace ManagedCorDebug
{
    public struct GetHashFromFileWResult
    {
        public uint PiHashAlg { get; }

        public byte PbHash { get; }

        public uint PchHash { get; }

        public GetHashFromFileWResult(uint piHashAlg, byte pbHash, uint pchHash)
        {
            PiHashAlg = piHashAlg;
            PbHash = pbHash;
            PchHash = pchHash;
        }
    }
}