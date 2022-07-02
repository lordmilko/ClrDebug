using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that enable developers to debug Silverlight-based applications in the common language runtime (CLR) environment.
    /// </summary>
    /// <remarks>
    /// Mixed-mode (that is, managed and native code) debugging is not supported on non-x86 platforms (such as IA-64 and
    /// AMD64).
    /// </remarks>
    public class CorDebugRemoteTarget : ComObject<ICorDebugRemoteTarget>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugRemoteTarget"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugRemoteTarget(ICorDebugRemoteTarget raw) : base(raw)
        {
        }

        #region ICorDebugRemoteTarget
        #region HostName

        /// <summary>
        /// Returns the fully qualified domain name or IPv4 address of the remote debugging target machine. IPV6 is not supported at this time.
        /// </summary>
        public string HostName
        {
            get
            {
                string szHostNameResult;
                TryGetHostName(out szHostNameResult).ThrowOnNotOK();

                return szHostNameResult;
            }
        }

        /// <summary>
        /// Returns the fully qualified domain name or IPv4 address of the remote debugging target machine. IPV6 is not supported at this time.
        /// </summary>
        /// <param name="szHostNameResult">[out] Buffer that contains the host name or IP address.</param>
        /// <returns>
        /// * S_OK - The host name or IP address was successfully returned.
        /// * E_FAIL (or other E_ return codes) - Unable to return the host name or IP address.
        /// </returns>
        /// <remarks>
        /// This method is implemented by the debugger writer. It must follow the multiple call paradigm: On the first call,
        /// the caller passes null to both cchHostName and szHostName, and pcchHostName returns the size of the required buffer.
        /// On the second call, the size that was previously returned is passed in cchHostName, and an appropriately sized
        /// buffer is passed in szHostName.
        /// </remarks>
        public HRESULT TryGetHostName(out string szHostNameResult)
        {
            /*HRESULT GetHostName([In] int cchHostName, [Out] out int pcchHostName, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szHostName);*/
            int cchHostName = 0;
            int pcchHostName;
            StringBuilder szHostName = null;
            HRESULT hr = Raw.GetHostName(cchHostName, out pcchHostName, szHostName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchHostName = pcchHostName;
            szHostName = new StringBuilder(pcchHostName);
            hr = Raw.GetHostName(cchHostName, out pcchHostName, szHostName);

            if (hr == HRESULT.S_OK)
            {
                szHostNameResult = szHostName.ToString();

                return hr;
            }

            fail:
            szHostNameResult = default(string);

            return hr;
        }

        #endregion
        #endregion
    }
}