namespace ManagedCorDebug
{
    public struct GetCodeRangeResult
    {
        public uint PCodeStartAddress { get; }

        public uint PCodeSize { get; }

        public GetCodeRangeResult(uint pCodeStartAddress, uint pCodeSize)
        {
            PCodeStartAddress = pCodeStartAddress;
            PCodeSize = pCodeSize;
        }
    }
}