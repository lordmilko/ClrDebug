namespace ManagedCorDebug
{
    public struct GetPublicKeyResult
    {
        public uint PcbPublicKey { get; }

        public byte[] PbPublicKey { get; }

        public GetPublicKeyResult(uint pcbPublicKey, byte[] pbPublicKey)
        {
            PcbPublicKey = pcbPublicKey;
            PbPublicKey = pbPublicKey;
        }
    }
}