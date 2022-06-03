namespace ManagedCorDebug
{
    public enum CorGCReferenceType
    {
        CorReferenceStack = -2147483647,
        CorHandleStrong = 1,
        CorHandleStrongPinning = 2,
        CorHandleWeakShort = 4,
        CorHandleWeakLong = 8,
        CorHandleWeakRefCount = 16,
        CorHandleStrongRefCount = 32,
        CorHandleStrongDependent = 64,
        CorHandleStrongAsyncPinned = 128,
        CorHandleStrongSizedByref = 256,
        CorHandleStrongOnly = 483,
        CorHandleWeakWinRT = 512,
        CorHandleWeakOnly = 540,
        CorReferenceFinalizer = 80000002,
        CorHandleAll = 2147483647
    }
}