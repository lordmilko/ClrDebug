namespace ManagedCorDebug
{
    public enum CorDebugMappingResult
    {
        MAPPING_PROLOG = 1,
        MAPPING_EPILOG = 2,
        MAPPING_NO_INFO = 4,
        MAPPING_UNMAPPED_ADDRESS = 8,
        MAPPING_EXACT = 16,
        MAPPING_APPROXIMATE = 32,
    }
}