namespace ManagedCorDebug
{
    public struct GetHashFromFileResult
    {
        public int PiHashAlg { get; }

        public byte PbHash { get; }

        public int PchHash { get; }

        public GetHashFromFileResult(int piHashAlg, byte pbHash, int pchHash)
        {
            PiHashAlg = piHashAlg;
            PbHash = pbHash;
            PchHash = pchHash;
        }
    }
}