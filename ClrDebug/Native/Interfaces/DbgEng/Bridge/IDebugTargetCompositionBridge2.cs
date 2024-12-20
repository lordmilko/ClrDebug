using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("DEA2739F-401E-4ab6-BC62-2A85453F8C52")]
    [ComImport]
    public interface IDebugTargetCompositionBridge2 : IDebugTargetCompositionBridge
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

        /// <summary>
        /// Registers a protocol activator for a particular protocol string. Whenever a protocol is opened from the debugger, the activator will be called to ensure the protocol string is valid and then subsequently to fill in the requisite services in order to establish debuggability on top of the file.<para/>
        /// Note that multiple activators can be registered on a protocol. Only one of the activators is allowed to indicate that the protocol matches their criteria for handling that type of protocol.
        /// </summary>
        [PreserveSig]
        HRESULT RegisterProtocolActivatorForProtocolString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszProtocolName,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionProtocolActivator pProtocolActivator);

        /// <summary>
        /// Unregisters a protocol activator from a particular protocol string.
        /// </summary>
        [PreserveSig]
        HRESULT UnregisterProtocolActivatorForProtocolString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszProtocolName,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionProtocolActivator pProtocolActivator);
    }
}
