using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugCode.GetCode"/> method.
    /// </summary>
    [DebuggerDisplay("buffer = {buffer}, pcBufferSize = {pcBufferSize}")]
    public struct GetCodeResult
    {
        /// <summary>
        /// The array into which the code will be returned.
        /// </summary>
        public byte[] buffer { get; }

        /// <summary>
        /// The number of bytes returned.
        /// </summary>
        public int pcBufferSize { get; }

        public GetCodeResult(byte[] buffer, int pcBufferSize)
        {
            this.buffer = buffer;
            this.pcBufferSize = pcBufferSize;
        }
    }
}