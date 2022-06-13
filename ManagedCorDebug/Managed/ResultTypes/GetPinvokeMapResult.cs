using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetPinvokeMap"/> method.
    /// </summary>
    [DebuggerDisplay("pdwMappingFlags = {pdwMappingFlags}, szImportName = {szImportName}, pmrImportDLL = {pmrImportDLL}")]
    public struct GetPinvokeMapResult
    {
        /// <summary>
        /// A pointer to flags used for mapping. This value is a bitmask from the <see cref="CorPinvokeMap"/> enumeration.
        /// </summary>
        public CorPinvokeMap pdwMappingFlags { get; }

        /// <summary>
        /// The name of the unmanaged target DLL.
        /// </summary>
        public string szImportName { get; }

        /// <summary>
        /// A pointer to a ModuleRef token that represents the unmanaged target object library.
        /// </summary>
        public mdModuleRef pmrImportDLL { get; }

        public GetPinvokeMapResult(CorPinvokeMap pdwMappingFlags, string szImportName, mdModuleRef pmrImportDLL)
        {
            this.pdwMappingFlags = pdwMappingFlags;
            this.szImportName = szImportName;
            this.pmrImportDLL = pmrImportDLL;
        }
    }
}