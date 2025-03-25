namespace ClrDebug.PDB
{
    public enum CV_cookietype_e : byte //cvinfo.h doesn't say it, but FRAMECOOKIE needs it to be a byte
    {
        CV_COOKIETYPE_COPY = 0,
        CV_COOKIETYPE_XOR_SP,
        CV_COOKIETYPE_XOR_BP,
        CV_COOKIETYPE_XOR_R13,
    }
}
