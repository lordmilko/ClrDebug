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
        public virtual extern ISymUnmanagedDocumentWriter DefineDocument(
            [In] ref ushort url,
            [In] ref Guid language,
            [In] ref Guid languageVendor,
            [In] ref Guid documentType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetUserEntryPoint([In] uint entryMethod);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void OpenMethod([In] uint method);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void CloseMethod();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern uint OpenScope([In] uint startOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void CloseScope([In] uint endOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetScopeRange([In] uint scopeID, [In] uint startOffset, [In] uint endOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void DefineLocalVariable(
            [In] ref ushort name,
            [In] uint attributes,
            [In] uint cSig,
            [In] ref byte signature,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3,
            [In] uint startOffset,
            [In] uint endOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void DefineParameter(
            [In] ref ushort name,
            [In] uint attributes,
            [In] uint sequence,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void DefineField(
            [In] uint parent,
            [In] ref ushort name,
            [In] uint attributes,
            [In] uint cSig,
            [In] ref byte signature,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void DefineGlobalVariable(
            [In] ref ushort name,
            [In] uint attributes,
            [In] uint cSig,
            [In] ref byte signature,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Close();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetSymAttribute(
            [In] uint parent,
            [In] ref ushort name,
            [In] uint cData,
            [In] ref byte data);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void OpenNamespace([In] ref ushort name);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void CloseNamespace();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void UsingNamespace([In] ref ushort fullName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetMethodSourceRange(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter startDoc,
            [In] uint startLine,
            [In] uint startColumn,
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter endDoc,
            [In] uint endLine,
            [In] uint endColumn);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Initialize(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object emitter,
            [In] ref ushort filename,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream,
            [In] int fFullBuild);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetDebugInfo(
            [ComAliasName("CorSym.ULONG_PTR"), In, Out]
            ref ulong pIDD,
            [In] uint cData,
            out uint pcData,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedWriter data);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void DefineSequencePoints(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter document,
            [In] uint spCount,
            [In] ref uint offsets,
            [In] ref uint lines,
            [In] ref uint columns,
            [In] ref uint endLines,
            [In] ref uint endColumns);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void RemapToken([In] uint oldToken, [In] uint newToken);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Initialize2(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object emitter,
            [In] ref ushort tempfilename,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream,
            [In] int fFullBuild,
            [In] ref ushort finalfilename);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void DefineConstant(
            [In] ref ushort name,
            [MarshalAs(UnmanagedType.Struct), In] object value,
            [In] uint cSig,
            [In] ref byte signature);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Abort();
    }
}