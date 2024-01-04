using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D15DF42A-5E14-4981-8DFE-3379D0198846")]
    [ComImport]
    public interface ISvcSymbolSetSimpleInlineSourceLineResolution
    {
        [PreserveSig]
        HRESULT FindSourceLineByOffsetAndInlineSymbol(
            [In] long moduleOffset,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbol inlineSymbol,
            [Out, MarshalAs(UnmanagedType.BStr)] out string sourceFileName,
            [Out] out long sourceLine,
            [Out] out long lineDisplacement);
    }
}
