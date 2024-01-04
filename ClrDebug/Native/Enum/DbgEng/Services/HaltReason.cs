namespace ClrDebug.DbgEng
{
    public enum HaltReason : uint
    {
        HaltUnknown,
        HaltRequested,
        HaltStepComplete,
        HaltBreakpoint,
        HaltException,
        HaltProcessExit
    }
}
