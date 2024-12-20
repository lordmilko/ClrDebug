using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E453C59B-ED09-4c25-B155-C70158CE5837")]
    [ComImport]
    public interface IDebugTargetCompositionBridge4 : IDebugTargetCompositionBridge3
    {
        [PreserveSig]
        new HRESULT CreateStaticView(
            [In] int systemId,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer pInitialServices,
            [Out] out int newSystemId);

        [PreserveSig]
        new HRESULT CreateFileView(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer pInitialServices,
            [Out] out int newSystemId);

        [PreserveSig]
        new HRESULT GetCompositionManager(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugTargetComposition ppCompositionManager);

        [PreserveSig]
        new HRESULT GetServiceManager(
            [In] int systemId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager ppServiceManager);

        [PreserveSig]
        new HRESULT RegisterFileActivatorForExtension(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileExtension,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionFileActivator pFileActivator);

        /// <summary>
        /// Unregisters a file activator from a particular extension.
        /// </summary>
        [PreserveSig]
        new HRESULT UnregisterFileActivatorForExtension(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileExtension,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionFileActivator pFileActivator);

        [PreserveSig]
        new HRESULT RegisterProtocolActivatorForProtocolString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszProtocolName,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionProtocolActivator pProtocolActivator);

        [PreserveSig]
        new HRESULT UnregisterProtocolActivatorForProtocolString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszProtocolName,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionProtocolActivator pProtocolActivator);

        [PreserveSig]
        new HRESULT ReparseActivation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager);

        /// <summary>
        /// This method may *ONLY* be called during the ::InitializeServices call for a given activator *AFTER* performing some modification of the service container; it causes the debugger to walk through the activation path for the given service container once again.<para/>
        /// This allows, for instance, a plug-in which presents some transformation on a file (e.g.: allowing for dynamic decryption of dump files, for instance).<para/>
        /// Typically, an activator which uses this will stack a plug-in modifying the file source and call ReparseActivation.<para/>
        /// Note that calling without making those changes may result in infinite recursion. As it is entirely possible to have files which require multiple phases of transcode through the same plug-in, nothing prevents a call to the same activator.<para/>
        /// Note that calls to ReparseActivation2 *MUST* be the last thing in the ::InitializeServices call. The service manager which is passed to this method may not be used after a return.<para/>
        /// If a reparse completion callback interface (and data) is passed to this method, it will be made after the reparse has completed *AND* the service container has added requisite services.<para/>
        /// These callbacks will be made in reverse nested order (innermost reparse to outermost) and may legally modify the service container by injecting new services (or stacking on top of existing ones).<para/>
        /// It is important to note that the service manager passed to the callback may or may not be the same as 'pServiceManager' depending on the implementation of the reparse.
        /// </summary>
        [PreserveSig]
        HRESULT ReparseActivation2(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionBridgeReparseCompletion pCallback,
            [In] IntPtr pData);
    }
}
