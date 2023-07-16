using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.CoClass
{
    [Guid("108296C1-281E-11D3-BD22-0000F80849BD")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public class CorSymWriter_deprecatedClass : ISymUnmanagedWriter, CorSymWriter_deprecated
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineDocument(
            [In, MarshalAs(UnmanagedType.LPWStr)] string url,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid language,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid languageVendor,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid documentType,
#else
            [MarshalUsing(typeof(GuidMarshaller))] in Guid language,
            [MarshalUsing(typeof(GuidMarshaller))] in Guid languageVendor,
            [MarshalUsing(typeof(GuidMarshaller))] in Guid documentType,
#endif
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedDocumentWriter pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetUserEntryPoint([In] int entryMethod);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT OpenMethod([In] int method);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT CloseMethod();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT OpenScope([In] int startOffset, [Out] out int pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT CloseScope([In] int endOffset);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetScopeRange([In] int scopeID, [In] int startOffset, [In] int endOffset);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineLocalVariable(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] int cSig,
            [In] IntPtr signature,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3,
            [In] int startOffset,
            [In] int endOffset);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineParameter(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] int sequence,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineField(
            [In] int parent,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] int cSig,
            [In] IntPtr signature,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineGlobalVariable(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] int cSig,
            [In] IntPtr signature,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Close();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetSymAttribute(
            [In] int parent,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int cData,
            [In] IntPtr data);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT OpenNamespace([In, MarshalAs(UnmanagedType.LPWStr)] string name);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT CloseNamespace();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT UsingNamespace([In, MarshalAs(UnmanagedType.LPWStr)] string fullName);

        [PreserveSig]
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

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Initialize(
            [MarshalAs(UnmanagedType.Interface), In]
            object emitter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string filename,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream,
            [In, MarshalAs(UnmanagedType.Bool)] bool fFullBuild);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetDebugInfo(
            [In, Out] ref IntPtr pIDD,
            [In] int cData,
            [Out] out int pcData,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] data);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineSequencePoints(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocumentWriter document,
            [In] int spCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] offsets,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] lines,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] columns,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] endLines,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] endColumns);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT RemapToken([In] mdToken oldToken, [In] mdToken newToken);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Initialize2(
            [MarshalAs(UnmanagedType.Interface), In]
            object emitter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string tempfilename,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream,
            [In, MarshalAs(UnmanagedType.Bool)] bool fFullBuild,
            [In, MarshalAs(UnmanagedType.LPWStr)] string finalfilename);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DefineConstant(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [MarshalAs(UnmanagedType.Struct), In] object value,
            [In] int cSig,
            [In] IntPtr signature);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Abort();
    }
}
