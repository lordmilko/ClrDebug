namespace ManagedCorDebug
{
    public struct GetHashFromAssemblyFileResult
    {
        public uint PiHashAlg { get; }

        public byte PbHash { get; }

        public uint PchHash { get; }

        public GetHashFromAssemblyFileResult(uint piHashAlg, byte pbHash, uint pchHash)
        {
            PiHashAlg = piHashAlg;
            PbHash = pbHash;
            PchHash = pchHash;
        }
    }
}