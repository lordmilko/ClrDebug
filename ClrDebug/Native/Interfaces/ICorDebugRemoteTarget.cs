using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
    [Guid("C3ED8383-5A49-4CF5-B4B7-01864D9E582D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugRemoteTarget
    {
        /// <summary>
        /// Returns the fully qualified domain name or IPv4 address of the remote debugging target machine. IPV6 is not supported at this time.
        /// </summary>
        /// <param name="cchHostName">[in] The size, in characters, of the szHostName buffer. If this parameter is 0 (zero), szHostName must be null.</param>
        /// <param name="pcchHostName">[out] The number of characters, including a null terminator, in the host name or IP address. This parameter can be null.</param>
        /// <param name="szHostName">[out] Buffer that contains the host name or IP address.</param>
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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHostName(
            [In] int cchHostName,
            [Out] out int pcchHostName,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szHostName);
    }
}
