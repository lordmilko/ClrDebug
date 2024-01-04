using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An interface to which errors will be sinked. An interface implemented by callers to receive errors from certain portions of the host and data model.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C8FF0F0B-FCE9-467E-8BB3-5D69EF109C00")]
    [ComImport]
    public interface IDebugHostErrorSink
    {
        /// <summary>
        /// The ReportError method is a callback on the error sink to notify it that an error has occurred and allow the sink to route the error to whatever UI or mechanism is appropriate.
        /// </summary>
        /// <param name="errClass">An enumeration of type ErrorClass which indicates what class the error is (e.g.: warning or error)</param>
        /// <param name="hrError">The HRESULT of the error which occurred.</param>
        /// <param name="message">An optional message associated with the error.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT ReportError(
            [In] ErrorClass errClass,
            [In] HRESULT hrError,
            [In, MarshalAs(UnmanagedType.LPWStr)] string message);
    }
}
