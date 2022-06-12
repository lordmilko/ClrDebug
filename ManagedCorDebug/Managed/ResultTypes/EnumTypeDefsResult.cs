using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumTypeDefs"/> method.
    /// </summary>
    public struct EnumTypeDefsResult
    {
        /// <summary>
        /// [out] A pointer to the new enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [in] The array used to store the TypeDef tokens.
        /// </summary>
        public mdTypeDef[] typeDefs { get; }

        /// <summary>
        /// [out] The number of TypeDef tokens returned in rTypeDefs.
        /// </summary>
        public int pcTypeDefs { get; }

        public EnumTypeDefsResult(IntPtr phEnum, mdTypeDef[] typeDefs, int pcTypeDefs)
        {
            this.phEnum = phEnum;
            this.typeDefs = typeDefs;
            this.pcTypeDefs = pcTypeDefs;
        }
    }
}