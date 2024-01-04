namespace ClrDebug.DbgEng
{
    public enum SvcStackUnwindFlags : uint
    {
        StackUnwindUnknownReturn = 0x00000001,
        StackUnwindArchitectureSpecified = 0x00000002,
        StackUnwindParametersSpecified = 0x00000004,
        StackUnwindTailCallReturn = 0x00000008,
        StackUnwindSkippedFrames = 0x00000010,
        StackUnwindFromExceptionOrSignalFrame = 0x00000020
    }
}
