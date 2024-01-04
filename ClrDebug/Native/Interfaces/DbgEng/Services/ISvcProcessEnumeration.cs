using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3CFA6328-A170-4D90-BCE2-C9FDB898C1F5")]
    [ComImport]
    public interface ISvcProcessEnumeration
    {
        [PreserveSig]
        HRESULT FindProcess(
            [In] long processKey,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess targetProcess);
        
        [PreserveSig]
        HRESULT EnumerateProcesses(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcessEnumerator targetProcessEnumerator);
    }
}
