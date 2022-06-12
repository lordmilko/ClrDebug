namespace ManagedCorDebug
{
    public struct GetHashFromAssemblyFileWResult
    {
        public int PiHashAlg { get; }

        public byte PbHash { get; }

        public int PchHash { get; }

        public GetHashFromAssemblyFileWResult(int piHashAlg, byte pbHash, int pchHash)
        {
            PiHashAlg = piHashAlg;
            PbHash = pbHash;
            PchHash = pchHash;
        }
    }
}