namespace ManagedCorDebug
{
    public enum CorDebugUnmappedStop
    {
        STOP_NONE = 0,
        STOP_PROLOG = 1,
        STOP_EPILOG = 2,
        STOP_NO_MAPPING_INFO = 4,
        STOP_OTHER_UNMAPPED = 8,
        STOP_UNMANAGED = 16,
        STOP_ALL = 65535
    }
}