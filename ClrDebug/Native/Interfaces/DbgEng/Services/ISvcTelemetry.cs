using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("39BCF55E-9150-4BBA-9472-88C972DD7885")]
    [ComImport]
    public interface ISvcTelemetry
    {
        [PreserveSig]
        HRESULT NotifyUsage(
            [In, MarshalAs(UnmanagedType.LPWStr)] string product,
            [In, MarshalAs(UnmanagedType.LPWStr)] string feature,
            [In, MarshalAs(UnmanagedType.LPWStr)] string action);
    }
}
