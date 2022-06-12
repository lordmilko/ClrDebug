using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.GetGlobalVariables"/> method.
    /// </summary>
    [DebuggerDisplay("pcVars = {pcVars}, pVars = {pVars}")]
    public struct GetGlobalVariablesResult
    {
        /// <summary>
        /// [out] A pointer to a ULONG32 that receives the size of the buffer required to contain the variables.
        /// </summary>
        public int pcVars { get; }

        /// <summary>
        /// [out] A buffer that contains the variables.
        /// </summary>
        public IntPtr pVars { get; }

        public GetGlobalVariablesResult(int pcVars, IntPtr pVars)
        {
            this.pcVars = pcVars;
            this.pVars = pVars;
        }
    }
}