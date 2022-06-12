using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedCorDebug
{
    public abstract class SequentialStream : ComObject<ISequentialStream>
    {
        public static SequentialStream New(ISequentialStream value)
        {
            if (value is IStream)
                return new Stream((IStream) value);

            throw new NotImplementedException("Encountered an ISequentialStream' interface of an unknown type. Cannot create wrapper type.");
        }

        protected SequentialStream(ISequentialStream raw) : base(raw)
        {
        }

        #region ISequentialStream
        #region RemoteRead

        public RemoteReadResult RemoteRead(int cb)
        {
            HRESULT hr;
            RemoteReadResult result;

            if ((hr = TryRemoteRead(cb, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryRemoteRead(int cb, out RemoteReadResult result)
        {
            /*HRESULT RemoteRead(out byte pv, [In] int cb, out int pcbRead);*/
            byte pv;
            int pcbRead;
            HRESULT hr = Raw.RemoteRead(out pv, cb, out pcbRead);

            if (hr == HRESULT.S_OK)
                result = new RemoteReadResult(pv, pcbRead);
            else
                result = default(RemoteReadResult);

            return hr;
        }

        #endregion
        #region RemoteWrite

        public int RemoteWrite(IntPtr pv, int cb)
        {
            HRESULT hr;
            int pcbWritten;

            if ((hr = TryRemoteWrite(pv, cb, out pcbWritten)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pcbWritten;
        }

        public HRESULT TryRemoteWrite(IntPtr pv, int cb, out int pcbWritten)
        {
            /*HRESULT RemoteWrite([In] IntPtr pv, [In] int cb, out int pcbWritten);*/
            return Raw.RemoteWrite(pv, cb, out pcbWritten);
        }

        #endregion
        #endregion
    }
}