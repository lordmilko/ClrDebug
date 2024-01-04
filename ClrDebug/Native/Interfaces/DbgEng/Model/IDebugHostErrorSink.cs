using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C8FF0F0B-FCE9-467E-8BB3-5D69EF109C00")]
    [ComImport]
    public interface IDebugHostErrorSink
    {
        [PreserveSig]
        HRESULT ReportError(
            [In] ErrorClass errClass,
            [In] HRESULT hrError,
            [In, MarshalAs(UnmanagedType.LPWStr)] string message);
    }
}
