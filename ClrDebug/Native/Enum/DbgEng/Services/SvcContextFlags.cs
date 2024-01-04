namespace ClrDebug.DbgEng
{
    public enum SvcContextFlags : uint
    {
        SvcContextCategorizationMask = 0x0000ffff,
        SvcContextIntegerGPR = 0x00000001,
        SvcContextFloatingPoint = 0x00000002,
        SvcContextExtended = 0x00000004,
        SvcContextControl = 0x00000008,
        SvcContextDebug = 0x00000010,
        SvcContextSpecial = 0x00000020,
        SvcContextInformationMask = 0xffff0000,
        SvcContextSubRegister = 0x00010000,
        SvcContextFlagsRegister = 0x00020000
    }
}
