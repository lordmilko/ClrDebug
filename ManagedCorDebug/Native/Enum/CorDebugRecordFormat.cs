namespace ManagedCorDebug
{
    /// <summary>
    /// Describes the format of the data in a byte array that contains information about a native exception debug event.
    /// </summary>
    /// <remarks>
    /// A member of the CorDebugRecordFormat enumeration is passed to the <see cref="ICorDebugProcess6.DecodeEvent"/> method
    /// to indicate the format of the byte array in its pRecord argument.
    /// </remarks>
    public enum CorDebugRecordFormat
    {
        /// <summary>
        /// The data is a 32-bit Windows exception record.
        /// </summary>
        FORMAT_WINDOWS_EXCEPTIONRECORD32 = 1,

        /// <summary>
        /// The data is a 64-bit Windows exception record.
        /// </summary>
        FORMAT_WINDOWS_EXCEPTIONRECORD64 = 2
    }
}