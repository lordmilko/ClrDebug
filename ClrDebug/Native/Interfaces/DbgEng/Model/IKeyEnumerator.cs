using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("345FA92E-5E00-4319-9CAE-971F7601CDCF")]
    [ComImport]
    public interface IKeyEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject value,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
    }
}
