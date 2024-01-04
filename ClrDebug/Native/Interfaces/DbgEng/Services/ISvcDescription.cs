using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("131E4723-1CC2-4EC7-BB12-9F40EDF63B66")]
    [ComImport]
    public interface ISvcDescription
    {
        [PreserveSig]
        HRESULT GetDescription(
            [Out, MarshalAs(UnmanagedType.BStr)] out string objectDescription);
    }
}
