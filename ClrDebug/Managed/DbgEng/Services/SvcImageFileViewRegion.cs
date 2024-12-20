namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes a "file view region" of an executable. This might be called a "section" in some parlances.
    /// </summary>
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

        /// <summary>
        /// Gets the file offset of the file region.
        /// </summary>
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

        /// <summary>
        /// Gets the size of the file region.
        /// </summary>
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

        /// <summary>
        /// Gets the name of the region. If the region has no name, E_NOT_SET is returned.
        /// </summary>
        public string Name
        {
            get
            {
                string pRegionName;
                TryGetName(out pRegionName).ThrowDbgEngNotOK();

                return pRegionName;
            }
        }

        /// <summary>
        /// Gets the name of the region. If the region has no name, E_NOT_SET is returned.
        /// </summary>
        public HRESULT TryGetName(out string pRegionName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRegionName);*/
            return Raw.GetName(out pRegionName);
        }

        #endregion
        #region MemoryViewAssociation

        /// <summary>
        /// Gets the association of this file view region to the memory view. If this file section is *NOT* associated with the memory view (it is not mapped by a loader), S_FALSE is returned with a 0/0 mapping and pExtraByteMapping filled in.<para/>
        /// By default, this will return a singular mapping (of the start of the file view region).
        /// </summary>
        public GetMemoryViewAssociationResult MemoryViewAssociation
        {
            get
            {
                GetMemoryViewAssociationResult result;
                TryGetMemoryViewAssociation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// Gets the association of this file view region to the memory view. If this file section is *NOT* associated with the memory view (it is not mapped by a loader), S_FALSE is returned with a 0/0 mapping and pExtraByteMapping filled in.<para/>
        /// By default, this will return a singular mapping (of the start of the file view region).
        /// </summary>
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
