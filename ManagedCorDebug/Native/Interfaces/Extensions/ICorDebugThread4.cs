using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides thread blocking information.
    /// </summary>
    /// <remarks>
    /// This interface is a logical extension of the ICorDebugThread, ICorDebugThread2, and <see cref="ICorDebugThread3"/>
    /// interfaces.
    /// </remarks>
    [Guid("1A1F204B-1C66-4637-823F-3EE6C744A69C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugThread4
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT HasUnhandledException();

        /// <summary>
        /// Provides an ordered enumeration of <see cref="CorDebugBlockingObject"/> structures that provide thread blocking information.
        /// </summary>
        /// <param name="ppBlockingObjectEnum">[out] A pointer to an ordered enumeration of <see cref="CorDebugBlockingObject"/> structures.</param>
        /// <remarks>
        /// The first element in the returned enumeration corresponds to the first structure that is blocking the thread. The
        /// second element corresponds to a blocking item that is encountered while running an asynchronous procedure call
        /// (APC) when blocked on the first, and so on. The enumeration is valid only for the duration of the current synchronized
        /// state. This method must be called while the debuggee is in a synchronized state. If ppBlockingObjectEnum is not
        /// a valid pointer, the result is undefined. If a thread is blocked and the error cannot be determined, the method
        /// returns an HRESULT that indicates failure; otherwise, it returns S_OK.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetBlockingObjects(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugBlockingObjectEnum ppBlockingObjectEnum);

        /// <summary>
        /// Gets the current <see cref="ICorDebugManagedCallback3.CustomNotification"/> object on the current thread.
        /// </summary>
        /// <param name="ppNotificationObject">[out] A pointer to the current ICorDebugManagedCallback3::CustomNotification object on the current thread.</param>
        /// <remarks>
        /// The value of ppNotificationObject is null if the method is not called from within a ICorDebugManagedCallback3::CustomNotification
        /// callback, or if no current notification object exists.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCurrentCustomDebuggerNotification(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppNotificationObject);
    }
}