using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    //MSF_HB
    //Retrieve via mspdbcore!MSFOpenW, MSFOpenExW.
    //Doesn't seem to be a way to get the MSF from a PDB1
    public unsafe class MSF : IDisposable
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private MSFVtbl* vtbl;

        #region QueryInterfaceVersion

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate MSFIntv QueryInterfaceVersionDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryInterfaceVersionDelegate queryInterfaceVersion;

        public MSFIntv InterfaceVersion
        {
            get
            {
                InitDelegate(ref queryInterfaceVersion, vtbl->QueryInterfaceVersion);

                return queryInterfaceVersion(Raw);
            }
        }

        #endregion
        #region QueryImplementationVersion

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate MSFImpv QueryImplementationVersionDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryImplementationVersionDelegate queryImplementationVersion;

        public MSFImpv ImplementationVersion
        {
            get
            {
                InitDelegate(ref queryImplementationVersion, vtbl->QueryImplementationVersion);

                return queryImplementationVersion(Raw);
            }
        }

        #endregion
        #region GetCbPage

        //Returns MSFParms.cbPg which should also be the page size set in your BIGMSF_HDR

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate int GetCbPageDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCbPageDelegate getCbPage;

        public int CbPage
        {
            get
            {
                InitDelegate(ref getCbPage, vtbl->GetCbPage);

                return getCbPage(Raw);
            }
        }

        #endregion
        #region GetCbStream

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate int GetCbStreamDelegate(
            [In] IntPtr @this,
            [In] int sn);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCbStreamDelegate getCbStream;

        public int GetCbStream(int sn)
        {
            InitDelegate(ref getCbStream, vtbl->GetCbStream);

            return getCbStream(Raw, sn);
        }

        #endregion
        #region GetFreeSn

        //Returns StrmTbl.snMinFree()

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate int GetFreeSnDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFreeSnDelegate getFreeSn;

        //Allocates the next free SN
        public int GetFreeSn()
        {
            InitDelegate(ref getFreeSn, vtbl->GetFreeSn);

            return getFreeSn(Raw);
        }

        #endregion
        #region ReplaceStream

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool ReplaceStreamDelegate(
            [In] IntPtr @this,
            [In] int sn,
            [In] IntPtr pvBuf,
            [In] int cbBuf);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReplaceStreamDelegate replaceStream;

        public void ReplaceStream(int sn, IntPtr pvBuf, int cbBuf)
        {
            InitDelegate(ref replaceStream, vtbl->ReplaceStream);

            if (!replaceStream(Raw, sn, pvBuf, cbBuf))
                throw new NotImplementedException();
        }

        #endregion
        #region AppendStream

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AppendStreamDelegate(
            [In] IntPtr @this,
            [In] int sn,
            [In] IntPtr pvBuf,
            [In] int cbBuf);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AppendStreamDelegate appendStream;

        public void AppendStream(int sn, IntPtr pvBuf, int cbBuf)
        {
            //AppendStream2 is the overload with fewer args
            InitDelegate(ref appendStream, vtbl->AppendStream2);

            if (!appendStream(Raw, sn, pvBuf, cbBuf))
                throw new NotImplementedException();
        }

        #endregion
        #region Commit

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool CommitDelegate(
            [In] IntPtr @this,
            [Out] out MSF_EC pec);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CommitDelegate commit;

        public void Commit()
        {
            InitDelegate(ref commit, vtbl->Commit);

            if (!commit(Raw, out var pec))
                throw new NotImplementedException();

            if (pec != MSF_EC.MSF_EC_OK)
                throw new NotImplementedException();
        }

        #endregion
        #region Close

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool CloseDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CloseDelegate close;

        public void Close()
        {
            InitDelegate(ref close, vtbl->Close);

            if (!close(Raw))
                throw new NotImplementedException();
        }

        #endregion

        public MSF(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(MSFVtbl**) raw;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
