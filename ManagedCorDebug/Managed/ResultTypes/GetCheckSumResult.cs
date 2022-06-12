namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedDocument.GetCheckSum"/> method.
    /// </summary>
    public struct GetCheckSumResult
    {
        /// <summary>
        /// [out] The size and length of the checksum, in bytes.
        /// </summary>
        public int pcData { get; }

        /// <summary>
        /// [out] The buffer that receives the checksum.
        /// </summary>
        public byte[] data { get; }

        public GetCheckSumResult(int pcData, byte[] data)
        {
            this.pcData = pcData;
            this.data = data;
        }
    }
}