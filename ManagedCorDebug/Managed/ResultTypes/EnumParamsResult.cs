using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumParams"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rParams = {rParams}")]
    public struct EnumParamsResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the ParamDef tokens.
        /// </summary>
        public mdParamDef[] rParams { get; }

        public EnumParamsResult(IntPtr phEnum, mdParamDef[] rParams)
        {
            this.phEnum = phEnum;
            this.rParams = rParams;
        }
    }
}