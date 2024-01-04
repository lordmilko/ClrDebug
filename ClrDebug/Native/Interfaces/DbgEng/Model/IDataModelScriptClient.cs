using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3B362B0E-89F0-46C6-A663-DFDC95194AEF")]
    [ComImport]
    public interface IDataModelScriptClient
    {
        [PreserveSig]
        HRESULT ReportError(
            [In] ErrorClass errClass,
            [In] HRESULT hrFail,
            [In, MarshalAs(UnmanagedType.LPWStr)] string message,
            [In] int line,
            [In] int position);
    }
}
