using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// A service which offers the ability to aggregate other services implements this interface. Typically, this is used in one of two scenarios
    /// 1) Enumerators which provide the capability to enumerate from multiple sources -- each an independent service.<para/>
    /// An aggregate service will "merge" all of the enumerators and direct calls to Find* to the appropriate service.
    ///
    /// 2) ...
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6041DBC4-5BDA-4581-9BF4-0A6F74A643D4")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugServiceAggregate
    {
        /// <summary>
        /// Adds a new service to the aggregate.
        /// </summary>
        [PreserveSig]
        HRESULT AggregateService(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer childService);

        /// <summary>
        /// Removes a service from the aggregate.
        /// </summary>
        [PreserveSig]
        HRESULT DeaggregateService(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer childService);
    }
}
