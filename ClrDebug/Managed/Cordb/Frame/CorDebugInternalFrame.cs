using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Represents a runtime-internal frame on the stack. This interface is a subclass of the <see cref="ICorDebugFrame"/> interface.
    /// </summary>
    public class CorDebugInternalFrame : CorDebugFrame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugInternalFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugInternalFrame(ICorDebugInternalFrame raw) : base(raw)
        {
        }

        #region ICorDebugInternalFrame

        public new ICorDebugInternalFrame Raw => (ICorDebugInternalFrame) base.Raw;

        #region FrameType

        /// <summary>
        /// Gets the type of this internal frame.
        /// </summary>
        public CorDebugInternalFrameType FrameType
        {
            get
            {
                CorDebugInternalFrameType pType;
                TryGetFrameType(out pType).ThrowOnNotOK();

                return pType;
            }
        }

        /// <summary>
        /// Gets the type of this internal frame.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the <see cref="CorDebugInternalFrameType"/> enumeration that indicates the type of internal frame represented by this <see cref="ICorDebugInternalFrame"/> object.</param>
        /// <remarks>
        /// The internal frame type will never be STUBFRAME_NONE. Debuggers should gracefully ignore unrecognized internal
        /// frame types.
        /// </remarks>
        public HRESULT TryGetFrameType(out CorDebugInternalFrameType pType)
        {
            /*HRESULT GetFrameType(
            [Out] out CorDebugInternalFrameType pType);*/
            return Raw.GetFrameType(out pType);
        }

        #endregion
        #endregion
        #region ICorDebugInternalFrame2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugInternalFrame2 Raw2 => (ICorDebugInternalFrame2) Raw;

        #region Address

        /// <summary>
        /// Returns the stack address of the internal frame.
        /// </summary>
        public CORDB_ADDRESS Address
        {
            get
            {
                CORDB_ADDRESS pAddress;
                TryGetAddress(out pAddress).ThrowOnNotOK();

                return pAddress;
            }
        }

        /// <summary>
        /// Returns the stack address of the internal frame.
        /// </summary>
        /// <param name="pAddress">[out] Pointer to the <see cref="CORDB_ADDRESS"/> for the internal frame.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as <see cref="HRESULT"/> errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                                                  |
        /// | ------------ | ------------------------------------------------------------ |
        /// | S_OK         | The address of the internal frame was successfully returned. |
        /// | E_FAIL       | The address of the internal frame could not be returned.     |
        /// | E_INVALIDARG | pAddress is null.                                            |
        /// </returns>
        /// <remarks>
        /// The value returned in pAddress can be used to determine the location of the internal frame relative to other frames
        /// on the stack. Even on IA-64-based computers, the internal frame lives on the stack only, and there is no corresponding
        /// pointer to a backing store.
        /// </remarks>
        public HRESULT TryGetAddress(out CORDB_ADDRESS pAddress)
        {
            /*HRESULT GetAddress(
            [Out] out CORDB_ADDRESS pAddress);*/
            return Raw2.GetAddress(out pAddress);
        }

        #endregion
        #region IsCloserToLeaf

        /// <summary>
        /// Checks whether the this internal frame is closer to the leaf than the specified <see cref="ICorDebugFrame"/> object.
        /// </summary>
        /// <param name="pFrameToCompare">[in] A pointer to the comparison <see cref="ICorDebugFrame"/> object.</param>
        /// <returns>[out] true if the this internal frame is closer to the leaf than the frame specified by pFrameToCompare; otherwise, false.</returns>
        /// <remarks>
        /// IsCloserToLeaf can be used to implement a policy for interleaving internal frames with other frames on the stack.
        /// </remarks>
        public int IsCloserToLeaf(ICorDebugFrame pFrameToCompare)
        {
            int pIsCloser;
            TryIsCloserToLeaf(pFrameToCompare, out pIsCloser).ThrowOnNotOK();

            return pIsCloser;
        }

        /// <summary>
        /// Checks whether the this internal frame is closer to the leaf than the specified <see cref="ICorDebugFrame"/> object.
        /// </summary>
        /// <param name="pFrameToCompare">[in] A pointer to the comparison <see cref="ICorDebugFrame"/> object.</param>
        /// <param name="pIsCloser">[out] true if the this internal frame is closer to the leaf than the frame specified by pFrameToCompare; otherwise, false.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                                |
        /// | ------------ | ------------------------------------------ |
        /// | S_OK         | The comparison was successfully performed. |
        /// | E_FAIL       | The comparison could not be performed.     |
        /// | E_INVALIDARG | pFrameToCompare or pIsCloser is null.      |
        /// </returns>
        /// <remarks>
        /// IsCloserToLeaf can be used to implement a policy for interleaving internal frames with other frames on the stack.
        /// </remarks>
        public HRESULT TryIsCloserToLeaf(ICorDebugFrame pFrameToCompare, out int pIsCloser)
        {
            /*HRESULT IsCloserToLeaf(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugFrame pFrameToCompare,
            [Out] out int pIsCloser);*/
            return Raw2.IsCloserToLeaf(pFrameToCompare, out pIsCloser);
        }

        #endregion
        #endregion
    }
}
