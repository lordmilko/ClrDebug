using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides basic global static functions for signing assemblies with strong names. All <see cref="ICLRStrongName"/> methods return standard COM HRESULTs.
    /// </summary>
    /// <remarks>
    /// You can get an instance of the <see cref="ICLRStrongName"/> by calling the <see cref="CLRRuntimeInfo.GetInterface"/> method
    /// using CLSID_CLRStrongName and IID_ICLRStrongName as parameters.
    /// </remarks>
    public class CLRStrongName : ComObject<ICLRStrongName>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRStrongName"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CLRStrongName(ICLRStrongName raw) : base(raw)
        {
        }

        #region ICLRStrongName
        #region GetHashFromAssemblyFile

        /// <summary>
        /// Gets a hash of the specified assembly file, using the specified hash algorithm.
        /// </summary>
        /// <param name="pszFilePath">[in] The path to the file to be hashed.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetHashFromAssemblyFileResult GetHashFromAssemblyFile(string pszFilePath, int cchHash)
        {
            HRESULT hr;
            GetHashFromAssemblyFileResult result;

            if ((hr = TryGetHashFromAssemblyFile(pszFilePath, cchHash, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets a hash of the specified assembly file, using the specified hash algorithm.
        /// </summary>
        /// <param name="pszFilePath">[in] The path to the file to be hashed.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        public HRESULT TryGetHashFromAssemblyFile(string pszFilePath, int cchHash, out GetHashFromAssemblyFileResult result)
        {
            /*HRESULT GetHashFromAssemblyFile(
            [MarshalAs(UnmanagedType.LPStr), In] string pszFilePath,
            [In] [Out] ref int piHashAlg,
            out byte pbHash,
            [In] int cchHash,
            out int pchHash);*/
            int piHashAlg = default(int);
            byte pbHash;
            int pchHash;
            HRESULT hr = Raw.GetHashFromAssemblyFile(pszFilePath, ref piHashAlg, out pbHash, cchHash, out pchHash);

            if (hr == HRESULT.S_OK)
                result = new GetHashFromAssemblyFileResult(piHashAlg, pbHash, pchHash);
            else
                result = default(GetHashFromAssemblyFileResult);

            return hr;
        }

        #endregion
        #region GetHashFromAssemblyFileW

        /// <summary>
        /// Generates a hash over the contents of the file specified by a Unicode string.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the file to be hashed. This parameter must be a Unicode string.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetHashFromAssemblyFileWResult GetHashFromAssemblyFileW(string pwzFilePath, int cchHash)
        {
            HRESULT hr;
            GetHashFromAssemblyFileWResult result;

            if ((hr = TryGetHashFromAssemblyFileW(pwzFilePath, cchHash, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Generates a hash over the contents of the file specified by a Unicode string.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the file to be hashed. This parameter must be a Unicode string.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        public HRESULT TryGetHashFromAssemblyFileW(string pwzFilePath, int cchHash, out GetHashFromAssemblyFileWResult result)
        {
            /*HRESULT GetHashFromAssemblyFileW(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In] [Out] ref int piHashAlg,
            out byte pbHash,
            [In] int cchHash,
            out int pchHash);*/
            int piHashAlg = default(int);
            byte pbHash;
            int pchHash;
            HRESULT hr = Raw.GetHashFromAssemblyFileW(pwzFilePath, ref piHashAlg, out pbHash, cchHash, out pchHash);

            if (hr == HRESULT.S_OK)
                result = new GetHashFromAssemblyFileWResult(piHashAlg, pbHash, pchHash);
            else
                result = default(GetHashFromAssemblyFileWResult);

            return hr;
        }

        #endregion
        #region GetHashFromBlob

        /// <summary>
        /// Gets a hash of the assembly at the specified memory address, using the specified hash algorithm.
        /// </summary>
        /// <param name="pbBlob">[in] A pointer to the address of the memory block to be hashed.</param>
        /// <param name="cchBlob">[in] The length, in bytes, of the memory block.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetHashFromBlobResult GetHashFromBlob(IntPtr pbBlob, int cchBlob, int cchHash)
        {
            HRESULT hr;
            GetHashFromBlobResult result;

            if ((hr = TryGetHashFromBlob(pbBlob, cchBlob, cchHash, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets a hash of the assembly at the specified memory address, using the specified hash algorithm.
        /// </summary>
        /// <param name="pbBlob">[in] A pointer to the address of the memory block to be hashed.</param>
        /// <param name="cchBlob">[in] The length, in bytes, of the memory block.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        public HRESULT TryGetHashFromBlob(IntPtr pbBlob, int cchBlob, int cchHash, out GetHashFromBlobResult result)
        {
            /*HRESULT GetHashFromBlob(
            [In] IntPtr pbBlob,
            [In] int cchBlob,
            [In] [Out] ref int piHashAlg,
            out byte pbHash,
            [In] int cchHash,
            out int pchHash);*/
            int piHashAlg = default(int);
            byte pbHash;
            int pchHash;
            HRESULT hr = Raw.GetHashFromBlob(pbBlob, cchBlob, ref piHashAlg, out pbHash, cchHash, out pchHash);

            if (hr == HRESULT.S_OK)
                result = new GetHashFromBlobResult(piHashAlg, pbHash, pchHash);
            else
                result = default(GetHashFromBlobResult);

            return hr;
        }

        #endregion
        #region GetHashFromFile

        /// <summary>
        /// Generates a hash over the contents of the specified file.
        /// </summary>
        /// <param name="pszFilePath">[in] The name of the file to hash.</param>
        /// <param name="cchHash">[in] The maximum size of the buffer that pbHash points to.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// This method is the same as the <see cref="GetHashFromFileW"/> method, except that the file name specification is
        /// ANSI instead of Unicode.
        /// </remarks>
        public GetHashFromFileResult GetHashFromFile(string pszFilePath, int cchHash)
        {
            HRESULT hr;
            GetHashFromFileResult result;

            if ((hr = TryGetHashFromFile(pszFilePath, cchHash, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Generates a hash over the contents of the specified file.
        /// </summary>
        /// <param name="pszFilePath">[in] The name of the file to hash.</param>
        /// <param name="cchHash">[in] The maximum size of the buffer that pbHash points to.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// This method is the same as the <see cref="GetHashFromFileW"/> method, except that the file name specification is
        /// ANSI instead of Unicode.
        /// </remarks>
        public HRESULT TryGetHashFromFile(string pszFilePath, int cchHash, out GetHashFromFileResult result)
        {
            /*HRESULT GetHashFromFile(
            [MarshalAs(UnmanagedType.LPStr), In] string pszFilePath,
            [In] [Out] ref int piHashAlg,
            out byte pbHash,
            [In] int cchHash,
            out int pchHash);*/
            int piHashAlg = default(int);
            byte pbHash;
            int pchHash;
            HRESULT hr = Raw.GetHashFromFile(pszFilePath, ref piHashAlg, out pbHash, cchHash, out pchHash);

            if (hr == HRESULT.S_OK)
                result = new GetHashFromFileResult(piHashAlg, pbHash, pchHash);
            else
                result = default(GetHashFromFileResult);

            return hr;
        }

        #endregion
        #region GetHashFromFileW

        /// <summary>
        /// Generates a hash over the contents of the file specified by a Unicode string.
        /// </summary>
        /// <param name="pwzFilePath">[in] The Unicode name of the file to hash.</param>
        /// <param name="cchHash">[in] The maximum size of the buffer pointed to by pbHash.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// This method is the same as the <see cref="GetHashFromFile"/> method, except that the file name specification is
        /// Unicode instead of ANSI.
        /// </remarks>
        public GetHashFromFileWResult GetHashFromFileW(string pwzFilePath, int cchHash)
        {
            HRESULT hr;
            GetHashFromFileWResult result;

            if ((hr = TryGetHashFromFileW(pwzFilePath, cchHash, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Generates a hash over the contents of the file specified by a Unicode string.
        /// </summary>
        /// <param name="pwzFilePath">[in] The Unicode name of the file to hash.</param>
        /// <param name="cchHash">[in] The maximum size of the buffer pointed to by pbHash.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// This method is the same as the <see cref="GetHashFromFile"/> method, except that the file name specification is
        /// Unicode instead of ANSI.
        /// </remarks>
        public HRESULT TryGetHashFromFileW(string pwzFilePath, int cchHash, out GetHashFromFileWResult result)
        {
            /*HRESULT GetHashFromFileW(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In] [Out] ref int piHashAlg,
            out byte pbHash,
            [In] int cchHash,
            out int pchHash);*/
            int piHashAlg = default(int);
            byte pbHash;
            int pchHash;
            HRESULT hr = Raw.GetHashFromFileW(pwzFilePath, ref piHashAlg, out pbHash, cchHash, out pchHash);

            if (hr == HRESULT.S_OK)
                result = new GetHashFromFileWResult(piHashAlg, pbHash, pchHash);
            else
                result = default(GetHashFromFileWResult);

            return hr;
        }

        #endregion
        #region GetHashFromHandle

        /// <summary>
        /// Generates a hash over the contents of the file that has the specified file handle, using the specified hash algorithm.
        /// </summary>
        /// <param name="hFile">[in] The handle of the file to be hashed.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetHashFromHandleResult GetHashFromHandle(IntPtr hFile, int cchHash)
        {
            HRESULT hr;
            GetHashFromHandleResult result;

            if ((hr = TryGetHashFromHandle(hFile, cchHash, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Generates a hash over the contents of the file that has the specified file handle, using the specified hash algorithm.
        /// </summary>
        /// <param name="hFile">[in] The handle of the file to be hashed.</param>
        /// <param name="cchHash">[in] The requested maximum size of pbHash.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        public HRESULT TryGetHashFromHandle(IntPtr hFile, int cchHash, out GetHashFromHandleResult result)
        {
            /*HRESULT GetHashFromHandle(
            [In] IntPtr hFile,
            [In] [Out] ref int piHashAlg,
            out byte pbHash,
            [In] int cchHash,
            out int pchHash);*/
            int piHashAlg = default(int);
            byte pbHash;
            int pchHash;
            HRESULT hr = Raw.GetHashFromHandle(hFile, ref piHashAlg, out pbHash, cchHash, out pchHash);

            if (hr == HRESULT.S_OK)
                result = new GetHashFromHandleResult(piHashAlg, pbHash, pchHash);
            else
                result = default(GetHashFromHandleResult);

            return hr;
        }

        #endregion
        #region StrongNameCompareAssemblies

        /// <summary>
        /// Determines whether two assemblies differ only by their strong name signatures.
        /// </summary>
        /// <param name="wszAssembly1">[in] The path to the first assembly.</param>
        /// <param name="wszAssembly2">[in] The path to the second assembly.</param>
        /// <returns>[out] One of the following values:</returns>
        /// <remarks>
        /// The strong name signature of an assembly consists of the assembly's text name, version, culture, and public key
        /// token.
        /// </remarks>
        public int StrongNameCompareAssemblies(string wszAssembly1, string wszAssembly2)
        {
            HRESULT hr;
            int pdwResult;

            if ((hr = TryStrongNameCompareAssemblies(wszAssembly1, wszAssembly2, out pdwResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pdwResult;
        }

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
        public HRESULT TryStrongNameCompareAssemblies(string wszAssembly1, string wszAssembly2, out int pdwResult)
        {
            /*HRESULT StrongNameCompareAssemblies(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszAssembly1,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszAssembly2,
            [Out] out int pdwResult);*/
            return Raw.StrongNameCompareAssemblies(wszAssembly1, wszAssembly2, out pdwResult);
        }

        #endregion
        #region StrongNameFreeBuffer

        /// <summary>
        /// Frees memory that was allocated with a previous call to a strong name method such as <see cref="StrongNameGetPublicKey"/>, <see cref="StrongNameTokenFromPublicKey"/>, or <see cref="StrongNameSignatureGeneration"/>.
        /// </summary>
        /// <param name="pbMemory">[in] A pointer to the memory to free.</param>
        public void StrongNameFreeBuffer(IntPtr pbMemory)
        {
            HRESULT hr;

            if ((hr = TryStrongNameFreeBuffer(pbMemory)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Frees memory that was allocated with a previous call to a strong name method such as <see cref="StrongNameGetPublicKey"/>, <see cref="StrongNameTokenFromPublicKey"/>, or <see cref="StrongNameSignatureGeneration"/>.
        /// </summary>
        /// <param name="pbMemory">[in] A pointer to the memory to free.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        public HRESULT TryStrongNameFreeBuffer(IntPtr pbMemory)
        {
            /*HRESULT StrongNameFreeBuffer([In] IntPtr pbMemory);*/
            return Raw.StrongNameFreeBuffer(pbMemory);
        }

        #endregion
        #region StrongNameGetBlob

        /// <summary>
        /// Fills the specified buffer with the binary representation of the executable file at the specified address.
        /// </summary>
        /// <param name="pwzFilePath">[in] A valid path to the executable file to be loaded.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public StrongNameGetBlobResult StrongNameGetBlob(string pwzFilePath)
        {
            HRESULT hr;
            StrongNameGetBlobResult result;

            if ((hr = TryStrongNameGetBlob(pwzFilePath, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Fills the specified buffer with the binary representation of the executable file at the specified address.
        /// </summary>
        /// <param name="pwzFilePath">[in] A valid path to the executable file to be loaded.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        public HRESULT TryStrongNameGetBlob(string pwzFilePath, out StrongNameGetBlobResult result)
        {
            /*HRESULT StrongNameGetBlob([MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath, [In] [Out] IntPtr pbBlob,
            [In] [Out] ref int pcbBlob);*/
            IntPtr pbBlob = default(IntPtr);
            int pcbBlob = default(int);
            HRESULT hr = Raw.StrongNameGetBlob(pwzFilePath, pbBlob, ref pcbBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameGetBlobResult(pbBlob, pcbBlob);
            else
                result = default(StrongNameGetBlobResult);

            return hr;
        }

        #endregion
        #region StrongNameGetBlobFromImage

        /// <summary>
        /// Gets a binary representation of the assembly image at the specified memory address.
        /// </summary>
        /// <param name="pbBase">[in] The memory address of the mapped assembly manifest.</param>
        /// <param name="dwLength">[in] The size, in bytes, of the image at pbBase.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public StrongNameGetBlobFromImageResult StrongNameGetBlobFromImage(IntPtr pbBase, int dwLength)
        {
            HRESULT hr;
            StrongNameGetBlobFromImageResult result;

            if ((hr = TryStrongNameGetBlobFromImage(pbBase, dwLength, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets a binary representation of the assembly image at the specified memory address.
        /// </summary>
        /// <param name="pbBase">[in] The memory address of the mapped assembly manifest.</param>
        /// <param name="dwLength">[in] The size, in bytes, of the image at pbBase.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        public HRESULT TryStrongNameGetBlobFromImage(IntPtr pbBase, int dwLength, out StrongNameGetBlobFromImageResult result)
        {
            /*HRESULT StrongNameGetBlobFromImage(
            [In] IntPtr pbBase,
            [In] int dwLength,
            out byte pbBlob,
            [In] [Out] ref int pcbBlob);*/
            byte pbBlob;
            int pcbBlob = default(int);
            HRESULT hr = Raw.StrongNameGetBlobFromImage(pbBase, dwLength, out pbBlob, ref pcbBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameGetBlobFromImageResult(pbBlob, pcbBlob);
            else
                result = default(StrongNameGetBlobFromImageResult);

            return hr;
        }

        #endregion
        #region StrongNameGetPublicKey

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
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The public key is contained in a <see cref="PublicKeyBlob"/> structure.
        /// </remarks>
        public StrongNameGetPublicKeyResult StrongNameGetPublicKey(string pwzKeyContainer, IntPtr pbKeyBlob, int cbKeyBlob)
        {
            HRESULT hr;
            StrongNameGetPublicKeyResult result;

            if ((hr = TryStrongNameGetPublicKey(pwzKeyContainer, pbKeyBlob, cbKeyBlob, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// The public key is contained in a <see cref="PublicKeyBlob"/> structure.
        /// </remarks>
        public HRESULT TryStrongNameGetPublicKey(string pwzKeyContainer, IntPtr pbKeyBlob, int cbKeyBlob, out StrongNameGetPublicKeyResult result)
        {
            /*HRESULT StrongNameGetPublicKey(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] IntPtr pbKeyBlob,
            [In] int cbKeyBlob,
            [Out] IntPtr ppbPublicKeyBlob,
            out int pcbPublicKeyBlob);*/
            IntPtr ppbPublicKeyBlob = default(IntPtr);
            int pcbPublicKeyBlob;
            HRESULT hr = Raw.StrongNameGetPublicKey(pwzKeyContainer, pbKeyBlob, cbKeyBlob, ppbPublicKeyBlob, out pcbPublicKeyBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameGetPublicKeyResult(ppbPublicKeyBlob, pcbPublicKeyBlob);
            else
                result = default(StrongNameGetPublicKeyResult);

            return hr;
        }

        #endregion
        #region StrongNameHashSize

        /// <summary>
        /// Gets the buffer size required for a hash, using the specified hash algorithm.
        /// </summary>
        /// <param name="ulHashAlg">[in] The hash algorithm used to compute the buffer size.</param>
        /// <returns>[out] The returned buffer size, in bytes.</returns>
        public int StrongNameHashSize(int ulHashAlg)
        {
            HRESULT hr;
            int pcbSize;

            if ((hr = TryStrongNameHashSize(ulHashAlg, out pcbSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pcbSize;
        }

        /// <summary>
        /// Gets the buffer size required for a hash, using the specified hash algorithm.
        /// </summary>
        /// <param name="ulHashAlg">[in] The hash algorithm used to compute the buffer size.</param>
        /// <param name="pcbSize">[out] The returned buffer size, in bytes.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        public HRESULT TryStrongNameHashSize(int ulHashAlg, out int pcbSize)
        {
            /*HRESULT StrongNameHashSize([In] int ulHashAlg, [Out] out int pcbSize);*/
            return Raw.StrongNameHashSize(ulHashAlg, out pcbSize);
        }

        #endregion
        #region StrongNameKeyDelete

        /// <summary>
        /// Deletes the specified key container.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The name of the key container to delete.</param>
        /// <remarks>
        /// Use the <see cref="StrongNameKeyInstall"/> method to import a public/private key pair into a container.
        /// </remarks>
        public void StrongNameKeyDelete(string pwzKeyContainer)
        {
            HRESULT hr;

            if ((hr = TryStrongNameKeyDelete(pwzKeyContainer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Deletes the specified key container.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The name of the key container to delete.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// Use the <see cref="StrongNameKeyInstall"/> method to import a public/private key pair into a container.
        /// </remarks>
        public HRESULT TryStrongNameKeyDelete(string pwzKeyContainer)
        {
            /*HRESULT StrongNameKeyDelete([MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer);*/
            return Raw.StrongNameKeyDelete(pwzKeyContainer);
        }

        #endregion
        #region StrongNameKeyGen

        /// <summary>
        /// Creates a new public/private key pair for strong name use.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The requested key container name. wszKeyContainer must either be a non-empty string or null to generate a temporary name.</param>
        /// <param name="dwFlags">[in] A value that specifies whether to leave the key registered. The following values are supported:</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The <see cref="StrongNameKeyGen"/> method creates a 1024-bit key. After the key is retrieved, you should call the
        /// <see cref="StrongNameFreeBuffer"/> method to release the allocated memory.
        /// </remarks>
        public StrongNameKeyGenResult StrongNameKeyGen(string pwzKeyContainer, int dwFlags)
        {
            HRESULT hr;
            StrongNameKeyGenResult result;

            if ((hr = TryStrongNameKeyGen(pwzKeyContainer, dwFlags, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Creates a new public/private key pair for strong name use.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The requested key container name. wszKeyContainer must either be a non-empty string or null to generate a temporary name.</param>
        /// <param name="dwFlags">[in] A value that specifies whether to leave the key registered. The following values are supported:</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// The <see cref="StrongNameKeyGen"/> method creates a 1024-bit key. After the key is retrieved, you should call the
        /// <see cref="StrongNameFreeBuffer"/> method to release the allocated memory.
        /// </remarks>
        public HRESULT TryStrongNameKeyGen(string pwzKeyContainer, int dwFlags, out StrongNameKeyGenResult result)
        {
            /*HRESULT StrongNameKeyGen(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] int dwFlags,
            [Out] IntPtr ppbKeyBlob,
            out int pcbKeyBlob);*/
            IntPtr ppbKeyBlob = default(IntPtr);
            int pcbKeyBlob;
            HRESULT hr = Raw.StrongNameKeyGen(pwzKeyContainer, dwFlags, ppbKeyBlob, out pcbKeyBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameKeyGenResult(ppbKeyBlob, pcbKeyBlob);
            else
                result = default(StrongNameKeyGenResult);

            return hr;
        }

        #endregion
        #region StrongNameKeyGenEx

        /// <summary>
        /// Generates a new public/private key pair with the specified key size, for strong name use.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The requested key container name. wszKeyContainer must either be a non-empty string or null to generate a temporary name.</param>
        /// <param name="dwFlags">[in] A value that specifies whether to leave the key registered. The following values are supported:</param>
        /// <param name="dwKeySize">[in] The requested size of the key, in bits.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The .NET Framework versions 1.0 and 1.1 require a dwKeySize of 1024 bits to sign an assembly with a strong name;
        /// version 2.0 adds supports for 2048-bit keys. After the key is retrieved, you should call the <see cref="StrongNameFreeBuffer"/>
        /// method to release the allocated memory.
        /// </remarks>
        public StrongNameKeyGenExResult StrongNameKeyGenEx(string pwzKeyContainer, int dwFlags, int dwKeySize)
        {
            HRESULT hr;
            StrongNameKeyGenExResult result;

            if ((hr = TryStrongNameKeyGenEx(pwzKeyContainer, dwFlags, dwKeySize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Generates a new public/private key pair with the specified key size, for strong name use.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The requested key container name. wszKeyContainer must either be a non-empty string or null to generate a temporary name.</param>
        /// <param name="dwFlags">[in] A value that specifies whether to leave the key registered. The following values are supported:</param>
        /// <param name="dwKeySize">[in] The requested size of the key, in bits.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// The .NET Framework versions 1.0 and 1.1 require a dwKeySize of 1024 bits to sign an assembly with a strong name;
        /// version 2.0 adds supports for 2048-bit keys. After the key is retrieved, you should call the <see cref="StrongNameFreeBuffer"/>
        /// method to release the allocated memory.
        /// </remarks>
        public HRESULT TryStrongNameKeyGenEx(string pwzKeyContainer, int dwFlags, int dwKeySize, out StrongNameKeyGenExResult result)
        {
            /*HRESULT StrongNameKeyGenEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] int dwFlags,
            [In] int dwKeySize,
            [Out] IntPtr ppbKeyBlob,
            out int pcbKeyBlob);*/
            IntPtr ppbKeyBlob = default(IntPtr);
            int pcbKeyBlob;
            HRESULT hr = Raw.StrongNameKeyGenEx(pwzKeyContainer, dwFlags, dwKeySize, ppbKeyBlob, out pcbKeyBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameKeyGenExResult(ppbKeyBlob, pcbKeyBlob);
            else
                result = default(StrongNameKeyGenExResult);

            return hr;
        }

        #endregion
        #region StrongNameKeyInstall

        /// <summary>
        /// Imports a public/private key pair into a container.
        /// </summary>
        /// <param name="pwzKeyContainer">[in] The name of the key container. wszKeyContainer must be a non-empty string.</param>
        /// <param name="pbKeyBlob">[in] The binary key pair.</param>
        /// <param name="cbKeyBlob">[in] The size, in bytes, of pbKeyBlob.</param>
        /// <remarks>
        /// Use the <see cref="StrongNameKeyDelete"/> method to delete the key container.
        /// </remarks>
        public void StrongNameKeyInstall(string pwzKeyContainer, IntPtr pbKeyBlob, int cbKeyBlob)
        {
            HRESULT hr;

            if ((hr = TryStrongNameKeyInstall(pwzKeyContainer, pbKeyBlob, cbKeyBlob)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

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
        public HRESULT TryStrongNameKeyInstall(string pwzKeyContainer, IntPtr pbKeyBlob, int cbKeyBlob)
        {
            /*HRESULT StrongNameKeyInstall([MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] IntPtr pbKeyBlob, [In] int cbKeyBlob);*/
            return Raw.StrongNameKeyInstall(pwzKeyContainer, pbKeyBlob, cbKeyBlob);
        }

        #endregion
        #region StrongNameSignatureGeneration

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
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Specify null for wszFilePath to calculate the size of the signature without creating the signature. The signature
        /// can be stored either directly in the file, or returned to the caller.
        /// </remarks>
        public StrongNameSignatureGenerationResult StrongNameSignatureGeneration(string pwzFilePath, string pwzKeyContainer, IntPtr pbKeyBlob, int cbKeyBlob)
        {
            HRESULT hr;
            StrongNameSignatureGenerationResult result;

            if ((hr = TryStrongNameSignatureGeneration(pwzFilePath, pwzKeyContainer, pbKeyBlob, cbKeyBlob, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// Specify null for wszFilePath to calculate the size of the signature without creating the signature. The signature
        /// can be stored either directly in the file, or returned to the caller.
        /// </remarks>
        public HRESULT TryStrongNameSignatureGeneration(string pwzFilePath, string pwzKeyContainer, IntPtr pbKeyBlob, int cbKeyBlob, out StrongNameSignatureGenerationResult result)
        {
            /*HRESULT StrongNameSignatureGeneration(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] IntPtr pbKeyBlob,
            [In] int cbKeyBlob,
            [Out] IntPtr ppbSignatureBlob,
            out int pcbSignatureBlob);*/
            IntPtr ppbSignatureBlob = default(IntPtr);
            int pcbSignatureBlob;
            HRESULT hr = Raw.StrongNameSignatureGeneration(pwzFilePath, pwzKeyContainer, pbKeyBlob, cbKeyBlob, ppbSignatureBlob, out pcbSignatureBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameSignatureGenerationResult(ppbSignatureBlob, pcbSignatureBlob);
            else
                result = default(StrongNameSignatureGenerationResult);

            return hr;
        }

        #endregion
        #region StrongNameSignatureGenerationEx

        /// <summary>
        /// Generates a strong name signature for the specified assembly, according to the specified flags.
        /// </summary>
        /// <param name="wszFilePath">[in] The path to the file that contains the manifest of the assembly for which the strong name signature will be generated.</param>
        /// <param name="wszKeyContainer">[in] The name of the key container that contains the public/private key pair. If pbKeyBlob is null, wszKeyContainer must specify a valid container within the cryptographic service provider (CSP).<para/>
        /// In this case, the key pair stored in the container is used to sign the file. If pbKeyBlob is not null, the key pair is assumed to be contained in the key binary large object (BLOB).</param>
        /// <param name="pbKeyBlob">[in] A pointer to the public/private key pair. This pair is in the format created by the Win32 CryptExportKey function.<para/>
        /// If pbKeyBlob is null, the key container specified by wszKeyContainer is assumed to contain the key pair.</param>
        /// <param name="cbKeyBlob">[in] The size, in bytes, of pbKeyBlob.</param>
        /// <param name="dwFlags">[in] One or more of the following values:</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Specify null for wszFilePath to calculate the size of the signature without creating the signature. The signature
        /// can be either stored directly in the file, or returned to the caller. If SN_SIGN_ALL_FILES is specified but a public
        /// key is not included (both pbKeyBlob and wszFilePath are null), hashes for linked modules are recomputed, but the
        /// assembly is not re-signed. If SN_TEST_SIGN is specified, the common language runtime header is not modified to
        /// indicate that the assembly is signed with a strong name.
        /// </remarks>
        public StrongNameSignatureGenerationExResult StrongNameSignatureGenerationEx(string wszFilePath, string wszKeyContainer, IntPtr pbKeyBlob, int cbKeyBlob, int dwFlags)
        {
            HRESULT hr;
            StrongNameSignatureGenerationExResult result;

            if ((hr = TryStrongNameSignatureGenerationEx(wszFilePath, wszKeyContainer, pbKeyBlob, cbKeyBlob, dwFlags, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Generates a strong name signature for the specified assembly, according to the specified flags.
        /// </summary>
        /// <param name="wszFilePath">[in] The path to the file that contains the manifest of the assembly for which the strong name signature will be generated.</param>
        /// <param name="wszKeyContainer">[in] The name of the key container that contains the public/private key pair. If pbKeyBlob is null, wszKeyContainer must specify a valid container within the cryptographic service provider (CSP).<para/>
        /// In this case, the key pair stored in the container is used to sign the file. If pbKeyBlob is not null, the key pair is assumed to be contained in the key binary large object (BLOB).</param>
        /// <param name="pbKeyBlob">[in] A pointer to the public/private key pair. This pair is in the format created by the Win32 CryptExportKey function.<para/>
        /// If pbKeyBlob is null, the key container specified by wszKeyContainer is assumed to contain the key pair.</param>
        /// <param name="cbKeyBlob">[in] The size, in bytes, of pbKeyBlob.</param>
        /// <param name="dwFlags">[in] One or more of the following values:</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// Specify null for wszFilePath to calculate the size of the signature without creating the signature. The signature
        /// can be either stored directly in the file, or returned to the caller. If SN_SIGN_ALL_FILES is specified but a public
        /// key is not included (both pbKeyBlob and wszFilePath are null), hashes for linked modules are recomputed, but the
        /// assembly is not re-signed. If SN_TEST_SIGN is specified, the common language runtime header is not modified to
        /// indicate that the assembly is signed with a strong name.
        /// </remarks>
        public HRESULT TryStrongNameSignatureGenerationEx(string wszFilePath, string wszKeyContainer, IntPtr pbKeyBlob, int cbKeyBlob, int dwFlags, out StrongNameSignatureGenerationExResult result)
        {
            /*HRESULT StrongNameSignatureGenerationEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszFilePath,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszKeyContainer,
            [In] IntPtr pbKeyBlob,
            [In] int cbKeyBlob,
            [Out] IntPtr ppbSignatureBlob,
            out int pcbSignatureBlob,
            [In] int dwFlags);*/
            IntPtr ppbSignatureBlob = default(IntPtr);
            int pcbSignatureBlob;
            HRESULT hr = Raw.StrongNameSignatureGenerationEx(wszFilePath, wszKeyContainer, pbKeyBlob, cbKeyBlob, ppbSignatureBlob, out pcbSignatureBlob, dwFlags);

            if (hr == HRESULT.S_OK)
                result = new StrongNameSignatureGenerationExResult(ppbSignatureBlob, pcbSignatureBlob);
            else
                result = default(StrongNameSignatureGenerationExResult);

            return hr;
        }

        #endregion
        #region StrongNameSignatureSize

        /// <summary>
        /// Returns the size of the strong name signature. This method is typically used by compilers to determine how much space to reserve in the file when creating a delay-signed assembly.
        /// </summary>
        /// <param name="pbPublicKeyBlob">[in] A structure of type <see cref="PublicKeyBlob"/> that contains the public portion of the key pair used to generate the strong name signature.</param>
        /// <param name="cbPublicKeyBlob">[in] The size, in bytes, of pbPublicKeyBlob.</param>
        /// <param name="pcbSize">[in] The number of bytes required to store the strong name signature.</param>
        public void StrongNameSignatureSize(IntPtr pbPublicKeyBlob, PublicKeyBlob cbPublicKeyBlob, int pcbSize)
        {
            HRESULT hr;

            if ((hr = TryStrongNameSignatureSize(pbPublicKeyBlob, cbPublicKeyBlob, pcbSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Returns the size of the strong name signature. This method is typically used by compilers to determine how much space to reserve in the file when creating a delay-signed assembly.
        /// </summary>
        /// <param name="pbPublicKeyBlob">[in] A structure of type <see cref="PublicKeyBlob"/> that contains the public portion of the key pair used to generate the strong name signature.</param>
        /// <param name="cbPublicKeyBlob">[in] The size, in bytes, of pbPublicKeyBlob.</param>
        /// <param name="pcbSize">[in] The number of bytes required to store the strong name signature.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        public HRESULT TryStrongNameSignatureSize(IntPtr pbPublicKeyBlob, PublicKeyBlob cbPublicKeyBlob, int pcbSize)
        {
            /*HRESULT StrongNameSignatureSize([In] IntPtr pbPublicKeyBlob, [In] PublicKeyBlob cbPublicKeyBlob, [In] ref int pcbSize);*/
            return Raw.StrongNameSignatureSize(pbPublicKeyBlob, cbPublicKeyBlob, ref pcbSize);
        }

        #endregion
        #region StrongNameSignatureVerification

        /// <summary>
        /// Gets a value that indicates whether the assembly manifest at the supplied path contains a strong name signature, which is verified according to the specified flags.
        /// </summary>
        /// <param name="wszFilePath">[in] The path to the portable executable (.dll or .exe) file for the assembly to verify.</param>
        /// <param name="dwInFlags">[in] Flags to modify the verification behavior. The following values are supported:</param>
        /// <returns>[out] Flags indicating whether the strong name signature was verified. The following value is supported:</returns>
        public int StrongNameSignatureVerification(string wszFilePath, int dwInFlags)
        {
            HRESULT hr;
            int pdwOutFlags;

            if ((hr = TryStrongNameSignatureVerification(wszFilePath, dwInFlags, out pdwOutFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pdwOutFlags;
        }

        /// <summary>
        /// Gets a value that indicates whether the assembly manifest at the supplied path contains a strong name signature, which is verified according to the specified flags.
        /// </summary>
        /// <param name="wszFilePath">[in] The path to the portable executable (.dll or .exe) file for the assembly to verify.</param>
        /// <param name="dwInFlags">[in] Flags to modify the verification behavior. The following values are supported:</param>
        /// <param name="pdwOutFlags">[out] Flags indicating whether the strong name signature was verified. The following value is supported:</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        public HRESULT TryStrongNameSignatureVerification(string wszFilePath, int dwInFlags, out int pdwOutFlags)
        {
            /*HRESULT StrongNameSignatureVerification(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszFilePath,
            [In] int dwInFlags,
            [Out] out int pdwOutFlags);*/
            return Raw.StrongNameSignatureVerification(wszFilePath, dwInFlags, out pdwOutFlags);
        }

        #endregion
        #region StrongNameSignatureVerificationEx

        /// <summary>
        /// Gets a value that indicates whether the assembly manifest at the supplied path contains a strong name signature.
        /// </summary>
        /// <param name="wszFilePath">[in] The path to the portable executable (.exe or .dll) file for the assembly to be verified.</param>
        /// <param name="fForceVerification">[in] true to perform verification, even if it is necessary to override registry settings; otherwise, false.</param>
        /// <returns>[out] true if the strong name signature was verified; otherwise, false. pfWasVerified is also set to false if the verification was successful due to registry settings.</returns>
        /// <remarks>
        /// The <see cref="StrongNameSignatureVerificationEx"/> method provides a capability similar to the <see cref="StrongNameSignatureVerification"/>
        /// method. However, the second input parameter and the output parameter for <see cref="StrongNameSignatureVerificationEx"/>
        /// are of type BOOLEAN instead of DWORD.
        /// </remarks>
        public int StrongNameSignatureVerificationEx(string wszFilePath, int fForceVerification)
        {
            HRESULT hr;
            int pfWasVerified = default(int);

            if ((hr = TryStrongNameSignatureVerificationEx(wszFilePath, fForceVerification, ref pfWasVerified)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pfWasVerified;
        }

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
        public HRESULT TryStrongNameSignatureVerificationEx(string wszFilePath, int fForceVerification, ref int pfWasVerified)
        {
            /*HRESULT StrongNameSignatureVerificationEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszFilePath,
            [In] int fForceVerification,
            [Out] int pfWasVerified);*/
            return Raw.StrongNameSignatureVerificationEx(wszFilePath, fForceVerification, pfWasVerified);
        }

        #endregion
        #region StrongNameSignatureVerificationFromImage

        /// <summary>
        /// Verifies that an assembly that has already been mapped to memory is valid for the associated public key.
        /// </summary>
        /// <param name="pbBase">[in] The relative virtual address of the mapped assembly manifest.</param>
        /// <param name="dwLength">[in] The size, in bytes, of the mapped image.</param>
        /// <param name="dwInFlags">[in] Flags that influence verification behavior. The following values are supported:</param>
        /// <returns>[out] A flag for additional output information. The following value is supported:</returns>
        public int StrongNameSignatureVerificationFromImage(IntPtr pbBase, int dwLength, int dwInFlags)
        {
            HRESULT hr;
            int pdwOutFlags;

            if ((hr = TryStrongNameSignatureVerificationFromImage(pbBase, dwLength, dwInFlags, out pdwOutFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pdwOutFlags;
        }

        /// <summary>
        /// Verifies that an assembly that has already been mapped to memory is valid for the associated public key.
        /// </summary>
        /// <param name="pbBase">[in] The relative virtual address of the mapped assembly manifest.</param>
        /// <param name="dwLength">[in] The size, in bytes, of the mapped image.</param>
        /// <param name="dwInFlags">[in] Flags that influence verification behavior. The following values are supported:</param>
        /// <param name="pdwOutFlags">[out] A flag for additional output information. The following value is supported:</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        public HRESULT TryStrongNameSignatureVerificationFromImage(IntPtr pbBase, int dwLength, int dwInFlags, out int pdwOutFlags)
        {
            /*HRESULT StrongNameSignatureVerificationFromImage(
            [In] IntPtr pbBase,
            [In] int dwLength,
            [In] int dwInFlags,
            [Out] out int pdwOutFlags);*/
            return Raw.StrongNameSignatureVerificationFromImage(pbBase, dwLength, dwInFlags, out pdwOutFlags);
        }

        #endregion
        #region StrongNameTokenFromAssembly

        /// <summary>
        /// Creates a strong name token from the specified assembly file.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the portable executable (PE) file for the assembly.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// A strong name token is the shortened form of a public key. The token is a 64-bit hash that is created from the
        /// public key used to sign the assembly. The token is a part of the strong name for the assembly, and can be read
        /// from the assembly metadata. After the token is created, you should call the <see cref="StrongNameFreeBuffer"/>
        /// method to release the allocated memory.
        /// </remarks>
        public StrongNameTokenFromAssemblyResult StrongNameTokenFromAssembly(string pwzFilePath)
        {
            HRESULT hr;
            StrongNameTokenFromAssemblyResult result;

            if ((hr = TryStrongNameTokenFromAssembly(pwzFilePath, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Creates a strong name token from the specified assembly file.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the portable executable (PE) file for the assembly.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// A strong name token is the shortened form of a public key. The token is a 64-bit hash that is created from the
        /// public key used to sign the assembly. The token is a part of the strong name for the assembly, and can be read
        /// from the assembly metadata. After the token is created, you should call the <see cref="StrongNameFreeBuffer"/>
        /// method to release the allocated memory.
        /// </remarks>
        public HRESULT TryStrongNameTokenFromAssembly(string pwzFilePath, out StrongNameTokenFromAssemblyResult result)
        {
            /*HRESULT StrongNameTokenFromAssembly(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [Out] IntPtr ppbStrongNameToken,
            out int pcbStrongNameToken);*/
            IntPtr ppbStrongNameToken = default(IntPtr);
            int pcbStrongNameToken;
            HRESULT hr = Raw.StrongNameTokenFromAssembly(pwzFilePath, ppbStrongNameToken, out pcbStrongNameToken);

            if (hr == HRESULT.S_OK)
                result = new StrongNameTokenFromAssemblyResult(ppbStrongNameToken, pcbStrongNameToken);
            else
                result = default(StrongNameTokenFromAssemblyResult);

            return hr;
        }

        #endregion
        #region StrongNameTokenFromAssemblyEx

        /// <summary>
        /// Creates a strong name token from the specified assembly file, and returns the public key that the token represents.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the portable executable (PE) file for the assembly.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// A strong name token is the shortened form of a public key. The token is a 64-bit hash that is created from the
        /// public key used to sign the assembly. The token is a part of the strong name for the assembly, and can be read
        /// from the assembly metadata. After the key is retrieved and the token is created, you should call the <see cref="StrongNameFreeBuffer"/>
        /// method to release the allocated memory.
        /// </remarks>
        public StrongNameTokenFromAssemblyExResult StrongNameTokenFromAssemblyEx(string pwzFilePath)
        {
            HRESULT hr;
            StrongNameTokenFromAssemblyExResult result;

            if ((hr = TryStrongNameTokenFromAssemblyEx(pwzFilePath, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Creates a strong name token from the specified assembly file, and returns the public key that the token represents.
        /// </summary>
        /// <param name="pwzFilePath">[in] The path to the portable executable (PE) file for the assembly.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// A strong name token is the shortened form of a public key. The token is a 64-bit hash that is created from the
        /// public key used to sign the assembly. The token is a part of the strong name for the assembly, and can be read
        /// from the assembly metadata. After the key is retrieved and the token is created, you should call the <see cref="StrongNameFreeBuffer"/>
        /// method to release the allocated memory.
        /// </remarks>
        public HRESULT TryStrongNameTokenFromAssemblyEx(string pwzFilePath, out StrongNameTokenFromAssemblyExResult result)
        {
            /*HRESULT StrongNameTokenFromAssemblyEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [Out] IntPtr ppbStrongNameToken,
            out int pcbStrongNameToken,
            [Out] IntPtr ppbPublicKeyBlob,
            out int pcbPublicKeyBlob);*/
            IntPtr ppbStrongNameToken = default(IntPtr);
            int pcbStrongNameToken;
            IntPtr ppbPublicKeyBlob = default(IntPtr);
            int pcbPublicKeyBlob;
            HRESULT hr = Raw.StrongNameTokenFromAssemblyEx(pwzFilePath, ppbStrongNameToken, out pcbStrongNameToken, ppbPublicKeyBlob, out pcbPublicKeyBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameTokenFromAssemblyExResult(ppbStrongNameToken, pcbStrongNameToken, ppbPublicKeyBlob, pcbPublicKeyBlob);
            else
                result = default(StrongNameTokenFromAssemblyExResult);

            return hr;
        }

        #endregion
        #region StrongNameTokenFromPublicKey

        /// <summary>
        /// Gets a token that represents a public key. A strong name token is the shortened form of a public key.
        /// </summary>
        /// <param name="pbPublicKeyBlob">[in] A structure of type <see cref="PublicKeyBlob"/> that contains the public portion of the key pair used to generate the strong name signature.</param>
        /// <param name="cbPublicKeyBlob">[in] The size, in bytes, of pbPublicKeyBlob.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// A strong name token is the shortened form of a public key that is used to save space when storing key information
        /// in metadata. Specifically, strong name tokens are used in assembly references to refer to the dependent assembly.
        /// </remarks>
        public StrongNameTokenFromPublicKeyResult StrongNameTokenFromPublicKey(IntPtr pbPublicKeyBlob, PublicKeyBlob cbPublicKeyBlob)
        {
            HRESULT hr;
            StrongNameTokenFromPublicKeyResult result;

            if ((hr = TryStrongNameTokenFromPublicKey(pbPublicKeyBlob, cbPublicKeyBlob, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets a token that represents a public key. A strong name token is the shortened form of a public key.
        /// </summary>
        /// <param name="pbPublicKeyBlob">[in] A structure of type <see cref="PublicKeyBlob"/> that contains the public portion of the key pair used to generate the strong name signature.</param>
        /// <param name="cbPublicKeyBlob">[in] The size, in bytes, of pbPublicKeyBlob.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method completed successfully; otherwise, an <see cref="HRESULT"/> value that indicates failure (see Common <see cref="HRESULT"/> Values for a list).</returns>
        /// <remarks>
        /// A strong name token is the shortened form of a public key that is used to save space when storing key information
        /// in metadata. Specifically, strong name tokens are used in assembly references to refer to the dependent assembly.
        /// </remarks>
        public HRESULT TryStrongNameTokenFromPublicKey(IntPtr pbPublicKeyBlob, PublicKeyBlob cbPublicKeyBlob, out StrongNameTokenFromPublicKeyResult result)
        {
            /*HRESULT StrongNameTokenFromPublicKey(
            [In] IntPtr pbPublicKeyBlob,
            [In] PublicKeyBlob cbPublicKeyBlob,
            [Out] IntPtr ppbStrongNameToken,
            out int pcbStrongNameToken);*/
            IntPtr ppbStrongNameToken = default(IntPtr);
            int pcbStrongNameToken;
            HRESULT hr = Raw.StrongNameTokenFromPublicKey(pbPublicKeyBlob, cbPublicKeyBlob, ppbStrongNameToken, out pcbStrongNameToken);

            if (hr == HRESULT.S_OK)
                result = new StrongNameTokenFromPublicKeyResult(ppbStrongNameToken, pcbStrongNameToken);
            else
                result = default(StrongNameTokenFromPublicKeyResult);

            return hr;
        }

        #endregion
        #endregion
    }
}