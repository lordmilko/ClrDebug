namespace ClrDebug.DbgEng
{
    public enum SvcOSPlatform : uint
    {
        SvcOSPlatUnknown = 0,
        SvcOSPlatWindows = 2,
        SvcOSPlatUNIX = 10,
        SvcOSPlatMacOS = 11,
        SvcOSPlatiOS = 12,
        SvcOSPlatChromeOS = 21,
        SvcOSPlatAndroid = 22,
        SvcOSPlatLinux = 0x80000001
    }
}
