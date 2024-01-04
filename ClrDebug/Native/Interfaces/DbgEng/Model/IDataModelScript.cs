using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7B4D30FC-B14A-49F8-8D87-D9A1480C97F7")]
    [ComImport]
    public interface IDataModelScript
    {
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string scriptName);
        
        [PreserveSig]
        HRESULT Rename(
            [In, MarshalAs(UnmanagedType.LPWStr)] string scriptName);
        
        [PreserveSig]
        HRESULT Populate(
            [In, MarshalAs(UnmanagedType.Interface)] IStream contentStream);
        
        [PreserveSig]
        HRESULT Execute(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptClient client);
        
        [PreserveSig]
        HRESULT Unlink();
        
        [PreserveSig]
        HRESULT IsInvocable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isInvocable);
        
        [PreserveSig]
        HRESULT InvokeMain(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptClient client);
    }
}
