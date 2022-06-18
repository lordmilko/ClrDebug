using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethodSpecs"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rMethodSpecs = {rMethodSpecs}")]
    public struct EnumMethodSpecsResult
    {
        /// <summary>
        /// A pointer to the enumerator for rMethodSpecs.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array of MethodSpec tokens to enumerate.
        /// </summary>
        public mdMethodSpec[] rMethodSpecs { get; }

        public EnumMethodSpecsResult(IntPtr phEnum, mdMethodSpec[] rMethodSpecs)
        {
            this.phEnum = phEnum;
            this.rMethodSpecs = rMethodSpecs;
        }
    }
}