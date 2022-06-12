using System;
using System.Runtime.InteropServices;

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

            throw new NotImplementedException("Encountered an ICorDebugBreakpoint' interface of an unknown type. Cannot create wrapper type.");
        }

        protected CorDebugBreakpoint(ICorDebugBreakpoint raw) : base(raw)
        {
        }

        #region ICorDebugBreakpoint
        #region IsActive

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugBreakpoint"/> is active.
        /// </summary>
        public int IsActive
        {
            get
            {
                HRESULT hr;
                int pbActive;

                if ((hr = TryIsActive(out pbActive)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbActive;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugBreakpoint"/> is active.
        /// </summary>
        /// <param name="pbActive">[out] true if this breakpoint is active; otherwise, false.</param>
        public HRESULT TryIsActive(out int pbActive)
        {
            /*HRESULT IsActive(out int pbActive);*/
            return Raw.IsActive(out pbActive);
        }

        #endregion
        #region Activate

        /// <summary>
        /// Sets the active state of this <see cref="ICorDebugBreakpoint"/>.
        /// </summary>
        /// <param name="bActive">[in] Set this value to true to specify the state as active; otherwise, set this value to false.</param>
        public void Activate(int bActive)
        {
            HRESULT hr;

            if ((hr = TryActivate(bActive)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Sets the active state of this <see cref="ICorDebugBreakpoint"/>.
        /// </summary>
        /// <param name="bActive">[in] Set this value to true to specify the state as active; otherwise, set this value to false.</param>
        public HRESULT TryActivate(int bActive)
        {
            /*HRESULT Activate([In] int bActive);*/
            return Raw.Activate(bActive);
        }

        #endregion
        #endregion
    }
}