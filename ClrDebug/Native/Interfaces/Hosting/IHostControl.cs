using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using System.Security;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for configuring the loading of assemblies, and for determining which hosting interfaces the host supports.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("02CA073C-7079-4860-880A-C2F7A449C991")]
    [SuppressUnmanagedCodeSecurity]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IHostControl
    {
        /// <summary>
        /// Gets an interface pointer to the host's implementation of the interface with the specified IID.
        /// </summary>
        /// <param name="riid">[in] The IID of the interface that the common language runtime (CLR) is querying for.</param>
        /// <param name="ppObject">[out] A pointer to the host-implemented interface, or null if the host does not support this interface.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | GetHostManager returned successfully.                                                                                                                                                      |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_INVALIDARG           | The requested IID is not valid.                                                                                                                                                            |
        /// | E_NOINTERFACE          | The requested interface is not supported.                                                                                                                                                  |
        /// </returns>
        /// <remarks>
        /// The CLR queries the host to determine whether it supports one or more of the following interfaces: If the host
        /// supports the specified interface, it sets ppObject to its implementation of that interface. Otherwise, it sets
        /// ppObject to null. The CLR does not call Release on host managers, even when you shut it down.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall)]
        HRESULT GetHostManager(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppObject);

        /// <summary>
        /// Notifies the host that an application domain has been created.
        /// </summary>
        /// <param name="dwAppDomainID">[in] The numeric identifier of the selected <see cref="AppDomain"/>.</param>
        /// <param name="pUnkAppDomainManager">[in] A pointer to the System.AppDomainManager object that the host implements as IUnknown.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetAppDomainManager returned successfully.                                                                                                                                                 |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The System.AppDomainManager provides the host with a mechanism to bootstrap into managed code and to control
        /// the creation and settings of each <see cref="AppDomain"/>. The System.AppDomainManager is loaded into each
        /// <see cref="AppDomain"/> when that <see cref="AppDomain"/> is created. If it chooses, the CLR notifies the host
        /// that the application domain has been created by setting the value of the pUnkAppDomainManager parameter. In its
        /// implementation of the SetAppDomainManager method, the host can set the assembly name and type for the application
        /// domain manager.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall)]
        HRESULT SetAppDomainManager(
            [In] int dwAppDomainID,
            [MarshalAs(UnmanagedType.Interface), In] object pUnkAppDomainManager);
    }
}
