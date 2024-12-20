using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E7E438BB-E771-457a-96C9-1C58482C9174")]
    [ComImport]
    public interface IDebugTargetCompositionBridge
    {
        /// <summary>
        /// Creates a new target which is a static view of an existing target.
        /// </summary>
        [PreserveSig]
        HRESULT CreateStaticView(
            [In] int systemId,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer pInitialServices,
            [Out] out int newSystemId);

        /// <summary>
        /// Creates a new target on top of a particular file.
        /// </summary>
        [PreserveSig]
        HRESULT CreateFileView(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer pInitialServices,
            [Out] out int newSystemId);

        /// <summary>
        /// Gets the composition manager that the debugger engine created.
        /// </summary>
        [PreserveSig]
        HRESULT GetCompositionManager(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugTargetComposition ppCompositionManager);

        /// <summary>
        /// Gets the service manager for a particular target as given by its system id.
        /// </summary>
        [PreserveSig]
        HRESULT GetServiceManager(
            [In] int systemId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager ppServiceManager);

        /// <summary>
        /// Registers a file activator for a particular extension. Whenever a file with this extension is opened from the debugger, the activator will be called to ensure the file is valid and then subsequently to fill in the requisite services in order to establish debuggability on top of the file.<para/>
        /// Note that multiple activators can be registered on an extension. Only one of the activators is allowed to indicate that the file matches their criteria for handling that type of file.
        /// </summary>
        [PreserveSig]
        HRESULT RegisterFileActivatorForExtension(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileExtension,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionFileActivator pFileActivator);

        /// <summary>
        /// Unregisters a file activator from a particular extension.
        /// </summary>
        [PreserveSig]
        HRESULT UnregisterFileActivatorForExtension(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileExtension,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionFileActivator pFileActivator);
    }
}
