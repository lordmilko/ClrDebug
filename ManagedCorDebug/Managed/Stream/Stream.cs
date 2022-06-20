namespace ManagedCorDebug
{
    public class Stream : SequentialStream
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Stream"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public Stream(IStream raw) : base(raw)
        {
        }

        #region IStream

        public new IStream Raw => (IStream) base.Raw;

        #region RemoteSeek

        public ULARGE_INTEGER RemoteSeek(LARGE_INTEGER dlibMove, int dwOrigin)
        {
            ULARGE_INTEGER plibNewPosition;
            TryRemoteSeek(dlibMove, dwOrigin, out plibNewPosition).ThrowOnNotOK();

            return plibNewPosition;
        }

        public HRESULT TryRemoteSeek(LARGE_INTEGER dlibMove, int dwOrigin, out ULARGE_INTEGER plibNewPosition)
        {
            /*HRESULT RemoteSeek([In] LARGE_INTEGER dlibMove, [In] int dwOrigin, [Out] out ULARGE_INTEGER plibNewPosition);*/
            return Raw.RemoteSeek(dlibMove, dwOrigin, out plibNewPosition);
        }

        #endregion
        #region SetSize

        public void SetSize(ULARGE_INTEGER libNewSize)
        {
            TrySetSize(libNewSize).ThrowOnNotOK();
        }

        public HRESULT TrySetSize(ULARGE_INTEGER libNewSize)
        {
            /*HRESULT SetSize([In] ULARGE_INTEGER libNewSize);*/
            return Raw.SetSize(libNewSize);
        }

        #endregion
        #region RemoteCopyTo

        public RemoteCopyToResult RemoteCopyTo(IStream pstm, ULARGE_INTEGER cb)
        {
            RemoteCopyToResult result;
            TryRemoteCopyTo(pstm, cb, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryRemoteCopyTo(IStream pstm, ULARGE_INTEGER cb, out RemoteCopyToResult result)
        {
            /*HRESULT RemoteCopyTo(
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pstm,
            [In] ULARGE_INTEGER cb,
            [Out] out ULARGE_INTEGER pcbRead,
            [Out] out ULARGE_INTEGER pcbWritten);*/
            ULARGE_INTEGER pcbRead;
            ULARGE_INTEGER pcbWritten;
            HRESULT hr = Raw.RemoteCopyTo(pstm, cb, out pcbRead, out pcbWritten);

            if (hr == HRESULT.S_OK)
                result = new RemoteCopyToResult(pcbRead, pcbWritten);
            else
                result = default(RemoteCopyToResult);

            return hr;
        }

        #endregion
        #region Commit

        public void Commit(int grfCommitFlags)
        {
            TryCommit(grfCommitFlags).ThrowOnNotOK();
        }

        public HRESULT TryCommit(int grfCommitFlags)
        {
            /*HRESULT Commit([In] int grfCommitFlags);*/
            return Raw.Commit(grfCommitFlags);
        }

        #endregion
        #region Revert

        public void Revert()
        {
            TryRevert().ThrowOnNotOK();
        }

        public HRESULT TryRevert()
        {
            /*HRESULT Revert();*/
            return Raw.Revert();
        }

        #endregion
        #region LockRegion

        public void LockRegion(ULARGE_INTEGER libOffset, ULARGE_INTEGER cb, int dwLockType)
        {
            TryLockRegion(libOffset, cb, dwLockType).ThrowOnNotOK();
        }

        public HRESULT TryLockRegion(ULARGE_INTEGER libOffset, ULARGE_INTEGER cb, int dwLockType)
        {
            /*HRESULT LockRegion([In] ULARGE_INTEGER libOffset, [In] ULARGE_INTEGER cb, [In] int dwLockType);*/
            return Raw.LockRegion(libOffset, cb, dwLockType);
        }

        #endregion
        #region UnlockRegion

        public void UnlockRegion(ULARGE_INTEGER libOffset, ULARGE_INTEGER cb, int dwLockType)
        {
            TryUnlockRegion(libOffset, cb, dwLockType).ThrowOnNotOK();
        }

        public HRESULT TryUnlockRegion(ULARGE_INTEGER libOffset, ULARGE_INTEGER cb, int dwLockType)
        {
            /*HRESULT UnlockRegion([In] ULARGE_INTEGER libOffset, [In] ULARGE_INTEGER cb, [In] int dwLockType);*/
            return Raw.UnlockRegion(libOffset, cb, dwLockType);
        }

        #endregion
        #region Stat

        public tagSTATSTG Stat(int grfStatFlag)
        {
            tagSTATSTG pstatstg;
            TryStat(out pstatstg, grfStatFlag).ThrowOnNotOK();

            return pstatstg;
        }

        public HRESULT TryStat(out tagSTATSTG pstatstg, int grfStatFlag)
        {
            /*HRESULT Stat([Out] out tagSTATSTG pstatstg, [In] int grfStatFlag);*/
            return Raw.Stat(out pstatstg, grfStatFlag);
        }

        #endregion
        #region Clone

        public Stream Clone()
        {
            Stream ppstmResult;
            TryClone(out ppstmResult).ThrowOnNotOK();

            return ppstmResult;
        }

        public HRESULT TryClone(out Stream ppstmResult)
        {
            /*HRESULT Clone([Out, MarshalAs(UnmanagedType.Interface)] out IStream ppstm);*/
            IStream ppstm;
            HRESULT hr = Raw.Clone(out ppstm);

            if (hr == HRESULT.S_OK)
                ppstmResult = new Stream(ppstm);
            else
                ppstmResult = default(Stream);

            return hr;
        }

        #endregion
        #endregion
    }
}