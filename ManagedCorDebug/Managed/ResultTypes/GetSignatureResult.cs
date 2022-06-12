namespace ManagedCorDebug
{
    public struct GetSignatureResult
    {
        public int PcSig { get; }

        public byte[] Sig { get; }

        public GetSignatureResult(int pcSig, byte[] sig)
        {
            PcSig = pcSig;
            Sig = sig;
        }
    }
}