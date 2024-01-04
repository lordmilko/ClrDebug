using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7D90CF81-BEE2-4B91-9D49-8FEC0F7D56D1")]
    [ComImport]
    public interface IDataModelScript2 : IDataModelScript
    {
        [PreserveSig]
        new HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string scriptName);
        
        [PreserveSig]
        new HRESULT Rename(
            [In, MarshalAs(UnmanagedType.LPWStr)] string scriptName);
        
        [PreserveSig]
        new HRESULT Populate(
            [In, MarshalAs(UnmanagedType.Interface)] IStream contentStream);
        
        [PreserveSig]
        new HRESULT Execute(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptClient client);
        
        [PreserveSig]
        new HRESULT Unlink();
        
        [PreserveSig]
        new HRESULT IsInvocable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isInvocable);
        
        [PreserveSig]
        new HRESULT InvokeMain(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptClient client);
        
        [PreserveSig]
        HRESULT GetScriptFullFilePathName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string scriptFullPathName);
        
        [PreserveSig]
        HRESULT SetScriptFullFilePathName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string scriptFullPathName);
    }
}
