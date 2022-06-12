using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumGenericParamConstraints"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rGenericParamConstraints = {rGenericParamConstraints}, pcGenericParamConstraints = {pcGenericParamConstraints}")]
    public struct EnumGenericParamConstraintsResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array of generic parameter constraints to enumerate.
        /// </summary>
        public mdGenericParamConstraint[] rGenericParamConstraints { get; }

        /// <summary>
        /// [out] A pointer to the number of tokens placed in rGenericParamConstraints.
        /// </summary>
        public int pcGenericParamConstraints { get; }

        public EnumGenericParamConstraintsResult(IntPtr phEnum, mdGenericParamConstraint[] rGenericParamConstraints, int pcGenericParamConstraints)
        {
            this.phEnum = phEnum;
            this.rGenericParamConstraints = rGenericParamConstraints;
            this.pcGenericParamConstraints = pcGenericParamConstraints;
        }
    }
}