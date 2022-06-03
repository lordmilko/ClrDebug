using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("40DE4037-7C81-3E1E-B022-AE1ABFF2CA08")]
    [ComImport]
    public interface ISymUnmanagedDocument
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetURL([In] uint cchUrl, out uint pcchUrl, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedDocument szUrl);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Guid GetDocumentType();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Guid GetLanguage();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Guid GetLanguageVendor();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Guid GetCheckSumAlgorithmId();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCheckSum([In] uint cData, out uint pcData, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedDocument data);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint FindClosestLine([In] uint line);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int HasEmbeddedSource();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetSourceLength();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSourceRange(
            [In] uint startLine,
            [In] uint startColumn,
            [In] uint endLine,
            [In] uint endColumn,
            [In] uint cSourceBytes,
            out uint pcSourceBytes,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedDocument source);
    }
}