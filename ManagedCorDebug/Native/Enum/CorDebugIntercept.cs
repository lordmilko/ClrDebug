namespace ManagedCorDebug
{
    public enum CorDebugIntercept
    {
        INTERCEPT_NONE = 0,
        INTERCEPT_CLASS_INIT = 1,
        INTERCEPT_EXCEPTION_FILTER = 2,
        INTERCEPT_SECURITY = 4,
        INTERCEPT_CONTEXT_POLICY = 8,
        INTERCEPT_INTERCEPTION = 16, // 0x00000010
        INTERCEPT_ALL = 65535 // 0x0000FFFF
    }
}