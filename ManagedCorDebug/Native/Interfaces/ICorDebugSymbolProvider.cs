using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("3948A999-FD8A-4C38-A708-8A71E9B04DBB")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugSymbolProvider
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetStaticFieldSymbols(
            [In] uint cbSignature,
            [In] ref byte typeSig,
            [In] uint cRequestedSymbols,
            out uint pcFetchedSymbols,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider pSymbols);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetInstanceFieldSymbols(
            [In] uint cbSignature,
            [In] ref byte typeSig,
            [In] uint cRequestedSymbols,
            out uint pcFetchedSymbols,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider pSymbols);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMethodLocalSymbols(
            [In] uint nativeRVA,
            [In] uint cRequestedSymbols,
            out uint pcFetchedSymbols,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider pSymbols);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMethodParameterSymbols(
            [In] uint nativeRVA,
            [In] uint cRequestedSymbols,
            out uint pcFetchedSymbols,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider pSymbols);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMergedAssemblyRecords(
            [In] uint cRequestedRecords,
            out uint pcFetchedRecords,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider pRecords);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMethodProps(
            [In] uint codeRva,
            out uint pMethodToken,
            out uint pcGenericParams,
            [In] uint cbSignature,
            out uint pcbSignature,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider signature);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetTypeProps(
            [In] uint vtableRva,
            [In] uint cbSignature,
            out uint pcbSignature,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider signature);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCodeRange([In] uint codeRva, out uint pCodeStartAddress, ref uint pCodeSize);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAssemblyImageBytes([In] ulong rva, [In] uint length,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetObjectSize([In] uint cbSignature, [In] ref byte typeSig, out uint pObjectSize);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAssemblyImageMetadata([MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);
    }
}