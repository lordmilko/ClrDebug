using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    public unsafe class Stream : IDisposable
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private StreamVtbl* vtbl;

        public Stream(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(StreamVtbl**) raw;
        }

        #region QueryCb

        //virtual long QueryCb() pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate int QueryCbDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryCbDelegate queryCb;

        //Relays to MSF::GetCbStream
        public int Cb
        {
            get
            {
                InitDelegate(ref queryCb, vtbl->QueryCb);

                return queryCb(Raw);
            }
        }

        #endregion
        #region Read

        //virtual BOOL Read(long off, void* pvBuf, long* pcbBuf) pure;

        //Relays to MSF::ReadStream

        #endregion
        #region Write

        //virtual BOOL Write(long off, void* pvBuf, long cbBuf) pure;

        //Relays to MSF::WriteStream.
        //Checks that the region you're writing to is within GetCbStream

        #endregion
        #region Replace

        //virtual BOOL Replace(void* pvBuf, long cbBuf) pure;

        //Relays to MSF::ReplaceStream

        #endregion
        #region Append

        //virtual BOOL Append(void* pvBuf, long cbBuf) pure;

        //Relays to MSF::AppendStream

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AppendDelegate(
            [In] IntPtr @this,
            [In] IntPtr pvBuf,
            [In] int cbBuf);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AppendDelegate append;

        public void Append(IntPtr pvBuf, int cbBuf)
        {
            InitDelegate(ref append, vtbl->Append);

            if (!append(Raw, pvBuf, cbBuf))
                throw new NotImplementedException();
        }

        #endregion
        #region Delete

        //virtual BOOL Delete() pure;

        #endregion
        #region Release

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool ReleaseDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReleaseDelegate release;

        public void Release()
        {
            InitDelegate(ref release, vtbl->Release);

            if (!release(Raw))
                throw new NotImplementedException();
        }

        #endregion
        #region Read2

        //virtual BOOL Read2(long off, void* pvBuf, long cbBuf) pure;

        //Relays to MSF::ReadStream and checks that cbBuf == the resulting pcbBuf from MSF::ReadStream

        #endregion
        #region Truncate

        //virtual BOOL Truncate(long cb) pure;

        //Relays to MSF::TruncateStream

        #endregion

        public void Dispose()
        {
            Release();
        }
    }
}
