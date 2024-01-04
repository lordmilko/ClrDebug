using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8803404F-DFE5-40C5-A8B8-F39AEB04CF86")]
    [ComImport]
    public interface ISvcSymbolSetSimpleSourceLineResolution
    {
        [PreserveSig]
        HRESULT FindOffsetBySourceLine(
            [In, MarshalAs(UnmanagedType.LPWStr)] string sourceFileName,
            [In] long line,
            [Out] out long moduleOffset,
            [Out, MarshalAs(UnmanagedType.BStr)] out string actualSourceFileName,
            [Out] out long returnedLine);
        
        [PreserveSig]
        HRESULT FindSourceLineByOffset(
            [In] long moduleOffset,
            [Out, MarshalAs(UnmanagedType.BStr)] out string sourceFileName,
            [Out] out long sourceLine,
            [Out] out long lineDisplacement);
    }
}
