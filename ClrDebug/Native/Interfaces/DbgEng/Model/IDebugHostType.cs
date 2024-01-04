using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
using ClrDebug.TypeLib;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3AADC353-2B14-4ABB-9893-5E03458E07EE")]
    [ComImport]
    public interface IDebugHostType : IDebugHostSymbol
    {
        [PreserveSig]
        new HRESULT GetContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext context);
        
        [PreserveSig]
        new HRESULT EnumerateChildren(
            [In] SymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator ppEnum);
        
        [PreserveSig]
        new HRESULT GetSymbolKind(
            [Out] out SymbolKind kind);
        
        [PreserveSig]
        new HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolName);
        
        [PreserveSig]
        new HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);
        
        [PreserveSig]
        new HRESULT GetContainingModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule containingModule);
        
        [PreserveSig]
        new HRESULT CompareAgainst(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbol pComparisonSymbol,
            [In] int comparisonFlags,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pMatches);
        
        [PreserveSig]
        HRESULT GetTypeKind(
            [Out] out TypeKind kind);
        
        [PreserveSig]
        HRESULT GetSize(
            [Out] out long size);
        
        [PreserveSig]
        HRESULT GetBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType baseType);
        
        [PreserveSig]
        HRESULT GetHashCode(
            [Out] out int hashCode);
        
        [PreserveSig]
        HRESULT GetIntrinsicType(
            [Out] out IntrinsicKind intrinsicKind,
            [Out] out VARENUM carrierType);
        
        [PreserveSig]
        HRESULT GetBitField(
            [Out] out int lsbOfField,
            [Out] out int lengthOfField);
        
        [PreserveSig]
        HRESULT GetPointerKind(
            [Out] out PointerKind pointerKind);
        
        [PreserveSig]
        HRESULT GetMemberType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType memberType);
        
        [PreserveSig]
        HRESULT CreatePointerTo(
            [In] PointerKind kind,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType newType);
        
        [PreserveSig]
        HRESULT GetArrayDimensionality(
            [Out] out long arrayDimensionality);
        
        [PreserveSig]
        HRESULT GetArrayDimensions(
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ArrayDimension[] pDimensions);
        
        [PreserveSig]
        HRESULT CreateArrayOf(
            [In] long dimensions,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ArrayDimension[] pDimensions,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType newType);
        
        [PreserveSig]
        HRESULT GetFunctionCallingConvention(
            [Out] out CallingConventionKind conventionKind);
        
        [PreserveSig]
        HRESULT GetFunctionReturnType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType returnType);
        
        [PreserveSig]
        HRESULT GetFunctionParameterTypeCount(
            [Out] out long count);
        
        [PreserveSig]
        HRESULT GetFunctionParameterTypeAt(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType parameterType);
        
        [PreserveSig]
        HRESULT IsGeneric(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isGeneric);
        
        [PreserveSig]
        HRESULT GetGenericArgumentCount(
            [Out] out long argCount);
        
        [PreserveSig]
        HRESULT GetGenericArgumentAt(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol argument);
    }
}
