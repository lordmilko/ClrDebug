namespace ManagedCorDebug
{
    public struct GetPinvokeMapResult
    {
        public CorPinvokeMap PdwMappingFlags { get; }

        public string SzImportName { get; }

        public mdModuleRef PmrImportDLL { get; }

        public GetPinvokeMapResult(CorPinvokeMap pdwMappingFlags, string szImportName, mdModuleRef pmrImportDLL)
        {
            PdwMappingFlags = pdwMappingFlags;
            SzImportName = szImportName;
            PmrImportDLL = pmrImportDLL;
        }
    }
}