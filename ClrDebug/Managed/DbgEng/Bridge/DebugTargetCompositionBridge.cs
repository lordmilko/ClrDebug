using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class DebugTargetCompositionBridge : ComObject<IDebugTargetCompositionBridge>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugTargetCompositionBridge"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugTargetCompositionBridge(IDebugTargetCompositionBridge raw) : base(raw)
        {
        }

        #region IDebugTargetCompositionBridge
        #region CompositionManager

        /// <summary>
        /// Gets the composition manager that the debugger engine created.
        /// </summary>
        public DebugTargetComposition CompositionManager
        {
            get
            {
                DebugTargetComposition ppCompositionManagerResult;
                TryGetCompositionManager(out ppCompositionManagerResult).ThrowDbgEngNotOK();

                return ppCompositionManagerResult;
            }
        }

        /// <summary>
        /// Gets the composition manager that the debugger engine created.
        /// </summary>
        public HRESULT TryGetCompositionManager(out DebugTargetComposition ppCompositionManagerResult)
        {
            /*HRESULT GetCompositionManager(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugTargetComposition ppCompositionManager);*/
            IDebugTargetComposition ppCompositionManager;
            HRESULT hr = Raw.GetCompositionManager(out ppCompositionManager);

            if (hr == HRESULT.S_OK)
                ppCompositionManagerResult = ppCompositionManager == null ? null : new DebugTargetComposition(ppCompositionManager);
            else
                ppCompositionManagerResult = default(DebugTargetComposition);

            return hr;
        }

        #endregion
        #region CreateStaticView

        /// <summary>
        /// Creates a new target which is a static view of an existing target.
        /// </summary>
        public int CreateStaticView(int systemId, IDebugServiceLayer pInitialServices)
        {
            int newSystemId;
            TryCreateStaticView(systemId, pInitialServices, out newSystemId).ThrowDbgEngNotOK();

            return newSystemId;
        }

        /// <summary>
        /// Creates a new target which is a static view of an existing target.
        /// </summary>
        public HRESULT TryCreateStaticView(int systemId, IDebugServiceLayer pInitialServices, out int newSystemId)
        {
            /*HRESULT CreateStaticView(
            [In] int systemId,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer pInitialServices,
            [Out] out int newSystemId);*/
            return Raw.CreateStaticView(systemId, pInitialServices, out newSystemId);
        }

        #endregion
        #region CreateFileView

        /// <summary>
        /// Creates a new target on top of a particular file.
        /// </summary>
        public int CreateFileView(string fileName, IDebugServiceLayer pInitialServices)
        {
            int newSystemId;
            TryCreateFileView(fileName, pInitialServices, out newSystemId).ThrowDbgEngNotOK();

            return newSystemId;
        }

        /// <summary>
        /// Creates a new target on top of a particular file.
        /// </summary>
        public HRESULT TryCreateFileView(string fileName, IDebugServiceLayer pInitialServices, out int newSystemId)
        {
            /*HRESULT CreateFileView(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer pInitialServices,
            [Out] out int newSystemId);*/
            return Raw.CreateFileView(fileName, pInitialServices, out newSystemId);
        }

        #endregion
        #region GetServiceManager

        /// <summary>
        /// Gets the service manager for a particular target as given by its system id.
        /// </summary>
        public DebugServiceManager GetServiceManager(int systemId)
        {
            DebugServiceManager ppServiceManagerResult;
            TryGetServiceManager(systemId, out ppServiceManagerResult).ThrowDbgEngNotOK();

            return ppServiceManagerResult;
        }

        /// <summary>
        /// Gets the service manager for a particular target as given by its system id.
        /// </summary>
        public HRESULT TryGetServiceManager(int systemId, out DebugServiceManager ppServiceManagerResult)
        {
            /*HRESULT GetServiceManager(
            [In] int systemId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager ppServiceManager);*/
            IDebugServiceManager ppServiceManager;
            HRESULT hr = Raw.GetServiceManager(systemId, out ppServiceManager);

            if (hr == HRESULT.S_OK)
                ppServiceManagerResult = ppServiceManager == null ? null : new DebugServiceManager(ppServiceManager);
            else
                ppServiceManagerResult = default(DebugServiceManager);

            return hr;
        }

        #endregion
        #region RegisterFileActivatorForExtension

        /// <summary>
        /// Registers a file activator for a particular extension. Whenever a file with this extension is opened from the debugger, the activator will be called to ensure the file is valid and then subsequently to fill in the requisite services in order to establish debuggability on top of the file.<para/>
        /// Note that multiple activators can be registered on an extension. Only one of the activators is allowed to indicate that the file matches their criteria for handling that type of file.
        /// </summary>
        public void RegisterFileActivatorForExtension(string pwszFileExtension, IDebugTargetCompositionFileActivator pFileActivator)
        {
            TryRegisterFileActivatorForExtension(pwszFileExtension, pFileActivator).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Registers a file activator for a particular extension. Whenever a file with this extension is opened from the debugger, the activator will be called to ensure the file is valid and then subsequently to fill in the requisite services in order to establish debuggability on top of the file.<para/>
        /// Note that multiple activators can be registered on an extension. Only one of the activators is allowed to indicate that the file matches their criteria for handling that type of file.
        /// </summary>
        public HRESULT TryRegisterFileActivatorForExtension(string pwszFileExtension, IDebugTargetCompositionFileActivator pFileActivator)
        {
            /*HRESULT RegisterFileActivatorForExtension(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileExtension,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionFileActivator pFileActivator);*/
            return Raw.RegisterFileActivatorForExtension(pwszFileExtension, pFileActivator);
        }

        #endregion
        #region UnregisterFileActivatorForExtension

        /// <summary>
        /// Unregisters a file activator from a particular extension.
        /// </summary>
        public void UnregisterFileActivatorForExtension(string pwszFileExtension, IDebugTargetCompositionFileActivator pFileActivator)
        {
            TryUnregisterFileActivatorForExtension(pwszFileExtension, pFileActivator).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Unregisters a file activator from a particular extension.
        /// </summary>
        public HRESULT TryUnregisterFileActivatorForExtension(string pwszFileExtension, IDebugTargetCompositionFileActivator pFileActivator)
        {
            /*HRESULT UnregisterFileActivatorForExtension(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileExtension,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionFileActivator pFileActivator);*/
            return Raw.UnregisterFileActivatorForExtension(pwszFileExtension, pFileActivator);
        }

        #endregion
        #endregion
        #region IDebugTargetCompositionBridge2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugTargetCompositionBridge2 Raw2 => (IDebugTargetCompositionBridge2) Raw;

        #region RegisterProtocolActivatorForProtocolString

        /// <summary>
        /// Registers a protocol activator for a particular protocol string. Whenever a protocol is opened from the debugger, the activator will be called to ensure the protocol string is valid and then subsequently to fill in the requisite services in order to establish debuggability on top of the file.<para/>
        /// Note that multiple activators can be registered on a protocol. Only one of the activators is allowed to indicate that the protocol matches their criteria for handling that type of protocol.
        /// </summary>
        public void RegisterProtocolActivatorForProtocolString(string pwszProtocolName, IDebugTargetCompositionProtocolActivator pProtocolActivator)
        {
            TryRegisterProtocolActivatorForProtocolString(pwszProtocolName, pProtocolActivator).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Registers a protocol activator for a particular protocol string. Whenever a protocol is opened from the debugger, the activator will be called to ensure the protocol string is valid and then subsequently to fill in the requisite services in order to establish debuggability on top of the file.<para/>
        /// Note that multiple activators can be registered on a protocol. Only one of the activators is allowed to indicate that the protocol matches their criteria for handling that type of protocol.
        /// </summary>
        public HRESULT TryRegisterProtocolActivatorForProtocolString(string pwszProtocolName, IDebugTargetCompositionProtocolActivator pProtocolActivator)
        {
            /*HRESULT RegisterProtocolActivatorForProtocolString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszProtocolName,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionProtocolActivator pProtocolActivator);*/
            return Raw2.RegisterProtocolActivatorForProtocolString(pwszProtocolName, pProtocolActivator);
        }

        #endregion
        #region UnregisterProtocolActivatorForProtocolString

        /// <summary>
        /// Unregisters a protocol activator from a particular protocol string.
        /// </summary>
        public void UnregisterProtocolActivatorForProtocolString(string pwszProtocolName, IDebugTargetCompositionProtocolActivator pProtocolActivator)
        {
            TryUnregisterProtocolActivatorForProtocolString(pwszProtocolName, pProtocolActivator).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Unregisters a protocol activator from a particular protocol string.
        /// </summary>
        public HRESULT TryUnregisterProtocolActivatorForProtocolString(string pwszProtocolName, IDebugTargetCompositionProtocolActivator pProtocolActivator)
        {
            /*HRESULT UnregisterProtocolActivatorForProtocolString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszProtocolName,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionProtocolActivator pProtocolActivator);*/
            return Raw2.UnregisterProtocolActivatorForProtocolString(pwszProtocolName, pProtocolActivator);
        }

        #endregion
        #endregion
        #region IDebugTargetCompositionBridge3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugTargetCompositionBridge3 Raw3 => (IDebugTargetCompositionBridge3) Raw;

        #region ReparseActivation

        /// <summary>
        /// This method may *ONLY* be called during the ::InitializeServices call for a given activator *AFTER* performing some modification of the service container; it causes the debugger to walk through the activation path for the given service container once again.<para/>
        /// This allows, for instance, a plug-in which presents some transformation on a file (e.g.: allowing for dynamic decryption of dump files, for instance).<para/>
        /// Typically, an activator which uses this will stack a plug-in modifying the file source and call ReparseActivation.<para/>
        /// Note that calling without making those changes may result in infinite recursion. As it is entirely possible to have files which require multiple phases of transcode through the same plug-in, nothing prevents a call to the same activator.<para/>
        /// Note that calls to ReparseActivation *MUST* be the last thing in the ::InitializeServices call. The service manager which is passed to this method may not be used after a return.<para/>
        /// It is, therefore, impossible to modify the service container after the reparse. Any caller needing to modify the service container *AFTER* the reparse must use IDebugTargetCompositionBridge4::ReparseActivation2.
        /// </summary>
        public void ReparseActivation(IDebugServiceManager pServiceManager)
        {
            TryReparseActivation(pServiceManager).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// This method may *ONLY* be called during the ::InitializeServices call for a given activator *AFTER* performing some modification of the service container; it causes the debugger to walk through the activation path for the given service container once again.<para/>
        /// This allows, for instance, a plug-in which presents some transformation on a file (e.g.: allowing for dynamic decryption of dump files, for instance).<para/>
        /// Typically, an activator which uses this will stack a plug-in modifying the file source and call ReparseActivation.<para/>
        /// Note that calling without making those changes may result in infinite recursion. As it is entirely possible to have files which require multiple phases of transcode through the same plug-in, nothing prevents a call to the same activator.<para/>
        /// Note that calls to ReparseActivation *MUST* be the last thing in the ::InitializeServices call. The service manager which is passed to this method may not be used after a return.<para/>
        /// It is, therefore, impossible to modify the service container after the reparse. Any caller needing to modify the service container *AFTER* the reparse must use IDebugTargetCompositionBridge4::ReparseActivation2.
        /// </summary>
        public HRESULT TryReparseActivation(IDebugServiceManager pServiceManager)
        {
            /*HRESULT ReparseActivation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager);*/
            return Raw3.ReparseActivation(pServiceManager);
        }

        #endregion
        #endregion
        #region IDebugTargetCompositionBridge4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugTargetCompositionBridge4 Raw4 => (IDebugTargetCompositionBridge4) Raw;

        #region ReparseActivation2

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
        public void ReparseActivation2(IDebugServiceManager pServiceManager, IDebugTargetCompositionBridgeReparseCompletion pCallback, IntPtr pData)
        {
            TryReparseActivation2(pServiceManager, pCallback, pData).ThrowDbgEngNotOK();
        }

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
        public HRESULT TryReparseActivation2(IDebugServiceManager pServiceManager, IDebugTargetCompositionBridgeReparseCompletion pCallback, IntPtr pData)
        {
            /*HRESULT ReparseActivation2(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionBridgeReparseCompletion pCallback,
            [In] IntPtr pData);*/
            return Raw4.ReparseActivation2(pServiceManager, pCallback, pData);
        }

        #endregion
        #endregion
    }
}
