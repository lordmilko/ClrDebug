namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the kind of exceptional event.
    /// </summary>
    public enum SvcExceptionKind : uint
    {
        /// <summary>
        /// Unknown exception type.
        /// </summary>
        SvcException,

        /// <summary>
        /// Exception is a Win32 exception. Canonical data representation (optionally provided) is an EXCEPTION_RECORD64.
        /// </summary>
        SvcExceptionWin32,

        /// <summary>
        /// Exception is a Linux signal. ISvcLinuxSignalInformation is supported. Canonical data representation (optionally provided) is a 64-bit siginfo_t.
        /// </summary>
        SvcExceptionLinuxSignal,

        /// <summary>
        /// Exception is a Linux kernel panic.
        /// </summary>
        SvcExceptionLinuxKernelPanic,

        /// <summary>
        /// Exception is a Windows kernel bugcheck. ISvcWindowsBugCheckInformation is supported.
        /// </summary>
        SvcExceptionWindowsBugCheck
    }
}
