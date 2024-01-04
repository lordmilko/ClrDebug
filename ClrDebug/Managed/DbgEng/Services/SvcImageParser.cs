namespace ClrDebug.DbgEng
{
    public class SvcImageParser : ComObject<ISvcImageParser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcImageParser"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcImageParser(ISvcImageParser raw) : base(raw)
        {
        }

        #region ISvcImageParser
        #region ImageArchitecture

        public int ImageArchitecture
        {
            get
            {
                int pImageArch;
                TryGetImageArchitecture(out pImageArch).ThrowDbgEngNotOK();

                return pImageArch;
            }
        }

        public HRESULT TryGetImageArchitecture(out int pImageArch)
        {
            /*HRESULT GetImageArchitecture(
            [Out] out int pImageArch);*/
            return Raw.GetImageArchitecture(out pImageArch);
        }

        #endregion
        #region ImageLoadSize

        public long ImageLoadSize
        {
            get
            {
                long pImageLoadSize;
                TryGetImageLoadSize(out pImageLoadSize).ThrowDbgEngNotOK();

                return pImageLoadSize;
            }
        }

        public HRESULT TryGetImageLoadSize(out long pImageLoadSize)
        {
            /*HRESULT GetImageLoadSize(
            [Out] out long pImageLoadSize);*/
            return Raw.GetImageLoadSize(out pImageLoadSize);
        }

        #endregion
        #region ReparseForAlternateArchitecture

        public SvcImageParser ReparseForAlternateArchitecture(int altArch)
        {
            SvcImageParser ppAltParserResult;
            TryReparseForAlternateArchitecture(altArch, out ppAltParserResult).ThrowDbgEngNotOK();

            return ppAltParserResult;
        }

        public HRESULT TryReparseForAlternateArchitecture(int altArch, out SvcImageParser ppAltParserResult)
        {
            /*HRESULT ReparseForAlternateArchitecture(
            [In] int altArch,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppAltParser);*/
            ISvcImageParser ppAltParser;
            HRESULT hr = Raw.ReparseForAlternateArchitecture(altArch, out ppAltParser);

            if (hr == HRESULT.S_OK)
                ppAltParserResult = ppAltParser == null ? null : new SvcImageParser(ppAltParser);
            else
                ppAltParserResult = default(SvcImageParser);

            return hr;
        }

        #endregion
        #region EnumerateFileViewRegions

        public SvcImageFileViewRegionEnumerator EnumerateFileViewRegions()
        {
            SvcImageFileViewRegionEnumerator ppEnumResult;
            TryEnumerateFileViewRegions(out ppEnumResult).ThrowDbgEngNotOK();

            return ppEnumResult;
        }

        public HRESULT TryEnumerateFileViewRegions(out SvcImageFileViewRegionEnumerator ppEnumResult)
        {
            /*HRESULT EnumerateFileViewRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageFileViewRegionEnumerator ppEnum);*/
            ISvcImageFileViewRegionEnumerator ppEnum;
            HRESULT hr = Raw.EnumerateFileViewRegions(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new SvcImageFileViewRegionEnumerator(ppEnum);
            else
                ppEnumResult = default(SvcImageFileViewRegionEnumerator);

            return hr;
        }

        #endregion
        #region FindFileViewRegion

        public SvcImageFileViewRegion FindFileViewRegion(string pwsRegionName)
        {
            SvcImageFileViewRegion ppRegionResult;
            TryFindFileViewRegion(pwsRegionName, out ppRegionResult).ThrowDbgEngNotOK();

            return ppRegionResult;
        }

        public HRESULT TryFindFileViewRegion(string pwsRegionName, out SvcImageFileViewRegion ppRegionResult)
        {
            /*HRESULT FindFileViewRegion(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwsRegionName,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageFileViewRegion ppRegion);*/
            ISvcImageFileViewRegion ppRegion;
            HRESULT hr = Raw.FindFileViewRegion(pwsRegionName, out ppRegion);

            if (hr == HRESULT.S_OK)
                ppRegionResult = ppRegion == null ? null : new SvcImageFileViewRegion(ppRegion);
            else
                ppRegionResult = default(SvcImageFileViewRegion);

            return hr;
        }

        #endregion
        #region FindFileViewRegionByOffset

        public SvcImageFileViewRegion FindFileViewRegionByOffset(long offset)
        {
            SvcImageFileViewRegion ppRegionResult;
            TryFindFileViewRegionByOffset(offset, out ppRegionResult).ThrowDbgEngNotOK();

            return ppRegionResult;
        }

        public HRESULT TryFindFileViewRegionByOffset(long offset, out SvcImageFileViewRegion ppRegionResult)
        {
            /*HRESULT FindFileViewRegionByOffset(
            [In] long offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageFileViewRegion ppRegion);*/
            ISvcImageFileViewRegion ppRegion;
            HRESULT hr = Raw.FindFileViewRegionByOffset(offset, out ppRegion);

            if (hr == HRESULT.S_OK)
                ppRegionResult = ppRegion == null ? null : new SvcImageFileViewRegion(ppRegion);
            else
                ppRegionResult = default(SvcImageFileViewRegion);

            return hr;
        }

        #endregion
        #region EnumerateMemoryViewRegions

        public SvcImageMemoryViewRegionEnumerator EnumerateMemoryViewRegions()
        {
            SvcImageMemoryViewRegionEnumerator ppEnumResult;
            TryEnumerateMemoryViewRegions(out ppEnumResult).ThrowDbgEngNotOK();

            return ppEnumResult;
        }

        public HRESULT TryEnumerateMemoryViewRegions(out SvcImageMemoryViewRegionEnumerator ppEnumResult)
        {
            /*HRESULT EnumerateMemoryViewRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageMemoryViewRegionEnumerator ppEnum);*/
            ISvcImageMemoryViewRegionEnumerator ppEnum;
            HRESULT hr = Raw.EnumerateMemoryViewRegions(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new SvcImageMemoryViewRegionEnumerator(ppEnum);
            else
                ppEnumResult = default(SvcImageMemoryViewRegionEnumerator);

            return hr;
        }

        #endregion
        #region FindMemoryViewRegionByOffset

        public SvcImageMemoryViewRegion FindMemoryViewRegionByOffset(long offset)
        {
            SvcImageMemoryViewRegion ppRegionResult;
            TryFindMemoryViewRegionByOffset(offset, out ppRegionResult).ThrowDbgEngNotOK();

            return ppRegionResult;
        }

        public HRESULT TryFindMemoryViewRegionByOffset(long offset, out SvcImageMemoryViewRegion ppRegionResult)
        {
            /*HRESULT FindMemoryViewRegionByOffset(
            [In] long offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageMemoryViewRegion ppRegion);*/
            ISvcImageMemoryViewRegion ppRegion;
            HRESULT hr = Raw.FindMemoryViewRegionByOffset(offset, out ppRegion);

            if (hr == HRESULT.S_OK)
                ppRegionResult = ppRegion == null ? null : new SvcImageMemoryViewRegion(ppRegion);
            else
                ppRegionResult = default(SvcImageMemoryViewRegion);

            return hr;
        }

        #endregion
        #region FindMemoryViewRegionById

        public SvcImageMemoryViewRegion FindMemoryViewRegionById(long id)
        {
            SvcImageMemoryViewRegion ppRegionResult;
            TryFindMemoryViewRegionById(id, out ppRegionResult).ThrowDbgEngNotOK();

            return ppRegionResult;
        }

        public HRESULT TryFindMemoryViewRegionById(long id, out SvcImageMemoryViewRegion ppRegionResult)
        {
            /*HRESULT FindMemoryViewRegionById(
            [In] long id,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageMemoryViewRegion ppRegion);*/
            ISvcImageMemoryViewRegion ppRegion;
            HRESULT hr = Raw.FindMemoryViewRegionById(id, out ppRegion);

            if (hr == HRESULT.S_OK)
                ppRegionResult = ppRegion == null ? null : new SvcImageMemoryViewRegion(ppRegion);
            else
                ppRegionResult = default(SvcImageMemoryViewRegion);

            return hr;
        }

        #endregion
        #region TranslateFileViewOffsetToMemoryViewOffset

        public TranslateFileViewOffsetToMemoryViewOffsetResult TranslateFileViewOffsetToMemoryViewOffset(long fileViewOffset)
        {
            TranslateFileViewOffsetToMemoryViewOffsetResult result;
            TryTranslateFileViewOffsetToMemoryViewOffset(fileViewOffset, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryTranslateFileViewOffsetToMemoryViewOffset(long fileViewOffset, out TranslateFileViewOffsetToMemoryViewOffsetResult result)
        {
            /*HRESULT TranslateFileViewOffsetToMemoryViewOffset(
            [In] long fileViewOffset,
            [Out] out long pMemoryViewOffset,
            [Out] out long pMappedByteCount);*/
            long pMemoryViewOffset;
            long pMappedByteCount;
            HRESULT hr = Raw.TranslateFileViewOffsetToMemoryViewOffset(fileViewOffset, out pMemoryViewOffset, out pMappedByteCount);

            if (hr == HRESULT.S_OK)
                result = new TranslateFileViewOffsetToMemoryViewOffsetResult(pMemoryViewOffset, pMappedByteCount);
            else
                result = default(TranslateFileViewOffsetToMemoryViewOffsetResult);

            return hr;
        }

        #endregion
        #region GetMemoryViewOffset

        public GetMemoryViewOffsetResult GetMemoryViewOffset(long currentViewOffset)
        {
            GetMemoryViewOffsetResult result;
            TryGetMemoryViewOffset(currentViewOffset, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryGetMemoryViewOffset(long currentViewOffset, out GetMemoryViewOffsetResult result)
        {
            /*HRESULT GetMemoryViewOffset(
            [In] long currentViewOffset,
            [Out] out long pMemoryViewOffset,
            [Out] out long pMappedByteCount);*/
            long pMemoryViewOffset;
            long pMappedByteCount;
            HRESULT hr = Raw.GetMemoryViewOffset(currentViewOffset, out pMemoryViewOffset, out pMappedByteCount);

            if (hr == HRESULT.S_OK)
                result = new GetMemoryViewOffsetResult(pMemoryViewOffset, pMappedByteCount);
            else
                result = default(GetMemoryViewOffsetResult);

            return hr;
        }

        #endregion
        #region TranslateMemoryViewOffsetToFileViewOffset

        public TranslateMemoryViewOffsetToFileViewOffsetResult TranslateMemoryViewOffsetToFileViewOffset(long memoryViewOffset)
        {
            TranslateMemoryViewOffsetToFileViewOffsetResult result;
            TryTranslateMemoryViewOffsetToFileViewOffset(memoryViewOffset, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryTranslateMemoryViewOffsetToFileViewOffset(long memoryViewOffset, out TranslateMemoryViewOffsetToFileViewOffsetResult result)
        {
            /*HRESULT TranslateMemoryViewOffsetToFileViewOffset(
            [In] long memoryViewOffset,
            [Out] out long pFileViewOffset,
            [Out] out long pMappedByteCount);*/
            long pFileViewOffset;
            long pMappedByteCount;
            HRESULT hr = Raw.TranslateMemoryViewOffsetToFileViewOffset(memoryViewOffset, out pFileViewOffset, out pMappedByteCount);

            if (hr == HRESULT.S_OK)
                result = new TranslateMemoryViewOffsetToFileViewOffsetResult(pFileViewOffset, pMappedByteCount);
            else
                result = default(TranslateMemoryViewOffsetToFileViewOffsetResult);

            return hr;
        }

        #endregion
        #region GetFileViewOffset

        public GetFileViewOffsetResult GetFileViewOffset(long currentViewOffset)
        {
            GetFileViewOffsetResult result;
            TryGetFileViewOffset(currentViewOffset, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryGetFileViewOffset(long currentViewOffset, out GetFileViewOffsetResult result)
        {
            /*HRESULT GetFileViewOffset(
            [In] long currentViewOffset,
            [Out] out long pFileViewOffset,
            [Out] out long pMappedByteCount);*/
            long pFileViewOffset;
            long pMappedByteCount;
            HRESULT hr = Raw.GetFileViewOffset(currentViewOffset, out pFileViewOffset, out pMappedByteCount);

            if (hr == HRESULT.S_OK)
                result = new GetFileViewOffsetResult(pFileViewOffset, pMappedByteCount);
            else
                result = default(GetFileViewOffsetResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
