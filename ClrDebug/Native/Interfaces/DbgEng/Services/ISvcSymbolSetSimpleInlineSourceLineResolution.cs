using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a "simple interface" around the mapping of addresses to lines of code within the image for inlined locations.<para/>
    /// This is an optional interface for symbol sets to implement. A symbol set which handles inlined frames should always implement this interface.<para/>
    /// Reverse mappings require the more advanced ISvcSymbolSetLineResolution interface (not as yet defined) as there are nearly always multiple mappings for an inlined method.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D15DF42A-5E14-4981-8DFE-3379D0198846")]
    [ComImport]
    public interface ISvcSymbolSetSimpleInlineSourceLineResolution
    {
        /// <summary>
        /// FindSourceLineByOffsetAndInlineSymbol Works similarly to ISvcSymbolSetSimpleLineResolution::FindSourceLineByOffset excepting that it passes a specific inline frame to indicate which of multiply nested inline functions to return the line of code for.<para/>
        /// If no inline symbol is provided or the outer function symbol is provided, this operates identically to FindSourceLineByOffset.
        /// </summary>
        [PreserveSig]
        HRESULT FindSourceLineByOffsetAndInlineSymbol(
            [In] long moduleOffset,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbol inlineSymbol,
            [Out, MarshalAs(UnmanagedType.BStr)] out string sourceFileName,
            [Out] out long sourceLine,
            [Out] out long lineDisplacement);
    }
}
