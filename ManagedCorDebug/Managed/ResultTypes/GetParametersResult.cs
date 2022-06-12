using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedMethod.GetParameters"/> method.
    /// </summary>
    public struct GetParametersResult
    {
        /// <summary>
        /// [in] A pointer to a ULONG32 that receives the size of the buffer that is required to contain the parameters.
        /// </summary>
        public int pcParams { get; }

        /// <summary>
        /// [out] A pointer to the buffer that receives the parameters.
        /// </summary>
        public IntPtr @params { get; }

        public GetParametersResult(int pcParams, IntPtr @params)
        {
            this.pcParams = pcParams;
            this.@params = @params;
        }
    }
}