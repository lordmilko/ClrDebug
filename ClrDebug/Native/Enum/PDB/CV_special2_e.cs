namespace ClrDebug.PDB
{
    /// <summary>
    /// subtype enumeration values for CV_SPECIAL2
    /// </summary>
    public enum CV_special2_e
    {
        CV_S2_BIT       = 0x00,

        /// <summary>
        /// Pascal CHAR
        /// </summary>
        CV_S2_PASCHAR   = 0x01,

        /// <summary>
        /// 32-bit BOOL where true is 0xffffffff
        /// </summary>
        CV_S2_BOOL32FF  = 0x02
    }
}
