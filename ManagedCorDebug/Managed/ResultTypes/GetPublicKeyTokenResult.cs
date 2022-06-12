namespace ManagedCorDebug
{
    public struct GetPublicKeyTokenResult
    {
        public int PcbPublicKeyToken { get; }

        public byte[] PbPublicKeyToken { get; }

        public GetPublicKeyTokenResult(int pcbPublicKeyToken, byte[] pbPublicKeyToken)
        {
            PcbPublicKeyToken = pcbPublicKeyToken;
            PbPublicKeyToken = pbPublicKeyToken;
        }
    }
}