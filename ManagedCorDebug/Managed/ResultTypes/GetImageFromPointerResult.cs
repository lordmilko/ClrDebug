namespace ManagedCorDebug
{
    public struct GetImageFromPointerResult
    {
        public CORDB_ADDRESS PImageBase { get; }

        public int PSize { get; }

        public GetImageFromPointerResult(CORDB_ADDRESS pImageBase, int pSize)
        {
            PImageBase = pImageBase;
            PSize = pSize;
        }
    }
}