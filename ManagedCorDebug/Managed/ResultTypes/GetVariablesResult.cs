using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.GetVariables"/> method.
    /// </summary>
    [DebuggerDisplay("pcVars = {pcVars}, pVars = {pVars}")]
    public struct GetVariablesResult
    {
        /// <summary>
        /// A pointer to the variable that receives the number of variables returned in pVars.
        /// </summary>
        public int pcVars { get; }

        /// <summary>
        /// A pointer to the variable that receives the variables.
        /// </summary>
        public ISymUnmanagedVariable[] pVars { get; }

        public GetVariablesResult(int pcVars, ISymUnmanagedVariable[] pVars)
        {
            this.pcVars = pcVars;
            this.pVars = pVars;
        }
    }
}