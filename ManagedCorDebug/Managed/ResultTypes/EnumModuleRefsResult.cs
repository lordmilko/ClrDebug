using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumModuleRefs"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rModuleRefs = {rModuleRefs}")]
    public struct EnumModuleRefsResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the ModuleRef tokens.
        /// </summary>
        public mdModuleRef[] rModuleRefs { get; }

        public EnumModuleRefsResult(IntPtr phEnum, mdModuleRef[] rModuleRefs)
        {
            this.phEnum = phEnum;
            this.rModuleRefs = rModuleRefs;
        }
    }
}