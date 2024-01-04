using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("58AC3F3F-0886-4AA0-A074-9635CC0DDE95")]
    [ComImport]
    public interface ISvcSymbolType
    {
        [PreserveSig]
        HRESULT GetTypeKind(
            [Out] out SvcSymbolTypeKind kind);
        
        [PreserveSig]
        HRESULT GetSize(
            [Out] out long size);
        
        [PreserveSig]
        HRESULT GetBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol baseType);
        
        [PreserveSig]
        HRESULT GetUnmodifiedType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol unmodifiedType);
        
        [PreserveSig]
        HRESULT GetIntrinsicType(
            [Out] out SvcSymbolIntrinsicKind kind,
            [Out] out int packingSize);
        
        [PreserveSig]
        HRESULT GetPointerKind(
            [Out] out SvcSymbolPointerKind kind);
        
        [PreserveSig]
        HRESULT GetMemberType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolType memberType);
        
        [PreserveSig]
        HRESULT GetArrayDimensionality(
            [Out] out long arrayDimensionality);
        
        [PreserveSig]
        HRESULT GetArrayDimensions(
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SvcSymbolArrayDimension[] pDimensions);
        
        [PreserveSig]
        HRESULT GetArrayHeaderSize(
            [Out] out long arrayHeaderSize);
        
        [PreserveSig]
        HRESULT GetFunctionReturnType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol returnType);
        
        [PreserveSig]
        HRESULT GetFunctionParameterTypeCount(
            [Out] out long count);
        
        [PreserveSig]
        HRESULT GetFunctionParameterTypeAt(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol parameterType);
    }
}
