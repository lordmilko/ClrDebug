using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("63832802-2DB3-4DE7-B76C-197AC15B5EC6")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IFilteredNamespacePropertyToken
    {
        [PreserveSig]
        HRESULT RemoveFilter();
        
        [PreserveSig]
        HRESULT GetFilter(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelMethod ppFilter);
        
        [PreserveSig]
        HRESULT TrySetFilter(
            [In, MarshalAs(UnmanagedType.Interface)] IModelMethod pFilter);
    }
}
