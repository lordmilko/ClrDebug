using System;
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
        /// [out] A pointer to a ULONG32 that receives the size of the buffer required to contain the methods.
        /// </summary>
        public int pcMethod { get; }

        /// <summary>
        /// [out] A pointer to the buffer that receives the methods.
        /// </summary>
        public IntPtr pRetVal { get; }

        public GetMethodsInDocumentResult(int pcMethod, IntPtr pRetVal)
        {
            this.pcMethod = pcMethod;
            this.pRetVal = pRetVal;
        }
    }
}