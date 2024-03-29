﻿using System;
using System.Diagnostics;
using System.Reflection;

namespace ClrDebug
{
    /// <summary>
    /// Provides functionality similar to that of the <see cref="ICorRuntimeHost"/> interface provided in the .NET Framework version 1, with the following changes:
    /// </summary>
    /// <remarks>
    /// Starting with the .NET Framework 4, use the <see cref="ICLRMetaHost"/> interface to get a pointer to the <see cref="ICLRRuntimeInfo"/>
    /// interface, and then call the <see cref="CLRRuntimeInfo.GetInterface"/> method to get a pointer to <see cref="ICLRRuntimeHost"/>.
    /// In earlier versions of the .NET Framework, the host gets a pointer to an <see cref="ICLRRuntimeHost"/> instance by calling CorBindToRuntimeEx
    /// or CorBindToCurrentRuntime. To provide implementations of any of the technologies provided in the .NET Framework
    /// version 2.0, you must use <see cref="ICLRRuntimeHost"/> instead of <see cref="ICorRuntimeHost"/>.
    /// </remarks>
    public class CLRRuntimeHost : ComObject<ICLRRuntimeHost>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRRuntimeHost"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CLRRuntimeHost(ICLRRuntimeHost raw) : base(raw)
        {
        }

        #region ICLRRuntimeHost
        #region CLRControl

        /// <summary>
        /// Gets an interface pointer of type <see cref="ICLRControl"/> that hosts can use to customize aspects of the common language runtime (CLR).
        /// </summary>
        public CLRControl CLRControl
        {
            get
            {
                CLRControl pCLRControlResult;
                TryGetCLRControl(out pCLRControlResult).ThrowOnNotOK();

                return pCLRControlResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer of type <see cref="ICLRControl"/> that hosts can use to customize aspects of the common language runtime (CLR).
        /// </summary>
        /// <param name="pCLRControlResult">[out] An interface pointer of type <see cref="ICLRControl"/> that enables hosts to configure additional aspects of the CLR.</param>
        /// <returns>
        /// | HRESULT                 | Description                                                                                                                                                                              |
        /// | ----------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                    | GetCLRControl returned successfully.                                                                                                                                                     |
        /// | HOST_E_CLRNOTAVAILABLE  | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                               |
        /// | HOST_E_TIMEOUT          | The call timed out.                                                                                                                                                                      |
        /// | HOST_E_NOT_OWNER        | The caller does not own the lock.                                                                                                                                                        |
        /// | HOST_E_ABANDONED        | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                 |
        /// | E_FAIL                  | An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_INVALIDOPERATION | The CLR has already started.                                                                                                                                                             |
        /// </returns>
        /// <remarks>
        /// <see cref="ICLRControl"/> provides the <see cref="CLRControl.GetCLRManager"/> method, which enables the host to get an interface
        /// pointer to one of the manager types.
        /// </remarks>
        public HRESULT TryGetCLRControl(out CLRControl pCLRControlResult)
        {
            /*HRESULT GetCLRControl(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICLRControl pCLRControl);*/
            ICLRControl pCLRControl;
            HRESULT hr = Raw.GetCLRControl(out pCLRControl);

            if (hr == HRESULT.S_OK)
                pCLRControlResult = pCLRControl == null ? null : new CLRControl(pCLRControl);
            else
                pCLRControlResult = default(CLRControl);

            return hr;
        }

        #endregion
        #region CurrentAppDomainId

        /// <summary>
        /// Gets the numeric identifier of the <see cref="AppDomain"/> that is currently executing.
        /// </summary>
        public int CurrentAppDomainId
        {
            get
            {
                int pdwAppDomainId;
                TryGetCurrentAppDomainId(out pdwAppDomainId).ThrowOnNotOK();

                return pdwAppDomainId;
            }
        }

        /// <summary>
        /// Gets the numeric identifier of the <see cref="AppDomain"/> that is currently executing.
        /// </summary>
        /// <param name="pdwAppDomainId">[out] The numeric identifier of the <see cref="AppDomain"/> that is currently executing.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                              |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | GetCurrentAppDomainId returned successfully.                                                                                                                                             |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                     |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                      |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                        |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                 |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The pdwAppDomainId parameter is set to the value of the <see cref="AppDomain.Id"/> property of the <see cref="AppDomain"/>
        /// in which the current thread is executing.
        /// </remarks>
        public HRESULT TryGetCurrentAppDomainId(out int pdwAppDomainId)
        {
            /*HRESULT GetCurrentAppDomainId(
            [Out] out int pdwAppDomainId);*/
            return Raw.GetCurrentAppDomainId(out pdwAppDomainId);
        }

        #endregion
        #region Start

        /// <summary>
        /// Initializes the common language runtime (CLR) into a process.
        /// </summary>
        /// <remarks>
        /// In many scenarios it is not necessary to call Start, because the runtime will initialize itself automatically upon
        /// the first request to run managed code. You can, however, use Start to specify exactly when the runtime should be
        /// initialized.
        /// </remarks>
        public void Start()
        {
            TryStart().ThrowOnNotOK();
        }

        /// <summary>
        /// Initializes the common language runtime (CLR) into a process.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                              |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | Start returned successfully.                                                                                                                                                             |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                               |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                      |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                        |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                 |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// In many scenarios it is not necessary to call Start, because the runtime will initialize itself automatically upon
        /// the first request to run managed code. You can, however, use Start to specify exactly when the runtime should be
        /// initialized.
        /// </remarks>
        public HRESULT TryStart()
        {
            /*HRESULT Start();*/
            return Raw.Start();
        }

        #endregion
        #region Stop

        /// <summary>
        /// Stops the execution of code by the common language runtime (CLR).
        /// </summary>
        public void Stop()
        {
            TryStop().ThrowOnNotOK();
        }

        /// <summary>
        /// Stops the execution of code by the common language runtime (CLR).
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                              |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | Stop returned successfully.                                                                                                                                                              |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                               |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                      |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                        |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                 |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        public HRESULT TryStop()
        {
            /*HRESULT Stop();*/
            return Raw.Stop();
        }

        #endregion
        #region SetHostControl

        /// <summary>
        /// Sets the interface pointer that the common language runtime (CLR) can use to get the host's implementation of <see cref="IHostControl"/>.
        /// </summary>
        /// <param name="pHostControl">[in] An interface pointer to the host's implementation of <see cref="IHostControl"/>.</param>
        /// <remarks>
        /// You must call SetHostControl before the CLR is initialized, that is, before you call <see cref="Start"/> or use
        /// any of the Metadata Interfaces. It is recommended that you call SetHostControl immediately after calling CorBindToCurrentRuntime
        /// Function or CorBindToRuntimeEx Function.
        /// </remarks>
        public void SetHostControl(IHostControl pHostControl)
        {
            TrySetHostControl(pHostControl).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the interface pointer that the common language runtime (CLR) can use to get the host's implementation of <see cref="IHostControl"/>.
        /// </summary>
        /// <param name="pHostControl">[in] An interface pointer to the host's implementation of <see cref="IHostControl"/>.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                              |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | SetHostControl returned successfully.                                                                                                                                                    |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                               |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                      |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                        |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                 |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_CLR_ALREADY_STARTED  | The CLR has already been initialized.                                                                                                                                                    |
        /// </returns>
        /// <remarks>
        /// You must call SetHostControl before the CLR is initialized, that is, before you call <see cref="Start"/> or use
        /// any of the Metadata Interfaces. It is recommended that you call SetHostControl immediately after calling CorBindToCurrentRuntime
        /// Function or CorBindToRuntimeEx Function.
        /// </remarks>
        public HRESULT TrySetHostControl(IHostControl pHostControl)
        {
            /*HRESULT SetHostControl(
            [MarshalAs(UnmanagedType.Interface), In] IHostControl pHostControl);*/
            return Raw.SetHostControl(pHostControl);
        }

        #endregion
        #region UnloadAppDomain

        /// <summary>
        /// Unloads the managed <see cref="AppDomain"/> that corresponds to the specified numeric identifier.
        /// </summary>
        /// <param name="dwAppDomainID">[in] The numeric identifier of the application domain to unload.</param>
        /// <param name="fWaitUntilDone">[in] true to indicate that the common language runtime( CLR) must wait until it has finished executing the application's current thread before attempting to unload the application domain.</param>
        /// <remarks>
        /// You can get the numeric identifier of the application domain in which the current thread is executing by calling
        /// <see cref="CurrentAppDomainId"/>. This identifier corresponds to the <see cref="AppDomain.Id"/> property of
        /// the managed <see cref="AppDomain"/> type.
        /// </remarks>
        public void UnloadAppDomain(int dwAppDomainID, bool fWaitUntilDone)
        {
            TryUnloadAppDomain(dwAppDomainID, fWaitUntilDone).ThrowOnNotOK();
        }

        /// <summary>
        /// Unloads the managed <see cref="AppDomain"/> that corresponds to the specified numeric identifier.
        /// </summary>
        /// <param name="dwAppDomainID">[in] The numeric identifier of the application domain to unload.</param>
        /// <param name="fWaitUntilDone">[in] true to indicate that the common language runtime( CLR) must wait until it has finished executing the application's current thread before attempting to unload the application domain.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                              |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | UnloadAppDomain returned successfully.                                                                                                                                                   |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                               |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                      |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                        |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                 |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// You can get the numeric identifier of the application domain in which the current thread is executing by calling
        /// <see cref="CurrentAppDomainId"/>. This identifier corresponds to the <see cref="AppDomain.Id"/> property of
        /// the managed <see cref="AppDomain"/> type.
        /// </remarks>
        public HRESULT TryUnloadAppDomain(int dwAppDomainID, bool fWaitUntilDone)
        {
            /*HRESULT UnloadAppDomain(
            [In] int dwAppDomainID,
            [In, MarshalAs(UnmanagedType.Bool)] bool fWaitUntilDone);*/
            return Raw.UnloadAppDomain(dwAppDomainID, fWaitUntilDone);
        }

        #endregion
        #region ExecuteInAppDomain

        /// <summary>
        /// Specifies the <see cref="AppDomain"/> in which to execute the specified managed code.
        /// </summary>
        /// <param name="dwAppDomainID">[in] The numeric ID of the <see cref="AppDomain"/> in which to execute the specified method.</param>
        /// <param name="pCallback">[in] A pointer to the function to execute within the specified <see cref="AppDomain"/>.</param>
        /// <param name="cookie">[in] A pointer to opaque caller-allocated memory. This parameter is passed by the common language runtime (CLR) to the domain callback.<para/>
        /// It is not runtime-managed heap memory; both the allocation and lifetime of this memory are controlled by the caller.</param>
        /// <remarks>
        /// ExecuteInAppDomain allows the host to exercise control over which managed <see cref="AppDomain"/> the specified
        /// managed method should be executed in. You can get the value of an application domain's identifier, which corresponds
        /// to the value of the <see cref="AppDomain.Id"/> property, by calling <see cref="CurrentAppDomainId"/>.
        /// </remarks>
        public void ExecuteInAppDomain(int dwAppDomainID, FExecuteInAppDomainCallback pCallback, IntPtr cookie)
        {
            TryExecuteInAppDomain(dwAppDomainID, pCallback, cookie).ThrowOnNotOK();
        }

        /// <summary>
        /// Specifies the <see cref="AppDomain"/> in which to execute the specified managed code.
        /// </summary>
        /// <param name="dwAppDomainID">[in] The numeric ID of the <see cref="AppDomain"/> in which to execute the specified method.</param>
        /// <param name="pCallback">[in] A pointer to the function to execute within the specified <see cref="AppDomain"/>.</param>
        /// <param name="cookie">[in] A pointer to opaque caller-allocated memory. This parameter is passed by the common language runtime (CLR) to the domain callback.<para/>
        /// It is not runtime-managed heap memory; both the allocation and lifetime of this memory are controlled by the caller.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                              |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | ExecuteInAppDomain returned successfully.                                                                                                                                                |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                               |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                      |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                        |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                 |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// ExecuteInAppDomain allows the host to exercise control over which managed <see cref="AppDomain"/> the specified
        /// managed method should be executed in. You can get the value of an application domain's identifier, which corresponds
        /// to the value of the <see cref="AppDomain.Id"/> property, by calling <see cref="CurrentAppDomainId"/>.
        /// </remarks>
        public HRESULT TryExecuteInAppDomain(int dwAppDomainID, FExecuteInAppDomainCallback pCallback, IntPtr cookie)
        {
            /*HRESULT ExecuteInAppDomain(
            [In] int dwAppDomainID,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FExecuteInAppDomainCallback pCallback,
            [In] IntPtr cookie);*/
            return Raw.ExecuteInAppDomain(dwAppDomainID, pCallback, cookie);
        }

        #endregion
        #region ExecuteApplication

        /// <summary>
        /// Used in manifest-based ClickOnce deployment scenarios to specify the application to be activated in a new domain.<para/>
        /// For more information about these scenarios, see ClickOnce Security and Deployment.
        /// </summary>
        /// <param name="pwzAppFullName">[in] The full name of the application, as defined for System.ApplicationIdentity.</param>
        /// <param name="dwManifestPaths">[in] The number of strings contained in the ppwzManifestPaths array.</param>
        /// <param name="ppwzManifestPaths">[in] Optional. A string array that contains manifest paths for the application.</param>
        /// <param name="dwActivationData">[in] The number of strings contained in the ppwzActivationData array.</param>
        /// <param name="ppwzActivationData">[in] Optional. A string array that contains the application's activation data, such as the query string portion of the URL for applications deployed over the Web.</param>
        /// <returns>[out] The value returned from the entry point of the application.</returns>
        /// <remarks>
        /// ExecuteApplication is used to activate ClickOnce applications in a newly created application domain. The pReturnValue
        /// output parameter is set to the value returned by the application. If you supply a value of null for pReturnValue,
        /// ExecuteApplication does not fail, but it does not return a value.
        /// </remarks>
        public int ExecuteApplication(string pwzAppFullName, int dwManifestPaths, string ppwzManifestPaths, int dwActivationData, string ppwzActivationData)
        {
            int pReturnValue;
            TryExecuteApplication(pwzAppFullName, dwManifestPaths, ppwzManifestPaths, dwActivationData, ppwzActivationData, out pReturnValue).ThrowOnNotOK();

            return pReturnValue;
        }

        /// <summary>
        /// Used in manifest-based ClickOnce deployment scenarios to specify the application to be activated in a new domain.<para/>
        /// For more information about these scenarios, see ClickOnce Security and Deployment.
        /// </summary>
        /// <param name="pwzAppFullName">[in] The full name of the application, as defined for System.ApplicationIdentity.</param>
        /// <param name="dwManifestPaths">[in] The number of strings contained in the ppwzManifestPaths array.</param>
        /// <param name="ppwzManifestPaths">[in] Optional. A string array that contains manifest paths for the application.</param>
        /// <param name="dwActivationData">[in] The number of strings contained in the ppwzActivationData array.</param>
        /// <param name="ppwzActivationData">[in] Optional. A string array that contains the application's activation data, such as the query string portion of the URL for applications deployed over the Web.</param>
        /// <param name="pReturnValue">[out] The value returned from the entry point of the application.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                              |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | ExecuteApplication returned successfully.                                                                                                                                                |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                     |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                      |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                        |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                 |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// ExecuteApplication is used to activate ClickOnce applications in a newly created application domain. The pReturnValue
        /// output parameter is set to the value returned by the application. If you supply a value of null for pReturnValue,
        /// ExecuteApplication does not fail, but it does not return a value.
        /// </remarks>
        public HRESULT TryExecuteApplication(string pwzAppFullName, int dwManifestPaths, string ppwzManifestPaths, int dwActivationData, string ppwzActivationData, out int pReturnValue)
        {
            /*HRESULT ExecuteApplication(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzAppFullName,
            [In] int dwManifestPaths,
            [MarshalAs(UnmanagedType.LPWStr), In] string ppwzManifestPaths,
            [In] int dwActivationData,
            [MarshalAs(UnmanagedType.LPWStr), In] string ppwzActivationData,
            [Out] out int pReturnValue);*/
            return Raw.ExecuteApplication(pwzAppFullName, dwManifestPaths, ppwzManifestPaths, dwActivationData, ppwzActivationData, out pReturnValue);
        }

        #endregion
        #region ExecuteInDefaultAppDomain

        /// <summary>
        /// Calls the specified method of the specified type in the specified managed assembly.
        /// </summary>
        /// <param name="pwzAssemblyPath">[in] The path to the <see cref="Assembly"/> that defines the <see cref="Type"/> whose method is to be invoked.</param>
        /// <param name="pwzTypeName">[in] The name of the <see cref="Type"/> that defines the method to invoke.</param>
        /// <param name="pwzMethodName">[in] The name of the method to invoke.</param>
        /// <param name="pwzArgument">[in] The string parameter to pass to the method.</param>
        /// <returns>[out] The integer value returned by the invoked method.</returns>
        /// <remarks>
        /// The invoked method must have the following signature: where pwzMethodName represents the name of the invoked method,
        /// and pwzArgument represents the string value passed as a parameter to that method. If the <see cref="HRESULT"/> value is set to
        /// S_OK, pReturnValue is set to the integer value returned by the invoked method. Otherwise, pReturnValue is not set.
        /// </remarks>
        public int ExecuteInDefaultAppDomain(string pwzAssemblyPath, string pwzTypeName, string pwzMethodName, string pwzArgument)
        {
            int pReturnValue;
            TryExecuteInDefaultAppDomain(pwzAssemblyPath, pwzTypeName, pwzMethodName, pwzArgument, out pReturnValue).ThrowOnNotOK();

            return pReturnValue;
        }

        /// <summary>
        /// Calls the specified method of the specified type in the specified managed assembly.
        /// </summary>
        /// <param name="pwzAssemblyPath">[in] The path to the <see cref="Assembly"/> that defines the <see cref="Type"/> whose method is to be invoked.</param>
        /// <param name="pwzTypeName">[in] The name of the <see cref="Type"/> that defines the method to invoke.</param>
        /// <param name="pwzMethodName">[in] The name of the method to invoke.</param>
        /// <param name="pwzArgument">[in] The string parameter to pass to the method.</param>
        /// <param name="pReturnValue">[out] The integer value returned by the invoked method.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                              |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | ExecuteInDefaultAppDomain returned successfully.                                                                                                                                         |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                     |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                      |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                        |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                 |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. If a method returns E_FAIL, the CRL is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The invoked method must have the following signature: where pwzMethodName represents the name of the invoked method,
        /// and pwzArgument represents the string value passed as a parameter to that method. If the <see cref="HRESULT"/> value is set to
        /// S_OK, pReturnValue is set to the integer value returned by the invoked method. Otherwise, pReturnValue is not set.
        /// </remarks>
        public HRESULT TryExecuteInDefaultAppDomain(string pwzAssemblyPath, string pwzTypeName, string pwzMethodName, string pwzArgument, out int pReturnValue)
        {
            /*HRESULT ExecuteInDefaultAppDomain(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzAssemblyPath,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzTypeName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzMethodName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzArgument,
            [Out] out int pReturnValue);*/
            return Raw.ExecuteInDefaultAppDomain(pwzAssemblyPath, pwzTypeName, pwzMethodName, pwzArgument, out pReturnValue);
        }

        #endregion
        #endregion
        #region ICLRRuntimeHost2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICLRRuntimeHost2 Raw2 => (ICLRRuntimeHost2) Raw;

        #region CreateAppDomainWithManager

        public int CreateAppDomainWithManager(string wszFriendlyName, APPDOMAIN_SECURITY_FLAGS dwFlags, string wszAppDomainManagerAssemblyName, string wszAppDomainManagerTypeName, int nProperties, string[] pPropertyNames, string[] pPropertyValues)
        {
            int pAooDomainID;
            TryCreateAppDomainWithManager(wszFriendlyName, dwFlags, wszAppDomainManagerAssemblyName, wszAppDomainManagerTypeName, nProperties, pPropertyNames, pPropertyValues, out pAooDomainID).ThrowOnNotOK();

            return pAooDomainID;
        }

        public HRESULT TryCreateAppDomainWithManager(string wszFriendlyName, APPDOMAIN_SECURITY_FLAGS dwFlags, string wszAppDomainManagerAssemblyName, string wszAppDomainManagerTypeName, int nProperties, string[] pPropertyNames, string[] pPropertyValues, out int pAooDomainID)
        {
            /*HRESULT CreateAppDomainWithManager(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszFriendlyName,
            [In] APPDOMAIN_SECURITY_FLAGS dwFlags,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszAppDomainManagerAssemblyName,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszAppDomainManagerTypeName,
            [In] int nProperties,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 4), In] string[] pPropertyNames,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 4), In] string[] pPropertyValues,
            [Out] out int pAooDomainID);*/
            return Raw2.CreateAppDomainWithManager(wszFriendlyName, dwFlags, wszAppDomainManagerAssemblyName, wszAppDomainManagerTypeName, nProperties, pPropertyNames, pPropertyValues, out pAooDomainID);
        }

        #endregion
        #region CreateDelegate

        public IntPtr CreateDelegate(int appDomainID, string wszAssemblyName, string wszClassName, string wszMethodName)
        {
            IntPtr fnPtr;
            TryCreateDelegate(appDomainID, wszAssemblyName, wszClassName, wszMethodName, out fnPtr).ThrowOnNotOK();

            return fnPtr;
        }

        public HRESULT TryCreateDelegate(int appDomainID, string wszAssemblyName, string wszClassName, string wszMethodName, out IntPtr fnPtr)
        {
            /*HRESULT CreateDelegate(
            [In] int appDomainID,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszAssemblyName,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszClassName,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszMethodName,
            [Out] out IntPtr fnPtr);*/
            return Raw2.CreateDelegate(appDomainID, wszAssemblyName, wszClassName, wszMethodName, out fnPtr);
        }

        #endregion
        #region Authenticate

        public void Authenticate(long authKey)
        {
            TryAuthenticate(authKey).ThrowOnNotOK();
        }

        public HRESULT TryAuthenticate(long authKey)
        {
            /*HRESULT Authenticate(
            [In] long authKey);*/
            return Raw2.Authenticate(authKey);
        }

        #endregion
        #region RegisterMacEHPort

        public void RegisterMacEHPort()
        {
            TryRegisterMacEHPort().ThrowOnNotOK();
        }

        public HRESULT TryRegisterMacEHPort()
        {
            /*HRESULT RegisterMacEHPort();*/
            return Raw2.RegisterMacEHPort();
        }

        #endregion
        #region SetStartupFlags

        public void SetStartupFlags(STARTUP_FLAGS dwFlags)
        {
            TrySetStartupFlags(dwFlags).ThrowOnNotOK();
        }

        public HRESULT TrySetStartupFlags(STARTUP_FLAGS dwFlags)
        {
            /*HRESULT SetStartupFlags(
            STARTUP_FLAGS dwFlags);*/
            return Raw2.SetStartupFlags(dwFlags);
        }

        #endregion
        #region DllGetActivationFactory

        public ActivationFactory DllGetActivationFactory(int appDomainID, string wszTypeName)
        {
            ActivationFactory factoryResult;
            TryDllGetActivationFactory(appDomainID, wszTypeName, out factoryResult).ThrowOnNotOK();

            return factoryResult;
        }

        public HRESULT TryDllGetActivationFactory(int appDomainID, string wszTypeName, out ActivationFactory factoryResult)
        {
            /*HRESULT DllGetActivationFactory(
            int appDomainID,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszTypeName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IActivationFactory factory);*/
            IActivationFactory factory;
            HRESULT hr = Raw2.DllGetActivationFactory(appDomainID, wszTypeName, out factory);

            if (hr == HRESULT.S_OK)
                factoryResult = factory == null ? null : new ActivationFactory(factory);
            else
                factoryResult = default(ActivationFactory);

            return hr;
        }

        #endregion
        #region ExecuteAssembly

        public int ExecuteAssembly(int dwAppDomainId, string pwzAssemblyPath, int argc, string[] argv)
        {
            int pReturnValue;
            TryExecuteAssembly(dwAppDomainId, pwzAssemblyPath, argc, argv, out pReturnValue).ThrowOnNotOK();

            return pReturnValue;
        }

        public HRESULT TryExecuteAssembly(int dwAppDomainId, string pwzAssemblyPath, int argc, string[] argv, out int pReturnValue)
        {
            /*HRESULT ExecuteAssembly(
            [In] int dwAppDomainId,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzAssemblyPath,
            [In] int argc,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2), In] string[] argv,
            [Out] out int pReturnValue);*/
            return Raw2.ExecuteAssembly(dwAppDomainId, pwzAssemblyPath, argc, argv, out pReturnValue);
        }

        #endregion
        #endregion
        #region ICLRRuntimeHost4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICLRRuntimeHost4 Raw4 => (ICLRRuntimeHost4) Raw;

        #region UnloadAppDomain2

        public int UnloadAppDomain2(int dwAppDomainId, bool fWaitUntilDone)
        {
            int pLatchedExitCode;
            TryUnloadAppDomain2(dwAppDomainId, fWaitUntilDone, out pLatchedExitCode).ThrowOnNotOK();

            return pLatchedExitCode;
        }

        public HRESULT TryUnloadAppDomain2(int dwAppDomainId, bool fWaitUntilDone, out int pLatchedExitCode)
        {
            /*HRESULT UnloadAppDomain2(
            [In] int dwAppDomainId,
            [MarshalAs(UnmanagedType.Bool), In] bool fWaitUntilDone,
            [Out] out int pLatchedExitCode);*/
            return Raw4.UnloadAppDomain2(dwAppDomainId, fWaitUntilDone, out pLatchedExitCode);
        }

        #endregion
        #endregion
    }
}
