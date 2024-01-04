using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("026C9E81-8B9F-4D32-9606-A394EC62B045")]
    [ComImport]
    public interface IDebugHostFunctionLocalStorageEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalStorage storage);
    }
}
