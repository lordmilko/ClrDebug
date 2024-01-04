using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A61ADC36-1ED5-40FE-A976-6A21CD81E811")]
    [ComImport]
    public interface IDebugHostFunctionLocalDetailsEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalDetails localDetails);
    }
}
