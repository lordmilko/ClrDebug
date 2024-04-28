namespace ClrDebug.PDB
{
    /// <summary>
    /// enumeration for method properties
    /// </summary>
    public enum CV_methodprop_e : byte
    {
        CV_MTvanilla        = 0x00,
        CV_MTvirtual        = 0x01,
        CV_MTstatic         = 0x02,
        CV_MTfriend         = 0x03,
        CV_MTintro          = 0x04,
        CV_MTpurevirt       = 0x05,
        CV_MTpureintro      = 0x06
    }
}
