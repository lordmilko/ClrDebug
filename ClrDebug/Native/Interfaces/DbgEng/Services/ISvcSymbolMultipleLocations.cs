using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FA7F393E-9A93-42DE-BF41-4ED9C8E46882")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcSymbolMultipleLocations
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
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            [Out] out object pValue);
    }
}
