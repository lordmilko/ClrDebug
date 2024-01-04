using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FA7F393E-9A93-42DE-BF41-4ED9C8E46882")]
    [ComImport]
    public interface ISvcSymbolMultipleLocations
    {
        [PreserveSig]
        HRESULT GetLocations(
            [In] long maxSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SvcSymbolLocation[] pLocation,
            [Out] out long pSize);
        
        [PreserveSig]
        HRESULT GetLocationCount(
            [Out] out long pCount);
        
        [PreserveSig]
        HRESULT GetLocationAtIndex(
            [In] long index,
            [Out] out SvcSymbolLocation pLocation);
        
        [PreserveSig]
        HRESULT GetLocationOffsetAtIndex(
            [In] long index,
            [Out] out long pOffset);
        
        [PreserveSig]
        HRESULT GetConstantValueAtIndex(
            [In] long index,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pValue);
    }
}
