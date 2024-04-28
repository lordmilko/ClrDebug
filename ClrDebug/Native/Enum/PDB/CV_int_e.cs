namespace ClrDebug.PDB
{
    /// <summary>
    /// subtype enumeration values for CV_INT (really int)
    /// </summary>
    public enum CV_int_e
    {
        CV_RI_CHAR      = 0x00,
        CV_RI_INT1      = 0x00,
        CV_RI_WCHAR     = 0x01,
        CV_RI_UINT1     = 0x01,
        CV_RI_INT2      = 0x02,
        CV_RI_UINT2     = 0x03,
        CV_RI_INT4      = 0x04,
        CV_RI_UINT4     = 0x05,
        CV_RI_INT8      = 0x06,
        CV_RI_UINT8     = 0x07,
        CV_RI_INT16     = 0x08,
        CV_RI_UINT16    = 0x09,

        /// <summary>
        /// char16_t
        /// </summary>
        CV_RI_CHAR16    = 0x0a,

        /// <summary>
        /// char32_t
        /// </summary>
        CV_RI_CHAR32    = 0x0b
    }
}
