﻿using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6E8041B9-CB1B-4071-B789-D8A871124B57")]
    [ComImport]
    public interface IDebugTargetComposition3 : IDebugTargetComposition2
    {
        /// <summary>
        /// Registers a given component by GUID such that an instance of the component can be created via Create[AndQuery]Component.<para/>
        /// In addition, registers the component as a conditional implementation of a given service as given by the conditional service information.<para/>
        /// The given component can either be created by its explicit component GUID or it can be created by a the service GUID and a description of the conditions.
        /// </summary>
        [PreserveSig]
        new HRESULT RegisterComponentAsConditionalService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
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
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
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
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component);
        
        [PreserveSig]
        new HRESULT CreateComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);
        
        [PreserveSig]
        new HRESULT CreateAndQueryComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object interfaceUnknown);

        /// <summary>
        /// Unregisters a given component by GUID such that instances of the component can no longer be created via Create[AndQuery]Component.
        /// </summary>
        [PreserveSig]
        new HRESULT UnregisterComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component);

        /// <summary>
        /// Registers a given component by GUID such that it acts as the standard means of aggregation for another service as identified by GUID.<para/>
        /// The given component must implement IDebugServiceAggregate.
        /// </summary>
        [PreserveSig]
        HRESULT RegisterComponentAsStandardAggregator(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid aggregatedServiceGuid);

        /// <summary>
        /// Finds the component registered as the standard implementation of an aggregator for a particular service and creates it.<para/>
        /// The returned component will implement IDebugServiceAggregate.
        /// </summary>
        [PreserveSig]
        HRESULT CreateServiceAggregatorComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);
    }
}
