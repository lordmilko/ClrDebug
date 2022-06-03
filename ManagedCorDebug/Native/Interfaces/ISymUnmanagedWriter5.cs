using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("DCF7780D-BDE9-45DF-ACFE-21731A32000C")]
    [ComImport]
    public interface ISymUnmanagedWriter5 : ISymUnmanagedWriter4
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        new ISymUnmanagedDocumentWriter DefineDocument(
            [In] ref ushort url,
            [In] ref Guid language,
            [In] ref Guid languageVendor,
            [In] ref Guid documentType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void SetUserEntryPoint([In] uint entryMethod);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void OpenMethod([In] uint method);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void CloseMethod();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new uint OpenScope([In] uint startOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void CloseScope([In] uint endOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void SetScopeRange([In] uint scopeID, [In] uint startOffset, [In] uint endOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void DefineLocalVariable(
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
        new void DefineParameter(
            [In] ref ushort name,
            [In] uint attributes,
            [In] uint sequence,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void DefineField(
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
        new void DefineGlobalVariable(
            [In] ref ushort name,
            [In] uint attributes,
            [In] uint cSig,
            [In] ref byte signature,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Close();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void SetSymAttribute([In] uint parent, [In] ref ushort name, [In] uint cData, [In] ref byte data);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void OpenNamespace([In] ref ushort name);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void CloseNamespace();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void UsingNamespace([In] ref ushort fullName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void SetMethodSourceRange(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter startDoc,
            [In] uint startLine,
            [In] uint startColumn,
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter endDoc,
            [In] uint endLine,
            [In] uint endColumn);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Initialize([MarshalAs(UnmanagedType.IUnknown), In]
            object emitter, [In] ref ushort filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, [In] int fFullBuild);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetDebugInfo([ComAliasName("CorSym.ULONG_PTR"), In, Out]
            ref ulong pIDD, [In] uint cData, out uint pcData, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedWriter data);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void DefineSequencePoints(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter document,
            [In] uint spCount,
            [In] ref uint offsets,
            [In] ref uint lines,
            [In] ref uint columns,
            [In] ref uint endLines,
            [In] ref uint endColumns);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void RemapToken([In] uint oldToken, [In] uint newToken);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Initialize2(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object emitter,
            [In] ref ushort tempfilename,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream,
            [In] int fFullBuild,
            [In] ref ushort finalfilename);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void DefineConstant([In] ref ushort name, [MarshalAs(UnmanagedType.Struct), In] object value,
            [In] uint cSig, [In] ref byte signature);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Abort();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void DefineLocalVariable2(
            [In] ref ushort name,
            [In] uint attributes,
            [In] uint sigToken,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3,
            [In] uint startOffset,
            [In] uint endOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void DefineGlobalVariable2(
            [In] ref ushort name,
            [In] uint attributes,
            [In] uint sigToken,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void DefineConstant2([In] ref ushort name, [MarshalAs(UnmanagedType.Struct), In] object value,
            [In] uint sigToken);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void OpenMethod2([In] uint method, [In] uint isect, [In] uint offset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Commit();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetDebugInfoWithPadding(
            [ComAliasName("CorSym.ULONG_PTR"), In, Out]
            ref ulong pIDD,
            [In] uint cData,
            out uint pcData,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedWriter4 data);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void OpenMapTokensToSourceSpans();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CloseMapTokensToSourceSpans();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void MapTokenToSourceSpan(
            [In] uint token,
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter document,
            [In] uint line,
            [In] uint column,
            [In] uint endLine,
            [In] uint endColumn);
    }
}