using System;

namespace ManagedCorDebug
{
    [Flags]
    public enum METAHOST_POLICY_FLAGS
    {
        HIGHCOMPAT = 0,
        APPLY_UPGRADE_POLICY = 8,
        EMULATE_EXE_LAUNCH = 16, // 0x00000010
        SHOW_ERROR_DIALOG = 32, // 0x00000020
        USE_PROCESS_IMAGE_PATH = 64, // 0x00000040
        ENSURE_SKU_SUPPORTED = 128, // 0x00000080
        IGNORE_ERROR_MODE = 4096 // 0x00001000
    }
}