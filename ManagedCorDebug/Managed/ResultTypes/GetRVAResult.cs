namespace ManagedCorDebug
{
    public struct GetRVAResult
    {
        public int PulCodeRVA { get; }

        public CorMethodImpl PdwImplFlags { get; }

        public GetRVAResult(int pulCodeRVA, CorMethodImpl pdwImplFlags)
        {
            PulCodeRVA = pulCodeRVA;
            PdwImplFlags = pdwImplFlags;
        }
    }
}