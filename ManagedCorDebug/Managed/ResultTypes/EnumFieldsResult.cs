using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumFields"/> method.
    /// </summary>
    public struct EnumFieldsResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The list of FieldDef tokens.
        /// </summary>
        public mdFieldDef[] rFields { get; }

        /// <summary>
        /// [out] The actual number of FieldDef tokens returned in rFields.
        /// </summary>
        public int pcTokens { get; }

        public EnumFieldsResult(IntPtr phEnum, mdFieldDef[] rFields, int pcTokens)
        {
            this.phEnum = phEnum;
            this.rFields = rFields;
            this.pcTokens = pcTokens;
        }
    }
}