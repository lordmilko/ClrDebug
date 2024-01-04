using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("95BA00E2-704A-4FE2-A8F1-A7E7D8FB0941")]
    [ComImport]
    public interface IDataModelScriptProviderEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptProvider provider);
    }
}
