using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
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
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICLRMetaHostPolicy
    {
        /// <summary>
        /// Provides an interface to a preferred version of the common language runtime (CLR) based on a hosting policy, managed assembly, version string, and configuration stream.<para/>
        /// This method does not actually load or activate the CLR, but simply returns the <see cref="ICLRRuntimeInfo"/> interface that represents the policy result.<para/>
        /// This method supersedes the GetRequestedRuntimeInfo, GetRequestedRuntimeVersion, CorBindToRuntimeHost, CorBindToRuntimeByCfg, and GetCORRequiredVersion methods.
        /// </summary>
        /// <param name="dwPolicyFlags">[in] Required. Specifies a member of the <see cref="METAHOST_POLICY_FLAGS"/> enumeration, representing a binding policy,
        /// and any number of modifiers. The only policy that is currently available is <see cref="METAHOST_POLICY_FLAGS.HIGHCOMPAT"/>.</param>
        /// <param name="pwzBinary">[in] Optional. Specifies the assembly file path.</param>
        /// <param name="pCfgStream">[in] Optional. Specifies the configuration file as a <see cref="IStream"/>.</param>
        /// <param name="pwzVersion">[in, out] Optional. Specifies or returns the preferred CLR version to be loaded.</param>
        /// <param name="pcchVersion">[in, out] Required. Specifies the expected size of pwzVersion as input, to avoid buffer overruns.<para/>
        /// If pwzVersion is null, pcchVersion contains the expected size of pwzVersion when GetRequestedRuntime returns, to allow pre-allocation; otherwise, pcchVersion contains the number of characters written to pwzVersion.</param>
        /// <param name="pwzImageVersion">[out] Optional. When GetRequestedRuntime returns, contains the CLR version corresponding to the <see cref="ICLRRuntimeInfo"/> interface that is returned.</param>
        /// <param name="pcchImageVersion">[in, out] Optional. Specifies the size of pwzImageVersion as input to avoid buffer overruns. If pwzImageVersion is null, pcchImageVersion contains the required size of pwzImageVersion when GetRequestedRuntime returns, to allow pre-allocation.</param>
        /// <param name="pdwConfigFlags">[out] Optional. If GetRequestedRuntime uses a configuration file during the binding process, when it returns, pdwConfigFlags contains
        /// a <see cref="METAHOST_CONFIG_FLAGS"/> value that indicates whether the &lt;startup&gt; element has the useLegacyV2RuntimeActivationPolicy attribute set, and the value of the attribute.<para/>
        /// Apply the <see cref="METAHOST_CONFIG_FLAGS.LEGACY_V2_ACTIVATION_POLICY_MASK"/> mask to pdwConfigFlags to get the values relevant to useLegacyV2RuntimeActivationPolicy.</param>
        /// <param name="riid">Specifies the interface identifier IID_ICLRRuntimeInfo for the requested ICLRRuntimeInfo interface.</param>
        /// <param name="ppRuntime">[out] When GetRequestedRuntime returns, contains a pointer to the corresponding ICLRRuntimeInfo interface.</param>
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
            [MarshalAs(UnmanagedType.Interface), In] IStream pCfgStream,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4), Out] char[] pwzVersion,
            [In, Out] ref int pcchVersion,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 6), Out] char[] pwzImageVersion,
            [In, Out] ref int pcchImageVersion,
            [Out] out METAHOST_CONFIG_FLAGS pdwConfigFlags,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppRuntime);
    }
}
