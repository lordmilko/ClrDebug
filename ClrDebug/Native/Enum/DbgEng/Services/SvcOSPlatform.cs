namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the platform.
    /// </summary>
    public enum SvcOSPlatform : uint
    {
        SvcOSPlatUnknown = 0,

        /// <summary>
        /// Low values match defined VER_PLATFORM_* definitions.
        /// </summary>
        SvcOSPlatWindows = 2,
        SvcOSPlatUNIX = 10,
        SvcOSPlatMacOS = 11,
        SvcOSPlatiOS = 12,
        SvcOSPlatChromeOS = 21,
        SvcOSPlatAndroid = 22,

        /// <summary>
        /// High values are not defined by a VER_PLATFORM_* constant.
        /// </summary>
        SvcOSPlatLinux = 0x80000001
    }
}
