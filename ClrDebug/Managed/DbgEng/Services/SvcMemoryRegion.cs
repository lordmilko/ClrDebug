namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes a contiguous region of memory within an address space.
    /// </summary>
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

        /// <summary>
        /// Gets the bounds of this memory region.
        /// </summary>
        public SvcAddressRange Range
        {
            get
            {
                SvcAddressRange range;
                TryGetRange(out range).ThrowDbgEngNotOK();

                return range;
            }
        }

        /// <summary>
        /// Gets the bounds of this memory region.
        /// </summary>
        public HRESULT TryGetRange(out SvcAddressRange range)
        {
            /*HRESULT GetRange(
            [Out] out SvcAddressRange Range);*/
            return Raw.GetRange(out range);
        }

        #endregion
        #region IsReadable

        /// <summary>
        /// Indicates whether this region of memory is readable. If the implementation cannot make a determination of whether the range is readable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        public bool IsReadable
        {
            get
            {
                bool isReadable;
                TryIsReadable(out isReadable).ThrowDbgEngNotOK();

                return isReadable;
            }
        }

        /// <summary>
        /// Indicates whether this region of memory is readable. If the implementation cannot make a determination of whether the range is readable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        public HRESULT TryIsReadable(out bool isReadable)
        {
            /*HRESULT IsReadable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsReadable);*/
            return Raw.IsReadable(out isReadable);
        }

        #endregion
        #region IsWriteable

        /// <summary>
        /// Indicates whether this region of memory is writeable. If the implementation cannot make a determination of whether the range is writeable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        public bool IsWriteable
        {
            get
            {
                bool isWriteable;
                TryIsWriteable(out isWriteable).ThrowDbgEngNotOK();

                return isWriteable;
            }
        }

        /// <summary>
        /// Indicates whether this region of memory is writeable. If the implementation cannot make a determination of whether the range is writeable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        public HRESULT TryIsWriteable(out bool isWriteable)
        {
            /*HRESULT IsWriteable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsWriteable);*/
            return Raw.IsWriteable(out isWriteable);
        }

        #endregion
        #region IsExecutable

        /// <summary>
        /// Indicates whether this region of memory is executable. If the implementation cannot make a determination of whether the range is executable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        public bool IsExecutable
        {
            get
            {
                bool isExecutable;
                TryIsExecutable(out isExecutable).ThrowDbgEngNotOK();

                return isExecutable;
            }
        }

        /// <summary>
        /// Indicates whether this region of memory is executable. If the implementation cannot make a determination of whether the range is executable or not, E_NOTIMPL may legally be returned.
        /// </summary>
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
