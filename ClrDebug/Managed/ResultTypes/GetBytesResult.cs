using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.GetBytes"/> method.
    /// </summary>
    [DebuggerDisplay("dataSize = {dataSize}, buffer = {buffer}")]
    public struct GetBytesResult
    {
        public int dataSize { get; }

        public byte[] buffer { get; }

        public GetBytesResult(int dataSize, byte[] buffer)
        {
            this.dataSize = dataSize;
            this.buffer = buffer;
        }
    }
}
