using System;

namespace ClrDebug
{
    /// <summary>
    /// Defines the base interface from which all <see cref="ICorDebug"/> debug events derive.
    /// </summary>
    /// <remarks>
    /// The following interfaces are derived from the <see cref="ICorDebugDebugEvent"/> interface:
    /// </remarks>
    public abstract class CorDebugDebugEvent : ComObject<ICorDebugDebugEvent>
    {
        public static CorDebugDebugEvent New(ICorDebugDebugEvent value)
        {
            if (value == null)
                return null;

            if (value is ICorDebugExceptionDebugEvent)
                return new CorDebugExceptionDebugEvent((ICorDebugExceptionDebugEvent) value);

            if (value is ICorDebugModuleDebugEvent)
                return new CorDebugModuleDebugEvent((ICorDebugModuleDebugEvent) value);

            throw new NotImplementedException("Encountered an 'ICorDebugDebugEvent' interface of an unknown type. Cannot create wrapper type.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugDebugEvent"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        protected CorDebugDebugEvent(ICorDebugDebugEvent raw) : base(raw)
        {
        }

        #region ICorDebugDebugEvent
        #region EventKind

        /// <summary>
        /// Indicates what kind of event this <see cref="ICorDebugDebugEvent"/> object represents.
        /// </summary>
        public CorDebugDebugEventKind EventKind
        {
            get
            {
                CorDebugDebugEventKind pDebugEventKind;
                TryGetEventKind(out pDebugEventKind).ThrowOnNotOK();

                return pDebugEventKind;
            }
        }

        /// <summary>
        /// Indicates what kind of event this <see cref="ICorDebugDebugEvent"/> object represents.
        /// </summary>
        /// <param name="pDebugEventKind">A pointer to a <see cref="CorDebugDebugEventKind"/> enumeration member that indicates the type of event.</param>
        /// <remarks>
        /// Based on the value of pDebugEventKind, you can call QueryInterface to get a more precise debug event interface
        /// that has additional data.
        /// </remarks>
        public HRESULT TryGetEventKind(out CorDebugDebugEventKind pDebugEventKind)
        {
            /*HRESULT GetEventKind(
            [Out] out CorDebugDebugEventKind pDebugEventKind);*/
            return Raw.GetEventKind(out pDebugEventKind);
        }

        #endregion
        #region Thread

        /// <summary>
        /// Gets the thread on which the event occurred.
        /// </summary>
        public CorDebugThread Thread
        {
            get
            {
                CorDebugThread ppThreadResult;
                TryGetThread(out ppThreadResult).ThrowOnNotOK();

                return ppThreadResult;
            }
        }

        /// <summary>
        /// Gets the thread on which the event occurred.
        /// </summary>
        /// <param name="ppThreadResult">[out] A pointer to the address of an <see cref="ICorDebugThread"/> object that represents the thread on which the event occurred.</param>
        public HRESULT TryGetThread(out CorDebugThread ppThreadResult)
        {
            /*HRESULT GetThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);*/
            ICorDebugThread ppThread;
            HRESULT hr = Raw.GetThread(out ppThread);

            if (hr == HRESULT.S_OK)
                ppThreadResult = ppThread == null ? null : new CorDebugThread(ppThread);
            else
                ppThreadResult = default(CorDebugThread);

            return hr;
        }

        #endregion
        #endregion
    }
}
