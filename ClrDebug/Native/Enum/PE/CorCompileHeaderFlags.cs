using System;

namespace ClrDebug
{
    // Values for Flags field of CORCOMPILE_HEADER.
    [Flags]
    public enum CorCompileHeaderFlags
    {
        CORCOMPILE_HEADER_HAS_SECURITY_DIRECTORY = 0x00000001,   // Original image had a security directory
        // Note it is useless to cache the actual directory contents
        // since it must be verified as part of the original image
        CORCOMPILE_HEADER_IS_IBC_OPTIMIZED = 0x00000002,

        CORCOMPILE_HEADER_IS_READY_TO_RUN = 0x00000004,
    }
}
