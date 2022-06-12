using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRDataTarget.ReadVirtual"/> method.
    /// </summary>
    [DebuggerDisplay("buffer = {buffer}, bytesRead = {bytesRead}")]
    public struct ReadVirtualResult
    {
        /// <summary>
        /// [out] A pointer to a buffer that receives the data.
        /// </summary>
        public byte buffer { get; }

        /// <summary>
        /// [out] A pointer to the number of bytes returned.
        /// </summary>
        public int bytesRead { get; }

        public ReadVirtualResult(byte buffer, int bytesRead)
        {
            this.buffer = buffer;
            this.bytesRead = bytesRead;
        }
    }
}