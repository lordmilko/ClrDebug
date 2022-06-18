using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumFields"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rFields = {rFields}")]
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

        public EnumFieldsResult(IntPtr phEnum, mdFieldDef[] rFields)
        {
            this.phEnum = phEnum;
            this.rFields = rFields;
        }
    }
}