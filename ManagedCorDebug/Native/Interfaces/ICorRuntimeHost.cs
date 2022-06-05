using System;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Security.Principal;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that enable the host to start and stop the common language runtime (CLR) explicitly, to create and configure application domains, to access the default domain, and to enumerate all domains running in the process.<para/>
    /// In the .NET Framework version 2.0, this interface is superseded by <see cref="ICLRRuntimeHost"/>.
    /// </summary>
    [Guid("CB2F6722-AB3A-11d2-9C40-00C04FA30A3E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorRuntimeHost
    {
        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [PreserveSig]
        HRESULT CreateLogicalThreadState();

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [PreserveSig]
        HRESULT DeleteLogicalThreadState();

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="pFiberCookie">[in] Cookie that indicates the fiber to use.</param>
        [PreserveSig]
        HRESULT SwitchInLogicalThreadState([In] ref uint pFiberCookie);

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="FiberCookie">[out] Cookie that indicates the fiber being switched out.</param>
        [PreserveSig]
        HRESULT SwitchOutLogicalThreadState(out uint FiberCookie);

        /// <summary>
        /// Retrieves the number of locks that current thread holds. This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="pCount">[out] A pointer to the number of locks that the current thread holds.</param>
        [PreserveSig]
        HRESULT LocksHeldByLogicalThread(out uint pCount);

        /// <summary>
        /// Maps the specified file into memory. This method is obsolete.
        /// </summary>
        /// <param name="hFile">[in] The handle of the file to be mapped.</param>
        /// <param name="hMapAddress">[out] The starting memory address at which to begin mapping the file.</param>
        [PreserveSig]
        HRESULT MapFile(IntPtr hFile, out IntPtr hMapAddress);

        /// <summary>
        /// Gets an object that allows the host to specify the callback configuration of the common language runtime (CLR).
        /// </summary>
        /// <param name="pConfiguration">[out] A pointer to the address of an <see cref="ICorConfiguration"/> object that can be used to configure the CLR.</param>
        /// <remarks>
        /// The CLR must be configured prior to its initialization; otherwise, the GetConfiguration method returns an HRESULT
        /// indicating an error.
        /// </remarks>
        [PreserveSig]
        HRESULT GetConfiguration([MarshalAs(UnmanagedType.IUnknown)] out object pConfiguration);

        /// <summary>
        /// Starts the common language runtime (CLR).
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                            |
        /// | ---------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                          |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                      |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                             |
        /// </returns>
        /// <remarks>
        /// It is typically not necessary to call the Start method, because the CLR starts automatically upon the first request
        /// to run managed code.
        /// </remarks>
        [PreserveSig]
        HRESULT Start();

        /// <summary>
        /// Stops the execution of code in the runtime for the current process.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        /// <remarks>
        /// It is typically unnecessary to call the Stop method, because the code stops executing when the process exits.
        /// </remarks>
        [PreserveSig]
        HRESULT Stop();

        /// <summary>
        /// Creates an application domain. The caller receives an interface pointer of type <see cref="_AppDomain"/> to an instance of type <see cref="AppDomain"/>.
        /// </summary>
        /// <param name="pwzFriendlyName">[in] An optional parameter used to give a friendly name to the domain. This friendly name can be displayed in user interfaces such as debuggers to identify the domain.</param>
        /// <param name="pIdentityArray">[in] An optional array of pointers to IIdentity instances that represent evidence mapped through security policy to establish a permission set.<para/>
        /// An IIdentity object can be obtained by calling the <see cref="CreateEvidence"/> method.</param>
        /// <param name="pAppDomain">[out] An interface pointer of type <see cref="_AppDomain"/> to an instance of <see cref="AppDomain"/> that can be used to further control the domain.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        [PreserveSig]
        HRESULT CreateDomain(string pwzFriendlyName, [MarshalAs(UnmanagedType.IUnknown)] object pIdentityArray, [MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);

        /// <summary>
        /// Gets an interface pointer of type <see cref="_AppDomain"/> that represents the default domain for the current process.
        /// </summary>
        /// <param name="pAppDomain">[out] An interface pointer of type <see cref="_AppDomain"/> to the <see cref="AppDomain"/> instance that represents the default application domain for the process.<para/>
        /// This pointer is typed IUnknown, so callers should generally call QueryInterface to obtain an interface pointer of type <see cref="_AppDomain"/>.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        [PreserveSig]
        HRESULT GetDefaultDomain([MarshalAs(UnmanagedType.IUnknown)] object pAppDomain);

        /// <summary>
        /// Gets an enumerator for the domains in the current process.
        /// </summary>
        /// <param name="hEnum">[out] An enumerator for the domains.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        [PreserveSig]
        HRESULT EnumDomains(out IntPtr hEnum);

        /// <summary>
        /// Gets an interface pointer to the next domain in the enumeration.
        /// </summary>
        /// <param name="hEnum">[in] The enumerator that was obtained through a call to <see cref="EnumDomains"/>.</param>
        /// <param name="pAppDomain">[out] An interface pointer to the <see cref="_AppDomain"/> type that represents the next domain in the enumeration, or null, if no more domains exist.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete, or there are no more domains in the enumeration.                                                                                                                               |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        [PreserveSig]
        HRESULT NextDomain(IntPtr hEnum, [MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);

        /// <summary>
        /// Resets a domain enumerator back to the beginning of the domain list.
        /// </summary>
        /// <param name="hEnum">[in] The enumerator to reset.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        [PreserveSig]
        HRESULT CloseEnum(IntPtr hEnum);

        /// <summary>
        /// Creates an application domain. The caller receives an interface pointer, of type <see cref="_AppDomain"/>, to an instance of type <see cref="AppDomain"/>.<para/>
        /// This method allows the caller to pass an IAppDomainSetup instance to configure additional features of the returned <see cref="_AppDomain"/> instance.
        /// </summary>
        /// <param name="pwzFriendlyName">[in] An optional parameter used to give a friendly name to the domain. This friendly name can be displayed in user interfaces such as debuggers to identify the domain.</param>
        /// <param name="pSetup">[in] An optional interface pointer of type IAppDomainSetup, obtained by a call to the <see cref="CreateDomainSetup"/> method.</param>
        /// <param name="pEvidence">[in] An optional array of pointers to IIdentity instances that represent evidence mapped through security policy to establish a permission set.<para/>
        /// An IIdentity object can be obtained by calling the <see cref="CreateEvidence"/> method.</param>
        /// <param name="pAppDomain">[out] An interface pointer of type <see cref="_AppDomain"/> to an instance of <see cref="AppDomain"/> that can be used to further control the domain.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        /// <remarks>
        /// CreateDomainEx extends the capabilities of <see cref="CreateDomain"/> by allowing the caller to pass in an IAppDomainSetup
        /// instance with property values for configuring the application domain.
        /// </remarks>
        [PreserveSig]
        HRESULT CreateDomainEx(
            [In] string pwzFriendlyName,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pSetup,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pEvidence,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);

        /// <summary>
        /// Gets an interface pointer of type IAppDomainSetup to an <see cref="AppDomainSetup"/> instance. IAppDomainSetup provides methods to configure aspects of an application domain before it is created.
        /// </summary>
        /// <param name="pAppDomainSetup">[out] An interface pointer to an <see cref="AppDomainSetup"/> instance. This parameter is typed as IUnknown, so callers should generally call QueryInterface on this pointer to obtain an interface pointer of type IAppDomainSetup.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        /// <remarks>
        /// The pointer returned from this method is typically passed as a parameter to the <see cref="CreateDomainEx"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT CreateDomainSetup([MarshalAs(UnmanagedType.IUnknown)] out object pAppDomainSetup);

        /// <summary>
        /// Gets an interface pointer of type <see cref="IIdentity"/>, which allows the host to create security evidence to pass to the <see cref="CreateDomain"/> or <see cref="CreateDomainEx"/> method.
        /// </summary>
        /// <param name="pEvidence">[out] A interface pointer to an <see cref="IIdentity"/> instance used to create security evidence. This pointer is typed IUnknown, so callers should typically call QueryInterface on this interface to obtain a pointer to an <see cref="IIdentity"/>.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        /// <remarks>
        /// This method returns an empty collection that cannot be populated from native code. You should use the <see cref="Evidence"/>
        /// method instead.
        /// </remarks>
        [PreserveSig]
        HRESULT CreateEvidence([MarshalAs(UnmanagedType.IUnknown)] out object pEvidence);

        /// <summary>
        /// Unloads the specified application domain from the current process.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer of type <see cref="_AppDomain"/> that represents the domain to be unloaded.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        [PreserveSig]
        HRESULT UnloadDomain([MarshalAs(UnmanagedType.IUnknown)] object pAppDomain);

        /// <summary>
        /// Gets an interface pointer of type <see cref="AppDomain"/> that represents the domain loaded on the current thread.
        /// </summary>
        /// <param name="pAppDomain">[out] A pointer of type <see cref="AppDomain"/> that represents the thread's current application domain. This pointer is typed IUnknown, so callers should generally call QueryInterface to obtain a pointer of type <see cref="_AppDomain"/>.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        [PreserveSig]
        HRESULT CurrentDomain([MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);
    }
}