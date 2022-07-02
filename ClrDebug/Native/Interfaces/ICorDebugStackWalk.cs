using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for getting the managed methods, or frames, on a thread’s stack.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A0647DE9-55DE-4816-929C-385271C64CF7")]
    [ComImport]
    public interface ICorDebugStackWalk
    {
        /// <summary>
        /// Returns the context for the current frame in the <see cref="ICorDebugStackWalk"/> object.
        /// </summary>
        /// <param name="contextFlags">[in] Flags that indicate the requested contents of the context buffer (defined in WinNT.h).</param>
        /// <param name="contextBufSize">[in] The allocated size of the context buffer.</param>
        /// <param name="contextSize">[out] The actual size of the context. This value must be less than or equal to the size of the context buffer.</param>
        /// <param name="contextBuf">[out] The context buffer.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                                       | Description                                                                                            |
        /// | --------------------------------------------- | ------------------------------------------------------------------------------------------------------ |
        /// | S_OK                                          | The context for the current frame was successfully returned.                                           |
        /// | E_FAIL                                        | The context could not be returned.                                                                     |
        /// | HRESULT_FROM_WIN32(ERROR_INSUFFICIENT BUFFER) | The context buffer is too small.                                                                       |
        /// | CORDBG_E_PAST_END_OF_STACK                    | The frame pointer is already at the end of the stack; therefore, no additional frames can be accessed. |
        /// </returns>
        /// <remarks>
        /// Because unwinding restores only a subset of the registers, such as non-volatile registers, the context may not
        /// exactly match the register state at the time of the call.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetContext(
            [In] int contextFlags,
            [In] int contextBufSize,
            [Out] out int contextSize,
            [Out] IntPtr contextBuf);

        /// <summary>
        /// Sets the <see cref="ICorDebugStackWalk"/> object’s current context to a valid context for the thread.
        /// </summary>
        /// <param name="flag">[in] A <see cref="CorDebugSetContextFlag"/> flag that indicates whether the context is from the active frame on the stack, or a context obtained by unwinding the stack.</param>
        /// <param name="contextSize">[in] The allocated size of the CONTEXT buffer.</param>
        /// <param name="context">[in] The CONTEXT buffer.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                                       | Description                                                   |
        /// | --------------------------------------------- | ------------------------------------------------------------- |
        /// | S_OK                                          | The ICorDebugStackWalk object's context was successfully set. |
        /// | E_FAIL                                        | The ICorDebugStackWalk object's context was not set.          |
        /// | E_INVALIDARG                                  | The context is null.                                          |
        /// | HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) | The context buffer is too small.                              |
        /// </returns>
        /// <remarks>
        /// This method does not alter the current context of the thread. Setting the current context to an invalid context
        /// may cause unpredictable results from the stack walker. You can retrieve an exact bitwise copy of this context by
        /// immediately calling the <see cref="GetContext"/> method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetContext([In] CorDebugSetContextFlag flag, [In] int contextSize, [In] IntPtr context);

        /// <summary>
        /// Moves the <see cref="ICorDebugStackWalk"/> object to the next frame.
        /// </summary>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                    | Description                                                                                            |
        /// | -------------------------- | ------------------------------------------------------------------------------------------------------ |
        /// | S_OK                       | The runtime successfully unwound to the next frame (see Remarks).                                      |
        /// | E_FAIL                     | The ICorDebugStackWalk object could not be advanced.                                                   |
        /// | CORDBG_S_AT_END_OF_STACK   | The end of the stack was reached as a result of this unwind.                                           |
        /// | CORDBG_E_PAST_END_OF_STACK | The frame pointer is already at the end of the stack; therefore, no additional frames can be accessed. |
        /// </returns>
        /// <remarks>
        /// The Next method advances the <see cref="ICorDebugStackWalk"/> object to the calling frame only if the runtime can unwind the
        /// current frame. Otherwise, the object advances to the next frame that the runtime is able to unwind.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next();

        /// <summary>
        /// Gets the current frame in the <see cref="ICorDebugStackWalk"/> object.
        /// </summary>
        /// <param name="pFrame">[in] A pointer to the address of the created frame object that represents the current frame in the stack.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                    | Description                                                                                            |
        /// | -------------------------- | ------------------------------------------------------------------------------------------------------ |
        /// | S_OK                       | The runtime successfully returned the current frame.                                                   |
        /// | E_FAIL                     | The current frame was not returned.                                                                    |
        /// | S_FALSE                    | The current frame is a native stack frame.                                                             |
        /// | E_INVALIDARG               | pFrame is null.                                                                                        |
        /// | CORDBG_E_PAST_END_OF_STACK | The frame pointer is already at the end of the stack; therefore, no additional frames can be accessed. |
        /// </returns>
        /// <remarks>
        /// <see cref="ICorDebugStackWalk"/> returns only actual stack frames. Use the <see cref="ICorDebugThread3.GetActiveInternalFrames"/>
        /// method to return internal frames. (Internal frames are data structures pushed onto the stack by the runtime to
        /// store temporary data.)
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFrame([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame pFrame);
    }
}