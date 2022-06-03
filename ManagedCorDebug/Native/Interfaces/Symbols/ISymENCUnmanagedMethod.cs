using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("85E891DA-A631-4C76-ACA2-A44A39C46B8C")]
    [ComImport]
    public interface ISymENCUnmanagedMethod
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFileNameFromOffset(
            [In] uint dwOffset,
            [In] uint cchName,
            out uint pcchName,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymENCUnmanagedMethod szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLineFromOffset(
            [In] uint dwOffset,
            out uint pline,
            out uint pcolumn,
            out uint pendLine,
            out uint pendColumn,
            out uint pdwStartOffset);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetDocumentsForMethodCount();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetDocumentsForMethod([In] uint cDocs, out uint pcDocs, [MarshalAs(UnmanagedType.Interface), In]
            ref ISymUnmanagedDocument documents);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSourceExtentInDocument(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            out uint pstartLine,
            out uint pendLine);
    }
}