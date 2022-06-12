using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugVirtualUnwinder.GetContext"/> method.
    /// </summary>
    [DebuggerDisplay("contextSize = {contextSize}, contextBuf = {contextBuf}")]
    public struct GetContextResult
    {
        /// <summary>
        /// [out] A pointer to the number of bytes actually written to contextBuf.
        /// </summary>
        public int contextSize { get; }

        /// <summary>
        /// [out] A byte array that contains the current context of this unwinder.
        /// </summary>
        public byte contextBuf { get; }

        public GetContextResult(int contextSize, byte contextBuf)
        {
            this.contextSize = contextSize;
            this.contextBuf = contextBuf;
        }
    }
}