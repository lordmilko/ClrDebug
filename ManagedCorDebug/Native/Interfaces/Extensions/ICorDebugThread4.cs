using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides thread blocking information.
    /// </summary>
    /// <remarks>
    /// This interface is a logical extension of the <see cref="ICorDebugThread"/>, <see cref="ICorDebugThread2"/>, and <see cref="ICorDebugThread3"/>
    /// interfaces.
    /// </remarks>
    [Guid("1A1F204B-1C66-4637-823F-3EE6C744A69C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugThread4
    {
        /// <summary>
        /// Indicates whether the thread has ever had an unhandled exception.
        /// </summary>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as <see cref="HRESULT"/> errors that indicate method failure.
        /// 
        /// | HRESULT | Description                                                   |
        /// | ------- | ------------------------------------------------------------- |
        /// | S_OK    | The thread has had an unhandled exception since its creation. |
        /// | S_FALSE | The thread has never had an unhandled exception.              |
        /// </returns>
        /// <remarks>
        /// This method indicates whether the thread has ever had an unhandled exception. By the time the unhandled exception
        /// callback is triggered or native JIT-attach is initiated, this method is guaranteed to return S_OK. There is no
        /// guarantee that the <see cref="ICorDebugThread.GetCurrentException"/> method will return the unhandled exception; however, it
        /// will if the process has not yet been continued after getting the unhandled exception callback or upon native JIT-attach.
        /// Furthermore, it is possible (although unlikely) to have more than one thread with an unhandled exception at the
        /// time native JIT-attach is triggered. In such a case there is no way to determine which exception triggered the
        /// JIT-attach.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT HadUnhandledException();

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
        /// returns an <see cref="HRESULT"/> that indicates failure; otherwise, it returns S_OK.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetBlockingObjects(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugBlockingObjectEnum ppBlockingObjectEnum);

        /// <summary>
        /// Gets the current <see cref="ICorDebugManagedCallback3.CustomNotification"/> object on the current thread.
        /// </summary>
        /// <param name="ppNotificationObject">[out] A pointer to the current <see cref="ICorDebugManagedCallback3.CustomNotification"/> object on the current thread.</param>
        /// <remarks>
        /// The value of ppNotificationObject is null if the method is not called from within a ICorDebugManagedCallback3::CustomNotification
        /// callback, or if no current notification object exists.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCurrentCustomDebuggerNotification(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppNotificationObject);
    }
}