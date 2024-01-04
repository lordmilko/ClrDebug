using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4760A68C-DCAA-432E-A787-1063C9FA0D3D")]
    [ComImport]
    public interface ISvcSymbolSetInlineScopeResolution
    {
        [PreserveSig]
        HRESULT FindScopeByOffsetAndInlineSymbol(
            [In] long moduleOffset,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbol inlineSymbol,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScope scope);
        
        [PreserveSig]
        HRESULT FindScopeFrameForInlineSymbol(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext frameContext,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbol inlineSymbol,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScopeFrame scopeFrame);
    }
}
