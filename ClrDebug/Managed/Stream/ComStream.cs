namespace ClrDebug
{
    public class ComStream : SequentialStream
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComStream"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ComStream(IStream raw) : base(raw)
        {
        }

        #region IStream

        public new IStream Raw => (IStream) base.Raw;

        #region Seek

        public ULARGE_INTEGER Seek(LARGE_INTEGER dlibMove, int dwOrigin)
        {
            ULARGE_INTEGER plibNewPosition;
            TrySeek(dlibMove, dwOrigin, out plibNewPosition).ThrowOnNotOK();

            return plibNewPosition;
        }

        public HRESULT TrySeek(LARGE_INTEGER dlibMove, int dwOrigin, out ULARGE_INTEGER plibNewPosition)
        {
            /*HRESULT Seek(
            [In] LARGE_INTEGER dlibMove,
            [In] int dwOrigin,
            [Out] out ULARGE_INTEGER plibNewPosition);*/
            return Raw.Seek(dlibMove, dwOrigin, out plibNewPosition);
        }

        #endregion
        #region SetSize

        public void SetSize(ULARGE_INTEGER libNewSize)
        {
            TrySetSize(libNewSize).ThrowOnNotOK();
        }

        public HRESULT TrySetSize(ULARGE_INTEGER libNewSize)
        {
            /*HRESULT SetSize(
            [In] ULARGE_INTEGER libNewSize);*/
            return Raw.SetSize(libNewSize);
        }

        #endregion
        #region CopyTo

        public CopyToResult CopyTo(IStream pstm, ULARGE_INTEGER cb)
        {
            CopyToResult result;
            TryCopyTo(pstm, cb, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryCopyTo(IStream pstm, ULARGE_INTEGER cb, out CopyToResult result)
        {
            /*HRESULT CopyTo(
            [MarshalAs(UnmanagedType.Interface), In] IStream pstm,
            [In] ULARGE_INTEGER cb,
            [Out] out ULARGE_INTEGER pcbRead,
            [Out] out ULARGE_INTEGER pcbWritten);*/
            ULARGE_INTEGER pcbRead;
            ULARGE_INTEGER pcbWritten;
            HRESULT hr = Raw.CopyTo(pstm, cb, out pcbRead, out pcbWritten);

            if (hr == HRESULT.S_OK)
                result = new CopyToResult(pcbRead, pcbWritten);
            else
                result = default(CopyToResult);

            return hr;
        }

        #endregion
        #region Commit

        public void Commit(STGC grfCommitFlags)
        {
            TryCommit(grfCommitFlags).ThrowOnNotOK();
        }

        public HRESULT TryCommit(STGC grfCommitFlags)
        {
            /*HRESULT Commit(
            [In] STGC grfCommitFlags);*/
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
            /*HRESULT LockRegion(
            [In] ULARGE_INTEGER libOffset,
            [In] ULARGE_INTEGER cb,
            [In] int dwLockType);*/
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
            /*HRESULT UnlockRegion(
            [In] ULARGE_INTEGER libOffset,
            [In] ULARGE_INTEGER cb,
            [In] int dwLockType);*/
            return Raw.UnlockRegion(libOffset, cb, dwLockType);
        }

        #endregion
        #region Stat

        public tagSTATSTG Stat(STATFLAG grfStatFlag)
        {
            tagSTATSTG pstatstg;
            TryStat(out pstatstg, grfStatFlag).ThrowOnNotOK();

            return pstatstg;
        }

        public HRESULT TryStat(out tagSTATSTG pstatstg, STATFLAG grfStatFlag)
        {
            /*HRESULT Stat(
            [Out] out tagSTATSTG pstatstg,
            [In] STATFLAG grfStatFlag);*/
            return Raw.Stat(out pstatstg, grfStatFlag);
        }

        #endregion
        #region Clone

        public ComStream Clone()
        {
            ComStream ppstmResult;
            TryClone(out ppstmResult).ThrowOnNotOK();

            return ppstmResult;
        }

        public HRESULT TryClone(out ComStream ppstmResult)
        {
            /*HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IStream ppstm);*/
            IStream ppstm;
            HRESULT hr = Raw.Clone(out ppstm);

            if (hr == HRESULT.S_OK)
                ppstmResult = new ComStream(ppstm);
            else
                ppstmResult = default(ComStream);

            return hr;
        }

        #endregion
        #endregion
    }
}
