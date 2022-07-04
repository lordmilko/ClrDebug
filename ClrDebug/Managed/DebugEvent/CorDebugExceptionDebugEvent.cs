namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugDebugEvent"/> interface to support exception events.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugExceptionDebugEvent"/> interface is implemented by the following event types:
    /// </remarks>
    public class CorDebugExceptionDebugEvent : CorDebugDebugEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugExceptionDebugEvent"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugExceptionDebugEvent(ICorDebugExceptionDebugEvent raw) : base(raw)
        {
        }

        #region ICorDebugExceptionDebugEvent

        public new ICorDebugExceptionDebugEvent Raw => (ICorDebugExceptionDebugEvent) base.Raw;

        #region StackPointer

        /// <summary>
        /// Gets the stack pointer for this exception debug event.
        /// </summary>
        public CORDB_ADDRESS StackPointer
        {
            get
            {
                CORDB_ADDRESS pStackPointer;
                TryGetStackPointer(out pStackPointer).ThrowOnNotOK();

                return pStackPointer;
            }
        }

        /// <summary>
        /// Gets the stack pointer for this exception debug event.
        /// </summary>
        /// <param name="pStackPointer">[out] A pointer to the address of the stack pointer for this exception debug event. See the Remarks section for more information.</param>
        /// <remarks>
        /// The meaning of this stack pointer depends on the event type, as shown in the following table. The event type is
        /// available from the <see cref="CorDebugDebugEvent.EventKind"/> property.
        /// </remarks>
        public HRESULT TryGetStackPointer(out CORDB_ADDRESS pStackPointer)
        {
            /*HRESULT GetStackPointer([Out] out CORDB_ADDRESS pStackPointer);*/
            return Raw.GetStackPointer(out pStackPointer);
        }

        #endregion
        #region NativeIP

        /// <summary>
        /// Gets the native instruction pointer for this exception debug event.
        /// </summary>
        public CORDB_ADDRESS NativeIP
        {
            get
            {
                CORDB_ADDRESS pIP;
                TryGetNativeIP(out pIP).ThrowOnNotOK();

                return pIP;
            }
        }

        /// <summary>
        /// Gets the native instruction pointer for this exception debug event.
        /// </summary>
        /// <param name="pIP">[out] A pointer to the instruction pointer for this exception debug event. See the Remarks section for more information.</param>
        /// <remarks>
        /// The meaning of this instruction pointer depends on the event type, as shown in the following table. The event type
        /// is available from the <see cref="CorDebugDebugEvent.EventKind"/> property.
        /// </remarks>
        public HRESULT TryGetNativeIP(out CORDB_ADDRESS pIP)
        {
            /*HRESULT GetNativeIP([Out] out CORDB_ADDRESS pIP);*/
            return Raw.GetNativeIP(out pIP);
        }

        #endregion
        #region Flags

        /// <summary>
        /// Gets a flag that indicates whether the exception can be intercepted.
        /// </summary>
        public CorDebugExceptionFlags Flags
        {
            get
            {
                CorDebugExceptionFlags pdwFlags;
                TryGetFlags(out pdwFlags).ThrowOnNotOK();

                return pdwFlags;
            }
        }

        /// <summary>
        /// Gets a flag that indicates whether the exception can be intercepted.
        /// </summary>
        /// <param name="pdwFlags">[out] A pointer to a <see cref="CorDebugExceptionFlags"/> value that indicates whether the exception can be intercepted.</param>
        public HRESULT TryGetFlags(out CorDebugExceptionFlags pdwFlags)
        {
            /*HRESULT GetFlags([Out] out CorDebugExceptionFlags pdwFlags);*/
            return Raw.GetFlags(out pdwFlags);
        }

        #endregion
        #endregion
    }
}
