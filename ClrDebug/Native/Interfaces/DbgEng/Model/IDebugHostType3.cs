using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
using ClrDebug.TypeLib;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8B0409AC-C1BB-433D-887A-ED12C3AF0E7D")]
    [ComImport]
    public interface IDebugHostType3 : IDebugHostType2
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
        new HRESULT GetTypeKind(
            [Out] out TypeKind kind);
        
        [PreserveSig]
        new HRESULT GetSize(
            [Out] out long size);
        
        [PreserveSig]
        new HRESULT GetBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType baseType);
        
        [PreserveSig]
        new HRESULT GetHashCode(
            [Out] out int hashCode);
        
        [PreserveSig]
        new HRESULT GetIntrinsicType(
            [Out] out IntrinsicKind intrinsicKind,
            [Out] out VARENUM carrierType);
        
        [PreserveSig]
        new HRESULT GetBitField(
            [Out] out int lsbOfField,
            [Out] out int lengthOfField);
        
        [PreserveSig]
        new HRESULT GetPointerKind(
            [Out] out PointerKind pointerKind);
        
        [PreserveSig]
        new HRESULT GetMemberType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType memberType);
        
        [PreserveSig]
        new HRESULT CreatePointerTo(
            [In] PointerKind kind,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType newType);
        
        [PreserveSig]
        new HRESULT GetArrayDimensionality(
            [Out] out long arrayDimensionality);
        
        [PreserveSig]
        new HRESULT GetArrayDimensions(
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ArrayDimension[] pDimensions);
        
        [PreserveSig]
        new HRESULT CreateArrayOf(
            [In] long dimensions,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ArrayDimension[] pDimensions,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType newType);
        
        [PreserveSig]
        new HRESULT GetFunctionCallingConvention(
            [Out] out CallingConventionKind conventionKind);
        
        [PreserveSig]
        new HRESULT GetFunctionReturnType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType returnType);
        
        [PreserveSig]
        new HRESULT GetFunctionParameterTypeCount(
            [Out] out long count);
        
        [PreserveSig]
        new HRESULT GetFunctionParameterTypeAt(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType parameterType);
        
        [PreserveSig]
        new HRESULT IsGeneric(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isGeneric);
        
        [PreserveSig]
        new HRESULT GetGenericArgumentCount(
            [Out] out long argCount);
        
        [PreserveSig]
        new HRESULT GetGenericArgumentAt(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol argument);
        
        [PreserveSig]
        new HRESULT IsTypedef(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isTypedef);
        
        [PreserveSig]
        new HRESULT GetTypedefBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType2 baseType);
        
        [PreserveSig]
        new HRESULT GetTypedefFinalBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType2 finalBaseType);
        
        [PreserveSig]
        new HRESULT GetFunctionVarArgsKind(
            [Out] out VarArgsKind varArgsKind);
        
        [PreserveSig]
        new HRESULT GetFunctionInstancePointerType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType2 instancePointerType);
        
        [PreserveSig]
        new HRESULT CompareAgainst(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbol pComparisonSymbol,
            [In] int comparisonFlags,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pMatches);
        
        [PreserveSig]
        HRESULT GetContainingType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType3 containingParentType);
    }
}
