using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Interface a component directly using debugger script must implement as a multi-way communication channel with the script.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3B362B0E-89F0-46C6-A663-DFDC95194AEF")]
    [ComImport]
    public interface IDataModelScriptClient
    {
        /// <summary>
        /// If an error occurs during execution or invocation of the script, the script provider calls the ReportError method to notify the user interface of the error.<para/>
        /// The script provider may call the ReportError method an arbitrary number of times during an Execute or InvokeMain operation.<para/>
        /// It is up to the client to determine how to present the error information to the user.
        /// </summary>
        /// <param name="errClass">The class of error which is being reported as a member of the ErrorClass enumeration. Further information about this enumeration can be found in the documentation for <see cref="IDebugHostErrorSink"/>.</param>
        /// <param name="hrFail">The HRESULT of the error which occurred. If the domain of the error was not an HRESULT, it should be converted to such by the most appropriate means.</param>
        /// <param name="message">The error message which occurred.</param>
        /// <param name="line">The one based line number of the script where the error occurred.</param>
        /// <param name="position">The one based position (column number) within the line where the error occurred.</param>
        /// <returns>This method returns HRESULT.</returns>
        [PreserveSig]
        HRESULT ReportError(
            [In] ErrorClass errClass,
            [In] HRESULT hrFail,
            [In, MarshalAs(UnmanagedType.LPWStr)] string message,
            [In] int line,
            [In] int position);
    }
}
