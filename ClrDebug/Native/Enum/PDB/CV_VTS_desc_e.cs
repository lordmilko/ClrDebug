namespace ClrDebug.PDB
{
    /// <summary>
    /// enumeration for virtual shape table entries
    /// </summary>
    public enum CV_VTS_desc_e
    {
        CV_VTS_near         = 0x00,
        CV_VTS_far          = 0x01,
        CV_VTS_thin         = 0x02,
        CV_VTS_outer        = 0x03,
        CV_VTS_meta         = 0x04,
        CV_VTS_near32       = 0x05,
        CV_VTS_far32        = 0x06,
        CV_VTS_unused       = 0x07
    }
}
