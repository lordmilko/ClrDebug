using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedWriter.GetDebugInfoWithPadding"/> method.
    /// </summary>
    [DebuggerDisplay("pIDD = {pIDD}, pcData = {pcData}, data = {data}")]
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