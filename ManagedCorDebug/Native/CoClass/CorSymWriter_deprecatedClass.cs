using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug.CoClass
{
    [Guid("108296C1-281E-11D3-BD22-0000F80849BD")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public class CorSymWriter_deprecatedClass : ISymUnmanagedWriter, CorSymWriter_deprecated
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
        public virtual extern HRESULT SetUserEntryPoint([In] int entryMethod);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT OpenMethod([In] int method);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT CloseMethod();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT OpenScope([In] int startOffset, [Out] out int pRetVal);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT CloseScope([In] int endOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetScopeRange([In] int scopeID, [In] int startOffset, [In] int endOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineLocalVariable(
            [In] string name,
            [In] int attributes,
            [In] int cSig,
            [In] IntPtr signature,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3,
            [In] int startOffset,
            [In] int endOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineParameter(
            [In] string name,
            [In] int attributes,
            [In] int sequence,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineField(
            [In] int parent,
            [In] string name,
            [In] int attributes,
            [In] int cSig,
            [In] IntPtr signature,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineGlobalVariable(
            [In] string name,
            [In] int attributes,
            [In] int cSig,
            [In] IntPtr signature,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Close();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetSymAttribute(
            [In] int parent,
            [In] string name,
            [In] int cData,
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
            [In] int startLine,
            [In] int startColumn,
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter endDoc,
            [In] int endLine,
            [In] int endColumn);

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
            [In, Out] IntPtr pIDD,
            [In] int cData,
            out int pcData,
            [MarshalAs(UnmanagedType.Interface), Out]
            byte[] data);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineSequencePoints(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter document,
            [In] int spCount,
            [In] ref int offsets,
            [In] ref int lines,
            [In] ref int columns,
            [In] ref int endLines,
            [In] ref int endColumns);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT RemapToken([In] int oldToken, [In] int newToken);

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
            [In] int cSig,
            [In] IntPtr signature);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Abort();
    }
}