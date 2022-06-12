using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumFieldsWithName"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rFields = {rFields}, pcTokens = {pcTokens}")]
    public struct EnumFieldsWithNameResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] Array used to store the FieldDef tokens.
        /// </summary>
        public mdFieldDef[] rFields { get; }

        /// <summary>
        /// [out] The actual number of FieldDef tokens returned in rFields.
        /// </summary>
        public int pcTokens { get; }

        public EnumFieldsWithNameResult(IntPtr phEnum, mdFieldDef[] rFields, int pcTokens)
        {
            this.phEnum = phEnum;
            this.rFields = rFields;
            this.pcTokens = pcTokens;
        }
    }
}