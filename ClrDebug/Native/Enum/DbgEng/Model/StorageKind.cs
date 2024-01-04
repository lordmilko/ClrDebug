namespace ClrDebug.DbgEng
{
    public enum StorageKind : uint
    {
        StorageUnknown,
        StorageRegister,
        StorageRegisterRelative,
        StorageRegisterRelativeIndirect
    }
}
