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
        /// A pointer to a ULONG32 that receives the size of the buffer required to contain the variables.
        /// </summary>
        public int pcVars { get; }

        /// <summary>
        /// A buffer that contains the variables.
        /// </summary>
        public ISymUnmanagedVariable[] pVars { get; }

        public GetGlobalVariablesResult(int pcVars, ISymUnmanagedVariable[] pVars)
        {
            this.pcVars = pcVars;
            this.pVars = pVars;
        }
    }
}