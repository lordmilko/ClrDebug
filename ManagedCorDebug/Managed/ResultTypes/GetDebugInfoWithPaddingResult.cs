using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedWriter.GetDebugInfoWithPadding"/> method.
    /// </summary>
    public struct GetDebugInfoWithPaddingResult
    {
        public IntPtr pIDD { get; }

        public int pcData { get; }

        public byte[] data { get; }

        public GetDebugInfoWithPaddingResult(IntPtr pIDD, int pcData, byte[] data)
        {
            this.pIDD = pIDD;
            this.pcData = pcData;
            this.data = data;
        }
    }
}