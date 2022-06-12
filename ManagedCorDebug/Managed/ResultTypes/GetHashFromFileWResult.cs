namespace ManagedCorDebug
{
    public struct GetHashFromFileWResult
    {
        public int PiHashAlg { get; }

        public byte PbHash { get; }

        public int PchHash { get; }

        public GetHashFromFileWResult(int piHashAlg, byte pbHash, int pchHash)
        {
            PiHashAlg = piHashAlg;
            PbHash = pbHash;
            PchHash = pchHash;
        }
    }
}