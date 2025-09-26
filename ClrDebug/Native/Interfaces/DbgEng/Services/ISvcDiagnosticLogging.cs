using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_DIAGNOSTIC_LOGGING.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("76EB9426-DAE9-4607-8822-45BE93081D6E")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcDiagnosticLogging
    {
        /// <summary>
        /// Sends a message to a diagnostic logging sink. What the host does with the log message is entirely up to it.
        /// </summary>
        [PreserveSig]
        HRESULT Log(
            [In] DiagnosticLogLevel level,
            [In, MarshalAs(UnmanagedType.LPWStr)] string logMessage,
            [In, MarshalAs(UnmanagedType.LPWStr)] string component,
            [In, MarshalAs(UnmanagedType.LPWStr)] string category);
    }
}
