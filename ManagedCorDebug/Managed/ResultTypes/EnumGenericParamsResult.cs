using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumGenericParams"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rGenericParams = {rGenericParams}")]
    public struct EnumGenericParamsResult
    {
        /// <summary>
        /// A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array of generic parameters to enumerate.
        /// </summary>
        public mdGenericParam[] rGenericParams { get; }

        public EnumGenericParamsResult(IntPtr phEnum, mdGenericParam[] rGenericParams)
        {
            this.phEnum = phEnum;
            this.rGenericParams = rGenericParams;
        }
    }
}