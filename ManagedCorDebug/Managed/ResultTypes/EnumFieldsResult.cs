using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumFields"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rFields = {rFields}, pcTokens = {pcTokens}")]
    public struct EnumFieldsResult
    {
        /// <summary>
        /// A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The list of FieldDef tokens.
        /// </summary>
        public mdFieldDef[] rFields { get; }

        /// <summary>
        /// The actual number of FieldDef tokens returned in rFields.
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