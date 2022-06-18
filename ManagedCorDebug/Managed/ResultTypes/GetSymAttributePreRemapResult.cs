using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.GetSymAttributePreRemap"/> method.
    /// </summary>
    [DebuggerDisplay("pcBuffer = {pcBuffer}, buffer = {buffer}")]
    public struct GetSymAttributePreRemapResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that receives the size of the buffer required to contain the attribute bytes.
        /// </summary>
        public int pcBuffer { get; }

        /// <summary>
        /// A pointer to the buffer that receives the attribute bytes.
        /// </summary>
        public IntPtr buffer { get; }

        public GetSymAttributePreRemapResult(int pcBuffer, IntPtr buffer)
        {
            this.pcBuffer = pcBuffer;
            this.buffer = buffer;
        }
    }
}