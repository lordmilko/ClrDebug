namespace ClrDebug
{
    public enum SN_OUTFLAG
    {
        /// <summary>
        /// This value is set to false to specify that the verification succeeded due to registry settings.
        /// </summary>
        SN_OUTFLAG_WAS_VERIFIED = 0x00000001,

        /// <summary>
        /// Set if the public key corresponds to SN_THE_KEY
        /// </summary>
        SN_OUTFLAG_MICROSOFT_SIGNATURE = 0x00000002
    }
}