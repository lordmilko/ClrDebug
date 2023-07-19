using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that can be used to retrieve debug symbol information.
    /// </summary>
    [Guid("3948A999-FD8A-4C38-A708-8A71E9B04DBB")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugSymbolProvider
    {
        /// <summary>
        /// Gets the static field symbols that correspond to a typespec signature.
        /// </summary>
        /// <param name="cbSignature">[in] The number of bytes in the typeSig array.</param>
        /// <param name="typeSig">[in] A byte array that contains the typespec signature.</param>
        /// <param name="cRequestedSymbols">[in] The number of symbols requested.</param>
        /// <param name="pcFetchedSymbols">[out] A pointer to the number of symbols retrieved by the method.</param>
        /// <param name="pSymbols">[out] A pointer to an <see cref="ICorDebugStaticFieldSymbol"/> array that contains the requested static field symbols.</param>
        [PreserveSig]
        HRESULT GetStaticFieldSymbols(
            [In] int cbSignature,
            [In, MarshalAs(UnmanagedType.SysInt, SizeParamIndex = 0)] IntPtr typeSig,
            [In] int cRequestedSymbols,
            [Out] out int pcFetchedSymbols,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ICorDebugStaticFieldSymbol[] pSymbols);

        /// <summary>
        /// Gets the instance field symbols that correspond to a typespec signature.
        /// </summary>
        /// <param name="cbSignature">[in] The number of bytes in the typeSig array.</param>
        /// <param name="typeSig">[in] A byte array that contains the typespec signature.</param>
        /// <param name="cRequestedSymbols">[in] The number of symbols requested.</param>
        /// <param name="pcFetchedSymbols">[out] A pointer to the number of symbols retrieved by the method.</param>
        /// <param name="pSymbols">[out] A pointer to an <see cref="ICorDebugStaticFieldSymbol"/> array that contains the requested instance field symbols.</param>
        [PreserveSig]
        HRESULT GetInstanceFieldSymbols(
            [In] int cbSignature,
            [In, MarshalAs(UnmanagedType.SysInt, SizeParamIndex = 0)] IntPtr typeSig,
            [In] int cRequestedSymbols,
            [Out] out int pcFetchedSymbols,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ICorDebugInstanceFieldSymbol[] pSymbols);

        /// <summary>
        /// Gets a method's local symbols given the relative virtual address (RVA) of that method.
        /// </summary>
        /// <param name="nativeRVA">[in] The native relative virtual address of the method.</param>
        /// <param name="cRequestedSymbols">[in] The number of local symbols requested.</param>
        /// <param name="pcFetchedSymbols">[out] A pointer to the number of symbols retrieved by the method.</param>
        /// <param name="pSymbols">[out] A pointer to an <see cref="ICorDebugVariableSymbol"/> array that contains the method's local symbols.</param>
        [PreserveSig]
        HRESULT GetMethodLocalSymbols(
            [In] int nativeRVA,
            [In] int cRequestedSymbols,
            [Out] out int pcFetchedSymbols,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ICorDebugVariableSymbol[] pSymbols);

        /// <summary>
        /// Gets a method's parameter symbols given the relative virtual address (RVA) of that method.
        /// </summary>
        /// <param name="nativeRVA">[in] The native relative virtual address of the method.</param>
        /// <param name="cRequestedSymbols">[in] The number of local symbols requested.</param>
        /// <param name="pcFetchedSymbols">[out] A pointer to the number of symbols retrieved by the method.</param>
        /// <param name="pSymbols">[out] A pointer to an <see cref="ICorDebugVariableSymbol"/> array that contains the method's local symbols.</param>
        [PreserveSig]
        HRESULT GetMethodParameterSymbols(
            [In] int nativeRVA,
            [In] int cRequestedSymbols,
            [Out] out int pcFetchedSymbols,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ICorDebugVariableSymbol[] pSymbols);

        /// <summary>
        /// Gets the symbol records for all the merged assemblies.
        /// </summary>
        /// <param name="cRequestedRecords">[in] The number of symbol records requested.</param>
        /// <param name="pcFetchedRecords">[out] A pointer to the number of symbol records retrieved by the method.</param>
        /// <param name="pRecords">A pointer to an array of <see cref="ICorDebugMergedAssemblyRecord"/> objects.</param>
        [PreserveSig]
        HRESULT GetMergedAssemblyRecords(
            [In] int cRequestedRecords,
            [Out] out int pcFetchedRecords,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Out] ICorDebugMergedAssemblyRecord[] pRecords);

        /// <summary>
        /// Returns information about method properties, such as the method's metadata token and information about its generic parameters, given a relative virtual address (RVA) in that method.
        /// </summary>
        /// <param name="codeRva">[in] A relative virtual address in the method about which information is to be retrieved.</param>
        /// <param name="pMethodToken">[out] A pointer to the method's metadata token.</param>
        /// <param name="pcGenericParams">[out] A pointer to the number of generic parameters associated with this method.</param>
        /// <param name="cbSignature">[in] The size of the signature array. See the Remarks section.</param>
        /// <param name="pcbSignature">[out] A pointer to the size of the returned signature array.</param>
        /// <param name="signature">[out] A buffer that holds the typespec signatures of all generic parameters.</param>
        /// <remarks>
        /// To get the required size of the method's signature array, set the cbSignature argument to 0 and signature to null.
        /// When the method returns, pcbSignature will contain the number of bytes required for the signature array.
        /// </remarks>
        [PreserveSig]
        HRESULT GetMethodProps(
            [In] int codeRva,
            [Out] out mdToken pMethodToken,
            [Out] out int pcGenericParams,
            [In] int cbSignature,
            [Out] out int pcbSignature,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3), Out] byte[] signature);

        /// <summary>
        /// Returns information about a type's properties, such as the number of signature of its generic parameters, given a relative virtual address (RVA) in a vtable.
        /// </summary>
        /// <param name="vtableRva">[in] A relative virtual address (RVA) in a vtable.</param>
        /// <param name="cbSignature">[in] The size of the signature array. See the Remarks section.</param>
        /// <param name="pcbSignature">[out] A pointer to the size of the returned signature array.</param>
        /// <param name="signature">[out] A buffer that holds the typespec signatures of all generic parameters.</param>
        /// <remarks>
        /// To get the required size of the type's signature array, set the cbSignature argument to 0 and signature to null.
        /// When the method returns, pcbSignature will contain the number of bytes required for the signature array.
        /// </remarks>
        [PreserveSig]
        HRESULT GetTypeProps(
            [In] int vtableRva,
            [In] int cbSignature,
            [Out] out int pcbSignature,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] byte[] signature);

        /// <summary>
        /// Gets the method start address and size given a relative virtual address (RVA) in a method.
        /// </summary>
        /// <param name="codeRva">[in] The relative virtual address (RVA) in a method.</param>
        /// <param name="pCodeStartAddress">[out] A pointer to the starting address of the method.</param>
        /// <param name="pCodeSize">A pointer to the method code size (the number of bytes of the method's code).</param>
        [PreserveSig]
        HRESULT GetCodeRange(
            [In] int codeRva,
            [Out] out int pCodeStartAddress,
            [Out] out int pCodeSize);

        /// <summary>
        /// Reads data from a merged assembly given a relative virtual address (RVA) in the merged assembly.
        /// </summary>
        /// <param name="rva">[in] A relative virtual address (RVA) in a merged assembly.</param>
        /// <param name="length">The number of bytes to read from the merged assembly.</param>
        /// <param name="ppMemoryBuffer">A pointer to the address of an <see cref="ICorDebugMemoryBuffer"/> object that contains information about the memory buffer with merged assembly metadata.</param>
        [PreserveSig]
        HRESULT GetAssemblyImageBytes(
            [In] long rva,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);

        /// <summary>
        /// Returns the object size for an object based on its typespec signature.
        /// </summary>
        /// <param name="cbSignature">[in] The number of bytes in the typespec signature.</param>
        /// <param name="typeSig">[in] The typespec signature.</param>
        /// <param name="pObjectSize">[out] A pointer to the size of the object.</param>
        [PreserveSig]
        HRESULT GetObjectSize(
            [In] int cbSignature,
            [In] IntPtr typeSig,
            [Out] out int pObjectSize);

        /// <summary>
        /// Returns the metadata from a merged assembly.
        /// </summary>
        /// <param name="ppMemoryBuffer">[out] A pointer to the address of an <see cref="ICorDebugMemoryBuffer"/> object that contains information about the size and address of the merged assembly's metadata.</param>
        [PreserveSig]
        HRESULT GetAssemblyImageMetadata(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);
    }
}
