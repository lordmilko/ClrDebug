namespace ClrDebug.DbgEng
{
    public class SvcImageFileViewRegion : ComObject<ISvcImageFileViewRegion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcImageFileViewRegion"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcImageFileViewRegion(ISvcImageFileViewRegion raw) : base(raw)
        {
        }

        #region ISvcImageFileViewRegion
        #region FileOffset

        public long FileOffset
        {
            get
            {
                /*long GetFileOffset();*/
                return Raw.GetFileOffset();
            }
        }

        #endregion
        #region Size

        public long Size
        {
            get
            {
                /*long GetSize();*/
                return Raw.GetSize();
            }
        }

        #endregion
        #region Name

        public string Name
        {
            get
            {
                string pRegionName;
                TryGetName(out pRegionName).ThrowDbgEngNotOK();

                return pRegionName;
            }
        }

        public HRESULT TryGetName(out string pRegionName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRegionName);*/
            return Raw.GetName(out pRegionName);
        }

        #endregion
        #region MemoryViewAssociation

        public GetMemoryViewAssociationResult MemoryViewAssociation
        {
            get
            {
                GetMemoryViewAssociationResult result;
                TryGetMemoryViewAssociation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetMemoryViewAssociation(out GetMemoryViewAssociationResult result)
        {
            /*HRESULT GetMemoryViewAssociation(
            [Out] out long pMemoryViewOffset,
            [Out] out long pMemoryViewSize,
            [Out] out ServiceImageByteMapping pExtraByteMapping);*/
            long pMemoryViewOffset;
            long pMemoryViewSize;
            ServiceImageByteMapping pExtraByteMapping;
            HRESULT hr = Raw.GetMemoryViewAssociation(out pMemoryViewOffset, out pMemoryViewSize, out pExtraByteMapping);

            if (hr == HRESULT.S_OK)
                result = new GetMemoryViewAssociationResult(pMemoryViewOffset, pMemoryViewSize, pExtraByteMapping);
            else
                result = default(GetMemoryViewAssociationResult);

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
