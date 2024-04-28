namespace ClrDebug.PDB
{
    /// <summary>
    /// subtype enumeration values for CV_REAL and CV_COMPLEX
    /// </summary>
    public enum CV_real_e
    {
        CV_RC_REAL32    = 0x00,
        CV_RC_REAL64    = 0x01,
        CV_RC_REAL80    = 0x02,
        CV_RC_REAL128   = 0x03,
        CV_RC_REAL48    = 0x04,

        /// <summary>
        /// 32-bit partial precision real
        /// </summary>
        CV_RC_REAL32PP  = 0x05,

        CV_RC_REAL16    = 0x06,
    }
}
