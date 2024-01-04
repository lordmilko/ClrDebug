using System;

namespace ClrDebug.DbgEng
{
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

        public SvcImageParser ParseLoadedImage(ISvcModule pImage)
        {
            SvcImageParser ppImageParserResult;
            TryParseLoadedImage(pImage, out ppImageParserResult).ThrowDbgEngNotOK();

            return ppImageParserResult;
        }

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

        public SvcImageParser ParseImageFile(ISvcDebugSourceFile pImageFile)
        {
            SvcImageParser ppImageParserResult;
            TryParseImageFile(pImageFile, out ppImageParserResult).ThrowDbgEngNotOK();

            return ppImageParserResult;
        }

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

        public SvcImageParser ParseTargetMappedImage(ISvcAddressContext pImageContext, long imageOffset, long imageSize)
        {
            SvcImageParser ppImageParserResult;
            TryParseTargetMappedImage(pImageContext, imageOffset, imageSize, out ppImageParserResult).ThrowDbgEngNotOK();

            return ppImageParserResult;
        }

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

        public SvcImageParser ParseLocalLoadedImage(IntPtr pImageMap, long imageSize)
        {
            SvcImageParser ppImageParserResult;
            TryParseLocalLoadedImage(pImageMap, imageSize, out ppImageParserResult).ThrowDbgEngNotOK();

            return ppImageParserResult;
        }

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

        public SvcImageParser ParseLocalMappedImage(IntPtr pImageMap, long imageSize)
        {
            SvcImageParser ppImageParserResult;
            TryParseLocalMappedImage(pImageMap, imageSize, out ppImageParserResult).ThrowDbgEngNotOK();

            return ppImageParserResult;
        }

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
