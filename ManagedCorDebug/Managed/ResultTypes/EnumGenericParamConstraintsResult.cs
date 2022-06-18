using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumGenericParamConstraints"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rGenericParamConstraints = {rGenericParamConstraints}")]
    public struct EnumGenericParamConstraintsResult
    {
        /// <summary>
        /// A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array of generic parameter constraints to enumerate.
        /// </summary>
        public mdGenericParamConstraint[] rGenericParamConstraints { get; }

        public EnumGenericParamConstraintsResult(IntPtr phEnum, mdGenericParamConstraint[] rGenericParamConstraints)
        {
            this.phEnum = phEnum;
            this.rGenericParamConstraints = rGenericParamConstraints;
        }
    }
}