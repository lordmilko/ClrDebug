using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_TELEMETRY.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("39BCF55E-9150-4BBA-9472-88C972DD7885")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcTelemetry
    {
        /// <summary>
        /// Notify usage of a particular feature (with an optional "action" and "parameter").
        /// </summary>
        [PreserveSig]
        HRESULT NotifyUsage(
            [In, MarshalAs(UnmanagedType.LPWStr)] string product,
            [In, MarshalAs(UnmanagedType.LPWStr)] string feature,
            [In, MarshalAs(UnmanagedType.LPWStr)] string action);
    }
}
