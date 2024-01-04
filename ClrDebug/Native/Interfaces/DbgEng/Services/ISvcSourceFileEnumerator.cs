using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("55ED5393-5417-4582-BA85-850D58D5ECF0")]
    [ComImport]
    public interface ISvcSourceFileEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFile sourceFile);
    }
}
