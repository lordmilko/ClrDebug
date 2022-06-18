using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumTypeSpecs"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rTypeSpecs = {rTypeSpecs}")]
    public struct EnumTypeSpecsResult
    {
        /// <summary>
        /// A pointer to the enumerator. This value must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the TypeSpec tokens.
        /// </summary>
        public mdTypeSpec[] rTypeSpecs { get; }

        public EnumTypeSpecsResult(IntPtr phEnum, mdTypeSpec[] rTypeSpecs)
        {
            this.phEnum = phEnum;
            this.rTypeSpecs = rTypeSpecs;
        }
    }
}