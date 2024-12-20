using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_EXCEPTION_FORMATTER.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B181A69C-9D85-4747-8CF8-2ADF53CF750A")]
    [ComImport]
    public interface ISvcExceptionFormatter
    {
        /// <summary>
        /// Gets a description of the given exceptional event (Win32 exception, Linux signal, etc...).
        /// </summary>
        [PreserveSig]
        HRESULT GetDescription(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExceptionInformation exceptionInformation,
            [Out, MarshalAs(UnmanagedType.BStr)] out string exceptionDescription);
    }
}
