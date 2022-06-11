using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRStrongName : ComObject<ICLRStrongName>
    {
        public CLRStrongName(ICLRStrongName raw) : base(raw)
        {
        }

        #region ICLRStrongName
        #region GetHashFromAssemblyFile

        public GetHashFromAssemblyFileResult GetHashFromAssemblyFile(string pszFilePath, uint cchHash)
        {
            HRESULT hr;
            GetHashFromAssemblyFileResult result;

            if ((hr = TryGetHashFromAssemblyFile(pszFilePath, cchHash, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetHashFromAssemblyFile(string pszFilePath, uint cchHash, out GetHashFromAssemblyFileResult result)
        {
            /*HRESULT GetHashFromAssemblyFile(
            [MarshalAs(UnmanagedType.LPStr), In] string pszFilePath,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);*/
            uint piHashAlg = default(uint);
            byte pbHash;
            uint pchHash;
            HRESULT hr = Raw.GetHashFromAssemblyFile(pszFilePath, ref piHashAlg, out pbHash, cchHash, out pchHash);

            if (hr == HRESULT.S_OK)
                result = new GetHashFromAssemblyFileResult(piHashAlg, pbHash, pchHash);
            else
                result = default(GetHashFromAssemblyFileResult);

            return hr;
        }

        #endregion
        #region GetHashFromAssemblyFileW

        public GetHashFromAssemblyFileWResult GetHashFromAssemblyFileW(string pwzFilePath, uint cchHash)
        {
            HRESULT hr;
            GetHashFromAssemblyFileWResult result;

            if ((hr = TryGetHashFromAssemblyFileW(pwzFilePath, cchHash, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetHashFromAssemblyFileW(string pwzFilePath, uint cchHash, out GetHashFromAssemblyFileWResult result)
        {
            /*HRESULT GetHashFromAssemblyFileW(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);*/
            uint piHashAlg = default(uint);
            byte pbHash;
            uint pchHash;
            HRESULT hr = Raw.GetHashFromAssemblyFileW(pwzFilePath, ref piHashAlg, out pbHash, cchHash, out pchHash);

            if (hr == HRESULT.S_OK)
                result = new GetHashFromAssemblyFileWResult(piHashAlg, pbHash, pchHash);
            else
                result = default(GetHashFromAssemblyFileWResult);

            return hr;
        }

        #endregion
        #region GetHashFromBlob

        public GetHashFromBlobResult GetHashFromBlob(IntPtr pbBlob, uint cchBlob, uint cchHash)
        {
            HRESULT hr;
            GetHashFromBlobResult result;

            if ((hr = TryGetHashFromBlob(pbBlob, cchBlob, cchHash, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetHashFromBlob(IntPtr pbBlob, uint cchBlob, uint cchHash, out GetHashFromBlobResult result)
        {
            /*HRESULT GetHashFromBlob(
            [In] IntPtr pbBlob,
            [In] uint cchBlob,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);*/
            uint piHashAlg = default(uint);
            byte pbHash;
            uint pchHash;
            HRESULT hr = Raw.GetHashFromBlob(pbBlob, cchBlob, ref piHashAlg, out pbHash, cchHash, out pchHash);

            if (hr == HRESULT.S_OK)
                result = new GetHashFromBlobResult(piHashAlg, pbHash, pchHash);
            else
                result = default(GetHashFromBlobResult);

            return hr;
        }

        #endregion
        #region GetHashFromFile

        public GetHashFromFileResult GetHashFromFile(string pszFilePath, uint cchHash)
        {
            HRESULT hr;
            GetHashFromFileResult result;

            if ((hr = TryGetHashFromFile(pszFilePath, cchHash, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetHashFromFile(string pszFilePath, uint cchHash, out GetHashFromFileResult result)
        {
            /*HRESULT GetHashFromFile(
            [MarshalAs(UnmanagedType.LPStr), In] string pszFilePath,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);*/
            uint piHashAlg = default(uint);
            byte pbHash;
            uint pchHash;
            HRESULT hr = Raw.GetHashFromFile(pszFilePath, ref piHashAlg, out pbHash, cchHash, out pchHash);

            if (hr == HRESULT.S_OK)
                result = new GetHashFromFileResult(piHashAlg, pbHash, pchHash);
            else
                result = default(GetHashFromFileResult);

            return hr;
        }

        #endregion
        #region GetHashFromFileW

        public GetHashFromFileWResult GetHashFromFileW(string pwzFilePath, uint cchHash)
        {
            HRESULT hr;
            GetHashFromFileWResult result;

            if ((hr = TryGetHashFromFileW(pwzFilePath, cchHash, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetHashFromFileW(string pwzFilePath, uint cchHash, out GetHashFromFileWResult result)
        {
            /*HRESULT GetHashFromFileW(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);*/
            uint piHashAlg = default(uint);
            byte pbHash;
            uint pchHash;
            HRESULT hr = Raw.GetHashFromFileW(pwzFilePath, ref piHashAlg, out pbHash, cchHash, out pchHash);

            if (hr == HRESULT.S_OK)
                result = new GetHashFromFileWResult(piHashAlg, pbHash, pchHash);
            else
                result = default(GetHashFromFileWResult);

            return hr;
        }

        #endregion
        #region GetHashFromHandle

        public GetHashFromHandleResult GetHashFromHandle(IntPtr hFile, uint cchHash)
        {
            HRESULT hr;
            GetHashFromHandleResult result;

            if ((hr = TryGetHashFromHandle(hFile, cchHash, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetHashFromHandle(IntPtr hFile, uint cchHash, out GetHashFromHandleResult result)
        {
            /*HRESULT GetHashFromHandle(
            [In] IntPtr hFile,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);*/
            uint piHashAlg = default(uint);
            byte pbHash;
            uint pchHash;
            HRESULT hr = Raw.GetHashFromHandle(hFile, ref piHashAlg, out pbHash, cchHash, out pchHash);

            if (hr == HRESULT.S_OK)
                result = new GetHashFromHandleResult(piHashAlg, pbHash, pchHash);
            else
                result = default(GetHashFromHandleResult);

            return hr;
        }

        #endregion
        #region StrongNameCompareAssemblies

        public uint StrongNameCompareAssemblies(string wszAssembly1, string wszAssembly2)
        {
            HRESULT hr;
            uint pdwResult;

            if ((hr = TryStrongNameCompareAssemblies(wszAssembly1, wszAssembly2, out pdwResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pdwResult;
        }

        public HRESULT TryStrongNameCompareAssemblies(string wszAssembly1, string wszAssembly2, out uint pdwResult)
        {
            /*HRESULT StrongNameCompareAssemblies(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszAssembly1,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszAssembly2,
            [Out] out uint pdwResult);*/
            return Raw.StrongNameCompareAssemblies(wszAssembly1, wszAssembly2, out pdwResult);
        }

        #endregion
        #region StrongNameFreeBuffer

        public void StrongNameFreeBuffer(IntPtr pbMemory)
        {
            HRESULT hr;

            if ((hr = TryStrongNameFreeBuffer(pbMemory)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStrongNameFreeBuffer(IntPtr pbMemory)
        {
            /*HRESULT StrongNameFreeBuffer([In] IntPtr pbMemory);*/
            return Raw.StrongNameFreeBuffer(pbMemory);
        }

        #endregion
        #region StrongNameGetBlob

        public StrongNameGetBlobResult StrongNameGetBlob(string pwzFilePath)
        {
            HRESULT hr;
            StrongNameGetBlobResult result;

            if ((hr = TryStrongNameGetBlob(pwzFilePath, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryStrongNameGetBlob(string pwzFilePath, out StrongNameGetBlobResult result)
        {
            /*HRESULT StrongNameGetBlob([MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath, [In] [Out] IntPtr pbBlob,
            [In] [Out] ref uint pcbBlob);*/
            IntPtr pbBlob = default(IntPtr);
            uint pcbBlob = default(uint);
            HRESULT hr = Raw.StrongNameGetBlob(pwzFilePath, pbBlob, ref pcbBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameGetBlobResult(pbBlob, pcbBlob);
            else
                result = default(StrongNameGetBlobResult);

            return hr;
        }

        #endregion
        #region StrongNameGetBlobFromImage

        public StrongNameGetBlobFromImageResult StrongNameGetBlobFromImage(IntPtr pbBase, uint dwLength)
        {
            HRESULT hr;
            StrongNameGetBlobFromImageResult result;

            if ((hr = TryStrongNameGetBlobFromImage(pbBase, dwLength, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryStrongNameGetBlobFromImage(IntPtr pbBase, uint dwLength, out StrongNameGetBlobFromImageResult result)
        {
            /*HRESULT StrongNameGetBlobFromImage(
            [In] IntPtr pbBase,
            [In] uint dwLength,
            out byte pbBlob,
            [In] [Out] ref uint pcbBlob);*/
            byte pbBlob;
            uint pcbBlob = default(uint);
            HRESULT hr = Raw.StrongNameGetBlobFromImage(pbBase, dwLength, out pbBlob, ref pcbBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameGetBlobFromImageResult(pbBlob, pcbBlob);
            else
                result = default(StrongNameGetBlobFromImageResult);

            return hr;
        }

        #endregion
        #region StrongNameGetPublicKey

        public StrongNameGetPublicKeyResult StrongNameGetPublicKey(string pwzKeyContainer, IntPtr pbKeyBlob, uint cbKeyBlob)
        {
            HRESULT hr;
            StrongNameGetPublicKeyResult result;

            if ((hr = TryStrongNameGetPublicKey(pwzKeyContainer, pbKeyBlob, cbKeyBlob, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryStrongNameGetPublicKey(string pwzKeyContainer, IntPtr pbKeyBlob, uint cbKeyBlob, out StrongNameGetPublicKeyResult result)
        {
            /*HRESULT StrongNameGetPublicKey(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] IntPtr pbKeyBlob,
            [In] uint cbKeyBlob,
            [Out] IntPtr ppbPublicKeyBlob,
            out uint pcbPublicKeyBlob);*/
            IntPtr ppbPublicKeyBlob = default(IntPtr);
            uint pcbPublicKeyBlob;
            HRESULT hr = Raw.StrongNameGetPublicKey(pwzKeyContainer, pbKeyBlob, cbKeyBlob, ppbPublicKeyBlob, out pcbPublicKeyBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameGetPublicKeyResult(ppbPublicKeyBlob, pcbPublicKeyBlob);
            else
                result = default(StrongNameGetPublicKeyResult);

            return hr;
        }

        #endregion
        #region StrongNameHashSize

        public uint StrongNameHashSize(uint ulHashAlg)
        {
            HRESULT hr;
            uint pcbSize;

            if ((hr = TryStrongNameHashSize(ulHashAlg, out pcbSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pcbSize;
        }

        public HRESULT TryStrongNameHashSize(uint ulHashAlg, out uint pcbSize)
        {
            /*HRESULT StrongNameHashSize([In] uint ulHashAlg, [Out] out uint pcbSize);*/
            return Raw.StrongNameHashSize(ulHashAlg, out pcbSize);
        }

        #endregion
        #region StrongNameKeyDelete

        public void StrongNameKeyDelete(string pwzKeyContainer)
        {
            HRESULT hr;

            if ((hr = TryStrongNameKeyDelete(pwzKeyContainer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStrongNameKeyDelete(string pwzKeyContainer)
        {
            /*HRESULT StrongNameKeyDelete([MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer);*/
            return Raw.StrongNameKeyDelete(pwzKeyContainer);
        }

        #endregion
        #region StrongNameKeyGen

        public StrongNameKeyGenResult StrongNameKeyGen(string pwzKeyContainer, uint dwFlags)
        {
            HRESULT hr;
            StrongNameKeyGenResult result;

            if ((hr = TryStrongNameKeyGen(pwzKeyContainer, dwFlags, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryStrongNameKeyGen(string pwzKeyContainer, uint dwFlags, out StrongNameKeyGenResult result)
        {
            /*HRESULT StrongNameKeyGen(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] uint dwFlags,
            [Out] IntPtr ppbKeyBlob,
            out uint pcbKeyBlob);*/
            IntPtr ppbKeyBlob = default(IntPtr);
            uint pcbKeyBlob;
            HRESULT hr = Raw.StrongNameKeyGen(pwzKeyContainer, dwFlags, ppbKeyBlob, out pcbKeyBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameKeyGenResult(ppbKeyBlob, pcbKeyBlob);
            else
                result = default(StrongNameKeyGenResult);

            return hr;
        }

        #endregion
        #region StrongNameKeyGenEx

        public StrongNameKeyGenExResult StrongNameKeyGenEx(string pwzKeyContainer, uint dwFlags, uint dwKeySize)
        {
            HRESULT hr;
            StrongNameKeyGenExResult result;

            if ((hr = TryStrongNameKeyGenEx(pwzKeyContainer, dwFlags, dwKeySize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryStrongNameKeyGenEx(string pwzKeyContainer, uint dwFlags, uint dwKeySize, out StrongNameKeyGenExResult result)
        {
            /*HRESULT StrongNameKeyGenEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] uint dwFlags,
            [In] uint dwKeySize,
            [Out] IntPtr ppbKeyBlob,
            out uint pcbKeyBlob);*/
            IntPtr ppbKeyBlob = default(IntPtr);
            uint pcbKeyBlob;
            HRESULT hr = Raw.StrongNameKeyGenEx(pwzKeyContainer, dwFlags, dwKeySize, ppbKeyBlob, out pcbKeyBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameKeyGenExResult(ppbKeyBlob, pcbKeyBlob);
            else
                result = default(StrongNameKeyGenExResult);

            return hr;
        }

        #endregion
        #region StrongNameKeyInstall

        public void StrongNameKeyInstall(string pwzKeyContainer, IntPtr pbKeyBlob, uint cbKeyBlob)
        {
            HRESULT hr;

            if ((hr = TryStrongNameKeyInstall(pwzKeyContainer, pbKeyBlob, cbKeyBlob)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStrongNameKeyInstall(string pwzKeyContainer, IntPtr pbKeyBlob, uint cbKeyBlob)
        {
            /*HRESULT StrongNameKeyInstall([MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] IntPtr pbKeyBlob, [In] uint cbKeyBlob);*/
            return Raw.StrongNameKeyInstall(pwzKeyContainer, pbKeyBlob, cbKeyBlob);
        }

        #endregion
        #region StrongNameSignatureGeneration

        public StrongNameSignatureGenerationResult StrongNameSignatureGeneration(string pwzFilePath, string pwzKeyContainer, IntPtr pbKeyBlob, uint cbKeyBlob)
        {
            HRESULT hr;
            StrongNameSignatureGenerationResult result;

            if ((hr = TryStrongNameSignatureGeneration(pwzFilePath, pwzKeyContainer, pbKeyBlob, cbKeyBlob, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryStrongNameSignatureGeneration(string pwzFilePath, string pwzKeyContainer, IntPtr pbKeyBlob, uint cbKeyBlob, out StrongNameSignatureGenerationResult result)
        {
            /*HRESULT StrongNameSignatureGeneration(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] IntPtr pbKeyBlob,
            [In] uint cbKeyBlob,
            [Out] IntPtr ppbSignatureBlob,
            out uint pcbSignatureBlob);*/
            IntPtr ppbSignatureBlob = default(IntPtr);
            uint pcbSignatureBlob;
            HRESULT hr = Raw.StrongNameSignatureGeneration(pwzFilePath, pwzKeyContainer, pbKeyBlob, cbKeyBlob, ppbSignatureBlob, out pcbSignatureBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameSignatureGenerationResult(ppbSignatureBlob, pcbSignatureBlob);
            else
                result = default(StrongNameSignatureGenerationResult);

            return hr;
        }

        #endregion
        #region StrongNameSignatureGenerationEx

        public StrongNameSignatureGenerationExResult StrongNameSignatureGenerationEx(string wszFilePath, string wszKeyContainer, IntPtr pbKeyBlob, uint cbKeyBlob, uint dwFlags)
        {
            HRESULT hr;
            StrongNameSignatureGenerationExResult result;

            if ((hr = TryStrongNameSignatureGenerationEx(wszFilePath, wszKeyContainer, pbKeyBlob, cbKeyBlob, dwFlags, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryStrongNameSignatureGenerationEx(string wszFilePath, string wszKeyContainer, IntPtr pbKeyBlob, uint cbKeyBlob, uint dwFlags, out StrongNameSignatureGenerationExResult result)
        {
            /*HRESULT StrongNameSignatureGenerationEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszFilePath,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszKeyContainer,
            [In] IntPtr pbKeyBlob,
            [In] uint cbKeyBlob,
            [Out] IntPtr ppbSignatureBlob,
            out uint pcbSignatureBlob,
            [In] uint dwFlags);*/
            IntPtr ppbSignatureBlob = default(IntPtr);
            uint pcbSignatureBlob;
            HRESULT hr = Raw.StrongNameSignatureGenerationEx(wszFilePath, wszKeyContainer, pbKeyBlob, cbKeyBlob, ppbSignatureBlob, out pcbSignatureBlob, dwFlags);

            if (hr == HRESULT.S_OK)
                result = new StrongNameSignatureGenerationExResult(ppbSignatureBlob, pcbSignatureBlob);
            else
                result = default(StrongNameSignatureGenerationExResult);

            return hr;
        }

        #endregion
        #region StrongNameSignatureSize

        public void StrongNameSignatureSize(IntPtr pbPublicKeyBlob, PublicKeyBlob cbPublicKeyBlob, uint pcbSize)
        {
            HRESULT hr;

            if ((hr = TryStrongNameSignatureSize(pbPublicKeyBlob, cbPublicKeyBlob, pcbSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStrongNameSignatureSize(IntPtr pbPublicKeyBlob, PublicKeyBlob cbPublicKeyBlob, uint pcbSize)
        {
            /*HRESULT StrongNameSignatureSize([In] IntPtr pbPublicKeyBlob, [In] PublicKeyBlob cbPublicKeyBlob, [In] ref uint pcbSize);*/
            return Raw.StrongNameSignatureSize(pbPublicKeyBlob, cbPublicKeyBlob, ref pcbSize);
        }

        #endregion
        #region StrongNameSignatureVerification

        public uint StrongNameSignatureVerification(string wszFilePath, uint dwInFlags)
        {
            HRESULT hr;
            uint pdwOutFlags;

            if ((hr = TryStrongNameSignatureVerification(wszFilePath, dwInFlags, out pdwOutFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pdwOutFlags;
        }

        public HRESULT TryStrongNameSignatureVerification(string wszFilePath, uint dwInFlags, out uint pdwOutFlags)
        {
            /*HRESULT StrongNameSignatureVerification(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszFilePath,
            [In] uint dwInFlags,
            [Out] out uint pdwOutFlags);*/
            return Raw.StrongNameSignatureVerification(wszFilePath, dwInFlags, out pdwOutFlags);
        }

        #endregion
        #region StrongNameSignatureVerificationEx

        public int StrongNameSignatureVerificationEx(string wszFilePath, int fForceVerification)
        {
            HRESULT hr;
            int pfWasVerified = default(int);

            if ((hr = TryStrongNameSignatureVerificationEx(wszFilePath, fForceVerification, ref pfWasVerified)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pfWasVerified;
        }

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

        public uint StrongNameSignatureVerificationFromImage(IntPtr pbBase, uint dwLength, uint dwInFlags)
        {
            HRESULT hr;
            uint pdwOutFlags;

            if ((hr = TryStrongNameSignatureVerificationFromImage(pbBase, dwLength, dwInFlags, out pdwOutFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pdwOutFlags;
        }

        public HRESULT TryStrongNameSignatureVerificationFromImage(IntPtr pbBase, uint dwLength, uint dwInFlags, out uint pdwOutFlags)
        {
            /*HRESULT StrongNameSignatureVerificationFromImage(
            [In] IntPtr pbBase,
            [In] uint dwLength,
            [In] uint dwInFlags,
            [Out] out uint pdwOutFlags);*/
            return Raw.StrongNameSignatureVerificationFromImage(pbBase, dwLength, dwInFlags, out pdwOutFlags);
        }

        #endregion
        #region StrongNameTokenFromAssembly

        public StrongNameTokenFromAssemblyResult StrongNameTokenFromAssembly(string pwzFilePath)
        {
            HRESULT hr;
            StrongNameTokenFromAssemblyResult result;

            if ((hr = TryStrongNameTokenFromAssembly(pwzFilePath, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryStrongNameTokenFromAssembly(string pwzFilePath, out StrongNameTokenFromAssemblyResult result)
        {
            /*HRESULT StrongNameTokenFromAssembly(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [Out] IntPtr ppbStrongNameToken,
            out uint pcbStrongNameToken);*/
            IntPtr ppbStrongNameToken = default(IntPtr);
            uint pcbStrongNameToken;
            HRESULT hr = Raw.StrongNameTokenFromAssembly(pwzFilePath, ppbStrongNameToken, out pcbStrongNameToken);

            if (hr == HRESULT.S_OK)
                result = new StrongNameTokenFromAssemblyResult(ppbStrongNameToken, pcbStrongNameToken);
            else
                result = default(StrongNameTokenFromAssemblyResult);

            return hr;
        }

        #endregion
        #region StrongNameTokenFromAssemblyEx

        public StrongNameTokenFromAssemblyExResult StrongNameTokenFromAssemblyEx(string pwzFilePath)
        {
            HRESULT hr;
            StrongNameTokenFromAssemblyExResult result;

            if ((hr = TryStrongNameTokenFromAssemblyEx(pwzFilePath, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryStrongNameTokenFromAssemblyEx(string pwzFilePath, out StrongNameTokenFromAssemblyExResult result)
        {
            /*HRESULT StrongNameTokenFromAssemblyEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [Out] IntPtr ppbStrongNameToken,
            out uint pcbStrongNameToken,
            [Out] IntPtr ppbPublicKeyBlob,
            out uint pcbPublicKeyBlob);*/
            IntPtr ppbStrongNameToken = default(IntPtr);
            uint pcbStrongNameToken;
            IntPtr ppbPublicKeyBlob = default(IntPtr);
            uint pcbPublicKeyBlob;
            HRESULT hr = Raw.StrongNameTokenFromAssemblyEx(pwzFilePath, ppbStrongNameToken, out pcbStrongNameToken, ppbPublicKeyBlob, out pcbPublicKeyBlob);

            if (hr == HRESULT.S_OK)
                result = new StrongNameTokenFromAssemblyExResult(ppbStrongNameToken, pcbStrongNameToken, ppbPublicKeyBlob, pcbPublicKeyBlob);
            else
                result = default(StrongNameTokenFromAssemblyExResult);

            return hr;
        }

        #endregion
        #region StrongNameTokenFromPublicKey

        public StrongNameTokenFromPublicKeyResult StrongNameTokenFromPublicKey(IntPtr pbPublicKeyBlob, PublicKeyBlob cbPublicKeyBlob)
        {
            HRESULT hr;
            StrongNameTokenFromPublicKeyResult result;

            if ((hr = TryStrongNameTokenFromPublicKey(pbPublicKeyBlob, cbPublicKeyBlob, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryStrongNameTokenFromPublicKey(IntPtr pbPublicKeyBlob, PublicKeyBlob cbPublicKeyBlob, out StrongNameTokenFromPublicKeyResult result)
        {
            /*HRESULT StrongNameTokenFromPublicKey(
            [In] IntPtr pbPublicKeyBlob,
            [In] PublicKeyBlob cbPublicKeyBlob,
            [Out] IntPtr ppbStrongNameToken,
            out uint pcbStrongNameToken);*/
            IntPtr ppbStrongNameToken = default(IntPtr);
            uint pcbStrongNameToken;
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