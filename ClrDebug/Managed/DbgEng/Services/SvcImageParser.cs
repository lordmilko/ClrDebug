namespace ClrDebug.DbgEng
{
    /// <summary>
    /// General service for parsing an executable image of some generic format which may be on disk, may be memory mapped (as a file), or may be memory mapped (as a loaded image), or may be in the VA space of the target (as either a flat map or a loaded image).
    /// </summary>
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

        /// <summary>
        /// Gets the architecture of the image. If the image is a multi-architecture image (for any definition of such -- whether a "fat binary", a "CHPE image", etc..., this method will return S_FALSE to indicate that it returned the *DEFAULT ARCHITECTURE* but that another "view" of the binary is available.
        /// </summary>
        public int ImageArchitecture
        {
            get
            {
                int pImageArch;
                TryGetImageArchitecture(out pImageArch).ThrowDbgEngNotOK();

                return pImageArch;
            }
        }

        /// <summary>
        /// Gets the architecture of the image. If the image is a multi-architecture image (for any definition of such -- whether a "fat binary", a "CHPE image", etc..., this method will return S_FALSE to indicate that it returned the *DEFAULT ARCHITECTURE* but that another "view" of the binary is available.
        /// </summary>
        public HRESULT TryGetImageArchitecture(out int pImageArch)
        {
            /*HRESULT GetImageArchitecture(
            [Out] out int pImageArch);*/
            return Raw.GetImageArchitecture(out pImageArch);
        }

        #endregion
        #region ImageLoadSize

        /// <summary>
        /// Gets the load size of the image as determined from the headers of the format.
        /// </summary>
        public long ImageLoadSize
        {
            get
            {
                long pImageLoadSize;
                TryGetImageLoadSize(out pImageLoadSize).ThrowDbgEngNotOK();

                return pImageLoadSize;
            }
        }

        /// <summary>
        /// Gets the load size of the image as determined from the headers of the format.
        /// </summary>
        public HRESULT TryGetImageLoadSize(out long pImageLoadSize)
        {
            /*HRESULT GetImageLoadSize(
            [Out] out long pImageLoadSize);*/
            return Raw.GetImageLoadSize(out pImageLoadSize);
        }

        #endregion
        #region ReparseForAlternateArchitecture

        /// <summary>
        /// Maps an alternate view of the image for a secondary architecture. If the image is not a multi-architecture image, this will return E_NOTIMPL.
        /// </summary>
        public SvcImageParser ReparseForAlternateArchitecture(int altArch)
        {
            SvcImageParser ppAltParserResult;
            TryReparseForAlternateArchitecture(altArch, out ppAltParserResult).ThrowDbgEngNotOK();

            return ppAltParserResult;
        }

        /// <summary>
        /// Maps an alternate view of the image for a secondary architecture. If the image is not a multi-architecture image, this will return E_NOTIMPL.
        /// </summary>
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

        /// <summary>
        /// EnumerateFileViewRegions Enumerates every "file view region" within the file. This often corresponds to what an executable image format would call a section.
        /// </summary>
        public SvcImageFileViewRegionEnumerator EnumerateFileViewRegions()
        {
            SvcImageFileViewRegionEnumerator ppEnumResult;
            TryEnumerateFileViewRegions(out ppEnumResult).ThrowDbgEngNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// EnumerateFileViewRegions Enumerates every "file view region" within the file. This often corresponds to what an executable image format would call a section.
        /// </summary>
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

        /// <summary>
        /// FindFileViewRegion Locate a "file view region" within the file by its given name (e.g.: ".text", etc...). If there is no such named region, E_BOUNDS is returned.
        /// </summary>
        public SvcImageFileViewRegion FindFileViewRegion(string pwsRegionName)
        {
            SvcImageFileViewRegion ppRegionResult;
            TryFindFileViewRegion(pwsRegionName, out ppRegionResult).ThrowDbgEngNotOK();

            return ppRegionResult;
        }

        /// <summary>
        /// FindFileViewRegion Locate a "file view region" within the file by its given name (e.g.: ".text", etc...). If there is no such named region, E_BOUNDS is returned.
        /// </summary>
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

        /// <summary>
        /// FindFileViewRegionByOffset Locate a "file view region" given an offset within the file view.
        /// </summary>
        public SvcImageFileViewRegion FindFileViewRegionByOffset(long offset)
        {
            SvcImageFileViewRegion ppRegionResult;
            TryFindFileViewRegionByOffset(offset, out ppRegionResult).ThrowDbgEngNotOK();

            return ppRegionResult;
        }

        /// <summary>
        /// FindFileViewRegionByOffset Locate a "file view region" given an offset within the file view.
        /// </summary>
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

        /// <summary>
        /// EnumerateMemoryViewRegions Enumerates every "memory view region" within the file. This often corresponds to what an executable image format would call a segment.<para/>
        /// For ELF, this would correspond to program headers with a VA/PA mapping.
        /// </summary>
        public SvcImageMemoryViewRegionEnumerator EnumerateMemoryViewRegions()
        {
            SvcImageMemoryViewRegionEnumerator ppEnumResult;
            TryEnumerateMemoryViewRegions(out ppEnumResult).ThrowDbgEngNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// EnumerateMemoryViewRegions Enumerates every "memory view region" within the file. This often corresponds to what an executable image format would call a segment.<para/>
        /// For ELF, this would correspond to program headers with a VA/PA mapping.
        /// </summary>
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

        /// <summary>
        /// FindMemoryViewRegionByOffset Locate a "memory view region" given an offset within the VA space of the loaded module (what some parlances might call a relative virtual address or RVA).
        /// </summary>
        public SvcImageMemoryViewRegion FindMemoryViewRegionByOffset(long offset)
        {
            SvcImageMemoryViewRegion ppRegionResult;
            TryFindMemoryViewRegionByOffset(offset, out ppRegionResult).ThrowDbgEngNotOK();

            return ppRegionResult;
        }

        /// <summary>
        /// FindMemoryViewRegionByOffset Locate a "memory view region" given an offset within the VA space of the loaded module (what some parlances might call a relative virtual address or RVA).
        /// </summary>
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

        /// <summary>
        /// Locate a "memory view region" given its id.
        /// </summary>
        public SvcImageMemoryViewRegion FindMemoryViewRegionById(long id)
        {
            SvcImageMemoryViewRegion ppRegionResult;
            TryFindMemoryViewRegionById(id, out ppRegionResult).ThrowDbgEngNotOK();

            return ppRegionResult;
        }

        /// <summary>
        /// Locate a "memory view region" given its id.
        /// </summary>
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

        /// <summary>
        /// TranslateFileViewOffsetToMemoryViewOffset Translates an offset into the file view of the image into an offset in the memory view of the image.<para/>
        /// An offset out of bounds of the file view will return E_BOUNDS. An offset which does not map to anything in the memory view (it is only in the file and not put in memory by the loader) will return E_NOT_SET.<para/>
        /// If a mapping is returned, the number of contiguous bytes of the mapping can optionally be returned.
        /// </summary>
        public TranslateFileViewOffsetToMemoryViewOffsetResult TranslateFileViewOffsetToMemoryViewOffset(long fileViewOffset)
        {
            TranslateFileViewOffsetToMemoryViewOffsetResult result;
            TryTranslateFileViewOffsetToMemoryViewOffset(fileViewOffset, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// TranslateFileViewOffsetToMemoryViewOffset Translates an offset into the file view of the image into an offset in the memory view of the image.<para/>
        /// An offset out of bounds of the file view will return E_BOUNDS. An offset which does not map to anything in the memory view (it is only in the file and not put in memory by the loader) will return E_NOT_SET.<para/>
        /// If a mapping is returned, the number of contiguous bytes of the mapping can optionally be returned.
        /// </summary>
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

        /// <summary>
        /// GetMemoryViewOffset For an offset into the **CURRENT VIEW** of the image (depending on how the image was parsed), this will translate that offset into an offset in the memory view of the image.<para/>
        /// This may either be a no-op or may be equivalent to calling TranslateFileViewOffsetToMemoryViewOffset depending on how the image was originally parsed.
        /// </summary>
        public GetMemoryViewOffsetResult GetMemoryViewOffset(long currentViewOffset)
        {
            GetMemoryViewOffsetResult result;
            TryGetMemoryViewOffset(currentViewOffset, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// GetMemoryViewOffset For an offset into the **CURRENT VIEW** of the image (depending on how the image was parsed), this will translate that offset into an offset in the memory view of the image.<para/>
        /// This may either be a no-op or may be equivalent to calling TranslateFileViewOffsetToMemoryViewOffset depending on how the image was originally parsed.
        /// </summary>
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

        /// <summary>
        /// TranslateMemoryViewOffsetToFileViewOffset Translates an offset into the memory view of the image into an offset in the file view of the image.<para/>
        /// An offset out of bounds of the memory view will return E_BOUNDS. An offset which does not map to anything in the file view (e.g.: it is .bss or other uninitialized data) will return E_NOT_SET.<para/>
        /// If a mapping is returned, the number of contiguous bytes of the mapping can optionally be returned.
        /// </summary>
        public TranslateMemoryViewOffsetToFileViewOffsetResult TranslateMemoryViewOffsetToFileViewOffset(long memoryViewOffset)
        {
            TranslateMemoryViewOffsetToFileViewOffsetResult result;
            TryTranslateMemoryViewOffsetToFileViewOffset(memoryViewOffset, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// TranslateMemoryViewOffsetToFileViewOffset Translates an offset into the memory view of the image into an offset in the file view of the image.<para/>
        /// An offset out of bounds of the memory view will return E_BOUNDS. An offset which does not map to anything in the file view (e.g.: it is .bss or other uninitialized data) will return E_NOT_SET.<para/>
        /// If a mapping is returned, the number of contiguous bytes of the mapping can optionally be returned.
        /// </summary>
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

        /// <summary>
        /// GetFileViewOffset For an offset into the **CURRENT VIEW** of the image (depending on how the image was parsed), this will translate that offset into an offset in the file view of the image.<para/>
        /// This may either be a no-op or may be equivalent to calling TranslateMemoryViewOffsetToFileViewOffset depending on how the image was originally parsed.
        /// </summary>
        public GetFileViewOffsetResult GetFileViewOffset(long currentViewOffset)
        {
            GetFileViewOffsetResult result;
            TryGetFileViewOffset(currentViewOffset, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// GetFileViewOffset For an offset into the **CURRENT VIEW** of the image (depending on how the image was parsed), this will translate that offset into an offset in the file view of the image.<para/>
        /// This may either be a no-op or may be equivalent to calling TranslateMemoryViewOffsetToFileViewOffset depending on how the image was originally parsed.
        /// </summary>
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
