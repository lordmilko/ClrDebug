using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugValueBreakpoint : CorDebugBreakpoint
    {
        public CorDebugValueBreakpoint(ICorDebugValueBreakpoint raw) : base(raw)
        {
        }

        #region ICorDebugValueBreakpoint

        public new ICorDebugValueBreakpoint Raw => (ICorDebugValueBreakpoint) base.Raw;

        #region GetValue

        public CorDebugValue Value
        {
            get
            {
                HRESULT hr;
                CorDebugValue ppValueResult;

                if ((hr = TryGetValue(out ppValueResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppValueResult;
            }
        }

        public HRESULT TryGetValue(out CorDebugValue ppValueResult)
        {
            /*HRESULT GetValue([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetValue(out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
    }
}