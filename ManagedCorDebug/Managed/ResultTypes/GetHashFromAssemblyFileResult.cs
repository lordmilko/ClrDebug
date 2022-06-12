namespace ManagedCorDebug
{
    public struct GetHashFromAssemblyFileResult
    {
        public int PiHashAlg { get; }

        public byte PbHash { get; }

        public int PchHash { get; }

        public GetHashFromAssemblyFileResult(int piHashAlg, byte pbHash, int pchHash)
        {
            PiHashAlg = piHashAlg;
            PbHash = pbHash;
            PchHash = pchHash;
        }
    }
}