namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the hash algorithm for source files (among other things).
    /// </summary>
    public enum SvcHashAlgorithm : uint
    {
        HashAlgorithmMD5,
        HashAlgorithmSHA1,
        HashAlgorithmSHA256
    }
}
