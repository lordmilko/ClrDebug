using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug.CoClass
{
    [Guid("108296C2-281E-11D3-BD22-0000F80849BD")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public class CorSymReader_deprecatedClass : ISymUnmanagedReader, CorSymReader_deprecated
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetDocument(
            [In] string url,
            [In] Guid language,
            [In] Guid languageVendor,
            [In] Guid documentType,
            [Out] out ISymUnmanagedDocument pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetDocuments([In] int cDocs, out int pcDocs,
            [MarshalAs(UnmanagedType.Interface), Out]
            IntPtr pDocs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetUserEntryPoint([Out] out mdMethodDef pToken);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern HRESULT GetMethod([In] mdMethodDef token, [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern HRESULT GetMethodByVersion(
            [In] mdMethodDef token,
            [In] int version,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetVariables(
            [In] int parent,
            [In] int cVars,
            out int pcVars,
            [MarshalAs(UnmanagedType.Interface), Out]
            IntPtr pVars);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetGlobalVariables(
            [In] int cVars,
            out int pcVars,
            [Out] IntPtr pVars);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern HRESULT GetMethodFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetSymAttribute(
            [In] int parent,
            [In] string name,
            [In] int cBuffer,
            out int pcBuffer,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] buffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetNamespaces(
            [In] int cNameSpaces,
            out int pcNameSpaces,
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
            [In] int cchName,
            out int pcchName,
            [Out] StringBuilder szName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetMethodsFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [In] int cMethod,
            out int pcMethod,
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