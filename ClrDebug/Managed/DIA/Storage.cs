using System;
using ClrDebug;

namespace ClrDebug.DIA
{
    public class Storage : ComObject<IStorage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Storage"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public Storage(IStorage raw) : base(raw)
        {
        }

        #region IStorage
        #region CreateStream

        public ComStream CreateStream(string pwcsName, int grfMode, int reserved1, int reserved2)
        {
            ComStream ppstmResult;
            TryCreateStream(pwcsName, grfMode, reserved1, reserved2, out ppstmResult).ThrowOnNotOK();

            return ppstmResult;
        }

        public HRESULT TryCreateStream(string pwcsName, int grfMode, int reserved1, int reserved2, out ComStream ppstmResult)
        {
            /*HRESULT CreateStream(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName,
            [In] int grfMode,
            [In] int reserved1,
            [In] int reserved2,
            [Out, MarshalAs(UnmanagedType.Interface)] out IStream ppstm);*/
            IStream ppstm;
            HRESULT hr = Raw.CreateStream(pwcsName, grfMode, reserved1, reserved2, out ppstm);

            if (hr == HRESULT.S_OK)
                ppstmResult = new ComStream(ppstm);
            else
                ppstmResult = default(ComStream);

            return hr;
        }

        #endregion
        #region OpenStream

        public ComStream OpenStream(string pwcsName, IntPtr reserved1, int grfMode, int reserved2)
        {
            ComStream ppstmResult;
            TryOpenStream(pwcsName, reserved1, grfMode, reserved2, out ppstmResult).ThrowOnNotOK();

            return ppstmResult;
        }

        public HRESULT TryOpenStream(string pwcsName, IntPtr reserved1, int grfMode, int reserved2, out ComStream ppstmResult)
        {
            /*HRESULT OpenStream(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName,
            [In] IntPtr reserved1,
            [In] int grfMode,
            [In] int reserved2,
            [Out, MarshalAs(UnmanagedType.Interface)] out IStream ppstm);*/
            IStream ppstm;
            HRESULT hr = Raw.OpenStream(pwcsName, reserved1, grfMode, reserved2, out ppstm);

            if (hr == HRESULT.S_OK)
                ppstmResult = new ComStream(ppstm);
            else
                ppstmResult = default(ComStream);

            return hr;
        }

        #endregion
        #region CreateStorage

        public Storage CreateStorage(string pwcsName, int grfMode, int reserved1, int reserved2)
        {
            Storage ppstgResult;
            TryCreateStorage(pwcsName, grfMode, reserved1, reserved2, out ppstgResult).ThrowOnNotOK();

            return ppstgResult;
        }

        public HRESULT TryCreateStorage(string pwcsName, int grfMode, int reserved1, int reserved2, out Storage ppstgResult)
        {
            /*HRESULT CreateStorage(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName,
            [In] int grfMode,
            [In] int reserved1,
            [In] int reserved2,
            [Out, MarshalAs(UnmanagedType.Interface)] out IStorage ppstg);*/
            IStorage ppstg;
            HRESULT hr = Raw.CreateStorage(pwcsName, grfMode, reserved1, reserved2, out ppstg);

            if (hr == HRESULT.S_OK)
                ppstgResult = new Storage(ppstg);
            else
                ppstgResult = default(Storage);

            return hr;
        }

        #endregion
        #region OpenStorage

        public Storage OpenStorage(string pwcsName, IStorage pstgPriority, int grfMode, IntPtr snbExclude, int reserved)
        {
            Storage ppstgResult;
            TryOpenStorage(pwcsName, pstgPriority, grfMode, snbExclude, reserved, out ppstgResult).ThrowOnNotOK();

            return ppstgResult;
        }

        public HRESULT TryOpenStorage(string pwcsName, IStorage pstgPriority, int grfMode, IntPtr snbExclude, int reserved, out Storage ppstgResult)
        {
            /*HRESULT OpenStorage(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName,
            [MarshalAs(UnmanagedType.Interface), In] IStorage pstgPriority,
            [In] int grfMode,
            [In] IntPtr snbExclude, //Original type is SNB which is a LPOLESTR* (despite confusing spacing in objidl.h)
            [In] int reserved,
            [Out, MarshalAs(UnmanagedType.Interface)] out IStorage ppstg);*/
            IStorage ppstg;
            HRESULT hr = Raw.OpenStorage(pwcsName, pstgPriority, grfMode, snbExclude, reserved, out ppstg);

            if (hr == HRESULT.S_OK)
                ppstgResult = new Storage(ppstg);
            else
                ppstgResult = default(Storage);

            return hr;
        }

        #endregion
        #region CopyTo

        public void CopyTo(int ciidExclude, Guid rgiidExclude, IntPtr snbExclude, IStorage pstgDest)
        {
            TryCopyTo(ciidExclude, rgiidExclude, snbExclude, pstgDest).ThrowOnNotOK();
        }

        public HRESULT TryCopyTo(int ciidExclude, Guid rgiidExclude, IntPtr snbExclude, IStorage pstgDest)
        {
            /*HRESULT CopyTo(
            [In] int ciidExclude,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid rgiidExclude,
            [In] IntPtr snbExclude,
            [MarshalAs(UnmanagedType.Interface), In] IStorage pstgDest);*/
            return Raw.CopyTo(ciidExclude, rgiidExclude, snbExclude, pstgDest);
        }

        #endregion
        #region MoveElementTo

        public void MoveElementTo(string pwcsName, IStorage pstgDest, string pwcsNewName, int grfFlags)
        {
            TryMoveElementTo(pwcsName, pstgDest, pwcsNewName, grfFlags).ThrowOnNotOK();
        }

        public HRESULT TryMoveElementTo(string pwcsName, IStorage pstgDest, string pwcsNewName, int grfFlags)
        {
            /*HRESULT MoveElementTo(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName,
            [MarshalAs(UnmanagedType.Interface), In] IStorage pstgDest,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsNewName,
            [In] int grfFlags);*/
            return Raw.MoveElementTo(pwcsName, pstgDest, pwcsNewName, grfFlags);
        }

        #endregion
        #region Commit

        public void Commit(int grfCommitFlags)
        {
            TryCommit(grfCommitFlags).ThrowOnNotOK();
        }

        public HRESULT TryCommit(int grfCommitFlags)
        {
            /*HRESULT Commit(
            [In] int grfCommitFlags);*/
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
        #region EnumElements

        public EnumSTATSTG EnumElements(int reserved1, IntPtr reserved2, int reserved3)
        {
            EnumSTATSTG ppenumResult;
            TryEnumElements(reserved1, reserved2, reserved3, out ppenumResult).ThrowOnNotOK();

            return ppenumResult;
        }

        public HRESULT TryEnumElements(int reserved1, IntPtr reserved2, int reserved3, out EnumSTATSTG ppenumResult)
        {
            /*HRESULT EnumElements(
            [In] int reserved1,
            [In] IntPtr reserved2,
            [In] int reserved3,
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumSTATSTG ppenum);*/
            IEnumSTATSTG ppenum;
            HRESULT hr = Raw.EnumElements(reserved1, reserved2, reserved3, out ppenum);

            if (hr == HRESULT.S_OK)
                ppenumResult = new EnumSTATSTG(ppenum);
            else
                ppenumResult = default(EnumSTATSTG);

            return hr;
        }

        #endregion
        #region DestroyElement

        public void DestroyElement(string pwcsName)
        {
            TryDestroyElement(pwcsName).ThrowOnNotOK();
        }

        public HRESULT TryDestroyElement(string pwcsName)
        {
            /*HRESULT DestroyElement(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName);*/
            return Raw.DestroyElement(pwcsName);
        }

        #endregion
        #region RenameElement

        public void RenameElement(string pwcsOldName, string pwcsNewName)
        {
            TryRenameElement(pwcsOldName, pwcsNewName).ThrowOnNotOK();
        }

        public HRESULT TryRenameElement(string pwcsOldName, string pwcsNewName)
        {
            /*HRESULT RenameElement(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsOldName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsNewName);*/
            return Raw.RenameElement(pwcsOldName, pwcsNewName);
        }

        #endregion
        #region SetElementTimes

        public void SetElementTimes(string pwcsName, FILETIME pctime, FILETIME patime, FILETIME pmtime)
        {
            TrySetElementTimes(pwcsName, pctime, patime, pmtime).ThrowOnNotOK();
        }

        public HRESULT TrySetElementTimes(string pwcsName, FILETIME pctime, FILETIME patime, FILETIME pmtime)
        {
            /*HRESULT SetElementTimes(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName,
            [In] ref FILETIME pctime,
            [In] ref FILETIME patime,
            [In] ref FILETIME pmtime);*/
            return Raw.SetElementTimes(pwcsName, ref pctime, ref patime, ref pmtime);
        }

        #endregion
        #region SetClass

        public void SetClass(Guid clsid)
        {
            TrySetClass(clsid).ThrowOnNotOK();
        }

        public HRESULT TrySetClass(Guid clsid)
        {
            /*HRESULT SetClass(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid clsid);*/
            return Raw.SetClass(clsid);
        }

        #endregion
        #region SetStateBits

        public void SetStateBits(int grfStateBits, int grfMask)
        {
            TrySetStateBits(grfStateBits, grfMask).ThrowOnNotOK();
        }

        public HRESULT TrySetStateBits(int grfStateBits, int grfMask)
        {
            /*HRESULT SetStateBits(
            [In] int grfStateBits,
            [In] int grfMask);*/
            return Raw.SetStateBits(grfStateBits, grfMask);
        }

        #endregion
        #region Stat

        public STATSTG Stat(int grfStatFlag)
        {
            STATSTG pstatstg;
            TryStat(out pstatstg, grfStatFlag).ThrowOnNotOK();

            return pstatstg;
        }

        public HRESULT TryStat(out STATSTG pstatstg, int grfStatFlag)
        {
            /*HRESULT Stat(
            [Out] out STATSTG pstatstg,
            [In] int grfStatFlag);*/
            return Raw.Stat(out pstatstg, grfStatFlag);
        }

        #endregion
        #endregion
    }
}
