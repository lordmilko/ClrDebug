using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace ManagedCorDebug
{
    /// <summary>
    /// Exposes the monitor lock properties of objects. This interface extends the <see cref="ICorDebugHeapValue"/> and <see cref="ICorDebugHeapValue2"/> interfaces.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A69ACAD8-2374-46E9-9FF8-B1F14120D296")]
    [ComImport]
    public interface ICorDebugHeapValue3
    {
        /// <summary>
        /// Returns the managed thread that owns the monitor lock on this object.
        /// </summary>
        /// <param name="ppThread">[out] The managed thread that owns the monitor lock on this object.</param>
        /// <param name="pAcquisitionCount">[out] The number of times this thread would have to release the lock before it returns to being unowned.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                                             |
        /// | ------- | ------------------------------------------------------- |
        /// | S_OK    | The method completed successfully.                      |
        /// | S_FALSE | No managed thread owns the monitor lock on this object. |
        /// </returns>
        /// <remarks>
        /// If a managed thread owns the monitor lock on this object: If no managed thread owns the monitor lock on this object,
        /// ppThread and pAcquisitionCount are unchanged, and the method returns S_FALSE. If ppThread or pAcquisitionCount
        /// is not a valid pointer, the result is undefined. If an error occurs such that it cannot be determined which, if
        /// any, thread owns the monitor lock on this object, the method returns an <see cref="HRESULT"/> that indicates failure.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThreadOwningMonitorLock([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread,
            out int pAcquisitionCount);

        /// <summary>
        /// Provides an ordered list of threads that are queued on the event that is associated with a monitor lock.
        /// </summary>
        /// <param name="ppThreadEnum">[out] The <see cref="ICorDebugThreadEnum"/> enumerator that provides the ordered list of threads.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description            |
        /// | ------- | ---------------------- |
        /// | S_OK    | The list is not empty. |
        /// | S_FALSE | The list is empty.     |
        /// </returns>
        /// <remarks>
        /// The first thread in the list is the first thread that is released by the next call to <see cref="Monitor.Pulse(System.Object)"/>.
        /// The next thread in the list is released on the following call, and so on. If the list is not empty, this method
        /// returns S_OK. If the list is empty, the method returns S_FALSE; in this case, the enumeration is still valid, although
        /// it is empty. In either case, the enumeration interface is usable only for the duration of the current synchronized
        /// state. However, the thread's interfaces dispensed from it are valid until the thread exits. If ppThreadEnum is
        /// not a valid pointer, the result is undefined. If an error occurs such that it cannot be determined which, if any,
        /// threads are waiting for the monitor, the method returns an <see cref="HRESULT"/> that indicates failure.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMonitorEventWaitList([MarshalAs(UnmanagedType.Interface)] out ICorDebugThreadEnum ppThreadEnum);
    }
}