﻿using System;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to help in stack unwinding.
    /// </summary>
    /// <remarks>
    /// The members of the <see cref="ICorDebugVirtualUnwinder"/> interface are implemented by the debugger to help in stack unwinding.
    /// </remarks>
    public class CorDebugVirtualUnwinder : ComObject<ICorDebugVirtualUnwinder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugVirtualUnwinder"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugVirtualUnwinder(ICorDebugVirtualUnwinder raw) : base(raw)
        {
        }

        #region ICorDebugVirtualUnwinder
        #region GetContext

        /// <summary>
        /// Gets the current context of this unwinder.
        /// </summary>
        /// <param name="contextFlags">[in] Flags that specify which parts of the context to return (defined in WinNT.h).</param>
        /// <param name="cbContextBuf">[in] The number of bytes in contextBuf.</param>
        /// <param name="contextBuf">[out] A byte array that contains the current context of this unwinder.</param>
        /// <returns>[out] A pointer to the number of bytes actually written to contextBuf.</returns>
        /// <remarks>
        /// You set the initial value of the contextBuf argument to the context buffer returned by calling the <see cref="CorDebugStackWalk.GetContext"/>
        /// method. Because unwinding may only restore a subset of the registers, such as the non-volatile registers only,
        /// the context may not exactly match the register state at the time of the actual method call.
        /// </remarks>
        public int GetContext(ContextFlags contextFlags, int cbContextBuf, IntPtr contextBuf)
        {
            int contextSize;
            TryGetContext(contextFlags, cbContextBuf, out contextSize, contextBuf).ThrowOnNotOK();

            return contextSize;
        }

        /// <summary>
        /// Gets the current context of this unwinder.
        /// </summary>
        /// <param name="contextFlags">[in] Flags that specify which parts of the context to return (defined in WinNT.h).</param>
        /// <param name="cbContextBuf">[in] The number of bytes in contextBuf.</param>
        /// <param name="contextSize">[out] A pointer to the number of bytes actually written to contextBuf.</param>
        /// <param name="contextBuf">[out] A byte array that contains the current context of this unwinder.</param>
        /// <returns>Any failing <see cref="HRESULT"/> value received by mscordbi is considered fatal and will cause <see cref="ICorDebug"/> APIs to return CORDBG_E_DATA_TARGET_ERROR.</returns>
        /// <remarks>
        /// You set the initial value of the contextBuf argument to the context buffer returned by calling the <see cref="CorDebugStackWalk.GetContext"/>
        /// method. Because unwinding may only restore a subset of the registers, such as the non-volatile registers only,
        /// the context may not exactly match the register state at the time of the actual method call.
        /// </remarks>
        public HRESULT TryGetContext(ContextFlags contextFlags, int cbContextBuf, out int contextSize, IntPtr contextBuf)
        {
            /*HRESULT GetContext(
            [In] ContextFlags contextFlags,
            [In] int cbContextBuf,
            [Out] out int contextSize,
            [Out] IntPtr contextBuf);*/
            return Raw.GetContext(contextFlags, cbContextBuf, out contextSize, contextBuf);
        }

        #endregion
        #region Next

        /// <summary>
        /// Advances to the caller's context.
        /// </summary>
        /// <remarks>
        /// The stack walker should ensure that it makes forward progress, so that eventually a call to Next will return a
        /// failing <see cref="HRESULT"/> or CORDBG_S_AT_END_OF_STACK. Returning S_OK indefinitely may cause an infinite loop.
        /// </remarks>
        public void Next()
        {
            TryNext().ThrowOnNotOK();
        }

        /// <summary>
        /// Advances to the caller's context.
        /// </summary>
        /// <returns>S_OK if the unwind occurred successfully, or CORDBG_S_AT_END_OF_STACK if the unwind cannot be completed because there are no more frames.<para/>
        /// If a failing <see cref="HRESULT"/> is returned, <see cref="ICorDebug"/> APIs will return CORDBG_E_DATA_TARGET_ERROR.</returns>
        /// <remarks>
        /// The stack walker should ensure that it makes forward progress, so that eventually a call to Next will return a
        /// failing <see cref="HRESULT"/> or CORDBG_S_AT_END_OF_STACK. Returning S_OK indefinitely may cause an infinite loop.
        /// </remarks>
        public HRESULT TryNext()
        {
            /*HRESULT Next();*/
            return Raw.Next();
        }

        #endregion
        #endregion
    }
}
