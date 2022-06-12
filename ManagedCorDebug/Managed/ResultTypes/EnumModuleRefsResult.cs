using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumModuleRefs"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rModuleRefs = {rModuleRefs}, pcModuleRefs = {pcModuleRefs}")]
    public struct EnumModuleRefsResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array used to store the ModuleRef tokens.
        /// </summary>
        public mdModuleRef[] rModuleRefs { get; }

        /// <summary>
        /// [out] The number of ModuleRef tokens returned in rModuleRefs.
        /// </summary>
        public int pcModuleRefs { get; }

        public EnumModuleRefsResult(IntPtr phEnum, mdModuleRef[] rModuleRefs, int pcModuleRefs)
        {
            this.phEnum = phEnum;
            this.rModuleRefs = rModuleRefs;
            this.pcModuleRefs = pcModuleRefs;
        }
    }
}