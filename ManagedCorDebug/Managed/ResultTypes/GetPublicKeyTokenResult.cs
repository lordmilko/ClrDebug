namespace ManagedCorDebug
{
    public struct GetPublicKeyTokenResult
    {
        public uint PcbPublicKeyToken { get; }

        public byte[] PbPublicKeyToken { get; }

        public GetPublicKeyTokenResult(uint pcbPublicKeyToken, byte[] pbPublicKeyToken)
        {
            PcbPublicKeyToken = pcbPublicKeyToken;
            PbPublicKeyToken = pbPublicKeyToken;
        }
    }
}