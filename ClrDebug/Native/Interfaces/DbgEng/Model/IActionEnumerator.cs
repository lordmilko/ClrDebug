using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3DEC5C44-F63A-4CA6-90F0-FD5C269FDA59")]
    [ComImport]
    public interface IActionEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string keyName,
            [Out, MarshalAs(UnmanagedType.BStr)] out string actionName,
            [Out, MarshalAs(UnmanagedType.BStr)] out string actionDescription,
            [Out, MarshalAs(UnmanagedType.U1)] out bool actionIsDefault,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject actionMethod,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadta);
    }
}
