namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a mapping for byte(s) of memory in an image.
    /// </summary>
    public enum ServiceImageByteMapping : uint
    {
        SvcImageByteMappingUnmapped,
        SvcImageByteMappingZero,
        SvcImageByteMappingUninitialized
    }
}
