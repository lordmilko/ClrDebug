namespace ManagedCorDebug
{
    public struct GetHashFromBlobResult
    {
        public uint PiHashAlg { get; }

        public byte PbHash { get; }

        public uint PchHash { get; }

        public GetHashFromBlobResult(uint piHashAlg, byte pbHash, uint pchHash)
        {
            PiHashAlg = piHashAlg;
            PbHash = pbHash;
            PchHash = pchHash;
        }
    }
}