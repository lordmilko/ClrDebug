using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An (<see cref="IDebugHostSymbol"/> derived) interface to a base class.
    /// </summary>
    public class DebugHostBaseClass : DebugHostSymbol
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostBaseClass"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostBaseClass(IDebugHostBaseClass raw) : base(raw)
        {
        }

        #region IDebugHostBaseClass

        public new IDebugHostBaseClass Raw => (IDebugHostBaseClass) base.Raw;

        #region Offset

        /// <summary>
        /// The GetOffset method returns the offset of the base class from the base address of the derived class. Such offset may be zero or may be a positive unsigned 64-bit value.
        /// </summary>
        public long Offset
        {
            get
            {
                long offset;
                TryGetOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
        }

        /// <summary>
        /// The GetOffset method returns the offset of the base class from the base address of the derived class. Such offset may be zero or may be a positive unsigned 64-bit value.
        /// </summary>
        /// <param name="offset">The offset of the base class from the base address of the derived class is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetOffset(out long offset)
        {
            /*HRESULT GetOffset(
            [Out] out long offset);*/
            return Raw.GetOffset(out offset);
        }

        #endregion
        #endregion
        #region IDebugHostBaseClass2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public new IDebugHostBaseClass2 Raw2 => (IDebugHostBaseClass2) Raw;

        #region IsVirtual

        public bool IsVirtual
        {
            get
            {
                bool pIsVirtual;
                TryIsVirtual(out pIsVirtual).ThrowDbgEngNotOK();

                return pIsVirtual;
            }
        }

        public HRESULT TryIsVirtual(out bool pIsVirtual)
        {
            /*HRESULT IsVirtual(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsVirtual);*/
            return Raw2.IsVirtual(out pIsVirtual);
        }

        #endregion
        #region VirtualBaseOffsetLocation

        public GetVirtualBaseOffsetLocationResult VirtualBaseOffsetLocation
        {
            get
            {
                GetVirtualBaseOffsetLocationResult result;
                TryGetVirtualBaseOffsetLocation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetVirtualBaseOffsetLocation(out GetVirtualBaseOffsetLocationResult result)
        {
            /*HRESULT GetVirtualBaseOffsetLocation(
            [Out] out long pTableOffset,
            [Out] out long pSlotOffset,
            [Out] out long pSlotSize,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pSlotIsSigned);*/
            long pTableOffset;
            long pSlotOffset;
            long pSlotSize;
            bool pSlotIsSigned;
            HRESULT hr = Raw2.GetVirtualBaseOffsetLocation(out pTableOffset, out pSlotOffset, out pSlotSize, out pSlotIsSigned);

            if (hr == HRESULT.S_OK)
                result = new GetVirtualBaseOffsetLocationResult(pTableOffset, pSlotOffset, pSlotSize, pSlotIsSigned);
            else
                result = default(GetVirtualBaseOffsetLocationResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
