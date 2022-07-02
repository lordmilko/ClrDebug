namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugDebugEvent"/> interface to support module-level events.
    /// </summary>
    /// <remarks>
    /// The <see cref="CorDebugDebugEventKind.DEBUG_EVENT_KIND_MODULE_LOADED"/> and <see cref="CorDebugDebugEventKind.DEBUG_EVENT_KIND_MODULE_UNLOADED"/>
    /// event types implement this interface.
    /// </remarks>
    public class CorDebugModuleDebugEvent : CorDebugDebugEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugModuleDebugEvent"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugModuleDebugEvent(ICorDebugModuleDebugEvent raw) : base(raw)
        {
        }

        #region ICorDebugModuleDebugEvent

        public new ICorDebugModuleDebugEvent Raw => (ICorDebugModuleDebugEvent) base.Raw;

        #region Module

        /// <summary>
        /// Gets the merged module that was just loaded or unloaded.
        /// </summary>
        public CorDebugModule Module
        {
            get
            {
                CorDebugModule ppModuleResult;
                TryGetModule(out ppModuleResult).ThrowOnNotOK();

                return ppModuleResult;
            }
        }

        /// <summary>
        /// Gets the merged module that was just loaded or unloaded.
        /// </summary>
        /// <param name="ppModuleResult">[out] A pointer to the address of an <see cref="ICorDebugModule"/> object that represents the merged module that was just loaded or unloaded.</param>
        /// <remarks>
        /// You can call the <see cref="CorDebugDebugEvent.EventKind"/> property to determine whether the module was loaded
        /// or unloaded.
        /// </remarks>
        public HRESULT TryGetModule(out CorDebugModule ppModuleResult)
        {
            /*HRESULT GetModule([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);*/
            ICorDebugModule ppModule;
            HRESULT hr = Raw.GetModule(out ppModule);

            if (hr == HRESULT.S_OK)
                ppModuleResult = new CorDebugModule(ppModule);
            else
                ppModuleResult = default(CorDebugModule);

            return hr;
        }

        #endregion
        #endregion
    }
}