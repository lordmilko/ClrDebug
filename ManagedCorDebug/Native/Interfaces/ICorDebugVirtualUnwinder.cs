using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to help in stack unwinding.
    /// </summary>
    /// <remarks>
    /// The members of the <see cref="ICorDebugVirtualUnwinder"/> interface are implemented by the debugger to help in stack unwinding.
    /// </remarks>
    [Guid("F69126B7-C787-4F6B-AE96-A569786FC670")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugVirtualUnwinder
    {
        /// <summary>
        /// Gets the current context of this unwinder.
        /// </summary>
        /// <param name="contextFlags">[in] Flags that specify which parts of the context to return (defined in WinNT.h).</param>
        /// <param name="cbContextBuf">[in] The number of bytes in contextBuf.</param>
        /// <param name="contextSize">[out] A pointer to the number of bytes actually written to contextBuf.</param>
        /// <param name="contextBuf">[out] A byte array that contains the current context of this unwinder.</param>
        /// <returns>Any failing <see cref="HRESULT"/> value received by mscordbi is considered fatal and will cause <see cref="ICorDebug"/> APIs to return CORDBG_E_DATA_TARGET_ERROR.</returns>
        /// <remarks>
        /// You set the initial value of the contextBuf argument to the context buffer returned by calling the <see cref="ICorDebugStackWalk.GetContext"/>
        /// method. Because unwinding may only restore a subset of the registers, such as the non-volatile registers only,
        /// the context may not exactly match the register state at the time of the actual method call.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetContext(
            [In] int contextFlags,
            [In] int cbContextBuf,
            out int contextSize,
            out byte contextBuf);

        /// <summary>
        /// Advances to the caller's context.
        /// </summary>
        /// <returns>S_OK if the unwind occurred successfully, or CORDBG_S_AT_END_OF_STACK if the unwind cannot be completed because there are no more frames.<para/>
        /// If a failing <see cref="HRESULT"/> is returned, <see cref="ICorDebug"/> APIs will return CORDBG_E_DATA_TARGET_ERROR.</returns>
        /// <remarks>
        /// The stack walker should ensure that it makes forward progress, so that eventually a call to Next will return a
        /// failing <see cref="HRESULT"/> or CORDBG_S_AT_END_OF_STACK. Returning S_OK indefinitely may cause an infinite loop.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next();
    }
}