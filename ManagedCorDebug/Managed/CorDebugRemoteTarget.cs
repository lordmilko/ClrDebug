using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
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
        public CorDebugRemoteTarget(ICorDebugRemoteTarget raw) : base(raw)
        {
        }

        #region ICorDebugRemoteTarget
        #region GetHostName

        /// <summary>
        /// Returns the fully qualified domain name or IPv4 address of the remote debugging target machine. IPV6 is not supported at this time.
        /// </summary>
        /// <returns>[out] Buffer that contains the host name or IP address.</returns>
        /// <remarks>
        /// This method is implemented by the debugger writer. It must follow the multiple call paradigm: On the first call,
        /// the caller passes null to both cchHostName and szHostName, and pcchHostName returns the size of the required buffer.
        /// On the second call, the size that was previously returned is passed in cchHostName, and an appropriately sized
        /// buffer is passed in szHostName.
        /// </remarks>
        public string GetHostName()
        {
            HRESULT hr;
            string szHostNameResult;

            if ((hr = TryGetHostName(out szHostNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szHostNameResult;
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
            /*HRESULT GetHostName([In] int cchHostName, out int pcchHostName, [Out] StringBuilder szHostName);*/
            int cchHostName = 0;
            int pcchHostName;
            StringBuilder szHostName = null;
            HRESULT hr = Raw.GetHostName(cchHostName, out pcchHostName, szHostName);

            if (hr != HRESULT.S_FALSE)
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