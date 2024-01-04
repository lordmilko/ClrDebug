using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F3E0DAE9-6385-41BE-9EA6-75BCFBF5B727")]
    [ComImport]
    public interface ISvcSearchPaths
    {
        [PreserveSig]
        HRESULT SetAllPaths(
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPaths);
        
        [PreserveSig]
        HRESULT GetAllPaths(
            [Out, MarshalAs(UnmanagedType.BStr)] out string searchPaths);
    }
}
