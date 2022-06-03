using System;

namespace ManagedCorDebug
{
    [Flags]
    public enum METAHOST_CONFIG_FLAGS
    {
        LEGACY_V2_ACTIVATION_POLICY_UNSET = 0x00,
        LEGACY_V2_ACTIVATION_POLICY_TRUE = 0x01,
        LEGACY_V2_ACTIVATION_POLICY_FALSE = 0x02,
        LEGACY_V2_ACTIVATION_POLICY_MASK = 0x03
    }
}