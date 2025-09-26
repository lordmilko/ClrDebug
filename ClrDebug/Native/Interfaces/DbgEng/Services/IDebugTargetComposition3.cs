using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6E8041B9-CB1B-4071-B789-D8A871124B57")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugTargetComposition3 : IDebugTargetComposition2
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Registers a given component by GUID such that an instance of the component can be created via Create[AndQuery]Component.<para/>
        /// In addition, registers the component as a conditional implementation of a given service as given by the conditional service information.<para/>
        /// The given component can either be created by its explicit component GUID or it can be created by a the service GUID and a description of the conditions.
        /// </summary>
        [PreserveSig]
        new HRESULT RegisterComponentAsConditionalService(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component,
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo);

        /// <summary>
        /// Finds the component registered as the implementation of a particular service for a particular set of conditions and creates it.
        /// </summary>
        [PreserveSig]
        new HRESULT CreateConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);
        
        [PreserveSig]
        new HRESULT CreateAndQueryConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object interfaceUnknown);

        /// <summary>
        /// Creates a service manager.
        /// </summary>
        [PreserveSig]
        new HRESULT CreateServiceManager(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager serviceManager);

        /// <summary>
        /// Registers a given component by GUID such that an instance of the component can be created via Create[AndQuery]Component.
        /// </summary>
        [PreserveSig]
        new HRESULT RegisterComponent(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component);
        
        [PreserveSig]
        new HRESULT CreateComponent(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid componentGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);
        
        [PreserveSig]
        new HRESULT CreateAndQueryComponent(
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
        new HRESULT UnregisterComponent(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component);
#endif

        /// <summary>
        /// Registers a given component by GUID such that it acts as the standard means of aggregation for another service as identified by GUID.<para/>
        /// The given component must implement IDebugServiceAggregate.
        /// </summary>
        [PreserveSig]
        HRESULT RegisterComponentAsStandardAggregator(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid aggregatedServiceGuid);

        /// <summary>
        /// Finds the component registered as the standard implementation of an aggregator for a particular service and creates it.<para/>
        /// The returned component will implement IDebugServiceAggregate.
        /// </summary>
        [PreserveSig]
        HRESULT CreateServiceAggregatorComponent(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid serviceGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);
    }
}
