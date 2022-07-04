using System;

namespace ClrDebug
{
    public abstract class SequentialStream : ComObject<ISequentialStream>
    {
        public static SequentialStream New(ISequentialStream value)
        {
            if (value is IStream)
                return new Stream((IStream) value);

            throw new NotImplementedException("Encountered an 'ISequentialStream' interface of an unknown type. Cannot create wrapper type.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialStream"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        protected SequentialStream(ISequentialStream raw) : base(raw)
        {
        }

        #region ISequentialStream
        #region RemoteRead

        public int RemoteRead(IntPtr pv, int cb)
        {
            int pcbRead;
            TryRemoteRead(pv, cb, out pcbRead).ThrowOnNotOK();

            return pcbRead;
        }

        public HRESULT TryRemoteRead(IntPtr pv, int cb, out int pcbRead)
        {
            /*HRESULT RemoteRead([Out] IntPtr pv, [In] int cb, [Out] out int pcbRead);*/
            return Raw.RemoteRead(pv, cb, out pcbRead);
        }

        #endregion
        #region RemoteWrite

        public int RemoteWrite(IntPtr pv, int cb)
        {
            int pcbWritten;
            TryRemoteWrite(pv, cb, out pcbWritten).ThrowOnNotOK();

            return pcbWritten;
        }

        public HRESULT TryRemoteWrite(IntPtr pv, int cb, out int pcbWritten)
        {
            /*HRESULT RemoteWrite([In] IntPtr pv, [In] int cb, [Out] out int pcbWritten);*/
            return Raw.RemoteWrite(pv, cb, out pcbWritten);
        }

        #endregion
        #endregion
    }
}
