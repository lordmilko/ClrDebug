namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.GetSymAttributePreRemap"/> method.
    /// </summary>
    public struct GetSymAttributePreRemapResult
    {
        /// <summary>
        /// [out] A pointer to a ULONG32 that receives the size of the buffer required to contain the attribute bytes.
        /// </summary>
        public int pcBuffer { get; }

        /// <summary>
        /// [out] A pointer to the buffer that receives the attribute bytes.
        /// </summary>
        public byte[] buffer { get; }

        public GetSymAttributePreRemapResult(int pcBuffer, byte[] buffer)
        {
            this.pcBuffer = pcBuffer;
            this.buffer = buffer;
        }
    }
}