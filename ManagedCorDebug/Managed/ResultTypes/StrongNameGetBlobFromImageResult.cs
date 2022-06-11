namespace ManagedCorDebug
{
    public struct StrongNameGetBlobFromImageResult
    {
        public byte PbBlob { get; }

        public uint PcbBlob { get; }

        public StrongNameGetBlobFromImageResult(byte pbBlob, uint pcbBlob)
        {
            PbBlob = pbBlob;
            PcbBlob = pcbBlob;
        }
    }
}