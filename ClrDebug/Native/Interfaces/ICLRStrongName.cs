using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides basic global static functions for signing assemblies with strong names. All <see cref="ICLRStrongName"/> methods return standard COM HRESULTs.
    /// </summary>
    /// <remarks>
    /// You can get an instance of the <see cref="ICLRStrongName"/> by calling the <see cref="ICLRRuntimeInfo.GetInterface"/> method
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
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromAssemblyFile(
            [MarshalAs(UnmanagedType.LPStr), In] string pszFilePath,
            [In, Out] ref int piHashAlg,
            [Out] IntPtr pbHash,
            [In] int cchHash,
            [Out] out int pchHash);

        /// <summary>
        /// Generates a hash over the contents of the file specified by a Unicode string.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the file to be hashed. This parameter must be a Unicode string.</param>
        /// <param name="piHashAlg">[in, out] A constant that specifies the hash algorithm. Use zero for the default hash algorithm.</param>
        /// <param name="pbHash">[out] The returned hash buffer.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <param name="pchHash">[out] The returned size, in bytes, of pbHash.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromAssemblyFileW(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In, Out] ref int piHashAlg,
            [Out] IntPtr pbHash,
            [In] int cchHash,
            [Out] out int pchHash);

        /// <summary>
        /// Gets a hash of the assembly at the specified memory address, using the specified hash algorithm.
        /// </summary>
        /// <param name="pbBlob">[in] A pointer to the address of the memory block to be hashed.</param>
        /// <param name="cchBlob">[in] The length, in bytes, of the memory block.</param>
        /// <param name="piHashAlg">[in, out] A constant that specifies the hash algorithm. Use zero for the default algorithm.</param>
        /// <param name="pbHash">[out] The returned hash buffer.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <param name="pchHash">[out] The size, in bytes, of the returned pbHash.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromBlob(
            [In] IntPtr pbBlob,
            [In] int cchBlob,
            [In, Out] ref int piHashAlg,
            [Out] IntPtr pbHash,
            [In] int cchHash,
            [Out] out int pchHash);

        /// <summary>
        /// Generates a hash over the contents of the specified file.
        /// </summary>
        /// <param name="pszFilePath">[in] The name of the file to hash.</param>
        /// <param name="piHashAlg">[in, out] The algorithm to use when generating the hash. Valid algorithms are those defined by the Win32 CryptoAPI.<para/>
        /// If piHashAlg is set to 0, the default algorithm CALG_SHA-1 is used.</param>
        /// <param name="pbHash">[out] A byte array containing the generated hash.</param>
        /// <param name="cchHash">[in] The maximum size of the buffer that pbHash points to.</param>
        /// <param name="pchHash">[out] The size, in bytes, of the returned pbHash.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// This method is the same as the <see cref="GetHashFromFileW"/> method, except that the file name specification is
        /// ANSI instead of Unicode.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromFile(
            [MarshalAs(UnmanagedType.LPStr), In] string pszFilePath,
            [In, Out] ref int piHashAlg,
            [Out] IntPtr pbHash,
            [In] int cchHash,
            [Out] out int pchHash);

        /// <summary>
        /// Generates a hash over the contents of the file specified by a Unicode string.
        /// </summary>
        /// <param name="pwzFilePath">[in] The Unicode name of the file to hash.</param>
        /// <param name="piHashAlg">[in, out] The algorithm to use when generating the hash. Valid algorithms are those defined by the Win32 CryptoAPI.<para/>
        /// If piHashAlg is set to 0, the default algorithm CALG_SHA-1 is used.</param>
        /// <param name="pbHash">[out] A byte array containing the generated hash.</param>
        /// <param name="cchHash">[in] The maximum size of the buffer pointed to by pbHash.</param>
        /// <param name="pchHash">[out] The size, in bytes, of pbHash.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// This method is the same as the <see cref="GetHashFromFile"/> method, except that the file name specification is
        /// Unicode instead of ANSI.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromFileW(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In, Out] ref int piHashAlg,
            [Out] IntPtr pbHash,
            [In] int cchHash,
            [Out] out int pchHash);

        /// <summary>
        /// Generates a hash over the contents of the file that has the specified file handle, using the specified hash algorithm.
        /// </summary>
        /// <param name="hFile">[in] The handle of the file to be hashed.</param>
        /// <param name="piHashAlg">[in, out] A constant that specifies the hash algorithm. Use zero for the default algorithm.</param>
        /// <param name="pbHash">[out] The returned hash buffer.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <param name="pchHash">[out] The size, in bytes, of the returned pbHash.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromHandle(
            [In] IntPtr hFile,
            [In, Out] ref int piHashAlg,
            [Out] IntPtr pbHash,
            [In] int cchHash,
            [Out] out int pchHash);

        /// <summary>
        /// Determines whether two assemblies differ only by their strong name signatures.
        /// </summary>
        /// <param name="wszAssembly1">[in] The path to the first assembly.</param>
        /// <param name="wszAssembly2">[in] The path to the second assembly.</param>
        /// <param name="pdwResult">[out] One of the following values:</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// The strong name signature of an assembly consists of the assembly's text name, version, culture, and public key
        /// token.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameCompareAssemblies(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszAssembly1,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszAssembly2,
            [Out] out int pdwResult);

        /// <summary>
        /// Frees memory that was allocated with a previous call to a strong name method such as <see cref="StrongNameGetPublicKey"/>, <see cref="StrongNameTokenFromPublicKey"/>, or <see cref="StrongNameSignatureGeneration"/>.
        /// </summary>
        /// <param name="pbMemory">[in] A pointer to the memory to free.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameFreeBuffer(
            [In] IntPtr pbMemory);

        /// <summary>
        /// Fills the specified buffer with the binary representation of the executable file at the specified address.
        /// </summary>
        /// <param name="pwzFilePath">[in] A valid path to the executable file to be loaded.</param>
        /// <param name="pbBlob">[in] The buffer into which to load the executable file.</param>
        /// <param name="pcbBlob">[in, out] The requested maximum size, in bytes, of pbBlob. Upon return, the actual size, in bytes, of pbBlob.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameGetBlob(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In, Out] IntPtr pbBlob,
            [In, Out] ref int pcbBlob);

        /// <summary>
        /// Gets a binary representation of the assembly image at the specified memory address.
        /// </summary>
        /// <param name="pbBase">[in] The memory address of the mapped assembly manifest.</param>
        /// <param name="dwLength">[in] The size, in bytes, of the image at pbBase.</param>
        /// <param name="pbBlob">[in] A buffer to contain the binary representation of the image.</param>
        /// <param name="pcbBlob">[in, out] The requested maximum size, in bytes, of pbBlob. Upon return, the actual size, in bytes, of pbBlob.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameGetBlobFromImage(
            [In] IntPtr pbBase,
            [In] int dwLength,
            [Out] IntPtr pbBlob,
            [In, Out] ref int pcbBlob);

        /// <summary>
        /// Gets the public key from a public/private key pair. The key pair can be supplied either as a key container name within a cryptographic service provider (CSP) or as a raw collection of bytes.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The name of the key container that contains the public/private key pair. If pbKeyBlob is null, szKeyContainer must specify a valid container within the CSP.<para/>
        /// In this case, the <see cref="StrongNameGetPublicKey"/> method extracts the public key from the key pair stored in the container.<para/>
        /// If pbKeyBlob is not null, the key pair is assumed to be contained in the key binary large object (BLOB). The keys must be 1024-bit Rivest-Shamir-Adleman (RSA) signing keys.<para/>
        /// No other types of keys are supported at this time.</param>
        /// <param name="pbKeyBlob">[in] A pointer to the public/private key pair. This pair is in the format created by the Win32 CryptExportKey function.<para/>
        /// If pbKeyBlob is null, the key container specified by szKeyContainer is assumed to contain the key pair.</param>
        /// <param name="cbKeyBlob">[in] The size, in bytes, of pbKeyBlob.</param>
        /// <param name="ppbPublicKeyBlob">[out] The returned public key BLOB. The ppbPublicKeyBlob parameter is allocated by the common language runtime and returned to the caller.<para/>
        /// The caller must free the memory by using the <see cref="StrongNameFreeBuffer"/> method.</param>
        /// <param name="pcbPublicKeyBlob">[out] The size of the returned public key BLOB.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// The public key is contained in a <see cref="PublicKeyBlob"/> structure.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameGetPublicKey(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] IntPtr pbKeyBlob,
            [In] int cbKeyBlob,
            [Out] out IntPtr ppbPublicKeyBlob,
            [Out] out int pcbPublicKeyBlob);

        /// <summary>
        /// Gets the buffer size required for a hash, using the specified hash algorithm.
        /// </summary>
        /// <param name="ulHashAlg">[in] The hash algorithm used to compute the buffer size.</param>
        /// <param name="pcbSize">[out] The returned buffer size, in bytes.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameHashSize(
            [In] int ulHashAlg,
            [Out] out int pcbSize);

        /// <summary>
        /// Deletes the specified key container.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The name of the key container to delete.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// Use the <see cref="StrongNameKeyInstall"/> method to import a public/private key pair into a container.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameKeyDelete(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer);

        /// <summary>
        /// Creates a new public/private key pair for strong name use.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The requested key container name. wszKeyContainer must either be a non-empty string or null to generate a temporary name.</param>
        /// <param name="dwFlags">[in] A value that specifies whether to leave the key registered. The following values are supported:</param>
        /// <param name="ppbKeyBlob">[out] The returned public/private key pair.</param>
        /// <param name="pcbKeyBlob">[out] The size, in bytes, of ppbKeyBlob.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// The <see cref="StrongNameKeyGen"/> method creates a 1024-bit key. After the key is retrieved, you should call the
        /// <see cref="StrongNameFreeBuffer"/> method to release the allocated memory.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameKeyGen(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] SN_LEAVE dwFlags,
            [Out] out IntPtr ppbKeyBlob,
            [Out] out int pcbKeyBlob);

        /// <summary>
        /// Generates a new public/private key pair with the specified key size, for strong name use.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The requested key container name. wszKeyContainer must either be a non-empty string or null to generate a temporary name.</param>
        /// <param name="dwFlags">[in] A value that specifies whether to leave the key registered. The following values are supported:</param>
        /// <param name="dwKeySize">[in] The requested size of the key, in bits.</param>
        /// <param name="ppbKeyBlob">[out] The returned public/private key pair.</param>
        /// <param name="pcbKeyBlob">[out] The size, in bytes, of ppbKeyBlob.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// The .NET Framework versions 1.0 and 1.1 require a dwKeySize of 1024 bits to sign an assembly with a strong name;
        /// version 2.0 adds supports for 2048-bit keys. After the key is retrieved, you should call the <see cref="StrongNameFreeBuffer"/>
        /// method to release the allocated memory.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameKeyGenEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] SN_LEAVE dwFlags,
            [In] int dwKeySize,
            [Out] out IntPtr ppbKeyBlob,
            [Out] out int pcbKeyBlob);

        /// <summary>
        /// Imports a public/private key pair into a container.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The name of the key container. wszKeyContainer must be a non-empty string.</param>
        /// <param name="pbKeyBlob">[in] The binary key pair.</param>
        /// <param name="cbKeyBlob">[in] The size, in bytes, of pbKeyBlob.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// Use the <see cref="StrongNameKeyDelete"/> method to delete the key container.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameKeyInstall(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] IntPtr pbKeyBlob,
            [In] int cbKeyBlob);

        /// <summary>
        /// Generates a strong name signature for the specified assembly.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the file that contains the manifest of the assembly for which the strong name signature will be generated.</param>
        /// <param name="pwzKeyContainer">[in] The name of the key container that contains the public/private key pair. If pbKeyBlob is null, wszKeyContainer must specify a valid container within the cryptographic service provider (CSP).<para/>
        /// In this case, the key pair stored in the container is used to sign the file. If pbKeyBlob is not null, the key pair is assumed to be contained in the key binary large object (BLOB).<para/>
        /// The keys must be 1024-bit Rivest-Shamir-Adleman (RSA) signing keys. No other types of keys are supported at this time.</param>
        /// <param name="pbKeyBlob">[in] A pointer to the public/private key pair. This pair is in the format created by the Win32 CryptExportKey function.<para/>
        /// If pbKeyBlob is null, the key container specified by wszKeyContainer is assumed to contain the key pair.</param>
        /// <param name="cbKeyBlob">[in] The size, in bytes, of pbKeyBlob.</param>
        /// <param name="ppbSignatureBlob">[out] A pointer to the location to which the common language runtime returns the signature. If ppbSignatureBlob is null, the runtime stores the signature in the file specified by wszFilePath.<para/>
        /// If ppbSignatureBlob is not null, the common language runtime allocates space in which to return the signature. The caller must free this space by using the <see cref="StrongNameFreeBuffer"/> method.</param>
        /// <param name="pcbSignatureBlob">[out] The size, in bytes, of the returned signature.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// Specify null for wszFilePath to calculate the size of the signature without creating the signature. The signature
        /// can be stored either directly in the file, or returned to the caller.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureGeneration(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] IntPtr pbKeyBlob,
            [In] int cbKeyBlob,
            [Out] out IntPtr ppbSignatureBlob,
            [Out] out int pcbSignatureBlob);

        /// <summary>
        /// Generates a strong name signature for the specified assembly, according to the specified flags.
        /// </summary>
        /// <param name="wszFilePath">[in] The path to the file that contains the manifest of the assembly for which the strong name signature will be generated.</param>
        /// <param name="wszKeyContainer">[in] The name of the key container that contains the public/private key pair. If pbKeyBlob is null, wszKeyContainer must specify a valid container within the cryptographic service provider (CSP).<para/>
        /// In this case, the key pair stored in the container is used to sign the file. If pbKeyBlob is not null, the key pair is assumed to be contained in the key binary large object (BLOB).</param>
        /// <param name="pbKeyBlob">[in] A pointer to the public/private key pair. This pair is in the format created by the Win32 CryptExportKey function.<para/>
        /// If pbKeyBlob is null, the key container specified by wszKeyContainer is assumed to contain the key pair.</param>
        /// <param name="cbKeyBlob">[in] The size, in bytes, of pbKeyBlob.</param>
        /// <param name="ppbSignatureBlob">[out] A pointer to the location to which the common language runtime returns the signature. If ppbSignatureBlob is null, the runtime stores the signature in the file specified by wszFilePath.<para/>
        /// If ppbSignatureBlob is not null, the common language runtime allocates space in which to return the signature. The caller must free this space using the <see cref="StrongNameFreeBuffer"/> method.</param>
        /// <param name="pcbSignatureBlob">[out] The size, in bytes, of the returned signature.</param>
        /// <param name="dwFlags">[in] One or more of the following values:</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
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
            [In] IntPtr pbKeyBlob,
            [In] int cbKeyBlob,
            [Out] out IntPtr ppbSignatureBlob,
            [Out] out int pcbSignatureBlob,
            [In] SN_SIGN dwFlags);

        /// <summary>
        /// Returns the size of the strong name signature. This method is typically used by compilers to determine how much space to reserve in the file when creating a delay-signed assembly.
        /// </summary>
        /// <param name="pbPublicKeyBlob">[in] A structure of type <see cref="PublicKeyBlob"/> that contains the public portion of the key pair used to generate the strong name signature.</param>
        /// <param name="cbPublicKeyBlob">[in] The size, in bytes, of pbPublicKeyBlob.</param>
        /// <param name="pcbSize">[in] The number of bytes required to store the strong name signature.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureSize(
            [In] IntPtr pbPublicKeyBlob,
            [In] int cbPublicKeyBlob,
            [In] ref int pcbSize);

        /// <summary>
        /// Gets a value that indicates whether the assembly manifest at the supplied path contains a strong name signature, which is verified according to the specified flags.
        /// </summary>
        /// <param name="wszFilePath">[in] The path to the portable executable (.dll or .exe) file for the assembly to verify.</param>
        /// <param name="dwInFlags">[in] Flags to modify the verification behavior. The following values are supported:</param>
        /// <param name="pdwOutFlags">[out] Flags indicating whether the strong name signature was verified. The following value is supported:</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureVerification(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszFilePath,
            [In] SN_INFLAG dwInFlags,
            [Out] out SN_OUTFLAG pdwOutFlags);

        /// <summary>
        /// Gets a value that indicates whether the assembly manifest at the supplied path contains a strong name signature.
        /// </summary>
        /// <param name="wszFilePath">[in] The path to the portable executable (.exe or .dll) file for the assembly to be verified.</param>
        /// <param name="fForceVerification">[in] true to perform verification, even if it is necessary to override registry settings; otherwise, false.</param>
        /// <param name="pfWasVerified">[out] true if the strong name signature was verified; otherwise, false. pfWasVerified is also set to false if the verification was successful due to registry settings.</param>
        /// <returns>S_OK if the verification was successful; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// The <see cref="StrongNameSignatureVerificationEx"/> method provides a capability similar to the <see cref="StrongNameSignatureVerification"/>
        /// method. However, the second input parameter and the output parameter for <see cref="StrongNameSignatureVerificationEx"/>
        /// are of type BOOLEAN instead of DWORD.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureVerificationEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszFilePath,
            [In] bool fForceVerification,
            [Out] bool pfWasVerified);

        /// <summary>
        /// Verifies that an assembly that has already been mapped to memory is valid for the associated public key.
        /// </summary>
        /// <param name="pbBase">[in] The relative virtual address of the mapped assembly manifest.</param>
        /// <param name="dwLength">[in] The size, in bytes, of the mapped image.</param>
        /// <param name="dwInFlags">[in] Flags that influence verification behavior. The following values are supported:</param>
        /// <param name="pdwOutFlags">[out] A flag for additional output information. The following value is supported:</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureVerificationFromImage(
            [In] IntPtr pbBase,
            [In] int dwLength,
            [In] SN_INFLAG dwInFlags,
            [Out] out SN_OUTFLAG pdwOutFlags);

        /// <summary>
        /// Creates a strong name token from the specified assembly file.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the portable executable (PE) file for the assembly.</param>
        /// <param name="ppbStrongNameToken">[out] The returned strong name token.</param>
        /// <param name="pcbStrongNameToken">[out] The size, in bytes, of the strong name token.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// A strong name token is the shortened form of a public key. The token is a 64-bit hash that is created from the
        /// public key used to sign the assembly. The token is a part of the strong name for the assembly, and can be read
        /// from the assembly metadata. After the token is created, you should call the <see cref="StrongNameFreeBuffer"/>
        /// method to release the allocated memory.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameTokenFromAssembly(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [Out] out IntPtr ppbStrongNameToken,
            [Out] out int pcbStrongNameToken);

        /// <summary>
        /// Creates a strong name token from the specified assembly file, and returns the public key that the token represents.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the portable executable (PE) file for the assembly.</param>
        /// <param name="ppbStrongNameToken">[out] The returned strong name token.</param>
        /// <param name="pcbStrongNameToken">[out] The size, in bytes, of the strong name token.</param>
        /// <param name="ppbPublicKeyBlob">[out] The returned public key.</param>
        /// <param name="pcbPublicKeyBlob">[out] The size, in bytes, of the public key.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// A strong name token is the shortened form of a public key. The token is a 64-bit hash that is created from the
        /// public key used to sign the assembly. The token is a part of the strong name for the assembly, and can be read
        /// from the assembly metadata. After the key is retrieved and the token is created, you should call the <see cref="StrongNameFreeBuffer"/>
        /// method to release the allocated memory.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameTokenFromAssemblyEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [Out] IntPtr ppbStrongNameToken,
            [Out] out int pcbStrongNameToken,
            [Out] out IntPtr ppbPublicKeyBlob,
            [Out] out int pcbPublicKeyBlob);

        /// <summary>
        /// Gets a token that represents a public key. A strong name token is the shortened form of a public key.
        /// </summary>
        /// <param name="pbPublicKeyBlob">[in] A structure of type <see cref="PublicKeyBlob"/> that contains the public portion of the key pair used to generate the strong name signature.</param>
        /// <param name="cbPublicKeyBlob">[in] The size, in bytes, of pbPublicKeyBlob.</param>
        /// <param name="ppbStrongNameToken">[out] The strong name token corresponding to the key passed in pbPublicKeyBlob. The common language runtime allocates the memory in which to return the token.<para/>
        /// The caller must free this memory by using the <see cref="StrongNameFreeBuffer"/> method.</param>
        /// <param name="pcbStrongNameToken">[out] The size, in bytes, of the returned strong name token.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// A strong name token is the shortened form of a public key that is used to save space when storing key information
        /// in metadata. Specifically, strong name tokens are used in assembly references to refer to the dependent assembly.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameTokenFromPublicKey(
            [In] IntPtr pbPublicKeyBlob,
            [In] int cbPublicKeyBlob,
            [Out] out IntPtr ppbStrongNameToken,
            [Out] out int pcbStrongNameToken);
    }
}
