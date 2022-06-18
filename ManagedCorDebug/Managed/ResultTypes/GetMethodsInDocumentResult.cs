using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.GetMethodsInDocument"/> method.
    /// </summary>
    [DebuggerDisplay("pcMethod = {pcMethod}, pRetVal = {pRetVal}")]
    public struct GetMethodsInDocumentResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that receives the size of the buffer required to contain the methods.
        /// </summary>
        public int pcMethod { get; }

        /// <summary>
        /// A pointer to the buffer that receives the methods.
        /// </summary>
        public ISymUnmanagedMethod[] pRetVal { get; }

        public GetMethodsInDocumentResult(int pcMethod, ISymUnmanagedMethod[] pRetVal)
        {
            this.pcMethod = pcMethod;
            this.pRetVal = pRetVal;
        }
    }
}