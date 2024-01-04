using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2559B271-BFE2-4ECC-9FFB-DA5F49D17F3D")]
    [ComImport]
    public interface ISvcWindowsExceptionTranslation
    {
        [PreserveSig]
        HRESULT TranslateException(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit execUnit,
            [In, Out] ref EXCEPTION_RECORD64 exceptionRecord);
    }
}
