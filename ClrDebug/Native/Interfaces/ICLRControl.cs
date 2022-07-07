using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that allow a host to get references to, and configure aspects of, the common language runtime (CLR).
    /// </summary>
    [Guid("9065597E-D1A1-4FB2-B6BA-7E1FCE230F61")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICLRControl
    {
        /// <summary>
        /// Gets an interface pointer to an instance of any of the manager types the host can use to configure the common language runtime (CLR).
        /// </summary>
        /// <param name="riid">[in] The IID of the manager type to return. The following IID values are supported.</param>
        /// <param name="ppObject">[out] An interface pointer to the requested manager, or null, if an invalid manager type was requested.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                 |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The method returned successfully.                                                                                                                                                           |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                  |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                         |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                           |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                    |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_NOINTERFACE          | The interface type is not supported.                                                                                                                                                        |
        /// </returns>
        [PreserveSig]
        HRESULT GetCLRManager(
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppObject);

        /// <summary>
        /// Sets a type derived from System.AppDomainManager as the type for application domain managers.
        /// </summary>
        /// <param name="pwzAppDomainManagerAssembly">[in] The name of the assembly in which the requested type derived from System.AppDomainManager is implemented.</param>
        /// <param name="pwzAppDomainManagerType">[in] The name of the type implemented in the pwzAppDomainManagerAssembly parameter that implements the capabilities of System.AppDomainManager.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                 |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The method returned successfully.                                                                                                                                                           |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                        |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                         |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                           |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                    |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall)]
        HRESULT SetAppDomainManagerType(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzAppDomainManagerAssembly,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzAppDomainManagerType);
    }
}