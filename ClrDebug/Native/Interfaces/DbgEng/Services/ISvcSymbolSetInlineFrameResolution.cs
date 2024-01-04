using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CB416186-14D7-4DED-8EC2-9B45CBF06845")]
    [ComImport]
    public interface ISvcSymbolSetInlineFrameResolution
    {
        [PreserveSig]
        HRESULT GetInlineDepthAtOffset(
            [In] long moduleOffset,
            [Out] out long inlineDepth);
        
        [PreserveSig]
        HRESULT GetInlinedFunctionAtOffset(
            [In] long moduleOffset,
            [In] long inlineDepth,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol inlineFunction);
    }
}
