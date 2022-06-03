using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("3948A999-FD8A-4C38-A708-8A71E9B04DBB")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugSymbolProvider
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetStaticFieldSymbols(
            [In] uint cbSignature,
            [In] ref byte typeSig,
            [In] uint cRequestedSymbols,
            out uint pcFetchedSymbols,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider pSymbols);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetInstanceFieldSymbols(
            [In] uint cbSignature,
            [In] ref byte typeSig,
            [In] uint cRequestedSymbols,
            out uint pcFetchedSymbols,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider pSymbols);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMethodLocalSymbols(
            [In] uint nativeRVA,
            [In] uint cRequestedSymbols,
            out uint pcFetchedSymbols,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider pSymbols);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMethodParameterSymbols(
            [In] uint nativeRVA,
            [In] uint cRequestedSymbols,
            out uint pcFetchedSymbols,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider pSymbols);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMergedAssemblyRecords(
            [In] uint cRequestedRecords,
            out uint pcFetchedRecords,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider pRecords);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMethodProps(
            [In] uint codeRva,
            out uint pMethodToken,
            out uint pcGenericParams,
            [In] uint cbSignature,
            out uint pcbSignature,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider signature);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetTypeProps(
            [In] uint vtableRva,
            [In] uint cbSignature,
            out uint pcbSignature,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugSymbolProvider signature);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCodeRange([In] uint codeRva, out uint pCodeStartAddress, ref uint pCodeSize);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAssemblyImageBytes([In] ulong rva, [In] uint length,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetObjectSize([In] uint cbSignature, [In] ref byte typeSig, out uint pObjectSize);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAssemblyImageMetadata([MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);
    }
}