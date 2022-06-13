using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumTypeSpecs"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rTypeSpecs = {rTypeSpecs}, pcTypeSpecs = {pcTypeSpecs}")]
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

        /// <summary>
        /// The number of TypeSpec tokens returned in rTypeSpecs.
        /// </summary>
        public int pcTypeSpecs { get; }

        public EnumTypeSpecsResult(IntPtr phEnum, mdTypeSpec[] rTypeSpecs, int pcTypeSpecs)
        {
            this.phEnum = phEnum;
            this.rTypeSpecs = rTypeSpecs;
            this.pcTypeSpecs = pcTypeSpecs;
        }
    }
}