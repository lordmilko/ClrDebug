using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6D4E5F39-657E-4905-9670-448978F7FB27")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugTargetComposition
    {
        /// <summary>
        /// Creates a service manager.
        /// </summary>
        [PreserveSig]
        HRESULT CreateServiceManager(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager serviceManager);

        /// <summary>
        /// Registers a given component by GUID such that an instance of the component can be created via Create[AndQuery]Component.
        /// </summary>
        [PreserveSig]
        HRESULT RegisterComponent(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component);
        
        [PreserveSig]
        HRESULT CreateComponent(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid componentGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);
        
        [PreserveSig]
        HRESULT CreateAndQueryComponent(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid componentGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object interfaceUnknown);

        /// <summary>
        /// Unregisters a given component by GUID such that instances of the component can no longer be created via Create[AndQuery]Component.
        /// </summary>
        [PreserveSig]
        HRESULT UnregisterComponent(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component);
    }
}
