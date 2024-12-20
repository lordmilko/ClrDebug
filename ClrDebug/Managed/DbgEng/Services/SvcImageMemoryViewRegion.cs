namespace ClrDebug.DbgEng
{
    /// <summary>
    /// ISvcImageMemoryRegion Describes a "memory veiw region" of an executable. This might be called a "segment" in some parlances.
    /// </summary>
    public class SvcImageMemoryViewRegion : ComObject<ISvcImageMemoryViewRegion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcImageMemoryViewRegion"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcImageMemoryViewRegion(ISvcImageMemoryViewRegion raw) : base(raw)
        {
        }

        #region ISvcImageMemoryViewRegion
        #region MemoryOffset

        /// <summary>
        /// Gets the memory offset of the memory region. This corresponds to an offset from the load base of the image (or a "relative virtual address" as some might call it).
        /// </summary>
        public long MemoryOffset
        {
            get
            {
                /*long GetMemoryOffset();*/
                return Raw.GetMemoryOffset();
            }
        }

        #endregion
        #region Size

        /// <summary>
        /// Gets the size of the memory region.
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
        #region Id

        /// <summary>
        /// Gets a numeric id for the region. This may correspond to a segment number or may simply be an invented ID by the provider (e.g.: an index into the program header table).
        /// </summary>
        public long Id
        {
            get
            {
                /*long GetId();*/
                return Raw.GetId();
            }
        }

        #endregion
        #region IsReadable

        /// <summary>
        /// Indicates whether this region of the image is mapped as readable. If the implementation cannot make a determination of whether the range is readable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        public bool IsReadable
        {
            get
            {
                bool isReadable;
                TryIsReadable(out isReadable).ThrowDbgEngNotOK();

                return isReadable;
            }
        }

        /// <summary>
        /// Indicates whether this region of the image is mapped as readable. If the implementation cannot make a determination of whether the range is readable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        public HRESULT TryIsReadable(out bool isReadable)
        {
            /*HRESULT IsReadable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsReadable);*/
            return Raw.IsReadable(out isReadable);
        }

        #endregion
        #region IsWriteable

        /// <summary>
        /// Indicates whether this region of the image is mapped as writeable. If the implementation cannot make a determination of whether the range is writeable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        public bool IsWriteable
        {
            get
            {
                bool isWriteable;
                TryIsWriteable(out isWriteable).ThrowDbgEngNotOK();

                return isWriteable;
            }
        }

        /// <summary>
        /// Indicates whether this region of the image is mapped as writeable. If the implementation cannot make a determination of whether the range is writeable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        public HRESULT TryIsWriteable(out bool isWriteable)
        {
            /*HRESULT IsWriteable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsWriteable);*/
            return Raw.IsWriteable(out isWriteable);
        }

        #endregion
        #region IsExecutable

        /// <summary>
        /// Indicates whether this region of the image is mapped as executable. If the implementation cannot make a determination of whether the range is executable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        public bool IsExecutable
        {
            get
            {
                bool isExecutable;
                TryIsExecutable(out isExecutable).ThrowDbgEngNotOK();

                return isExecutable;
            }
        }

        /// <summary>
        /// Indicates whether this region of the image is mapped as executable. If the implementation cannot make a determination of whether the range is executable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        public HRESULT TryIsExecutable(out bool isExecutable)
        {
            /*HRESULT IsExecutable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsExecutable);*/
            return Raw.IsExecutable(out isExecutable);
        }

        #endregion
        #region Alignment

        /// <summary>
        /// Gets the required alignment for this mapping. If the implementation cannot make a determination of alignment, E_NOTIMPL may legally be returned.
        /// </summary>
        public int Alignment
        {
            get
            {
                int alignment;
                TryGetAlignment(out alignment).ThrowDbgEngNotOK();

                return alignment;
            }
        }

        /// <summary>
        /// Gets the required alignment for this mapping. If the implementation cannot make a determination of alignment, E_NOTIMPL may legally be returned.
        /// </summary>
        public HRESULT TryGetAlignment(out int alignment)
        {
            /*HRESULT GetAlignment(
            [Out] out int Alignment);*/
            return Raw.GetAlignment(out alignment);
        }

        #endregion
        #region FileViewAssociation

        /// <summary>
        /// Gets the association of this memory view region to the file view. If this memory section is *NOT* associated with the file view (it is uninitialized data, zero-fill, etc...), S_FALSE is returned with a 0/0 mapping and pExtraByteMapping filled in.<para/>
        /// By default, this will return a singular mapping (of the start of the memory view region).
        /// </summary>
        public GetFileViewAssociationResult FileViewAssociation
        {
            get
            {
                GetFileViewAssociationResult result;
                TryGetFileViewAssociation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// Gets the association of this memory view region to the file view. If this memory section is *NOT* associated with the file view (it is uninitialized data, zero-fill, etc...), S_FALSE is returned with a 0/0 mapping and pExtraByteMapping filled in.<para/>
        /// By default, this will return a singular mapping (of the start of the memory view region).
        /// </summary>
        public HRESULT TryGetFileViewAssociation(out GetFileViewAssociationResult result)
        {
            /*HRESULT GetFileViewAssociation(
            [Out] out long pFileViewOffset,
            [Out] out long pFileViewSize,
            [Out] out ServiceImageByteMapping pExtraByteMapping);*/
            long pFileViewOffset;
            long pFileViewSize;
            ServiceImageByteMapping pExtraByteMapping;
            HRESULT hr = Raw.GetFileViewAssociation(out pFileViewOffset, out pFileViewSize, out pExtraByteMapping);

            if (hr == HRESULT.S_OK)
                result = new GetFileViewAssociationResult(pFileViewOffset, pFileViewSize, pExtraByteMapping);
            else
                result = default(GetFileViewAssociationResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
