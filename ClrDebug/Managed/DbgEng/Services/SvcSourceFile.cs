namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a source file that contributes to the code in a binary.
    /// </summary>
    public class SvcSourceFile : ComObject<ISvcSourceFile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSourceFile"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSourceFile(ISvcSourceFile raw) : base(raw)
        {
        }

        #region ISvcSourceFile
        #region Id

        /// <summary>
        /// Gets a unique identifier for the source file.
        /// </summary>
        public long Id
        {
            get
            {
                /*long GetId();*/
                return Raw.GetId();
            }
        }

        #endregion
        #region Name

        /// <summary>
        /// Gets the name of the source file.
        /// </summary>
        public string Name
        {
            get
            {
                string name;
                TryGetName(out name).ThrowDbgEngNotOK();

                return name;
            }
        }

        /// <summary>
        /// Gets the name of the source file.
        /// </summary>
        public HRESULT TryGetName(out string name)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name);*/
            return Raw.GetName(out name);
        }

        #endregion
        #region Path

        /// <summary>
        /// Gets the path of the source file.
        /// </summary>
        public string Path
        {
            get
            {
                string path;
                TryGetPath(out path).ThrowDbgEngNotOK();

                return path;
            }
        }

        /// <summary>
        /// Gets the path of the source file.
        /// </summary>
        public HRESULT TryGetPath(out string path)
        {
            /*HRESULT GetPath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string path);*/
            return Raw.GetPath(out path);
        }

        #endregion
        #region HashDataSize

        /// <summary>
        /// Gets the size of the source file hash stored in symbolic information. If the symbolic information has no source file hash, this should return zero.
        /// </summary>
        public long HashDataSize
        {
            get
            {
                /*long GetHashDataSize();*/
                return Raw.GetHashDataSize();
            }
        }

        #endregion
        #region CompilationUnits

        /// <summary>
        /// Gets all the compilation units which reference this particular source file.
        /// </summary>
        public SvcSymbolSetEnumerator CompilationUnits
        {
            get
            {
                SvcSymbolSetEnumerator cuEnumeratorResult;
                TryGetCompilationUnits(out cuEnumeratorResult).ThrowDbgEngNotOK();

                return cuEnumeratorResult;
            }
        }

        /// <summary>
        /// Gets all the compilation units which reference this particular source file.
        /// </summary>
        public HRESULT TryGetCompilationUnits(out SvcSymbolSetEnumerator cuEnumeratorResult)
        {
            /*HRESULT GetCompilationUnits(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator cuEnumerator);*/
            ISvcSymbolSetEnumerator cuEnumerator;
            HRESULT hr = Raw.GetCompilationUnits(out cuEnumerator);

            if (hr == HRESULT.S_OK)
                cuEnumeratorResult = cuEnumerator == null ? null : new SvcSymbolSetEnumerator(cuEnumerator);
            else
                cuEnumeratorResult = default(SvcSymbolSetEnumerator);

            return hr;
        }

        #endregion
        #region GetHashData

        /// <summary>
        /// Gets the hash data associated with the source file. If there is no such information stored in the symbolic information, this will return E_NOT_SET.
        /// </summary>
        public GetHashDataResult GetHashData(long hashDataSize)
        {
            GetHashDataResult result;
            TryGetHashData(hashDataSize, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Gets the hash data associated with the source file. If there is no such information stored in the symbolic information, this will return E_NOT_SET.
        /// </summary>
        public HRESULT TryGetHashData(long hashDataSize, out GetHashDataResult result)
        {
            /*HRESULT GetHashData(
            [In] long hashDataSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] pHashData,
            [Out] out SvcHashAlgorithm pHashAlgorithm);*/
            byte[] pHashData = new byte[(int) hashDataSize];
            SvcHashAlgorithm pHashAlgorithm;
            HRESULT hr = Raw.GetHashData(hashDataSize, pHashData, out pHashAlgorithm);

            if (hr == HRESULT.S_OK)
                result = new GetHashDataResult(pHashData, pHashAlgorithm);
            else
                result = default(GetHashDataResult);

            return hr;
        }

        #endregion
        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
