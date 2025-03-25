using System;

namespace ClrDebug
{
    [Flags]
    public enum ReadyToRunFlag
    {
        /// <summary>
        /// Set if the original IL assembly was platform-neutral
        /// </summary>
        READYTORUN_FLAG_PLATFORM_NEUTRAL_SOURCE = 0x00000001,

        /// <summary>
        /// Set of methods with native code was determined using profile data
        /// </summary>
        READYTORUN_FLAG_SKIP_TYPE_VALIDATION = 0x00000002,
        READYTORUN_FLAG_PARTIAL = 0x00000004,

        /// <summary>
        /// PInvoke stubs compiled into image are non-shareable (no secret parameter)
        /// </summary>
        READYTORUN_FLAG_NONSHARED_PINVOKE_STUBS = 0x00000008,

        /// <summary>
        /// MSIL is embedded in the composite R2R executable
        /// </summary>
        READYTORUN_FLAG_EMBEDDED_MSIL = 0x00000010,

        /// <summary>
        /// This is the header describing a component assembly of composite R2R
        /// </summary>
        READYTORUN_FLAG_COMPONENT = 0x00000020,

        /// <summary>
        /// This R2R module has multiple modules within its version bubble (For versions before version 6.2, all modules are assumed to possibly have this characteristic)
        /// </summary>
        READYTORUN_FLAG_MULTIMODULE_VERSION_BUBBLE = 0x00000040,

        /// <summary>
        /// This R2R module has code in it that would not be naturally encoded into this module
        /// </summary>
        READYTORUN_FLAG_UNRELATED_R2R_CODE = 0x00000080,
    }
}
