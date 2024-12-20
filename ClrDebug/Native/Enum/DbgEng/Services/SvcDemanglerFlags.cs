namespace ClrDebug.DbgEng
{
    public enum SvcDemanglerFlags : uint
    {
        /// <summary>
        /// Indicates that only the name should be returned and not potential return types and function parameter types, etc...
        /// </summary>
        DemangleNameOnly = 0x00000001
    }
}
