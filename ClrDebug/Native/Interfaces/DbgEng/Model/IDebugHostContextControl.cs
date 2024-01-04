using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EEB8FB43-B44E-4B0F-B871-65F0886FCAF2")]
    [ComImport]
    public interface IDebugHostContextControl
    {
        [PreserveSig]
        HRESULT SwitchTo();
        
        [PreserveSig]
        HRESULT GetContextAlternator(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContextAlternator contextAlternator);
    }
}
