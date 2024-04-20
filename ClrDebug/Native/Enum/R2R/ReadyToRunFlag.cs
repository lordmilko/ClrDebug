namespace ClrDebug
{
    public enum ReadyToRunFlag
    {
        READYTORUN_FLAG_PLATFORM_NEUTRAL_SOURCE = 0x00000001,   // Set if the original IL assembly was platform-neutral
        READYTORUN_FLAG_SKIP_TYPE_VALIDATION = 0x00000002,   // Set of methods with native code was determined using profile data
        READYTORUN_FLAG_PARTIAL = 0x00000004,
        READYTORUN_FLAG_NONSHARED_PINVOKE_STUBS = 0x00000008,   // PInvoke stubs compiled into image are non-shareable (no secret parameter)
        READYTORUN_FLAG_EMBEDDED_MSIL = 0x00000010,   // MSIL is embedded in the composite R2R executable
        READYTORUN_FLAG_COMPONENT = 0x00000020,   // This is the header describing a component assembly of composite R2R
        READYTORUN_FLAG_MULTIMODULE_VERSION_BUBBLE = 0x00000040,   // This R2R module has multiple modules within its version bubble (For versions before version 6.2, all modules are assumed to possibly have this characteristic)
        READYTORUN_FLAG_UNRELATED_R2R_CODE = 0x00000080,   // This R2R module has code in it that would not be naturally encoded into this module
    }
}
