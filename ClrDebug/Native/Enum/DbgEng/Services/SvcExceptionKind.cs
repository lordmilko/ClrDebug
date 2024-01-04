namespace ClrDebug.DbgEng
{
    public enum SvcExceptionKind : uint
    {
        SvcException,
        SvcExceptionWin32,
        SvcExceptionLinuxSignal,
        SvcExceptionLinuxKernelPanic,
        SvcExceptionWindowsBugCheck
    }
}
