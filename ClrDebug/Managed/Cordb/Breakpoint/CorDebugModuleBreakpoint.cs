namespace ClrDebug
{
    /// <summary>
    /// Provides access to specific modules. This interface is a subclass of the <see cref="ICorDebugBreakpoint"/> interface.
    /// </summary>
    public class CorDebugModuleBreakpoint : CorDebugBreakpoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugModuleBreakpoint"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugModuleBreakpoint(ICorDebugModuleBreakpoint raw) : base(raw)
        {
        }

        #region ICorDebugModuleBreakpoint

        public new ICorDebugModuleBreakpoint Raw => (ICorDebugModuleBreakpoint) base.Raw;

        #region Module

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugModule"/> that references the module in which this breakpoint is set.
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
        /// Gets an interface pointer to an <see cref="ICorDebugModule"/> that references the module in which this breakpoint is set.
        /// </summary>
        /// <param name="ppModuleResult">[out] A pointer to the address of an <see cref="ICorDebugModule"/> interface that references the module in which the breakpoint is set.</param>
        public HRESULT TryGetModule(out CorDebugModule ppModuleResult)
        {
            /*HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);*/
            ICorDebugModule ppModule;
            HRESULT hr = Raw.GetModule(out ppModule);

            if (hr == HRESULT.S_OK)
                ppModuleResult = ppModule == null ? null : new CorDebugModule(ppModule);
            else
                ppModuleResult = default(CorDebugModule);

            return hr;
        }

        #endregion
        #endregion
    }
}
