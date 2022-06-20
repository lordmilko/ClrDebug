using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a breakpoint in a function, or a watch point on a value.
    /// </summary>
    /// <remarks>
    /// Breakpoints do not directly support conditional expressions. If such functionality is desired, a debugger must
    /// implement it on top of <see cref="ICorDebugBreakpoint"/>. The <see cref="ICorDebugFunctionBreakpoint"/> interface extends <see cref="ICorDebugBreakpoint"/>
    /// to support breakpoints within functions.
    /// </remarks>
    public abstract class CorDebugBreakpoint : ComObject<ICorDebugBreakpoint>
    {
        public static CorDebugBreakpoint New(ICorDebugBreakpoint value)
        {
            if (value is ICorDebugFunctionBreakpoint)
                return new CorDebugFunctionBreakpoint((ICorDebugFunctionBreakpoint) value);

            if (value is ICorDebugModuleBreakpoint)
                return new CorDebugModuleBreakpoint((ICorDebugModuleBreakpoint) value);

            if (value is ICorDebugValueBreakpoint)
                return new CorDebugValueBreakpoint((ICorDebugValueBreakpoint) value);

            throw new NotImplementedException("Encountered an 'ICorDebugBreakpoint' interface of an unknown type. Cannot create wrapper type.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugBreakpoint"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        protected CorDebugBreakpoint(ICorDebugBreakpoint raw) : base(raw)
        {
        }

        #region ICorDebugBreakpoint
        #region IsActive

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugBreakpoint"/> is active.
        /// </summary>
        public bool IsActive
        {
            get
            {
                bool pbActive;
                TryIsActive(out pbActive).ThrowOnNotOK();

                return pbActive;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugBreakpoint"/> is active.
        /// </summary>
        /// <param name="pbActive">[out] true if this breakpoint is active; otherwise, false.</param>
        public HRESULT TryIsActive(out bool pbActive)
        {
            /*HRESULT IsActive([Out] out bool pbActive);*/
            return Raw.IsActive(out pbActive);
        }

        #endregion
        #region Activate

        /// <summary>
        /// Sets the active state of this <see cref="ICorDebugBreakpoint"/>.
        /// </summary>
        /// <param name="bActive">[in] Set this value to true to specify the state as active; otherwise, set this value to false.</param>
        public void Activate(bool bActive)
        {
            TryActivate(bActive).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the active state of this <see cref="ICorDebugBreakpoint"/>.
        /// </summary>
        /// <param name="bActive">[in] Set this value to true to specify the state as active; otherwise, set this value to false.</param>
        public HRESULT TryActivate(bool bActive)
        {
            /*HRESULT Activate([In] bool bActive);*/
            return Raw.Activate(bActive);
        }

        #endregion
        #endregion
    }
}