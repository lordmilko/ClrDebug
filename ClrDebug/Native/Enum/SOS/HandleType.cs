namespace ClrDebug
{
    public enum HandleType
    {
        HNDTYPE_WEAK_SHORT = 0,

        HNDTYPE_WEAK_LONG = 1,
        HNDTYPE_WEAK_DEFAULT = 1,

        HNDTYPE_STRONG = 2,
        HNDTYPE_DEFAULT = 2,

        HNDTYPE_PINNED = 3,
        HNDTYPE_VARIABLE = 4,
        HNDTYPE_REFCOUNTED = 5,
        HNDTYPE_DEPENDENT = 6,
        HNDTYPE_ASYNCPINNED = 7,
        HNDTYPE_SIZEDREF = 8,
        HNDTYPE_WEAK_NATIVE_COM = 9
    }
}
