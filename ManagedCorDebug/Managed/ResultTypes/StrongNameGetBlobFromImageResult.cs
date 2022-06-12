namespace ManagedCorDebug
{
    public struct StrongNameGetBlobFromImageResult
    {
        public byte PbBlob { get; }

        public int PcbBlob { get; }

        public StrongNameGetBlobFromImageResult(byte pbBlob, int pcbBlob)
        {
            PbBlob = pbBlob;
            PcbBlob = pcbBlob;
        }
    }
}