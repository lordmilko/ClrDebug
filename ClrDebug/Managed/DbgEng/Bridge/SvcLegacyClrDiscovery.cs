using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Private bridge interface to the existing mechanism of DAC discovery for processes utilizing the CLR.<para/>
    /// That's a significant refactor that is not yet happening in order to get better CLR symbol support.
    /// </summary>
    public class SvcLegacyClrDiscovery : ComObject<ISvcLegacyClrDiscovery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcLegacyClrDiscovery"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcLegacyClrDiscovery(ISvcLegacyClrDiscovery raw) : base(raw)
        {
        }

        #region ISvcLegacyClrDiscovery
        #region LocateDacForProcess

        /// <summary>
        /// Locates the appropriate DAC for the given process.
        /// </summary>
        public string LocateDacForProcess(ISvcProcess process, string requestedModuleName, int requestedModuleTimeStamp, int requestedModuleSize)
        {
            string dacPath;
            TryLocateDacForProcess(process, out dacPath, requestedModuleName, requestedModuleTimeStamp, requestedModuleSize).ThrowDbgEngNotOK();

            return dacPath;
        }

        /// <summary>
        /// Locates the appropriate DAC for the given process.
        /// </summary>
        public HRESULT TryLocateDacForProcess(ISvcProcess process, out string dacPath, string requestedModuleName, int requestedModuleTimeStamp, int requestedModuleSize)
        {
            /*HRESULT LocateDacForProcess(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.BStr)] out string dacPath,
            [In, MarshalAs(UnmanagedType.LPWStr)] string requestedModuleName,
            [In] int requestedModuleTimeStamp,
            [In] int requestedModuleSize);*/
            return Raw.LocateDacForProcess(process, out dacPath, requestedModuleName, requestedModuleTimeStamp, requestedModuleSize);
        }

        #endregion
        #region LocateDbiForProcess

        /// <summary>
        /// Locates the appropriate DBI for the given process.
        /// </summary>
        public string LocateDbiForProcess(ISvcProcess process, string requestedModuleName, int requestedModuleTimeStamp, int requestedModuleSize)
        {
            string dbiPath;
            TryLocateDbiForProcess(process, out dbiPath, requestedModuleName, requestedModuleTimeStamp, requestedModuleSize).ThrowDbgEngNotOK();

            return dbiPath;
        }

        /// <summary>
        /// Locates the appropriate DBI for the given process.
        /// </summary>
        public HRESULT TryLocateDbiForProcess(ISvcProcess process, out string dbiPath, string requestedModuleName, int requestedModuleTimeStamp, int requestedModuleSize)
        {
            /*HRESULT LocateDbiForProcess(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.BStr)] out string dbiPath,
            [In, MarshalAs(UnmanagedType.LPWStr)] string requestedModuleName,
            [In] int requestedModuleTimeStamp,
            [In] int requestedModuleSize);*/
            return Raw.LocateDbiForProcess(process, out dbiPath, requestedModuleName, requestedModuleTimeStamp, requestedModuleSize);
        }

        #endregion
        #region SecureLoadModule

        /// <summary>
        /// Loads the given module and verifies its authenticity.
        /// </summary>
        public IntPtr SecureLoadModule(string dllPath)
        {
            IntPtr libraryHandle;
            TrySecureLoadModule(dllPath, out libraryHandle).ThrowDbgEngNotOK();

            return libraryHandle;
        }

        /// <summary>
        /// Loads the given module and verifies its authenticity.
        /// </summary>
        public HRESULT TrySecureLoadModule(string dllPath, out IntPtr libraryHandle)
        {
            /*HRESULT SecureLoadModule(
            [In, MarshalAs(UnmanagedType.LPWStr)] string dllPath,
            [Out] out IntPtr libraryHandle);*/
            return Raw.SecureLoadModule(dllPath, out libraryHandle);
        }

        #endregion
        #endregion
    }
}
