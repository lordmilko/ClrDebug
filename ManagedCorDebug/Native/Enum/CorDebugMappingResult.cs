namespace ManagedCorDebug
{
    public enum CorDebugMappingResult
    {
        MAPPING_PROLOG = 1,
        MAPPING_EPILOG = 2,
        MAPPING_NO_INFO = 4,
        MAPPING_UNMAPPED_ADDRESS = 8,
        MAPPING_EXACT = 16, // 0x00000010
        MAPPING_APPROXIMATE = 32 // 0x00000020
    }
}