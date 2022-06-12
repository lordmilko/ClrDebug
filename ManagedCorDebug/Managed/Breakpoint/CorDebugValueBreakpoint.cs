using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugBreakpoint"/> interface to provide access to specific values.
    /// </summary>
    public class CorDebugValueBreakpoint : CorDebugBreakpoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugValueBreakpoint"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugValueBreakpoint(ICorDebugValueBreakpoint raw) : base(raw)
        {
        }

        #region ICorDebugValueBreakpoint

        public new ICorDebugValueBreakpoint Raw => (ICorDebugValueBreakpoint) base.Raw;

        #region Value

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugValue"/> object that represents the value of the object on which the breakpoint is set.
        /// </summary>
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

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugValue"/> object that represents the value of the object on which the breakpoint is set.
        /// </summary>
        /// <param name="ppValueResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object.</param>
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