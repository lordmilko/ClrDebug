using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides the entry point to the <see cref="ICorDebugStackWalk"/> and corresponding interfaces.
    /// </summary>
    /// <remarks>
    /// ICorDebugThread3 is a logical extension to the ICorDebugThread interface.
    /// </remarks>
    [Guid("F8544EC3-5E4E-46C7-8D3E-A52B8405B1F5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugThread3
    {
        /// <summary>
        /// Creates an <see cref="ICorDebugStackWalk"/> object for the thread whose stack you want to unwind.
        /// </summary>
        /// <param name="ppStackWalk">[out] A pointer to address of the <see cref="ICorDebugStackWalk"/> object for the thread whose stack you want to unwind.</param>
        /// <remarks>
        /// If the CreateStackWalk method succeeds, the returned ICorDebugStackWalk object's context is set to the thread's
        /// current context.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateStackWalk([MarshalAs(UnmanagedType.Interface)] out ICorDebugStackWalk ppStackWalk);

        /// <summary>
        /// Returns an array of internal frames (<see cref="ICorDebugInternalFrame2"/> objects) on the stack.
        /// </summary>
        /// <param name="cInternalFrames">[in] The number of internal frames expected in ppInternalFrames.</param>
        /// <param name="pcInternalFrames">[out] A pointer to a ULONG32 that contains the number of internal frames on the stack.</param>
        /// <param name="ppInternalFrames">[in, out] A pointer to the address of an array of internal frames on the stack.</param>
        /// <remarks>
        /// Internal frames are data structures pushed onto the stack by the runtime to store temporary data. When you first
        /// call GetActiveInternalFrames, you should set the cInternalFrames parameter to 0 (zero), and the ppInternalFrames
        /// parameter to null. When GetActiveInternalFrames first returns, pcInternalFrames contains the count of the internal
        /// frames on the stack. GetActiveInternalFrames should then be called a second time. You should pass the proper count
        /// (pcInternalFrames) in the cInternalFrames parameter, and specify a pointer to an appropriately sized array in ppInternalFrames.
        /// Use the <see cref="ICorDebugThread3.GetActiveInternalFrames"/> method to return actual stack frames.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetActiveInternalFrames(
            [In] uint cInternalFrames,
            out uint pcInternalFrames,
            [In, Out] IntPtr ppInternalFrames); //ICorDebugInternalFrame2
    }
}