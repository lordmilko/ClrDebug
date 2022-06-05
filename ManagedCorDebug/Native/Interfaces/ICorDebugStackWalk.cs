using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
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
        /// <remarks>
        /// Because unwinding restores only a subset of the registers, such as non-volatile registers, the context may not
        /// exactly match the register state at the time of the call.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetContext(
            [In] uint contextFlags,
            [In] uint contextBufSize,
            out uint contextSize,
            out byte contextBuf);

        /// <summary>
        /// Sets the <see cref="ICorDebugStackWalk"/> object’s current context to a valid context for the thread.
        /// </summary>
        /// <param name="flag">[in] A <see cref="CorDebugSetContextFlag"/> flag that indicates whether the context is from the active frame on the stack, or a context obtained by unwinding the stack.</param>
        /// <param name="contextSize">[in] The allocated size of the CONTEXT buffer.</param>
        /// <param name="context">[in] The CONTEXT buffer.</param>
        /// <remarks>
        /// This method does not alter the current context of the thread. Setting the current context to an invalid context
        /// may cause unpredictable results from the stack walker. You can retrieve an exact bitwise copy of this context by
        /// immediately calling the <see cref="ICorDebugStackWalk.GetContext"/> method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetContext([In] CorDebugSetContextFlag flag, [In] uint contextSize, [In] ref byte context);

        /// <summary>
        /// Moves the <see cref="ICorDebugStackWalk"/> object to the next frame.
        /// </summary>
        /// <remarks>
        /// The Next method advances the ICorDebugStackWalk object to the calling frame only if the runtime can unwind the
        /// current frame. Otherwise, the object advances to the next frame that the runtime is able to unwind.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next();

        /// <summary>
        /// Gets the current frame in the <see cref="ICorDebugStackWalk"/> object.
        /// </summary>
        /// <param name="pFrame">[in] A pointer to the address of the created frame object that represents the current frame in the stack.</param>
        /// <remarks>
        /// ICorDebugStackWalk returns only actual stack frames. Use the <see cref="ICorDebugThread3.GetActiveInternalFrames"/>
        /// method to return internal frames. (Internal frames are data structures pushed onto the stack by the runtime to
        /// store temporary data.)
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFrame([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame pFrame);
    }
}