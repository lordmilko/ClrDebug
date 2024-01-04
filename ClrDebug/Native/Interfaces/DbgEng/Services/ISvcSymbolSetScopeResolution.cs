using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E1EE646E-0480-4DB3-8982-7DE87ED5B174")]
    [ComImport]
    public interface ISvcSymbolSetScopeResolution
    {
        [PreserveSig]
        HRESULT GetGlobalScope(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScope scope);
        
        [PreserveSig]
        HRESULT FindScopeByOffset(
            [In] long moduleOffset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScope scope);
        
        [PreserveSig]
        HRESULT FindScopeFrame(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext registerContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScopeFrame scopeFrame);
    }
}
