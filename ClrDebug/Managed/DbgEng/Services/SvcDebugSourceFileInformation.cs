namespace ClrDebug.DbgEng
{
    public class SvcDebugSourceFileInformation : ComObject<ISvcDebugSourceFileInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcDebugSourceFileInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcDebugSourceFileInformation(ISvcDebugSourceFileInformation raw) : base(raw)
        {
        }

        #region ISvcDebugSourceFileInformation
        #region Name

        /// <summary>
        /// Gets the name of the underlying file.
        /// </summary>
        public string Name
        {
            get
            {
                string fileName;
                TryGetName(out fileName).ThrowDbgEngNotOK();

                return fileName;
            }
        }

        /// <summary>
        /// Gets the name of the underlying file.
        /// </summary>
        public HRESULT TryGetName(out string fileName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string fileName);*/
            return Raw.GetName(out fileName);
        }

        #endregion
        #region Path

        /// <summary>
        /// Gets the path of the underlying file.
        /// </summary>
        public string Path
        {
            get
            {
                string filePath;
                TryGetPath(out filePath).ThrowDbgEngNotOK();

                return filePath;
            }
        }

        /// <summary>
        /// Gets the path of the underlying file.
        /// </summary>
        public HRESULT TryGetPath(out string filePath)
        {
            /*HRESULT GetPath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string filePath);*/
            return Raw.GetPath(out filePath);
        }

        #endregion
        #region Size

        /// <summary>
        /// Gets the size of the underlying file.
        /// </summary>
        public long Size
        {
            get
            {
                long fileSize;
                TryGetSize(out fileSize).ThrowDbgEngNotOK();

                return fileSize;
            }
        }

        /// <summary>
        /// Gets the size of the underlying file.
        /// </summary>
        public HRESULT TryGetSize(out long fileSize)
        {
            /*HRESULT GetSize(
            [Out] out long fileSize);*/
            return Raw.GetSize(out fileSize);
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
