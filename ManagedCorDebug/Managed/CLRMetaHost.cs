using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that return a specific version of the common language runtime (CLR) based on its version number,<para/>
    /// list all installed CLRs, list all runtimes that are loaded in a specified process, discover the CLR version used to compile an assembly,<para/>
    /// exit a process with a clean runtime shutdown, and query legacy API binding.
    /// </summary>
    /// <remarks>
    /// The only way to get an instance of this interface is by calling the CLRCreateInstance function.
    /// </remarks>
    public class CLRMetaHost : ComObject<ICLRMetaHost>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRMetaHost"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CLRMetaHost(ICLRMetaHost raw) : base(raw)
        {
        }

        #region ICLRMetaHost
        #region GetRuntime

        /// <summary>
        /// Gets the <see cref="ICLRRuntimeInfo"/> interface that corresponds to a particular version of the common language runtime (CLR).<para/>
        /// This method supersedes the CorBindToRuntimeEx function used with the STARTUP_FLAGS.STARTUP_LOADER_SAFEMODE flag.
        /// </summary>
        /// <param name="pwzVersion">[in] The .NET Framework compilation version stored in the metadata, in the format "vA.B[.X]". A, B, and X are decimal numbers that correspond to the major version, the minor version, and the build number.<para/>
        /// Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.X", where X depends on the build number installed.<para/>
        /// The "v" prefix is required.</param>
        /// <param name="riid">[in] The identifier for the desired interface. Currently, the only valid value for this parameter is IID_ICLRRuntimeInfo.</param>
        /// <returns>[out] A pointer to the <see cref="ICLRRuntimeInfo"/> interface that corresponds to the requested runtime.</returns>
        /// <remarks>
        /// This method interacts consistently with legacy interfaces such as the <see cref="ICorRuntimeHost"/> interface and
        /// legacy functions such as the deprecated CorBindTo* functions (see Deprecated CLR Hosting Functions in the .NET
        /// Framework 2.0 hosting API). That is, runtimes that are loaded with the legacy API are visible to the new API, and
        /// runtimes that are loaded with the new API are visible to the legacy API.
        /// </remarks>
        public object GetRuntime(string pwzVersion, Guid riid)
        {
            HRESULT hr;
            object ppRuntime;

            if ((hr = TryGetRuntime(pwzVersion, riid, out ppRuntime)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppRuntime;
        }

        /// <summary>
        /// Gets the <see cref="ICLRRuntimeInfo"/> interface that corresponds to a particular version of the common language runtime (CLR).<para/>
        /// This method supersedes the CorBindToRuntimeEx function used with the STARTUP_FLAGS.STARTUP_LOADER_SAFEMODE flag.
        /// </summary>
        /// <param name="pwzVersion">[in] The .NET Framework compilation version stored in the metadata, in the format "vA.B[.X]". A, B, and X are decimal numbers that correspond to the major version, the minor version, and the build number.<para/>
        /// Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.X", where X depends on the build number installed.<para/>
        /// The "v" prefix is required.</param>
        /// <param name="riid">[in] The identifier for the desired interface. Currently, the only valid value for this parameter is IID_ICLRRuntimeInfo.</param>
        /// <param name="ppRuntime">[out] A pointer to the <see cref="ICLRRuntimeInfo"/> interface that corresponds to the requested runtime.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                        |
        /// | --------- | ---------------------------------- |
        /// | S_OK      | The method completed successfully. |
        /// | E_POINTER | pwzVersion or ppRuntime is null.   |
        /// </returns>
        /// <remarks>
        /// This method interacts consistently with legacy interfaces such as the <see cref="ICorRuntimeHost"/> interface and
        /// legacy functions such as the deprecated CorBindTo* functions (see Deprecated CLR Hosting Functions in the .NET
        /// Framework 2.0 hosting API). That is, runtimes that are loaded with the legacy API are visible to the new API, and
        /// runtimes that are loaded with the new API are visible to the legacy API.
        /// </remarks>
        public HRESULT TryGetRuntime(string pwzVersion, Guid riid, out object ppRuntime)
        {
            /*HRESULT GetRuntime([MarshalAs(UnmanagedType.LPWStr), In] string pwzVersion, [In] ref Guid riid, [Out] out object ppRuntime);*/
            return Raw.GetRuntime(pwzVersion, ref riid, out ppRuntime);
        }

        #endregion
        #region GetVersionFromFile

        /// <summary>
        /// Gets an assembly's original .NET Framework compilation version (stored in the metadata), given its file path. This method supersedes the GetFileVersion function.
        /// </summary>
        /// <param name="pwzFilePath">[in] The complete assembly file path.</param>
        /// <returns>[out] The .NET Framework compilation version stored in the metadata, in the format "vA.B[.X]". A, B, and X are decimal numbers that correspond to the major version, the minor version, and the build number.<para/>
        /// The length of this string is limited to MAX_PATH. Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.X", where X depends on the build number installed.<para/>
        /// Note that the "v" prefix is required.</returns>
        public string GetVersionFromFile(string pwzFilePath)
        {
            HRESULT hr;
            string pwzBufferResult;

            if ((hr = TryGetVersionFromFile(pwzFilePath, out pwzBufferResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pwzBufferResult;
        }

        /// <summary>
        /// Gets an assembly's original .NET Framework compilation version (stored in the metadata), given its file path. This method supersedes the GetFileVersion function.
        /// </summary>
        /// <param name="pwzFilePath">[in] The complete assembly file path.</param>
        /// <param name="pwzBufferResult">[out] The .NET Framework compilation version stored in the metadata, in the format "vA.B[.X]". A, B, and X are decimal numbers that correspond to the major version, the minor version, and the build number.<para/>
        /// The length of this string is limited to MAX_PATH. Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.X", where X depends on the build number installed.<para/>
        /// Note that the "v" prefix is required.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                                       | Description                        |
        /// | --------------------------------------------- | ---------------------------------- |
        /// | S_OK                                          | The method completed successfully. |
        /// | E_POINTER                                     | pwzbuffer or pcchBuffer is null.   |
        /// | HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) | The buffer is too small.           |
        /// </returns>
        public HRESULT TryGetVersionFromFile(string pwzFilePath, out string pwzBufferResult)
        {
            /*HRESULT GetVersionFromFile([MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref int pcchBuffer);*/
            StringBuilder pwzBuffer = null;
            int pcchBuffer = default(int);
            HRESULT hr = Raw.GetVersionFromFile(pwzFilePath, pwzBuffer, ref pcchBuffer);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            pwzBuffer = new StringBuilder(pcchBuffer);
            hr = Raw.GetVersionFromFile(pwzFilePath, pwzBuffer, ref pcchBuffer);

            if (hr == HRESULT.S_OK)
            {
                pwzBufferResult = pwzBuffer.ToString();

                return hr;
            }

            fail:
            pwzBufferResult = default(string);

            return hr;
        }

        #endregion
        #region EnumerateInstalledRuntimes

        /// <summary>
        /// Returns an enumeration that contains a valid <see cref="ICLRRuntimeInfo"/> interface for each version of the common language runtime (CLR) that is installed on a computer.
        /// </summary>
        /// <returns>[out] An enumeration of <see cref="ICLRRuntimeInfo"/> interfaces corresponding to each version of the CLR that is installed on the computer.</returns>
        public EnumUnknown EnumerateInstalledRuntimes()
        {
            HRESULT hr;
            EnumUnknown ppEnumeratorResult;

            if ((hr = TryEnumerateInstalledRuntimes(out ppEnumeratorResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppEnumeratorResult;
        }

        /// <summary>
        /// Returns an enumeration that contains a valid <see cref="ICLRRuntimeInfo"/> interface for each version of the common language runtime (CLR) that is installed on a computer.
        /// </summary>
        /// <param name="ppEnumeratorResult">[out] An enumeration of <see cref="ICLRRuntimeInfo"/> interfaces corresponding to each version of the CLR that is installed on the computer.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                        |
        /// | --------- | ---------------------------------- |
        /// | S_OK      | The method completed successfully. |
        /// | E_POINTER | ppEnumerator is null.              |
        /// </returns>
        public HRESULT TryEnumerateInstalledRuntimes(out EnumUnknown ppEnumeratorResult)
        {
            /*HRESULT EnumerateInstalledRuntimes([MarshalAs(UnmanagedType.Interface)] out IEnumUnknown ppEnumerator);*/
            IEnumUnknown ppEnumerator;
            HRESULT hr = Raw.EnumerateInstalledRuntimes(out ppEnumerator);

            if (hr == HRESULT.S_OK)
                ppEnumeratorResult = new EnumUnknown(ppEnumerator);
            else
                ppEnumeratorResult = default(EnumUnknown);

            return hr;
        }

        #endregion
        #region EnumerateLoadedRuntimes

        /// <summary>
        /// Returns an enumeration that includes a valid <see cref="ICLRRuntimeInfo"/> interface pointer for each version of the common language runtime (CLR) that is loaded in a given process.<para/>
        /// This method supersedes the GetVersionFromProcess function.
        /// </summary>
        /// <param name="hndProcess">[in] The handle of the process to inspect for loaded runtimes.</param>
        /// <returns>[out] An Microsoft.VisualStudio.OLE.Interop.IEnumUnknown enumeration of <see cref="ICLRRuntimeInfo"/> interfaces corresponding to each CLR that is loaded by the process.</returns>
        /// <remarks>
        /// This method is lists all loaded runtimes, even if they were loaded with deprecated functions such as CorBindToRuntime.
        /// </remarks>
        public EnumUnknown EnumerateLoadedRuntimes(IntPtr hndProcess)
        {
            HRESULT hr;
            EnumUnknown ppEnumeratorResult;

            if ((hr = TryEnumerateLoadedRuntimes(hndProcess, out ppEnumeratorResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppEnumeratorResult;
        }

        /// <summary>
        /// Returns an enumeration that includes a valid <see cref="ICLRRuntimeInfo"/> interface pointer for each version of the common language runtime (CLR) that is loaded in a given process.<para/>
        /// This method supersedes the GetVersionFromProcess function.
        /// </summary>
        /// <param name="hndProcess">[in] The handle of the process to inspect for loaded runtimes.</param>
        /// <param name="ppEnumeratorResult">[out] An Microsoft.VisualStudio.OLE.Interop.IEnumUnknown enumeration of <see cref="ICLRRuntimeInfo"/> interfaces corresponding to each CLR that is loaded by the process.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                        |
        /// | --------- | ---------------------------------- |
        /// | S_OK      | The method completed successfully. |
        /// | E_POINTER | ppEnumerator is null.              |
        /// </returns>
        /// <remarks>
        /// This method is lists all loaded runtimes, even if they were loaded with deprecated functions such as CorBindToRuntime.
        /// </remarks>
        public HRESULT TryEnumerateLoadedRuntimes(IntPtr hndProcess, out EnumUnknown ppEnumeratorResult)
        {
            /*HRESULT EnumerateLoadedRuntimes([In] IntPtr hndProcess, [MarshalAs(UnmanagedType.Interface)] out IEnumUnknown ppEnumerator);*/
            IEnumUnknown ppEnumerator;
            HRESULT hr = Raw.EnumerateLoadedRuntimes(hndProcess, out ppEnumerator);

            if (hr == HRESULT.S_OK)
                ppEnumeratorResult = new EnumUnknown(ppEnumerator);
            else
                ppEnumeratorResult = default(EnumUnknown);

            return hr;
        }

        #endregion
        #region RequestRuntimeLoadedNotification

        /// <summary>
        /// Provides a callback function that is guaranteed to be called when a common language runtime (CLR) version is first loaded, but not yet started.<para/>
        /// This method supersedes the LockClrVersion function.
        /// </summary>
        /// <param name="pCallbackFunction">[in] The callback function that is invoked when a new runtime has been loaded.</param>
        /// <remarks>
        /// The callback works in the following way: The callback function has the following prototype: The callback function
        /// prototypes are as follows: If the host intends to load or cause another runtime to be loaded in a reentrant manner,
        /// the pfnCallbackThreadSet and pfnCallbackThreadUnset parameters that are provided in the callback function must
        /// be used in the following way:
        /// </remarks>
        public void RequestRuntimeLoadedNotification(RuntimeLoadedCallback pCallbackFunction)
        {
            HRESULT hr;

            if ((hr = TryRequestRuntimeLoadedNotification(pCallbackFunction)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Provides a callback function that is guaranteed to be called when a common language runtime (CLR) version is first loaded, but not yet started.<para/>
        /// This method supersedes the LockClrVersion function.
        /// </summary>
        /// <param name="pCallbackFunction">[in] The callback function that is invoked when a new runtime has been loaded.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                        |
        /// | --------- | ---------------------------------- |
        /// | S_OK      | The method completed successfully. |
        /// | E_POINTER | pCallbackFunction is null.         |
        /// </returns>
        /// <remarks>
        /// The callback works in the following way: The callback function has the following prototype: The callback function
        /// prototypes are as follows: If the host intends to load or cause another runtime to be loaded in a reentrant manner,
        /// the pfnCallbackThreadSet and pfnCallbackThreadUnset parameters that are provided in the callback function must
        /// be used in the following way:
        /// </remarks>
        public HRESULT TryRequestRuntimeLoadedNotification(RuntimeLoadedCallback pCallbackFunction)
        {
            /*HRESULT RequestRuntimeLoadedNotification([MarshalAs(UnmanagedType.FunctionPtr), In]
            RuntimeLoadedCallback pCallbackFunction);*/
            return Raw.RequestRuntimeLoadedNotification(pCallbackFunction);
        }

        #endregion
        #region QueryLegacyV2RuntimeBinding

        /// <summary>
        /// Returns an interface that represents a runtime to which legacy activation policy has been bound, for example, by using the useLegacyV2RuntimeActivationPolicy attribute on the &lt;startup&gt; element configuration file entry, by direct use of the legacy activation APIs, or by calling the <see cref="CLRRuntimeInfo.BindAsLegacyV2Runtime"/> method.
        /// </summary>
        /// <param name="riid">[in] Required.Currently the only valid value for this parameter is IID_ICLRRuntimeInfo.</param>
        /// <returns>[out] Required. When this method returns, contains a pointer to the <see cref="ICLRRuntimeInfo"/> interface that represents a runtime that has been bound to legacy activation policy.</returns>
        public object QueryLegacyV2RuntimeBinding(Guid riid)
        {
            HRESULT hr;
            object ppUnk;

            if ((hr = TryQueryLegacyV2RuntimeBinding(riid, out ppUnk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppUnk;
        }

        /// <summary>
        /// Returns an interface that represents a runtime to which legacy activation policy has been bound, for example, by using the useLegacyV2RuntimeActivationPolicy attribute on the &lt;startup&gt; element configuration file entry, by direct use of the legacy activation APIs, or by calling the <see cref="CLRRuntimeInfo.BindAsLegacyV2Runtime"/> method.
        /// </summary>
        /// <param name="riid">[in] Required.Currently the only valid value for this parameter is IID_ICLRRuntimeInfo.</param>
        /// <param name="ppUnk">[out] Required. When this method returns, contains a pointer to the <see cref="ICLRRuntimeInfo"/> interface that represents a runtime that has been bound to legacy activation policy.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT       | Description                                                                                                       |
        /// | ------------- | ----------------------------------------------------------------------------------------------------------------- |
        /// | S_OK          | The method completed successfully and returned a runtime that was bound to legacy activation policy.              |
        /// | S_FALSE       | The method completed successfully, but a legacy runtime has not yet been bound.                                   |
        /// | E_NOINTERFACE | The method found a runtime that was bound to legacy activation policy, but riid is not supported by that runtime. |
        /// </returns>
        public HRESULT TryQueryLegacyV2RuntimeBinding(Guid riid, out object ppUnk)
        {
            /*HRESULT QueryLegacyV2RuntimeBinding(
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppUnk);*/
            return Raw.QueryLegacyV2RuntimeBinding(ref riid, out ppUnk);
        }

        #endregion
        #region ExitProcess

        /// <summary>
        /// Attempts to shut down all loaded runtimes gracefully and then terminates the process. Supersedes the CorExitProcess function.
        /// </summary>
        /// <param name="iExitCode">[in] The exit code for the process.</param>
        public void ExitProcess(int iExitCode)
        {
            HRESULT hr;

            if ((hr = TryExitProcess(iExitCode)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Attempts to shut down all loaded runtimes gracefully and then terminates the process. Supersedes the CorExitProcess function.
        /// </summary>
        /// <param name="iExitCode">[in] The exit code for the process.</param>
        /// <returns>This method never returns, so its return value is undefined.</returns>
        public HRESULT TryExitProcess(int iExitCode)
        {
            /*HRESULT ExitProcess([In] int iExitCode);*/
            return Raw.ExitProcess(iExitCode);
        }

        #endregion
        #endregion
    }
}