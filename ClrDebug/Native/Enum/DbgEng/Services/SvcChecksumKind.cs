namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Indicates the kind of checksum.
    /// </summary>
    public enum SvcChecksumKind : uint
    {
        ChecksumKind_None,
        ChecksumKind_MD5,
        ChecksumKind_SHA1,
        ChecksumKind_SHA256
    }
}
