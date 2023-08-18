using System;
using System.Reflection;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("712AB73F-2C22-4807-AD7E-F501D7B72C2D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICLRRuntimeHost2 : ICLRRuntimeHost
    {
#if !GENERATED_MARSHALLING
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
        [PreserveSig]
        new HRESULT Start();

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
        [PreserveSig]
        new HRESULT Stop();

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
        [PreserveSig]
        new HRESULT SetHostControl(
            [MarshalAs(UnmanagedType.Interface), In] IHostControl pHostControl);

        /// <summary>
        /// Gets an interface pointer of type <see cref="ICLRControl"/> that hosts can use to customize aspects of the common language runtime (CLR).
        /// </summary>
        /// <param name="pCLRControl">[out] An interface pointer of type <see cref="ICLRControl"/> that enables hosts to configure additional aspects of the CLR.</param>
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
        /// <see cref="ICLRControl"/> provides the <see cref="ICLRControl.GetCLRManager"/> method, which enables the host to get an interface
        /// pointer to one of the manager types.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetCLRControl(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICLRControl pCLRControl);

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
        /// <see cref="GetCurrentAppDomainId"/>. This identifier corresponds to the <see cref="AppDomain.Id"/> property of
        /// the managed <see cref="AppDomain"/> type.
        /// </remarks>
        [PreserveSig]
        new HRESULT UnloadAppDomain(
            [In] int dwAppDomainID,
            [In, MarshalAs(UnmanagedType.Bool)] bool fWaitUntilDone);

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
        /// to the value of the <see cref="AppDomain.Id"/> property, by calling <see cref="GetCurrentAppDomainId"/>.
        /// </remarks>
        [PreserveSig]
        new HRESULT ExecuteInAppDomain(
            [In] int dwAppDomainID,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FExecuteInAppDomainCallback pCallback,
            [In] IntPtr cookie);

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
        [PreserveSig]
        new HRESULT GetCurrentAppDomainId(
            [Out] out int pdwAppDomainId);

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
        [PreserveSig]
        new HRESULT ExecuteApplication(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzAppFullName,
            [In] int dwManifestPaths,
            [MarshalAs(UnmanagedType.LPWStr), In] string ppwzManifestPaths,
            [In] int dwActivationData,
            [MarshalAs(UnmanagedType.LPWStr), In] string ppwzActivationData,
            [Out] out int pReturnValue);

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
        [PreserveSig]
        new HRESULT ExecuteInDefaultAppDomain(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzAssemblyPath,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzTypeName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzMethodName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzArgument,
            [Out] out int pReturnValue);
#endif

        [PreserveSig]
        HRESULT CreateAppDomainWithManager(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszFriendlyName,
            [In] APPDOMAIN_SECURITY_FLAGS dwFlags,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszAppDomainManagerAssemblyName,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszAppDomainManagerTypeName,
            [In] int nProperties,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 4), In] string[] pPropertyNames,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 4), In] string[] pPropertyValues,
            [Out] out int pAooDomainID);

        [PreserveSig]
        HRESULT CreateDelegate(
            [In] int appDomainID,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszAssemblyName,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszClassName,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszMethodName,
            [Out] out IntPtr fnPtr);

        [PreserveSig]
        HRESULT Authenticate(
            [In] long authKey);

        [PreserveSig]
        HRESULT RegisterMacEHPort();

        [PreserveSig]
        HRESULT SetStartupFlags(
            STARTUP_FLAGS dwFlags);

        [PreserveSig]
        HRESULT DllGetActivationFactory(
            int appDomainID,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszTypeName,
            [Out] out IActivationFactory factory);

        [PreserveSig]
        HRESULT ExecuteAssembly(
            [In] int dwAppDomainId,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzAssemblyPath,
            [In] int argc,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2), In] string[] argv,
            [Out] out int pReturnValue);
    }
}
