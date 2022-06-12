using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethodSpecs"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rMethodSpecs = {rMethodSpecs}, pcMethodSpecs = {pcMethodSpecs}")]
    public struct EnumMethodSpecsResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator for rMethodSpecs.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array of MethodSpec tokens to enumerate.
        /// </summary>
        public mdMethodSpec[] rMethodSpecs { get; }

        /// <summary>
        /// [out] The returned number of tokens placed in rMethodSpecs.
        /// </summary>
        public int pcMethodSpecs { get; }

        public EnumMethodSpecsResult(IntPtr phEnum, mdMethodSpec[] rMethodSpecs, int pcMethodSpecs)
        {
            this.phEnum = phEnum;
            this.rMethodSpecs = rMethodSpecs;
            this.pcMethodSpecs = pcMethodSpecs;
        }
    }
}