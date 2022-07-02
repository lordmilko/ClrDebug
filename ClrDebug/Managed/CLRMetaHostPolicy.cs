using System;
using System.Text;

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
    public class CLRMetaHostPolicy : ComObject<ICLRMetaHostPolicy>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRMetaHostPolicy"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CLRMetaHostPolicy(ICLRMetaHostPolicy raw) : base(raw)
        {
        }

        #region ICLRMetaHostPolicy
        #region GetRequestedRuntime

        /// <summary>
        /// Provides an interface to a preferred version of the common language runtime (CLR) based on a hosting policy, managed assembly, version string, and configuration stream.<para/>
        /// This method does not actually load or activate the CLR, but simply returns the <see cref="ICLRRuntimeInfo"/> interface that represents the policy result.<para/>
        /// This method supersedes the GetRequestedRuntimeInfo, GetRequestedRuntimeVersion, CorBindToRuntimeHost, CorBindToRuntimeByCfg, and GetCORRequiredVersion methods.
        /// </summary>
        /// <param name="dwPolicyFlags">[in] Required. Specifies a member of the <see cref="METAHOST_POLICY_FLAGS"/> enumeration, representing a binding policy,
        /// and any number of modifiers. The only policy that is currently available is <see cref="METAHOST_POLICY_FLAGS.HIGHCOMPAT"/>.</param>
        /// <param name="pwzBinary">[in] Optional. Specifies the assembly file path.</param>
        /// <param name="pCfgStream">[in] Optional. Specifies the configuration file as a <see cref="IStream"/>.</param>
        /// <param name="riid">Specifies the interface identifier IID_ICLRRuntimeInfo for the requested ICLRRuntimeInfo interface.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// When this method succeeds, it has the side effect of combining additional flags with the current default startup
        /// flags of the returned runtime interface, if and only if one or more of the following elements exist in the configuration
        /// stream within the &lt;configuration&gt; &lt;runtime&gt; section: The resulting default STARTUP_FLAGS value is the
        /// bitwise OR combination of the values that are set from the preceding list with the default startup flags.
        /// </remarks>
        public GetRequestedRuntimeResult GetRequestedRuntime(METAHOST_POLICY_FLAGS dwPolicyFlags, string pwzBinary, IStream pCfgStream, Guid riid)
        {
            GetRequestedRuntimeResult result;
            TryGetRequestedRuntime(dwPolicyFlags, pwzBinary, pCfgStream, riid, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Provides an interface to a preferred version of the common language runtime (CLR) based on a hosting policy, managed assembly, version string, and configuration stream.<para/>
        /// This method does not actually load or activate the CLR, but simply returns the <see cref="ICLRRuntimeInfo"/> interface that represents the policy result.<para/>
        /// This method supersedes the GetRequestedRuntimeInfo, GetRequestedRuntimeVersion, CorBindToRuntimeHost, CorBindToRuntimeByCfg, and GetCORRequiredVersion methods.
        /// </summary>
        /// <param name="dwPolicyFlags">[in] Required. Specifies a member of the <see cref="METAHOST_POLICY_FLAGS"/> enumeration, representing a binding policy,
        /// and any number of modifiers. The only policy that is currently available is <see cref="METAHOST_POLICY_FLAGS.HIGHCOMPAT"/>.</param>
        /// <param name="pwzBinary">[in] Optional. Specifies the assembly file path.</param>
        /// <param name="pCfgStream">[in] Optional. Specifies the configuration file as a <see cref="IStream"/>.</param>
        /// <param name="riid">Specifies the interface identifier IID_ICLRRuntimeInfo for the requested ICLRRuntimeInfo interface.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
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
        /// stream within the &lt;configuration&gt; &lt;runtime&gt; section: The resulting default STARTUP_FLAGS value is the
        /// bitwise OR combination of the values that are set from the preceding list with the default startup flags.
        /// </remarks>
        public HRESULT TryGetRequestedRuntime(METAHOST_POLICY_FLAGS dwPolicyFlags, string pwzBinary, IStream pCfgStream, Guid riid, out GetRequestedRuntimeResult result)
        {
            /*HRESULT GetRequestedRuntime(
            [In] METAHOST_POLICY_FLAGS dwPolicyFlags,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzBinary,
            [MarshalAs(UnmanagedType.Interface), In] IStream pCfgStream,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pwzVersion,
            [In, Out] ref int pcchVersion,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pwzImageVersion,
            [In, Out] ref int pcchImageVersion,
            [Out] out METAHOST_CONFIG_FLAGS pdwConfigFlags,
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppRuntime);*/
            StringBuilder pwzVersion = null;
            int pcchVersion = default(int);
            StringBuilder pwzImageVersion = null;
            int pcchImageVersion = default(int);
            METAHOST_CONFIG_FLAGS pdwConfigFlags;
            object ppRuntime;
            HRESULT hr = Raw.GetRequestedRuntime(dwPolicyFlags, pwzBinary, pCfgStream, pwzVersion, ref pcchVersion, pwzImageVersion, ref pcchImageVersion, out pdwConfigFlags, ref riid, out ppRuntime);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            pwzVersion = new StringBuilder(pcchVersion);
            pwzImageVersion = new StringBuilder(pcchImageVersion);
            hr = Raw.GetRequestedRuntime(dwPolicyFlags, pwzBinary, pCfgStream, pwzVersion, ref pcchVersion, pwzImageVersion, ref pcchImageVersion, out pdwConfigFlags, ref riid, out ppRuntime);

            if (hr == HRESULT.S_OK)
            {
                result = new GetRequestedRuntimeResult(pwzVersion.ToString(), pwzImageVersion.ToString(), pdwConfigFlags, ppRuntime);

                return hr;
            }

            fail:
            result = default(GetRequestedRuntimeResult);

            return hr;
        }

        #endregion
        #endregion
    }
}