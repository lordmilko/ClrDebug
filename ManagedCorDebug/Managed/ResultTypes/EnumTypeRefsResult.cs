using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumTypeRefs"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rTypeRefs = {rTypeRefs}")]
    public struct EnumTypeRefsResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the TypeRef tokens.
        /// </summary>
        public mdTypeRef[] rTypeRefs { get; }

        public EnumTypeRefsResult(IntPtr phEnum, mdTypeRef[] rTypeRefs)
        {
            this.phEnum = phEnum;
            this.rTypeRefs = rTypeRefs;
        }
    }
}