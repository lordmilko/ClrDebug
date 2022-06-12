namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.GetSymAttribute"/> method.
    /// </summary>
    public struct GetSymAttributeResult
    {
        /// <summary>
        /// [out] A pointer to the variable that receives the length of the attribute data.
        /// </summary>
        public int pcBuffer { get; }

        /// <summary>
        /// [out] A pointer to the variable that receives the attribute data.
        /// </summary>
        public byte[] buffer { get; }

        public GetSymAttributeResult(int pcBuffer, byte[] buffer)
        {
            this.pcBuffer = pcBuffer;
            this.buffer = buffer;
        }
    }
}