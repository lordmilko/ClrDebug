using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("ED14AA72-78E2-4884-84E2-334293AE5214")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedWriter
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ISymUnmanagedDocumentWriter DefineDocument(
            [In] ref ushort url,
            [In] ref Guid language,
            [In] ref Guid languageVendor,
            [In] ref Guid documentType);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetUserEntryPoint([In] uint entryMethod);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT OpenMethod([In] uint method);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CloseMethod();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT OpenScope([In] uint startOffset);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CloseScope([In] uint endOffset);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetScopeRange([In] uint scopeID, [In] uint startOffset, [In] uint endOffset);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DefineLocalVariable(
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

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DefineParameter(
            [In] ref ushort name,
            [In] uint attributes,
            [In] uint sequence,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DefineField(
            [In] uint parent,
            [In] ref ushort name,
            [In] uint attributes,
            [In] uint cSig,
            [In] ref byte signature,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DefineGlobalVariable(
            [In] ref ushort name,
            [In] uint attributes,
            [In] uint cSig,
            [In] ref byte signature,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Close();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetSymAttribute([In] uint parent, [In] ref ushort name, [In] uint cData, [In] ref byte data);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT OpenNamespace([In] ref ushort name);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CloseNamespace();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UsingNamespace([In] ref ushort fullName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetMethodSourceRange(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter startDoc,
            [In] uint startLine,
            [In] uint startColumn,
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter endDoc,
            [In] uint endLine,
            [In] uint endColumn);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Initialize([MarshalAs(UnmanagedType.IUnknown), In]
            object emitter, [In] ref ushort filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, [In] int fFullBuild);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetDebugInfo([In, Out]
            ref ulong pIDD, [In] uint cData, out uint pcData, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedWriter data);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DefineSequencePoints(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter document,
            [In] uint spCount,
            [In] ref uint offsets,
            [In] ref uint lines,
            [In] ref uint columns,
            [In] ref uint endLines,
            [In] ref uint endColumns);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemapToken([In] uint oldToken, [In] uint newToken);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Initialize2(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object emitter,
            [In] ref ushort tempfilename,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream,
            [In] int fFullBuild,
            [In] ref ushort finalfilename);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DefineConstant([In] ref ushort name, [MarshalAs(UnmanagedType.Struct), In] object value, [In] uint cSig,
            [In] ref byte signature);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Abort();
    }
}