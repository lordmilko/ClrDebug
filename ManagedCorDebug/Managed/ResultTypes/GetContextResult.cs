using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTask.GetContext"/> method.
    /// </summary>
    [DebuggerDisplay("contextSize = {contextSize}, contextBuf = {contextBuf}")]
    public struct GetContextResult
    {
        public int contextSize { get; }

        public IntPtr contextBuf { get; }

        public GetContextResult(int contextSize, IntPtr contextBuf)
        {
            this.contextSize = contextSize;
            this.contextBuf = contextBuf;
        }
    }
}