using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRDataTarget.GetExceptionRecord"/> method.
    /// </summary>
    [DebuggerDisplay("bufferUsed = {bufferUsed}, buffer = {buffer}")]
    public struct GetExceptionRecordResult
    {
        /// <summary>
        /// A pointer to a ULONG32 type that receives the number of bytes actually written to the buffer.
        /// </summary>
        public int bufferUsed { get; }

        /// <summary>
        /// A pointer to a memory buffer that receives a copy of the exception record. The exception record is returned as a MINIDUMP_EXCEPTION type.
        /// </summary>
        public byte buffer { get; }

        public GetExceptionRecordResult(int bufferUsed, byte buffer)
        {
            this.bufferUsed = bufferUsed;
            this.buffer = buffer;
        }
    }
}