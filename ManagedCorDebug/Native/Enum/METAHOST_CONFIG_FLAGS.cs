using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Describes the possible flags returned in the pdwConfigFlags parameter of the <see cref="ICLRMetaHostPolicy.GetRequestedRuntime"/> method, indicating the presence and setting of the useLegacyV2RuntimeActivationPolicy attribute in the &lt;startup&gt; element of the configuration file.
    /// </summary>
    [Flags]
    public enum METAHOST_CONFIG_FLAGS
    {
        /// <summary>
        /// The useLegacyV2RuntimeActivationPolicy attribute was not present in the &lt;startup&gt; Element.
        /// </summary>
        LEGACY_V2_ACTIVATION_POLICY_UNSET = 0x00,

        /// <summary>
        /// The useLegacyV2RuntimeActivationPolicy attribute was present and set to true.
        /// </summary>
        LEGACY_V2_ACTIVATION_POLICY_TRUE = 0x01,

        /// <summary>
        /// The useLegacyV2RuntimeActivationPolicy attribute was present and set to false.
        /// </summary>
        LEGACY_V2_ACTIVATION_POLICY_FALSE = 0x02,

        /// <summary>
        /// Apply this mask to the value returned in pdwConfigFlags to get the values relevant to useLegacyV2RuntimeActivationPolicy.
        /// </summary>
        LEGACY_V2_ACTIVATION_POLICY_MASK = 0x03
    }
}