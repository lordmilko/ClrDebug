using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3A0957C5-A583-4CE1-ACC4-DFE9CACE0CF0")]
    [ComImport]
    public interface ISvcProcessBasicInformation
    {
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string processName);
        
        [PreserveSig]
        HRESULT GetArguments(
            [Out, MarshalAs(UnmanagedType.BStr)] out string processArguments);
        
        [PreserveSig]
        HRESULT GetParentId(
            [Out] out long parentId);
    }
}
