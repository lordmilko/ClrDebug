using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTarget.GetMetaData"/> method.
    /// </summary>
    [DebuggerDisplay("buffer = {buffer}, dataSize = {dataSize}")]
    public struct XCLRDataTarget_GetMetaDataResult
    {
        public IntPtr buffer { get; }

        public int dataSize { get; }

        public XCLRDataTarget_GetMetaDataResult(IntPtr buffer, int dataSize)
        {
            this.buffer = buffer;
            this.dataSize = dataSize;
        }
    }
}