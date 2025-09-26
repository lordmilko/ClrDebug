using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: (Various Components).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("432BEA74-794D-46FB-AC50-EBECA9AA865C")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcDiagnosticLoggableControl
    {
        /// <summary>
        /// Gets the current diagnostic logging level for this service.
        /// </summary>
        [PreserveSig]
        DiagnosticLogLevel GetLoggingLevel();

        /// <summary>
        /// Sets the current diagnostic logging level for this service.
        /// </summary>
        [PreserveSig]
        void SetLoggingLevel(
            [In] DiagnosticLogLevel level);
    }
}
