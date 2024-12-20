namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a mechanism by which the original binary image for a module/image mapped into the debug target can be located from the limited information available from the debug target.<para/>
    /// A given debug target may, for example, represent a minidump which only has image headers or a core file which only has a subset of the image pages mapped into the core.<para/>
    /// This interface will attempt to find the original image file and return a file abstraction over it such that the entire module/image is available for debugging.
    /// </summary>
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

        /// <summary>
        /// Locate the file for a given image within the target.
        /// </summary>
        public SvcDebugSourceFile LocateImage(ISvcModule image)
        {
            SvcDebugSourceFile ppFileResult;
            TryLocateImage(image, out ppFileResult).ThrowDbgEngNotOK();

            return ppFileResult;
        }

        /// <summary>
        /// Locate the file for a given image within the target.
        /// </summary>
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
