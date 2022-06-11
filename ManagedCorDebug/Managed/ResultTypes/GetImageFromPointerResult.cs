namespace ManagedCorDebug
{
    public struct GetImageFromPointerResult
    {
        public CORDB_ADDRESS PImageBase { get; }

        public uint PSize { get; }

        public GetImageFromPointerResult(CORDB_ADDRESS pImageBase, uint pSize)
        {
            PImageBase = pImageBase;
            PSize = pSize;
        }
    }
}