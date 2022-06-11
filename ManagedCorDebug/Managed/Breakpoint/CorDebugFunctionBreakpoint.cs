using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugFunctionBreakpoint : CorDebugBreakpoint
    {
        public CorDebugFunctionBreakpoint(ICorDebugFunctionBreakpoint raw) : base(raw)
        {
        }

        #region ICorDebugFunctionBreakpoint

        public new ICorDebugFunctionBreakpoint Raw => (ICorDebugFunctionBreakpoint) base.Raw;

        #region GetFunction

        public CorDebugFunction Function
        {
            get
            {
                HRESULT hr;
                CorDebugFunction ppFunctionResult;

                if ((hr = TryGetFunction(out ppFunctionResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppFunctionResult;
            }
        }

        public HRESULT TryGetFunction(out CorDebugFunction ppFunctionResult)
        {
            /*HRESULT GetFunction([MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);*/
            ICorDebugFunction ppFunction;
            HRESULT hr = Raw.GetFunction(out ppFunction);

            if (hr == HRESULT.S_OK)
                ppFunctionResult = new CorDebugFunction(ppFunction);
            else
                ppFunctionResult = default(CorDebugFunction);

            return hr;
        }

        #endregion
        #region GetOffset

        public uint Offset
        {
            get
            {
                HRESULT hr;
                uint pnOffset;

                if ((hr = TryGetOffset(out pnOffset)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pnOffset;
            }
        }

        public HRESULT TryGetOffset(out uint pnOffset)
        {
            /*HRESULT GetOffset(out uint pnOffset);*/
            return Raw.GetOffset(out pnOffset);
        }

        #endregion
        #endregion
    }
}