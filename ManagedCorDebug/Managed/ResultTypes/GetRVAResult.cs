namespace ManagedCorDebug
{
    public struct GetRVAResult
    {
        public uint PulCodeRVA { get; }

        public CorMethodImpl PdwImplFlags { get; }

        public GetRVAResult(uint pulCodeRVA, CorMethodImpl pdwImplFlags)
        {
            PulCodeRVA = pulCodeRVA;
            PdwImplFlags = pdwImplFlags;
        }
    }
}