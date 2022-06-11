namespace ManagedCorDebug
{
    public struct GetSignatureResult
    {
        public uint PcSig { get; }

        public byte[] Sig { get; }

        public GetSignatureResult(uint pcSig, byte[] sig)
        {
            PcSig = pcSig;
            Sig = sig;
        }
    }
}