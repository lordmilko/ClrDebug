using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides information about a merged assembly.
    /// </summary>
    public class CorDebugMergedAssemblyRecord : ComObject<ICorDebugMergedAssemblyRecord>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugMergedAssemblyRecord"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugMergedAssemblyRecord(ICorDebugMergedAssemblyRecord raw) : base(raw)
        {
        }

        #region ICorDebugMergedAssemblyRecord
        #region SimpleName

        /// <summary>
        /// Gets the simple name of the assembly.
        /// </summary>
        public string SimpleName
        {
            get
            {
                HRESULT hr;
                string szNameResult;

                if ((hr = TryGetSimpleName(out szNameResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return szNameResult;
            }
        }

        /// <summary>
        /// Gets the simple name of the assembly.
        /// </summary>
        /// <param name="szNameResult">A pointer to a character array.</param>
        /// <remarks>
        /// This method retrieves the simple name of an assembly (such as "System.Collections"), without a file extension,
        /// version, culture, or public key token. It corresponds to the <see cref="AssemblyName.Name"/> property in managed
        /// code.
        /// </remarks>
        public HRESULT TryGetSimpleName(out string szNameResult)
        {
            /*HRESULT GetSimpleName([In] int cchName, out int pcchName, [Out] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetSimpleName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(pcchName);
            hr = Raw.GetSimpleName(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region Version

        /// <summary>
        /// Gets the assembly's version information.
        /// </summary>
        public GetVersionResult Version
        {
            get
            {
                HRESULT hr;
                GetVersionResult result;

                if ((hr = TryGetVersion(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        /// <summary>
        /// Gets the assembly's version information.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// For information on assembly version numbers, see the <see cref="Version"/> class topic.
        /// </remarks>
        public HRESULT TryGetVersion(out GetVersionResult result)
        {
            /*HRESULT GetVersion(out ushort pMajor, out ushort pMinor, out ushort pBuild, out ushort pRevision);*/
            ushort pMajor;
            ushort pMinor;
            ushort pBuild;
            ushort pRevision;
            HRESULT hr = Raw.GetVersion(out pMajor, out pMinor, out pBuild, out pRevision);

            if (hr == HRESULT.S_OK)
                result = new GetVersionResult(pMajor, pMinor, pBuild, pRevision);
            else
                result = default(GetVersionResult);

            return hr;
        }

        #endregion
        #region Culture

        /// <summary>
        /// Gets the culture name string of the assembly.
        /// </summary>
        public string Culture
        {
            get
            {
                HRESULT hr;
                string szCultureResult;

                if ((hr = TryGetCulture(out szCultureResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return szCultureResult;
            }
        }

        /// <summary>
        /// Gets the culture name string of the assembly.
        /// </summary>
        /// <param name="szCultureResult">[out] A character array that contains the culture name.</param>
        /// <remarks>
        /// The culture name is a unique string that identifies a culture, such as "en-US" (for the English (United States)
        /// culture), or "neutral" (for a neutral culture).
        /// </remarks>
        public HRESULT TryGetCulture(out string szCultureResult)
        {
            /*HRESULT GetCulture([In] int cchCulture, out int pcchCulture, [Out] StringBuilder szCulture);*/
            int cchCulture = 0;
            int pcchCulture;
            StringBuilder szCulture = null;
            HRESULT hr = Raw.GetCulture(cchCulture, out pcchCulture, szCulture);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchCulture = pcchCulture;
            szCulture = new StringBuilder(pcchCulture);
            hr = Raw.GetCulture(cchCulture, out pcchCulture, szCulture);

            if (hr == HRESULT.S_OK)
            {
                szCultureResult = szCulture.ToString();

                return hr;
            }

            fail:
            szCultureResult = default(string);

            return hr;
        }

        #endregion
        #region Index

        /// <summary>
        /// Gets the assembly's prefix index.
        /// </summary>
        public int Index
        {
            get
            {
                HRESULT hr;
                int pIndex;

                if ((hr = TryGetIndex(out pIndex)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pIndex;
            }
        }

        /// <summary>
        /// Gets the assembly's prefix index.
        /// </summary>
        /// <param name="pIndex">[out] A pointer to the prefix index.</param>
        /// <remarks>
        /// The prefix index is used to prevent name collisions in the merged metadata type names.
        /// </remarks>
        public HRESULT TryGetIndex(out int pIndex)
        {
            /*HRESULT GetIndex(out int pIndex);*/
            return Raw.GetIndex(out pIndex);
        }

        #endregion
        #region GetPublicKey

        /// <summary>
        /// Gets the assembly's public key.
        /// </summary>
        /// <param name="cbPublicKey">[in] The maximum number of bytes in the pbPublicKey array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetPublicKeyResult GetPublicKey(int cbPublicKey)
        {
            HRESULT hr;
            GetPublicKeyResult result;

            if ((hr = TryGetPublicKey(cbPublicKey, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the assembly's public key.
        /// </summary>
        /// <param name="cbPublicKey">[in] The maximum number of bytes in the pbPublicKey array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetPublicKey(int cbPublicKey, out GetPublicKeyResult result)
        {
            /*HRESULT GetPublicKey(
            [In] int cbPublicKey,
            out int pcbPublicKey,
            [MarshalAs(UnmanagedType.LPArray), Out]
            byte[] pbPublicKey);*/
            int pcbPublicKey;
            byte[] pbPublicKey = null;
            HRESULT hr = Raw.GetPublicKey(cbPublicKey, out pcbPublicKey, pbPublicKey);

            if (hr == HRESULT.S_OK)
                result = new GetPublicKeyResult(pcbPublicKey, pbPublicKey);
            else
                result = default(GetPublicKeyResult);

            return hr;
        }

        #endregion
        #region GetPublicKeyToken

        /// <summary>
        /// Gets the assembly's public key token.
        /// </summary>
        /// <param name="cbPublicKeyToken">[in] The maximum number of bytes in the pbPublicKeyToken array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// An assembly's public key token is the last eight bytes of a SHA1 hash of its public key.
        /// </remarks>
        public GetPublicKeyTokenResult GetPublicKeyToken(int cbPublicKeyToken)
        {
            HRESULT hr;
            GetPublicKeyTokenResult result;

            if ((hr = TryGetPublicKeyToken(cbPublicKeyToken, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the assembly's public key token.
        /// </summary>
        /// <param name="cbPublicKeyToken">[in] The maximum number of bytes in the pbPublicKeyToken array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// An assembly's public key token is the last eight bytes of a SHA1 hash of its public key.
        /// </remarks>
        public HRESULT TryGetPublicKeyToken(int cbPublicKeyToken, out GetPublicKeyTokenResult result)
        {
            /*HRESULT GetPublicKeyToken(
            [In] int cbPublicKeyToken,
            out int pcbPublicKeyToken,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] pbPublicKeyToken);*/
            int pcbPublicKeyToken;
            byte[] pbPublicKeyToken = null;
            HRESULT hr = Raw.GetPublicKeyToken(cbPublicKeyToken, out pcbPublicKeyToken, pbPublicKeyToken);

            if (hr == HRESULT.S_OK)
                result = new GetPublicKeyTokenResult(pcbPublicKeyToken, pbPublicKeyToken);
            else
                result = default(GetPublicKeyTokenResult);

            return hr;
        }

        #endregion
        #endregion
    }
}