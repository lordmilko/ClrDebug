using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedWriter.GetDebugInfo"/> method.
    /// </summary>
    public struct GetDebugInfoResult
    {
        /// <summary>
        /// [in, out] A pointer to an IMAGE_DEBUG_DIRECTORY that the symbol writer will fill out.
        /// </summary>
        public IntPtr pIDD { get; }

        /// <summary>
        /// [out] A pointer to a DWORD that receives the size of the buffer required to contain the debug data.
        /// </summary>
        public int pcData { get; }

        /// <summary>
        /// [out] A pointer to a buffer that is large enough to hold the debug data for the symbol store.
        /// </summary>
        public byte[] data { get; }

        public GetDebugInfoResult(IntPtr pIDD, int pcData, byte[] data)
        {
            this.pIDD = pIDD;
            this.pcData = pcData;
            this.data = data;
        }
    }
}