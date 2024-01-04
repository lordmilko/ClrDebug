using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6041DBC4-5BDA-4581-9BF4-0A6F74A643D4")]
    [ComImport]
    public interface IDebugServiceAggregate
    {
        [PreserveSig]
        HRESULT AggregateService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer childService);
        
        [PreserveSig]
        HRESULT DeaggregateService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer childService);
    }
}
