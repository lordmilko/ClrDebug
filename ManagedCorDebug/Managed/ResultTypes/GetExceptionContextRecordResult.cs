namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRDataTarget.GetExceptionContextRecord"/> method.
    /// </summary>
    public struct GetExceptionContextRecordResult
    {
        /// <summary>
        /// [out] A pointer to a ULONG32 type that receives the number of bytes actually written to the buffer.
        /// </summary>
        public int bufferUsed { get; }

        /// <summary>
        /// [out] A pointer to a memory buffer that receives a copy of the context record. The exception record is returned as a CONTEXT type.
        /// </summary>
        public byte buffer { get; }

        public GetExceptionContextRecordResult(int bufferUsed, byte buffer)
        {
            this.bufferUsed = bufferUsed;
            this.buffer = buffer;
        }
    }
}