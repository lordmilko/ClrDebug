using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugBreakpoint"/> interface to support breakpoints within functions.
    /// </summary>
    public class CorDebugFunctionBreakpoint : CorDebugBreakpoint
    {
        public CorDebugFunctionBreakpoint(ICorDebugFunctionBreakpoint raw) : base(raw)
        {
        }

        #region ICorDebugFunctionBreakpoint

        public new ICorDebugFunctionBreakpoint Raw => (ICorDebugFunctionBreakpoint) base.Raw;

        #region GetFunction

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugFunction"/> that references the function in which the breakpoint is set.
        /// </summary>
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

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugFunction"/> that references the function in which the breakpoint is set.
        /// </summary>
        /// <param name="ppFunctionResult">[out] A pointer to the address of the function in which the breakpoint is set.</param>
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

        /// <summary>
        /// Gets the offset of the breakpoint within the function.
        /// </summary>
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

        /// <summary>
        /// Gets the offset of the breakpoint within the function.
        /// </summary>
        /// <param name="pnOffset">[out] A pointer to the offset of the breakpoint.</param>
        public HRESULT TryGetOffset(out uint pnOffset)
        {
            /*HRESULT GetOffset(out uint pnOffset);*/
            return Raw.GetOffset(out pnOffset);
        }

        #endregion
        #endregion
    }
}