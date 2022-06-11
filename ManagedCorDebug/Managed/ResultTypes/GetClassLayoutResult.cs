namespace ManagedCorDebug
{
    public struct GetClassLayoutResult
    {
        public uint PdwPackSize { get; }

        public COR_FIELD_OFFSET[] RFieldOffset { get; }

        public uint PulClassSize { get; }

        public GetClassLayoutResult(uint pdwPackSize, COR_FIELD_OFFSET[] rFieldOffset, uint pulClassSize)
        {
            PdwPackSize = pdwPackSize;
            RFieldOffset = rFieldOffset;
            PulClassSize = pulClassSize;
        }
    }
}