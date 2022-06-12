using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedCorDebug
{
    public class Stream : SequentialStream
    {
        public Stream(IStream raw) : base(raw)
        {
        }

        #region IStream

        public new IStream Raw => (IStream) base.Raw;

        #region RemoteSeek

        public ULARGE_INTEGER RemoteSeek(LARGE_INTEGER dlibMove, int dwOrigin)
        {
            HRESULT hr;
            ULARGE_INTEGER plibNewPosition;

            if ((hr = TryRemoteSeek(dlibMove, dwOrigin, out plibNewPosition)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return plibNewPosition;
        }

        public HRESULT TryRemoteSeek(LARGE_INTEGER dlibMove, int dwOrigin, out ULARGE_INTEGER plibNewPosition)
        {
            /*HRESULT RemoteSeek([In] LARGE_INTEGER dlibMove, [In] int dwOrigin, out ULARGE_INTEGER plibNewPosition);*/
            return Raw.RemoteSeek(dlibMove, dwOrigin, out plibNewPosition);
        }

        #endregion
        #region SetSize

        public void SetSize(ULARGE_INTEGER libNewSize)
        {
            HRESULT hr;

            if ((hr = TrySetSize(libNewSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;
            RemoteCopyToResult result;

            if ((hr = TryRemoteCopyTo(pstm, cb, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryRemoteCopyTo(IStream pstm, ULARGE_INTEGER cb, out RemoteCopyToResult result)
        {
            /*HRESULT RemoteCopyTo(
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pstm,
            [In] ULARGE_INTEGER cb,
            out ULARGE_INTEGER pcbRead,
            out ULARGE_INTEGER pcbWritten);*/
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
            HRESULT hr;

            if ((hr = TryCommit(grfCommitFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryRevert()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryLockRegion(libOffset, cb, dwLockType)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryUnlockRegion(libOffset, cb, dwLockType)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;
            tagSTATSTG pstatstg;

            if ((hr = TryStat(out pstatstg, grfStatFlag)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pstatstg;
        }

        public HRESULT TryStat(out tagSTATSTG pstatstg, int grfStatFlag)
        {
            /*HRESULT Stat(out tagSTATSTG pstatstg, [In] int grfStatFlag);*/
            return Raw.Stat(out pstatstg, grfStatFlag);
        }

        #endregion
        #region Clone

        public Stream Clone()
        {
            HRESULT hr;
            Stream ppstmResult;

            if ((hr = TryClone(out ppstmResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppstmResult;
        }

        public HRESULT TryClone(out Stream ppstmResult)
        {
            /*HRESULT Clone([MarshalAs(UnmanagedType.Interface)] out IStream ppstm);*/
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