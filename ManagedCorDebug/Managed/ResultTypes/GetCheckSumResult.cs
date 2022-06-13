using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedDocument.GetCheckSum"/> method.
    /// </summary>
    [DebuggerDisplay("pcData = {pcData}, data = {data}")]
    public struct GetCheckSumResult
    {
        /// <summary>
        /// The size and length of the checksum, in bytes.
        /// </summary>
        public int pcData { get; }

        /// <summary>
        /// The buffer that receives the checksum.
        /// </summary>
        public byte[] data { get; }

        public GetCheckSumResult(int pcData, byte[] data)
        {
            this.pcData = pcData;
            this.data = data;
        }
    }
}