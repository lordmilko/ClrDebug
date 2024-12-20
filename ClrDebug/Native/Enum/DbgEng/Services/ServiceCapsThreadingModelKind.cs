namespace ClrDebug.DbgEng
{
    public enum ServiceCapsThreadingModelKind : uint
    {
        /// <summary>
        /// ServiceCapsThreadingModelNone Indicates that, unless otherwise specified as part of a service contract, the given service has no particular threading model.<para/>
        /// This means that it may only be accessed by a single thread at a time. This is the default value for any service which does not explicitly state otherwise via support of this capability and return of another value.
        /// </summary>
        ServiceCapsThreadingModelNone = 0,

        /// <summary>
        /// ServiceCapsThreadingModelFree Indicates that access to the service is free threaded. This means that calls on the service interfaces may happen on arbitrary and multiple threads.<para/>
        /// Any required synchronization is provided by the service. This also means that calls on objects returned from the service interfaces may happen on arbitrary and multiple threads.<para/>
        /// Those objects provide any required synchronization. Note that this *DOES NOT* imply a threading model on IDebugServiceLayer*.
        /// </summary>
        ServiceCapsThreadingModelFree
    }
}
