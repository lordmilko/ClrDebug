using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.GetBytes"/> method.
    /// </summary>
    [DebuggerDisplay("dataSize = {dataSize}, buffer = {buffer.ToString(),nq}")]
    public struct GetBytesResult
    {
        public int dataSize { get; }

        public IntPtr buffer { get; }

        public GetBytesResult(int dataSize, IntPtr buffer)
        {
            this.dataSize = dataSize;
            this.buffer = buffer;
        }
    }
}