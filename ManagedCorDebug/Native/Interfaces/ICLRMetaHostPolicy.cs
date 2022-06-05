using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides the <see cref="GetRequestedRuntime"/> method, which returns a pointer to a common language runtime (CLR) interface based on a policy criteria, managed assembly, version and configuration file.
    /// </summary>
    /// <remarks>
    /// You can get a reference to this interface by calling the CLRCreateInstance function as shown in the following code:
    /// The .NET Framework 4 hosting API consolidates policies so that hosts with specific needs may use basic functionality
    /// without incurring unintended penalties. For example, many of the MSCorEE.dll exports will bind to a specific CLR,
    /// although a method might not logically require it. The <see cref="METAHOST_POLICY_FLAGS"/> enumeration provides
    /// binding policies that are common to the majority of hosts.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E2190695-77B2-492E-8E14-C4B3A7FDD593")]
    [ComImport]
    public interface ICLRMetaHostPolicy
    {
        /// <summary>
        /// Provides an interface to a preferred version of the common language runtime (CLR) based on a hosting policy, managed assembly, version string, and configuration stream.<para/>
        /// This method does not actually load or activate the CLR, but simply returns the <see cref="ICLRRuntimeInfo"/> interface that represents the policy result.<para/>
        /// This method supersedes the GetRequestedRuntimeInfo, GetRequestedRuntimeVersion, CorBindToRuntimeHost, CorBindToRuntimeByCfg, and GetCORRequiredVersion methods.
        /// </summary>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                   | Description                                                                                                    |
        /// | ------------------------- | -------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                      | The method completed successfully.                                                                             |
        /// | E_POINTER                 | pwzVersion is not null and pcchVersion is null. -or- pwzImageVersion is not null and pcchImageVersion is null. |
        /// | E_INVALIDARG              | dwPolicyFlags does not specify METAHOST_POLICY_HIGHCOMPAT.                                                     |
        /// | ERROR_INSUFFICIENT_BUFFER | The memory allocated to pwzVersion is inadequate. -or- The memory allocated to pwzImageVersion is inadequate.  |
        /// | CLR_E_SHIM_RUNTIMELOAD    | dwPolicyFlags includes METAHOST_POLICY_APPLY_UPGRADE_POLICY, and both pwzVersion and pcchVersion are null.     |
        /// </returns>
        /// <remarks>
        /// When this method succeeds, it has the side effect of combining additional flags with the current default startup
        /// flags of the returned runtime interface, if and only if one or more of the following elements exist in the configuration
        /// stream within the &lt;configuration&gt;&lt;runtime&gt; section: The resulting default STARTUP_FLAGS value is the
        /// bitwise OR combination of the values that are set from the preceding list with the default startup flags.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRequestedRuntime(
            [In] METAHOST_POLICY_FLAGS dwPolicyFlags,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzBinary,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pCfgStream,
            [MarshalAs(UnmanagedType.LPWStr), In] [Out]
            StringBuilder pwzVersion,
            [In] [Out] ref uint pcchVersion,
            [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzImageVersion,
            [In] [Out] ref uint pcchImageVersion,
            out METAHOST_CONFIG_FLAGS pdwConfigFlags,
            [In] ref Guid riid,
            [Out] out object ppRuntime);
    }
}