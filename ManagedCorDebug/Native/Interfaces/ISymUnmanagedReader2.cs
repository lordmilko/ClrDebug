using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("A09E53B2-2A57-4CCA-8F63-B84F7C35D4AA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedReader2 : ISymUnmanagedReader
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        new ISymUnmanagedDocument GetDocument(
            [In] ref ushort url,
            [In] Guid language,
            [In] Guid languageVendor,
            [In] Guid documentType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetDocuments([In] uint cDocs, out uint pcDocs, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader pDocs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new uint GetUserEntryPoint();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        new ISymUnmanagedMethod GetMethod([In] uint token);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        new ISymUnmanagedMethod GetMethodByVersion([In] uint token, [In] int version);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetVariables([In] uint parent, [In] uint cVars, out uint pcVars,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader pVars);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetGlobalVariables([In] uint cVars, out uint pcVars, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader pVars);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        new ISymUnmanagedMethod GetMethodFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetSymAttribute(
            [In] uint parent,
            [In] ref ushort name,
            [In] uint cBuffer,
            out uint pcBuffer,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader buffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetNamespaces([In] uint cNameSpaces, out uint pcNameSpaces, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader namespaces);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Initialize(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object importer,
            [In] ref ushort filename,
            [In] ref ushort searchPath,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void UpdateSymbolStore([In] ref ushort filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void ReplaceSymbolStore([In] ref ushort filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetSymbolStoreFileName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader szName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetMethodsFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column,
            [In] uint cMethod,
            out uint pcMethod,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetDocumentVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument pDoc, out int version, out int pbCurrent);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetMethodVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedMethod pMethod, out int version);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ISymUnmanagedMethod GetMethodByVersionPreRemap([In] uint token, [In] int version);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSymAttributePreRemap(
            [In] uint parent,
            [In] ref ushort name,
            [In] uint cBuffer,
            out uint pcBuffer,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader2 buffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMethodsInDocument(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint cMethod,
            out uint pcMethod,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader2 pRetVal);
    }
}