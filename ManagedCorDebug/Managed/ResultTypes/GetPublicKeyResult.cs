namespace ManagedCorDebug
{
    public struct GetPublicKeyResult
    {
        public int PcbPublicKey { get; }

        public byte[] PbPublicKey { get; }

        public GetPublicKeyResult(int pcbPublicKey, byte[] pbPublicKey)
        {
            PcbPublicKey = pcbPublicKey;
            PbPublicKey = pbPublicKey;
        }
    }
}