namespace ClrDebug
{
    /// <summary>
    /// A subclass of <see cref="ICorDebugReferenceValue"/> that represents a reference value to which the debugger has created a handle for garbage collection.
    /// </summary>
    /// <remarks>
    /// An <see cref="ICorDebugReferenceValue"/> object is invalidated by a break in the execution of debugged code. An <see cref="ICorDebugHandleValue"/>
    /// maintains its reference through breaks and continuations, until it is explicitly released.
    /// </remarks>
    public class CorDebugHandleValue : CorDebugReferenceValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugHandleValue"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugHandleValue(ICorDebugHandleValue raw) : base(raw)
        {
        }

        #region ICorDebugHandleValue

        public new ICorDebugHandleValue Raw => (ICorDebugHandleValue) base.Raw;

        #region HandleType

        /// <summary>
        /// Gets a value that indicates the kind of handle referenced by this <see cref="ICorDebugHandleValue"/> object.
        /// </summary>
        public CorDebugHandleType HandleType
        {
            get
            {
                CorDebugHandleType pType;
                TryGetHandleType(out pType).ThrowOnNotOK();

                return pType;
            }
        }

        /// <summary>
        /// Gets a value that indicates the kind of handle referenced by this <see cref="ICorDebugHandleValue"/> object.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the <see cref="CorDebugHandleType"/> enumeration that indicates the type of this handle.</param>
        public HRESULT TryGetHandleType(out CorDebugHandleType pType)
        {
            /*HRESULT GetHandleType(
            [Out] out CorDebugHandleType pType);*/
            return Raw.GetHandleType(out pType);
        }

        #endregion
        #region Dispose

        /// <summary>
        /// Releases the handle referenced by this <see cref="ICorDebugHandleValue"/> object without explicitly releasing the interface pointer.
        /// </summary>
        public void Dispose()
        {
            TryDispose().ThrowOnNotOK();
        }

        /// <summary>
        /// Releases the handle referenced by this <see cref="ICorDebugHandleValue"/> object without explicitly releasing the interface pointer.
        /// </summary>
        public HRESULT TryDispose()
        {
            /*HRESULT Dispose();*/
            return Raw.Dispose();
        }

        #endregion
        #endregion
    }
}
