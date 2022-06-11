using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug.CoClass
{
    [Guid("0A3976C5-4529-4EF8-B0B0-42EED37082CD")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public class CorSymReader_SxSClass : ISymUnmanagedReader, CorSymReader_SxS
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern HRESULT GetDocument(
            [In] string url,
            [In] Guid language,
            [In] Guid languageVendor,
            [In] Guid documentType,
            [Out] out ISymUnmanagedDocument pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetDocuments([In] uint cDocs, out uint pcDocs,
            [Out] IntPtr pDocs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetUserEntryPoint([Out] out uint pToken);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern HRESULT GetMethod([In] uint token, [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern HRESULT GetMethodByVersion(
            [In] uint token,
            [In] int version,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetVariables(
            [In] uint parent,
            [In] uint cVars,
            out uint pcVars,
            [Out] IntPtr pVars);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetGlobalVariables(
            [In] uint cVars,
            out uint pcVars,
            [Out] IntPtr pVars);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern HRESULT GetMethodFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetSymAttribute(
            [In] uint parent,
            [In] string name,
            [In] uint cBuffer,
            out uint pcBuffer,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] buffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetNamespaces(
            [In] uint cNameSpaces,
            out uint pcNameSpaces,
            [Out] IntPtr namespaces);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Initialize(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object importer,
            [In] string filename,
            [In] string searchPath,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT UpdateSymbolStore([In] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT ReplaceSymbolStore([In] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetSymbolStoreFileName(
            [In] uint cchName,
            out uint pcchName,
            [Out] StringBuilder szName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetMethodsFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column,
            [In] uint cMethod,
            out uint pcMethod,
            [Out] IntPtr pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetDocumentVersion(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument pDoc,
            out int version,
            out int pbCurrent);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetMethodVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedMethod pMethod, out int version);
    }
}