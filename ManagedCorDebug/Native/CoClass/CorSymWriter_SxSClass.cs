using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("0AE2DEB0-F901-478B-BB9F-881EE8066788")]
    [ClassInterface(ClassInterfaceType.None)]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ComImport]
    public class CorSymWriter_SxSClass : ISymUnmanagedWriter, CorSymWriter_SxS
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern HRESULT DefineDocument(
            [In] string url,
            [In] ref Guid language,
            [In] ref Guid languageVendor,
            [In] ref Guid documentType,
            [Out] out ISymUnmanagedDocumentWriter pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetUserEntryPoint([In] uint entryMethod);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT OpenMethod([In] uint method);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT CloseMethod();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT OpenScope([In] uint startOffset, [Out] out uint pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT CloseScope([In] uint endOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetScopeRange([In] uint scopeID, [In] uint startOffset, [In] uint endOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineLocalVariable(
            [In] string name,
            [In] uint attributes,
            [In] uint cSig,
            [In] IntPtr signature,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3,
            [In] uint startOffset,
            [In] uint endOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineParameter(
            [In] string name,
            [In] uint attributes,
            [In] uint sequence,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineField(
            [In] uint parent,
            [In] string name,
            [In] uint attributes,
            [In] uint cSig,
            [In] IntPtr signature,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineGlobalVariable(
            [In] string name,
            [In] uint attributes,
            [In] uint cSig,
            [In] IntPtr signature,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Close();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetSymAttribute(
            [In] uint parent,
            [In] string name,
            [In] uint cData,
            [In] IntPtr data);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT OpenNamespace([In] string name);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT CloseNamespace();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT UsingNamespace([In] string fullName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetMethodSourceRange(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter startDoc,
            [In] uint startLine,
            [In] uint startColumn,
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter endDoc,
            [In] uint endLine,
            [In] uint endColumn);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Initialize(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object emitter,
            [In] string filename,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream,
            [In] int fFullBuild);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetDebugInfo(
            [In, Out] ref ulong pIDD,
            [In] uint cData,
            out uint pcData,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] data);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineSequencePoints(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter document,
            [In] uint spCount,
            [In] ref uint offsets,
            [In] ref uint lines,
            [In] ref uint columns,
            [In] ref uint endLines,
            [In] ref uint endColumns);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT RemapToken([In] uint oldToken, [In] uint newToken);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Initialize2(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object emitter,
            [In] string tempfilename,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream,
            [In] int fFullBuild,
            [In] string finalfilename);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineConstant(
            [In] string name,
            [MarshalAs(UnmanagedType.Struct), In] object value,
            [In] uint cSig,
            [In] IntPtr signature);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Abort();
    }
}