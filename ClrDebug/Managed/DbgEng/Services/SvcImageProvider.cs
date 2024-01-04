namespace ClrDebug.DbgEng
{
    public class SvcImageProvider : ComObject<ISvcImageProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcImageProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcImageProvider(ISvcImageProvider raw) : base(raw)
        {
        }

        #region ISvcImageProvider
        #region LocateImage

        public SvcDebugSourceFile LocateImage(ISvcModule image)
        {
            SvcDebugSourceFile ppFileResult;
            TryLocateImage(image, out ppFileResult).ThrowDbgEngNotOK();

            return ppFileResult;
        }

        public HRESULT TryLocateImage(ISvcModule image, out SvcDebugSourceFile ppFileResult)
        {
            /*HRESULT LocateImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule image,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcDebugSourceFile ppFile);*/
            ISvcDebugSourceFile ppFile;
            HRESULT hr = Raw.LocateImage(image, out ppFile);

            if (hr == HRESULT.S_OK)
                ppFileResult = ppFile == null ? null : new SvcDebugSourceFile(ppFile);
            else
                ppFileResult = default(SvcDebugSourceFile);

            return hr;
        }

        #endregion
        #endregion
    }
}
