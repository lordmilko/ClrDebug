namespace ManagedCorDebug
{
    public struct GetCodeRangeResult
    {
        public int PCodeStartAddress { get; }

        public int PCodeSize { get; }

        public GetCodeRangeResult(int pCodeStartAddress, int pCodeSize)
        {
            PCodeStartAddress = pCodeStartAddress;
            PCodeSize = pCodeSize;
        }
    }
}