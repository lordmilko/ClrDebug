using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides basic global static functions for signing assemblies with strong names. All ICLRStrongName methods return standard COM HRESULTs.
    /// </summary>
    /// <remarks>
    /// You can get an instance of the ICLRStrongName by calling the <see cref="ICLRRuntimeInfo.GetInterface"/> method
    /// using CLSID_CLRStrongName and IID_ICLRStrongName as parameters.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComConversionLoss]
    [ComImport]
    [Guid("9FD93CCF-3280-4391-B3A9-96E1CDE77C8D")]
    public interface ICLRStrongName
    {
        /// <summary>
        /// Gets a hash of the specified assembly file, using the specified hash algorithm.
        /// </summary>
        /// <param name="pszFilePath">[in] The path to the file to be hashed.</param>
        /// <param name="piHashAlg">[in, out] A constant that specifies the hash algorithm. Use zero for the default hash algorithm.</param>
        /// <param name="pbHash">[out] The returned hash buffer.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <param name="pchHash">[out] The returned size, in bytes, of pbHash.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromAssemblyFile(
            [MarshalAs(UnmanagedType.LPStr), In] string pszFilePath,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);

        /// <summary>
        /// Generates a hash over the contents of the file specified by a Unicode string.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the file to be hashed. This parameter must be a Unicode string.</param>
        /// <param name="piHashAlg">[in, out] A constant that specifies the hash algorithm. Use zero for the default hash algorithm.</param>
        /// <param name="pbHash">[out] The returned hash buffer.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <param name="pchHash">[out] The returned size, in bytes, of pbHash.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromAssemblyFileW(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);

        /// <summary>
        /// Gets a hash of the assembly at the specified memory address, using the specified hash algorithm.
        /// </summary>
        /// <param name="pbBlob">[in] A pointer to the address of the memory block to be hashed.</param>
        /// <param name="cchBlob">[in] The length, in bytes, of the memory block.</param>
        /// <param name="piHashAlg">[in, out] A constant that specifies the hash algorithm. Use zero for the default algorithm.</param>
        /// <param name="pbHash">[out] The returned hash buffer.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <param name="pchHash">[out] The size, in bytes, of the returned pbHash.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromBlob(
            [In] ref byte pbBlob,
            [In] uint cchBlob,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);

        /// <summary>
        /// Generates a hash over the contents of the specified file.
        /// </summary>
        /// <param name="pszFilePath">[in] The name of the file to hash.</param>
        /// <param name="piHashAlg">[in, out] The algorithm to use when generating the hash. Valid algorithms are those defined by the Win32 CryptoAPI. If piHashAlg is set to 0, the default algorithm CALG_SHA-1 is used.</param>
        /// <param name="pbHash">[out] A byte array containing the generated hash.</param>
        /// <param name="cchHash">[in] The maximum size of the buffer that pbHash points to.</param>
        /// <param name="pchHash">[out] The size, in bytes, of the returned pbHash.</param>
        /// <remarks>
        /// This method is the same as the <see cref="ICLRStrongName.GetHashFromFileW"/> method, except that the file name
        /// specification is ANSI instead of Unicode.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromFile(
            [MarshalAs(UnmanagedType.LPStr), In] string pszFilePath,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);

        /// <summary>
        /// Generates a hash over the contents of the file specified by a Unicode string.
        /// </summary>
        /// <param name="pwzFilePath">[in] The Unicode name of the file to hash.</param>
        /// <param name="piHashAlg">[in, out] The algorithm to use when generating the hash. Valid algorithms are those defined by the Win32 CryptoAPI. If piHashAlg is set to 0, the default algorithm CALG_SHA-1 is used.</param>
        /// <param name="pbHash">[out] A byte array containing the generated hash.</param>
        /// <param name="cchHash">[in] The maximum size of the buffer pointed to by pbHash.</param>
        /// <param name="pchHash">[out] The size, in bytes, of pbHash.</param>
        /// <remarks>
        /// This method is the same as the <see cref="ICLRStrongName.GetHashFromFile"/> method, except that the file name specification
        /// is Unicode instead of ANSI.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromFileW(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);

        /// <summary>
        /// Generates a hash over the contents of the file that has the specified file handle, using the specified hash algorithm.
        /// </summary>
        /// <param name="hFile">[in] The handle of the file to be hashed.</param>
        /// <param name="piHashAlg">[in, out] A constant that specifies the hash algorithm. Use zero for the default algorithm.</param>
        /// <param name="pbHash">[out] The returned hash buffer.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <param name="pchHash">[out] The size, in bytes, of the returned pbHash.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromHandle(
            [In] IntPtr hFile,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameCompareAssemblies([MarshalAs(UnmanagedType.LPWStr), In] string pwzAssembly1,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzAssembly2);

        /// <summary>
        /// Frees memory that was allocated with a previous call to a strong name method such as <see cref="ICLRStrongName.StrongNameGetPublicKey"/>, <see cref="ICLRStrongName.StrongNameTokenFromPublicKey"/>, or <see cref="ICLRStrongName.StrongNameSignatureGeneration"/>.
        /// </summary>
        /// <param name="pbMemory">[in] A pointer to the memory to free.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameFreeBuffer([In] ref byte pbMemory);

        /// <summary>
        /// Fills the specified buffer with the binary representation of the executable file at the specified address.
        /// </summary>
        /// <param name="pwzFilePath">[in] A valid path to the executable file to be loaded.</param>
        /// <param name="pbBlob">[in] The buffer into which to load the executable file.</param>
        /// <param name="pcbBlob">[in, out] The requested maximum size, in bytes, of pbBlob. Upon return, the actual size, in bytes, of pbBlob.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameGetBlob([MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath, [In] [Out] ref byte pbBlob,
            [In] [Out] ref uint pcbBlob);

        /// <summary>
        /// Gets a binary representation of the assembly image at the specified memory address.
        /// </summary>
        /// <param name="pbBase">[in] The memory address of the mapped assembly manifest.</param>
        /// <param name="dwLength">[in] The size, in bytes, of the image at pbBase.</param>
        /// <param name="pbBlob">[in] A buffer to contain the binary representation of the image.</param>
        /// <param name="pcbBlob">[in, out] The requested maximum size, in bytes, of pbBlob. Upon return, the actual size, in bytes, of pbBlob.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameGetBlobFromImage(
            [In] ref byte pbBase,
            [In] uint dwLength,
            out byte pbBlob,
            [In] [Out] ref uint pcbBlob);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameGetPublicKey(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] ref byte pbKeyBlob,
            [In] uint cbKeyBlob,
            [Out] IntPtr ppbPublicKeyBlob,
            out uint pcbPublicKeyBlob);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameHashSize([In] uint ulHashAlg);

        /// <summary>
        /// Deletes the specified key container.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The name of the key container to delete.</param>
        /// <remarks>
        /// Use the <see cref="ICLRStrongName.StrongNameKeyInstall"/> method to import a public/private key pair into a container.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameKeyDelete([MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer);

        /// <summary>
        /// Creates a new public/private key pair for strong name use.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The requested key container name. wszKeyContainer must either be a non-empty string or null to generate a temporary name.</param>
        /// <param name="dwFlags">[in] A value that specifies whether to leave the key registered. The following values are supported:</param>
        /// <param name="ppbKeyBlob">[out] The returned public/private key pair.</param>
        /// <param name="pcbKeyBlob">[out] The size, in bytes, of ppbKeyBlob.</param>
        /// <remarks>
        /// The <see cref="ICLRStrongName.StrongNameKeyGen"/> method creates a 1024-bit key. After the key is retrieved, you
        /// should call the <see cref="ICLRStrongName.StrongNameFreeBuffer"/> method to release the allocated memory.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameKeyGen(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] uint dwFlags,
            [Out] IntPtr ppbKeyBlob,
            out uint pcbKeyBlob);

        /// <summary>
        /// Generates a new public/private key pair with the specified key size, for strong name use.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The requested key container name. wszKeyContainer must either be a non-empty string or null to generate a temporary name.</param>
        /// <param name="dwFlags">[in] A value that specifies whether to leave the key registered. The following values are supported:</param>
        /// <param name="dwKeySize">[in] The requested size of the key, in bits.</param>
        /// <param name="ppbKeyBlob">[out] The returned public/private key pair.</param>
        /// <param name="pcbKeyBlob">[out] The size, in bytes, of ppbKeyBlob.</param>
        /// <remarks>
        /// The .NET Framework versions 1.0 and 1.1 require a dwKeySize of 1024 bits to sign an assembly with a strong name;
        /// version 2.0 adds supports for 2048-bit keys. After the key is retrieved, you should call the <see cref="ICLRStrongName.StrongNameFreeBuffer"/>
        /// method to release the allocated memory.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameKeyGenEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] uint dwFlags,
            [In] uint dwKeySize,
            [Out] IntPtr ppbKeyBlob,
            out uint pcbKeyBlob);

        /// <summary>
        /// Imports a public/private key pair into a container.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The name of the key container. wszKeyContainer must be a non-empty string.</param>
        /// <param name="pbKeyBlob">[in] The binary key pair.</param>
        /// <param name="cbKeyBlob">[in] The size, in bytes, of pbKeyBlob.</param>
        /// <remarks>
        /// Use the <see cref="ICLRStrongName.StrongNameKeyDelete"/> method to delete the key container.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameKeyInstall([MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] ref byte pbKeyBlob, [In] uint cbKeyBlob);

        /// <summary>
        /// Generates a strong name signature for the specified assembly.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the file that contains the manifest of the assembly for which the strong name signature will be generated.</param>
        /// <param name="pwzKeyContainer">[in] The name of the key container that contains the public/private key pair.
        /// If pbKeyBlob is null, wszKeyContainer must specify a valid container within the cryptographic service provider (CSP). In this case, the key pair stored in the container is used to sign the file.
        /// If pbKeyBlob is not null, the key pair is assumed to be contained in the key binary large object (BLOB).
        /// The keys must be 1024-bit Rivest-Shamir-Adleman (RSA) signing keys. No other types of keys are supported at this time.</param>
        /// <param name="pbKeyBlob">[in] A pointer to the public/private key pair. This pair is in the format created by the Win32 CryptExportKey function. If pbKeyBlob is null, the key container specified by wszKeyContainer is assumed to contain the key pair.</param>
        /// <param name="cbKeyBlob">[in] The size, in bytes, of pbKeyBlob.</param>
        /// <param name="ppbSignatureBlob">[out] A pointer to the location to which the common language runtime returns the signature. If ppbSignatureBlob is null, the runtime stores the signature in the file specified by wszFilePath.
        /// If ppbSignatureBlob is not null, the common language runtime allocates space in which to return the signature. The caller must free this space by using the <see cref="ICLRStrongName.StrongNameFreeBuffer"/> method.</param>
        /// <param name="pcbSignatureBlob">[out] The size, in bytes, of the returned signature.</param>
        /// <remarks>
        /// Specify null for wszFilePath to calculate the size of the signature without creating the signature. The signature
        /// can be stored either directly in the file, or returned to the caller.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureGeneration(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] ref byte pbKeyBlob,
            [In] uint cbKeyBlob,
            [Out] IntPtr ppbSignatureBlob,
            out uint pcbSignatureBlob);

        /// <summary>
        /// Generates a strong name signature for the specified assembly, according to the specified flags.
        /// </summary>
        /// <param name="wszFilePath">[in] The path to the file that contains the manifest of the assembly for which the strong name signature will be generated.</param>
        /// <param name="wszKeyContainer">[in] The name of the key container that contains the public/private key pair.
        /// If pbKeyBlob is null, wszKeyContainer must specify a valid container within the cryptographic service provider (CSP). In this case, the key pair stored in the container is used to sign the file.
        /// If pbKeyBlob is not null, the key pair is assumed to be contained in the key binary large object (BLOB).</param>
        /// <param name="pbKeyBlob">[in] A pointer to the public/private key pair. This pair is in the format created by the Win32 CryptExportKey function. If pbKeyBlob is null, the key container specified by wszKeyContainer is assumed to contain the key pair.</param>
        /// <param name="cbKeyBlob">[in] The size, in bytes, of pbKeyBlob.</param>
        /// <param name="ppbSignatureBlob">[out] A pointer to the location to which the common language runtime returns the signature. If ppbSignatureBlob is null, the runtime stores the signature in the file specified by wszFilePath.
        /// If ppbSignatureBlob is not null, the common language runtime allocates space in which to return the signature. The caller must free this space using the <see cref="ICLRStrongName.StrongNameFreeBuffer"/> method.</param>
        /// <param name="pcbSignatureBlob">[out] The size, in bytes, of the returned signature.</param>
        /// <param name="dwFlags">[in] One or more of the following values:</param>
        /// <remarks>
        /// Specify null for wszFilePath to calculate the size of the signature without creating the signature. The signature
        /// can be either stored directly in the file, or returned to the caller. If SN_SIGN_ALL_FILES is specified but a public
        /// key is not included (both pbKeyBlob and wszFilePath are null), hashes for linked modules are recomputed, but the
        /// assembly is not re-signed. If SN_TEST_SIGN is specified, the common language runtime header is not modified to
        /// indicate that the assembly is signed with a strong name.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureGenerationEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszFilePath,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszKeyContainer,
            [In] ref byte pbKeyBlob,
            [In] uint cbKeyBlob,
            [Out] IntPtr ppbSignatureBlob,
            out uint pcbSignatureBlob,
            [In] uint dwFlags);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureSize([In] ref byte pbPublicKeyBlob, [In] uint cbPublicKeyBlob, [In] ref uint pcbSize);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureVerification([MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In] uint dwInFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        sbyte StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In] sbyte fForceVerification);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureVerificationFromImage([In] ref byte pbBase, [In] uint dwLength, [In] uint dwInFlags);

        /// <summary>
        /// Creates a strong name token from the specified assembly file.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the portable executable (PE) file for the assembly.</param>
        /// <param name="ppbStrongNameToken">[out] The returned strong name token.</param>
        /// <param name="pcbStrongNameToken">[out] The size, in bytes, of the strong name token.</param>
        /// <remarks>
        /// A strong name token is the shortened form of a public key. The token is a 64-bit hash that is created from the
        /// public key used to sign the assembly. The token is a part of the strong name for the assembly, and can be read
        /// from the assembly metadata. After the token is created, you should call the <see cref="ICLRStrongName.StrongNameFreeBuffer"/>
        /// method to release the allocated memory.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameTokenFromAssembly(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [Out] IntPtr ppbStrongNameToken,
            out uint pcbStrongNameToken);

        /// <summary>
        /// Creates a strong name token from the specified assembly file, and returns the public key that the token represents.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the portable executable (PE) file for the assembly.</param>
        /// <param name="ppbStrongNameToken">[out] The returned strong name token.</param>
        /// <param name="pcbStrongNameToken">[out] The size, in bytes, of the strong name token.</param>
        /// <param name="ppbPublicKeyBlob">[out] The returned public key.</param>
        /// <param name="pcbPublicKeyBlob">[out] The size, in bytes, of the public key.</param>
        /// <remarks>
        /// A strong name token is the shortened form of a public key. The token is a 64-bit hash that is created from the
        /// public key used to sign the assembly. The token is a part of the strong name for the assembly, and can be read
        /// from the assembly metadata. After the key is retrieved and the token is created, you should call the <see cref="ICLRStrongName.StrongNameFreeBuffer"/>
        /// method to release the allocated memory.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameTokenFromAssemblyEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [Out] IntPtr ppbStrongNameToken,
            out uint pcbStrongNameToken,
            [Out] IntPtr ppbPublicKeyBlob,
            out uint pcbPublicKeyBlob);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameTokenFromPublicKey(
            [In] ref byte pbPublicKeyBlob,
            [In] uint cbPublicKeyBlob,
            [Out] IntPtr ppbStrongNameToken,
            out uint pcbStrongNameToken);
    }
}