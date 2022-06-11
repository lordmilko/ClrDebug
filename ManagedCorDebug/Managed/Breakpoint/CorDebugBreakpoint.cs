using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
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

        public HRESULT TryIsActive(out int pbActive)
        {
            /*HRESULT IsActive(out int pbActive);*/
            return Raw.IsActive(out pbActive);
        }

        #endregion
        #region Activate

        public void Activate(int bActive)
        {
            HRESULT hr;

            if ((hr = TryActivate(bActive)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryActivate(int bActive)
        {
            /*HRESULT Activate([In] int bActive);*/
            return Raw.Activate(bActive);
        }

        #endregion
        #endregion
    }
}