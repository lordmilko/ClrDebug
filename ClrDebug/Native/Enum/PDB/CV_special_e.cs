namespace ClrDebug.PDB
{
    /// <summary>
    /// subtype enumeration values for CV_SPECIAL
    /// </summary>
    public enum CV_special_e
    {
        CV_SP_NOTYPE    = 0x00,
        CV_SP_ABS       = 0x01,
        CV_SP_SEGMENT   = 0x02,
        CV_SP_VOID      = 0x03,
        CV_SP_CURRENCY  = 0x04,
        CV_SP_NBASICSTR = 0x05,
        CV_SP_FBASICSTR = 0x06,
        CV_SP_NOTTRANS  = 0x07,
        CV_SP_HRESULT   = 0x08,
    }
}
