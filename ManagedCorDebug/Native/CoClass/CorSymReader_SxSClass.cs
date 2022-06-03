using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("0A3976C5-4529-4EF8-B0B0-42EED37082CD")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public class CorSymReader_SxSClass : ISymUnmanagedReader, CorSymReader_SxS
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern ISymUnmanagedDocument GetDocument(
            [In] ref ushort url,
            [In] Guid language,
            [In] Guid languageVendor,
            [In] Guid documentType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetDocuments([In] uint cDocs, out uint pcDocs,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader pDocs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern uint GetUserEntryPoint();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern ISymUnmanagedMethod GetMethod([In] uint token);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern ISymUnmanagedMethod GetMethodByVersion(
            [In] uint token,
            [In] int version);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetVariables(
            [In] uint parent,
            [In] uint cVars,
            out uint pcVars,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader pVars);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetGlobalVariables(
            [In] uint cVars,
            out uint pcVars,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader pVars);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern ISymUnmanagedMethod GetMethodFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetSymAttribute(
            [In] uint parent,
            [In] ref ushort name,
            [In] uint cBuffer,
            out uint pcBuffer,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader buffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetNamespaces(
            [In] uint cNameSpaces,
            out uint pcNameSpaces,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader namespaces);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Initialize(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object importer,
            [In] ref ushort filename,
            [In] ref ushort searchPath,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void UpdateSymbolStore([In] ref ushort filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void ReplaceSymbolStore([In] ref ushort filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetSymbolStoreFileName(
            [In] uint cchName,
            out uint pcchName,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader szName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetMethodsFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column,
            [In] uint cMethod,
            out uint pcMethod,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetDocumentVersion(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument pDoc,
            out int version,
            out int pbCurrent);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetMethodVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedMethod pMethod, out int version);
    }
}