using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("996F652A-C052-413E-9406-87884D24FA1D")]
    [ComImport]
    public interface ISvcEventArgumentsSearchPathsChanged
    {
        [PreserveSig]
        HRESULT GetAllPaths(
            [Out, MarshalAs(UnmanagedType.BStr)] out string searchPaths);
    }
}
