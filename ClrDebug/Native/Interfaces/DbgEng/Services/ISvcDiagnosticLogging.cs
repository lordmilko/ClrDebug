using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("76EB9426-DAE9-4607-8822-45BE93081D6E")]
    [ComImport]
    public interface ISvcDiagnosticLogging
    {
        [PreserveSig]
        HRESULT Log(
            [In] DiagnosticLogLevel level,
            [In, MarshalAs(UnmanagedType.LPWStr)] string logMessage,
            [In, MarshalAs(UnmanagedType.LPWStr)] string component,
            [In, MarshalAs(UnmanagedType.LPWStr)] string category);
    }
}
