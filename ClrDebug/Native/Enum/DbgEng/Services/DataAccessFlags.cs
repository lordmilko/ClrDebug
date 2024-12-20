namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a particular type of data access.
    /// </summary>
    public enum DataAccessFlags : uint
    {
        DataNone = 0x00000000,
        DataRead = 0x00000001,
        DataWrite = 0x00000002,
        DataExecute = 0x00000004
    }
}
