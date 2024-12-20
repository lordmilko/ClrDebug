using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The image parse provider provides an image parser for recognized formats in one of several manners.
    /// </summary>
    public class SvcImageParseProvider : ComObject<ISvcImageParseProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcImageParseProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcImageParseProvider(ISvcImageParseProvider raw) : base(raw)
        {
        }

        #region ISvcImageParseProvider
        #region ParseLoadedImage

        /// <summary>
        /// Parses an image which is in the target VA space of the process and is given by an ISvcModule. Not every method will work on an image parsed directly out of target VA space.<para/>
        /// The ELF section table is often not pulled into the loaded image and hence enumerating sections will outright fail.
        /// </summary>
        public SvcImageParser ParseLoadedImage(ISvcModule pImage)
        {
            SvcImageParser ppImageParserResult;
            TryParseLoadedImage(pImage, out ppImageParserResult).ThrowDbgEngNotOK();

            return ppImageParserResult;
        }

        /// <summary>
        /// Parses an image which is in the target VA space of the process and is given by an ISvcModule. Not every method will work on an image parsed directly out of target VA space.<para/>
        /// The ELF section table is often not pulled into the loaded image and hence enumerating sections will outright fail.
        /// </summary>
        public HRESULT TryParseLoadedImage(ISvcModule pImage, out SvcImageParser ppImageParserResult)
        {
            /*HRESULT ParseLoadedImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pImage,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);*/
            ISvcImageParser ppImageParser;
            HRESULT hr = Raw.ParseLoadedImage(pImage, out ppImageParser);

            if (hr == HRESULT.S_OK)
                ppImageParserResult = ppImageParser == null ? null : new SvcImageParser(ppImageParser);
            else
                ppImageParserResult = default(SvcImageParser);

            return hr;
        }

        #endregion
        #region ParseImageFile

        /// <summary>
        /// Parses an image which is from a file on disk.
        /// </summary>
        public SvcImageParser ParseImageFile(ISvcDebugSourceFile pImageFile)
        {
            SvcImageParser ppImageParserResult;
            TryParseImageFile(pImageFile, out ppImageParserResult).ThrowDbgEngNotOK();

            return ppImageParserResult;
        }

        /// <summary>
        /// Parses an image which is from a file on disk.
        /// </summary>
        public HRESULT TryParseImageFile(ISvcDebugSourceFile pImageFile, out SvcImageParser ppImageParserResult)
        {
            /*HRESULT ParseImageFile(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcDebugSourceFile pImageFile,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);*/
            ISvcImageParser ppImageParser;
            HRESULT hr = Raw.ParseImageFile(pImageFile, out ppImageParser);

            if (hr == HRESULT.S_OK)
                ppImageParserResult = ppImageParser == null ? null : new SvcImageParser(ppImageParser);
            else
                ppImageParserResult = default(SvcImageParser);

            return hr;
        }

        #endregion
        #region ParseTargetMappedImage

        /// <summary>
        /// Parses an image which is memory mapped into a target VA space as a flat memory map (and not as a loaded image).
        /// </summary>
        public SvcImageParser ParseTargetMappedImage(ISvcAddressContext pImageContext, long imageOffset, long imageSize)
        {
            SvcImageParser ppImageParserResult;
            TryParseTargetMappedImage(pImageContext, imageOffset, imageSize, out ppImageParserResult).ThrowDbgEngNotOK();

            return ppImageParserResult;
        }

        /// <summary>
        /// Parses an image which is memory mapped into a target VA space as a flat memory map (and not as a loaded image).
        /// </summary>
        public HRESULT TryParseTargetMappedImage(ISvcAddressContext pImageContext, long imageOffset, long imageSize, out SvcImageParser ppImageParserResult)
        {
            /*HRESULT ParseTargetMappedImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext pImageContext,
            [In] long imageOffset,
            [In] long imageSize,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);*/
            ISvcImageParser ppImageParser;
            HRESULT hr = Raw.ParseTargetMappedImage(pImageContext, imageOffset, imageSize, out ppImageParser);

            if (hr == HRESULT.S_OK)
                ppImageParserResult = ppImageParser == null ? null : new SvcImageParser(ppImageParser);
            else
                ppImageParserResult = default(SvcImageParser);

            return hr;
        }

        #endregion
        #region ParseLocalLoadedImage

        /// <summary>
        /// Parsea an image which is loaded into the address space of the caller. Not every method will work on an image parsed from a loaded view.<para/>
        /// The ELF section table is often not pulled into the loaded image and hence enumerating sections will outright fail.
        /// </summary>
        public SvcImageParser ParseLocalLoadedImage(IntPtr pImageMap, long imageSize)
        {
            SvcImageParser ppImageParserResult;
            TryParseLocalLoadedImage(pImageMap, imageSize, out ppImageParserResult).ThrowDbgEngNotOK();

            return ppImageParserResult;
        }

        /// <summary>
        /// Parsea an image which is loaded into the address space of the caller. Not every method will work on an image parsed from a loaded view.<para/>
        /// The ELF section table is often not pulled into the loaded image and hence enumerating sections will outright fail.
        /// </summary>
        public HRESULT TryParseLocalLoadedImage(IntPtr pImageMap, long imageSize, out SvcImageParser ppImageParserResult)
        {
            /*HRESULT ParseLocalLoadedImage(
            [In] IntPtr pImageMap,
            [In] long imageSize,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);*/
            ISvcImageParser ppImageParser;
            HRESULT hr = Raw.ParseLocalLoadedImage(pImageMap, imageSize, out ppImageParser);

            if (hr == HRESULT.S_OK)
                ppImageParserResult = ppImageParser == null ? null : new SvcImageParser(ppImageParser);
            else
                ppImageParserResult = default(SvcImageParser);

            return hr;
        }

        #endregion
        #region ParseLocalMappedImage

        /// <summary>
        /// Parses an image which is memory mapped into the address space of the caller as a flat memory map (and not as a loaded image).
        /// </summary>
        public SvcImageParser ParseLocalMappedImage(IntPtr pImageMap, long imageSize)
        {
            SvcImageParser ppImageParserResult;
            TryParseLocalMappedImage(pImageMap, imageSize, out ppImageParserResult).ThrowDbgEngNotOK();

            return ppImageParserResult;
        }

        /// <summary>
        /// Parses an image which is memory mapped into the address space of the caller as a flat memory map (and not as a loaded image).
        /// </summary>
        public HRESULT TryParseLocalMappedImage(IntPtr pImageMap, long imageSize, out SvcImageParser ppImageParserResult)
        {
            /*HRESULT ParseLocalMappedImage(
            [In] IntPtr pImageMap,
            [In] long imageSize,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);*/
            ISvcImageParser ppImageParser;
            HRESULT hr = Raw.ParseLocalMappedImage(pImageMap, imageSize, out ppImageParser);

            if (hr == HRESULT.S_OK)
                ppImageParserResult = ppImageParser == null ? null : new SvcImageParser(ppImageParser);
            else
                ppImageParserResult = default(SvcImageParser);

            return hr;
        }

        #endregion
        #endregion
    }
}
