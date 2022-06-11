namespace ManagedCorDebug
{
    public struct GetHashFromFileResult
    {
        public uint PiHashAlg { get; }

        public byte PbHash { get; }

        public uint PchHash { get; }

        public GetHashFromFileResult(uint piHashAlg, byte pbHash, uint pchHash)
        {
            PiHashAlg = piHashAlg;
            PbHash = pbHash;
            PchHash = pchHash;
        }
    }
}