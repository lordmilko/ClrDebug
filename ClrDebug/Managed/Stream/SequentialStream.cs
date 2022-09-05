using System;

namespace ClrDebug
{
    public abstract class SequentialStream : ComObject<ISequentialStream>
    {
        public static SequentialStream New(ISequentialStream value)
        {
            if (value is IStream)
                return new ComStream((IStream) value);

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
        #region Read

        public int Read(IntPtr pv, int cb)
        {
            int pcbRead;
            TryRead(pv, cb, out pcbRead).ThrowOnNotOK();

            return pcbRead;
        }

        public HRESULT TryRead(IntPtr pv, int cb, out int pcbRead)
        {
            /*HRESULT Read(
            [Out] IntPtr pv,
            [In] int cb,
            [Out] out int pcbRead);*/
            return Raw.Read(pv, cb, out pcbRead);
        }

        #endregion
        #region Write

        public int Write(IntPtr pv, int cb)
        {
            int pcbWritten;
            TryWrite(pv, cb, out pcbWritten).ThrowOnNotOK();

            return pcbWritten;
        }

        public HRESULT TryWrite(IntPtr pv, int cb, out int pcbWritten)
        {
            /*HRESULT Write(
            [In] IntPtr pv,
            [In] int cb,
            [Out] out int pcbWritten);*/
            return Raw.Write(pv, cb, out pcbWritten);
        }

        #endregion
        #endregion
    }
}
