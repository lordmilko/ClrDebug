namespace ClrDebug.DbgEng
{
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

        public string Name
        {
            get
            {
                string name;
                TryGetName(out name).ThrowDbgEngNotOK();

                return name;
            }
        }

        public HRESULT TryGetName(out string name)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name);*/
            return Raw.GetName(out name);
        }

        #endregion
        #region Path

        public string Path
        {
            get
            {
                string path;
                TryGetPath(out path).ThrowDbgEngNotOK();

                return path;
            }
        }

        public HRESULT TryGetPath(out string path)
        {
            /*HRESULT GetPath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string path);*/
            return Raw.GetPath(out path);
        }

        #endregion
        #region HashDataSize

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

        public SvcSymbolSetEnumerator CompilationUnits
        {
            get
            {
                SvcSymbolSetEnumerator cuEnumeratorResult;
                TryGetCompilationUnits(out cuEnumeratorResult).ThrowDbgEngNotOK();

                return cuEnumeratorResult;
            }
        }

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

        public GetHashDataResult GetHashData(long hashDataSize)
        {
            GetHashDataResult result;
            TryGetHashData(hashDataSize, out result).ThrowDbgEngNotOK();

            return result;
        }

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
