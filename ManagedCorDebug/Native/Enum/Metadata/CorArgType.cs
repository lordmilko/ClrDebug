namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that describe the native type of a runtime handle.
    /// </summary>
    public enum CorArgType
    {
        IMAGE_CEE_CS_END = 0x0,
        IMAGE_CEE_CS_VOID = 0x1,
        IMAGE_CEE_CS_I4 = 0x2,
        IMAGE_CEE_CS_I8 = 0x3,
        IMAGE_CEE_CS_R4 = 0x4,
        IMAGE_CEE_CS_R8 = 0x5,
        IMAGE_CEE_CS_PTR = 0x6,
        IMAGE_CEE_CS_OBJECT = 0x7,
        IMAGE_CEE_CS_STRUCT4 = 0x8,
        IMAGE_CEE_CS_STRUCT32 = 0x9,
        IMAGE_CEE_CS_BYVALUE = 0xA,
    }
}