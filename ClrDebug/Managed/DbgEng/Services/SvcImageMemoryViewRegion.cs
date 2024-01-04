namespace ClrDebug.DbgEng
{
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

        public bool IsReadable
        {
            get
            {
                bool isReadable;
                TryIsReadable(out isReadable).ThrowDbgEngNotOK();

                return isReadable;
            }
        }

        public HRESULT TryIsReadable(out bool isReadable)
        {
            /*HRESULT IsReadable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsReadable);*/
            return Raw.IsReadable(out isReadable);
        }

        #endregion
        #region IsWriteable

        public bool IsWriteable
        {
            get
            {
                bool isWriteable;
                TryIsWriteable(out isWriteable).ThrowDbgEngNotOK();

                return isWriteable;
            }
        }

        public HRESULT TryIsWriteable(out bool isWriteable)
        {
            /*HRESULT IsWriteable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsWriteable);*/
            return Raw.IsWriteable(out isWriteable);
        }

        #endregion
        #region IsExecutable

        public bool IsExecutable
        {
            get
            {
                bool isExecutable;
                TryIsExecutable(out isExecutable).ThrowDbgEngNotOK();

                return isExecutable;
            }
        }

        public HRESULT TryIsExecutable(out bool isExecutable)
        {
            /*HRESULT IsExecutable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsExecutable);*/
            return Raw.IsExecutable(out isExecutable);
        }

        #endregion
        #region Alignment

        public int Alignment
        {
            get
            {
                int alignment;
                TryGetAlignment(out alignment).ThrowDbgEngNotOK();

                return alignment;
            }
        }

        public HRESULT TryGetAlignment(out int alignment)
        {
            /*HRESULT GetAlignment(
            [Out] out int Alignment);*/
            return Raw.GetAlignment(out alignment);
        }

        #endregion
        #region FileViewAssociation

        public GetFileViewAssociationResult FileViewAssociation
        {
            get
            {
                GetFileViewAssociationResult result;
                TryGetFileViewAssociation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

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
