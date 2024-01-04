using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B181A69C-9D85-4747-8CF8-2ADF53CF750A")]
    [ComImport]
    public interface ISvcExceptionFormatter
    {
        [PreserveSig]
        HRESULT GetDescription(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExceptionInformation exceptionInformation,
            [Out, MarshalAs(UnmanagedType.BStr)] out string exceptionDescription);
    }
}
