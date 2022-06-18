using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumFieldsWithName"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rFields = {rFields}")]
    public struct EnumFieldsWithNameResult
    {
        /// <summary>
        /// A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// Array used to store the FieldDef tokens.
        /// </summary>
        public mdFieldDef[] rFields { get; }

        public EnumFieldsWithNameResult(IntPtr phEnum, mdFieldDef[] rFields)
        {
            this.phEnum = phEnum;
            this.rFields = rFields;
        }
    }
}