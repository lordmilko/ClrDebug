namespace ClrDebug.PDB
{
    /// <summary>
    /// enum describing function data return method
    /// </summary>
    public enum CV_GENERIC_STYLE_e : byte
    {
        /// <summary>
        /// void return type
        /// </summary>
        CV_GENERIC_VOID = 0x00,

        /// <summary>
        /// return data is in registers
        /// </summary>
        CV_GENERIC_REG = 0x01,

        /// <summary>
        /// indirect caller allocated near
        /// </summary>
        CV_GENERIC_ICAN = 0x02,

        /// <summary>
        /// indirect caller allocated far
        /// </summary>
        CV_GENERIC_ICAF = 0x03,

        /// <summary>
        /// indirect returnee allocated near
        /// </summary>
        CV_GENERIC_IRAN = 0x04,

        /// <summary>
        /// indirect returnee allocated far
        /// </summary>
        CV_GENERIC_IRAF = 0x05,

        /// <summary>
        /// first unused
        /// </summary>
        CV_GENERIC_UNUSED = 0x06
    }
}
