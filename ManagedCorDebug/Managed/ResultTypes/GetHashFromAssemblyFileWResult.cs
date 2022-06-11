namespace ManagedCorDebug
{
    public struct GetHashFromAssemblyFileWResult
    {
        public uint PiHashAlg { get; }

        public byte PbHash { get; }

        public uint PchHash { get; }

        public GetHashFromAssemblyFileWResult(uint piHashAlg, byte pbHash, uint pchHash)
        {
            PiHashAlg = piHashAlg;
            PbHash = pbHash;
            PchHash = pchHash;
        }
    }
}