namespace ClrDebug.DbgEng
{
    public class SvcMemoryRegion : ComObject<ISvcMemoryRegion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcMemoryRegion"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcMemoryRegion(ISvcMemoryRegion raw) : base(raw)
        {
        }

        #region ISvcMemoryRegion
        #region Range

        public SvcAddressRange Range
        {
            get
            {
                SvcAddressRange range;
                TryGetRange(out range).ThrowDbgEngNotOK();

                return range;
            }
        }

        public HRESULT TryGetRange(out SvcAddressRange range)
        {
            /*HRESULT GetRange(
            [Out] out SvcAddressRange Range);*/
            return Raw.GetRange(out range);
        }

        #endregion
        #region IsReadable

        public bool IsReadable
        {
            get
            {
                bool isReadable;
                TryIsReadable(out isReadable).ThrowDbgEngNotOK();

                return isReadable;
            }
        }

        public HRESULT TryIsReadable(out bool isReadable)
        {
            /*HRESULT IsReadable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsReadable);*/
            return Raw.IsReadable(out isReadable);
        }

        #endregion
        #region IsWriteable

        public bool IsWriteable
        {
            get
            {
                bool isWriteable;
                TryIsWriteable(out isWriteable).ThrowDbgEngNotOK();

                return isWriteable;
            }
        }

        public HRESULT TryIsWriteable(out bool isWriteable)
        {
            /*HRESULT IsWriteable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsWriteable);*/
            return Raw.IsWriteable(out isWriteable);
        }

        #endregion
        #region IsExecutable

        public bool IsExecutable
        {
            get
            {
                bool isExecutable;
                TryIsExecutable(out isExecutable).ThrowDbgEngNotOK();

                return isExecutable;
            }
        }

        public HRESULT TryIsExecutable(out bool isExecutable)
        {
            /*HRESULT IsExecutable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsExecutable);*/
            return Raw.IsExecutable(out isExecutable);
        }

        #endregion
        #endregion
    }
}
