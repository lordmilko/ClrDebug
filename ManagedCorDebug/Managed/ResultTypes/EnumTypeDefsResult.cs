using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumTypeDefs"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, typeDefs = {typeDefs}")]
    public struct EnumTypeDefsResult
    {
        /// <summary>
        /// A pointer to the new enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the TypeDef tokens.
        /// </summary>
        public mdTypeDef[] typeDefs { get; }

        public EnumTypeDefsResult(IntPtr phEnum, mdTypeDef[] typeDefs)
        {
            this.phEnum = phEnum;
            this.typeDefs = typeDefs;
        }
    }
}