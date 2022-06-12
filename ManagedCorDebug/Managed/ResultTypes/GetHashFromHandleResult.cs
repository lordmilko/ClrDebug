namespace ManagedCorDebug
{
    public struct GetHashFromHandleResult
    {
        public int PiHashAlg { get; }

        public byte PbHash { get; }

        public int PchHash { get; }

        public GetHashFromHandleResult(int piHashAlg, byte pbHash, int pchHash)
        {
            PiHashAlg = piHashAlg;
            PbHash = pbHash;
            PchHash = pchHash;
        }
    }
}