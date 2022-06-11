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

        public RemoteReadResult RemoteRead(uint cb)
        {
            HRESULT hr;
            RemoteReadResult result;

            if ((hr = TryRemoteRead(cb, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryRemoteRead(uint cb, out RemoteReadResult result)
        {
            /*HRESULT RemoteRead(out byte pv, [In] uint cb, out uint pcbRead);*/
            byte pv;
            uint pcbRead;
            HRESULT hr = Raw.RemoteRead(out pv, cb, out pcbRead);

            if (hr == HRESULT.S_OK)
                result = new RemoteReadResult(pv, pcbRead);
            else
                result = default(RemoteReadResult);

            return hr;
        }

        #endregion
        #region RemoteWrite

        public uint RemoteWrite(IntPtr pv, uint cb)
        {
            HRESULT hr;
            uint pcbWritten;

            if ((hr = TryRemoteWrite(pv, cb, out pcbWritten)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pcbWritten;
        }

        public HRESULT TryRemoteWrite(IntPtr pv, uint cb, out uint pcbWritten)
        {
            /*HRESULT RemoteWrite([In] IntPtr pv, [In] uint cb, out uint pcbWritten);*/
            return Raw.RemoteWrite(pv, cb, out pcbWritten);
        }

        #endregion
        #endregion
    }
}