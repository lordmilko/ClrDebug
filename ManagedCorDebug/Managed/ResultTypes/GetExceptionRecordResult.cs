namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRDataTarget.GetExceptionRecord"/> method.
    /// </summary>
    public struct GetExceptionRecordResult
    {
        /// <summary>
        /// [out] A pointer to a ULONG32 type that receives the number of bytes actually written to the buffer.
        /// </summary>
        public int bufferUsed { get; }

        /// <summary>
        /// [out] A pointer to a memory buffer that receives a copy of the exception record. The exception record is returned as a MINIDUMP_EXCEPTION type.
        /// </summary>
        public byte buffer { get; }

        public GetExceptionRecordResult(int bufferUsed, byte buffer)
        {
            this.bufferUsed = bufferUsed;
            this.buffer = buffer;
        }
    }
}