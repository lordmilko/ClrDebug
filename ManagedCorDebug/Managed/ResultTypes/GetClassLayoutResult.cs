namespace ManagedCorDebug
{
    public struct GetClassLayoutResult
    {
        public int PdwPackSize { get; }

        public COR_FIELD_OFFSET[] RFieldOffset { get; }

        public int PulClassSize { get; }

        public GetClassLayoutResult(int pdwPackSize, COR_FIELD_OFFSET[] rFieldOffset, int pulClassSize)
        {
            PdwPackSize = pdwPackSize;
            RFieldOffset = rFieldOffset;
            PulClassSize = pulClassSize;
        }
    }
}