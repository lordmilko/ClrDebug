using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B62B923C-B500-3158-A543-24F307A8B7E1")]
    [ComImport]
    public interface ISymUnmanagedMethod
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetToken();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSequencePointCount();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ISymUnmanagedScope GetRootScope();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ISymUnmanagedScope GetScopeFromOffset([In] uint offset);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetOffset([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document, [In] uint line, [In] uint column);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRanges(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column,
            [In] uint cRanges,
            out uint pcRanges,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedMethod ranges);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetParameters([In] uint cParams, out uint pcParams, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedMethod @params);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetNamespace([MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedNamespace pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSourceStartEnd(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2), In]
            ISymUnmanagedDocument[] docs,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2), In]
            uint[] lines,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2), In]
            uint[] columns,
            out int pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSequencePoints(
            [In] uint cPoints,
            out uint pcPoints,
            [In] ref uint offsets,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ISymUnmanagedDocument documents,
            [In] ref uint lines,
            [In] ref uint columns,
            [In] ref uint endLines,
            [In] ref uint endColumns);
    }
}