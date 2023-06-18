using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.CoClass
{
    [Guid("108296C2-281E-11D3-BD22-0000F80849BD")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public class CorSymReader_deprecatedClass : ISymUnmanagedReader, CorSymReader_deprecated
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetDocument(
            [In, MarshalAs(UnmanagedType.LPWStr)] string url,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid language,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid languageVendor,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid documentType,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedDocument pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetDocuments([In] int cDocs, [Out] out int pcDocs,
            [MarshalAs(UnmanagedType.LPArray), Out] ISymUnmanagedDocument[] pDocs);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetUserEntryPoint([Out] out mdMethodDef pToken);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetMethod([In] mdMethodDef token, [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetMethodByVersion(
            [In] mdMethodDef token,
            [In] int version,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetVariables(
            [In] int parent,
            [In] int cVars,
            [Out] out int pcVars,
            [MarshalAs(UnmanagedType.LPArray), Out] ISymUnmanagedVariable[] pVars);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetGlobalVariables(
            [In] int cVars,
            [Out] out int pcVars,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedVariable[] pVars);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetMethodFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetSymAttribute(
            [In] int parent,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int cBuffer,
            [Out] out int pcBuffer,
            [Out] IntPtr buffer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetNamespaces(
            [In] int cNameSpaces,
            [Out] out int pcNameSpaces,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedNamespace[] namespaces);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Initialize(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [In, MarshalAs(UnmanagedType.LPWStr)] string filename,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT UpdateSymbolStore([In, MarshalAs(UnmanagedType.LPWStr)] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT ReplaceSymbolStore([In, MarshalAs(UnmanagedType.LPWStr)] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetSymbolStoreFileName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetMethodsFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [In] int cMethod,
            [Out] out int pcMethod,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedMethod[] pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetDocumentVersion(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument pDoc,
            [Out] out int version,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbCurrent);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetMethodVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedMethod pMethod, [Out] out int version);
    }
}
