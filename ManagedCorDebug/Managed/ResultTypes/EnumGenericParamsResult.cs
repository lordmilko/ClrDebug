using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumGenericParams"/> method.
    /// </summary>
    public struct EnumGenericParamsResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array of generic parameters to enumerate.
        /// </summary>
        public mdGenericParam[] rGenericParams { get; }

        /// <summary>
        /// [out] The returned number of tokens placed in rGenericParams.
        /// </summary>
        public int pcGenericParams { get; }

        public EnumGenericParamsResult(IntPtr phEnum, mdGenericParam[] rGenericParams, int pcGenericParams)
        {
            this.phEnum = phEnum;
            this.rGenericParams = rGenericParams;
            this.pcGenericParams = pcGenericParams;
        }
    }
}