using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.GetVariables"/> method.
    /// </summary>
    public struct GetVariablesResult
    {
        /// <summary>
        /// [out] A pointer to the variable that receives the number of variables returned in pVars.
        /// </summary>
        public int pcVars { get; }

        /// <summary>
        /// [out] A pointer to the variable that receives the variables.
        /// </summary>
        public IntPtr pVars { get; }

        public GetVariablesResult(int pcVars, IntPtr pVars)
        {
            this.pcVars = pcVars;
            this.pVars = pVars;
        }
    }
}