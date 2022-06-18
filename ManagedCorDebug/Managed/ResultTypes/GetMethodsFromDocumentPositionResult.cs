using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.GetMethodsFromDocumentPosition"/> method.
    /// </summary>
    [DebuggerDisplay("pcMethod = {pcMethod}, pRetVal = {pRetVal}")]
    public struct GetMethodsFromDocumentPositionResult
    {
        /// <summary>
        /// A pointer to a variable that receives the number of elements returned in the pRetVal array.
        /// </summary>
        public int pcMethod { get; }

        /// <summary>
        /// An array of pointers, each of which points to an <see cref="ISymUnmanagedMethod"/> object that represents a method containing the breakpoint.
        /// </summary>
        public ISymUnmanagedMethod[] pRetVal { get; }

        public GetMethodsFromDocumentPositionResult(int pcMethod, ISymUnmanagedMethod[] pRetVal)
        {
            this.pcMethod = pcMethod;
            this.pRetVal = pRetVal;
        }
    }
}