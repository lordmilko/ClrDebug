namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugCode.GetCode"/> method.
    /// </summary>
    public struct GetCodeResult
    {
        /// <summary>
        /// [out] The array into which the code will be returned.
        /// </summary>
        public byte[] buffer { get; }

        /// <summary>
        /// [out] The number of bytes returned.
        /// </summary>
        public int pcBufferSize { get; }

        public GetCodeResult(byte[] buffer, int pcBufferSize)
        {
            this.buffer = buffer;
            this.pcBufferSize = pcBufferSize;
        }
    }
}