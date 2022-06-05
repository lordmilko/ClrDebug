using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Exposes the monitor lock properties of objects. This interface extends the ICorDebugHeapValue and ICorDebugHeapValue2 interfaces.
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
        /// <remarks>
        /// If a managed thread owns the monitor lock on this object: If no managed thread owns the monitor lock on this object,
        /// ppThread and pAcquisitionCount are unchanged, and the method returns S_FALSE. If ppThread or pAcquisitionCount
        /// is not a valid pointer, the result is undefined. If an error occurs such that it cannot be determined which, if
        /// any, thread owns the monitor lock on this object, the method returns an HRESULT that indicates failure.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThreadOwningMonitorLock([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread,
            out uint pAcquisitionCount);

        /// <summary>
        /// Provides an ordered list of threads that are queued on the event that is associated with a monitor lock.
        /// </summary>
        /// <param name="ppThreadEnum">[out] The ICorDebugThreadEnum enumerator that provides the ordered list of threads.</param>
        /// <remarks>
        /// The first thread in the list is the first thread that is released by the next call to System.Threading.Monitor.Pulse(System.Object).
        /// The next thread in the list is released on the following call, and so on. If the list is not empty, this method
        /// returns S_OK. If the list is empty, the method returns S_FALSE; in this case, the enumeration is still valid, although
        /// it is empty. In either case, the enumeration interface is usable only for the duration of the current synchronized
        /// state. However, the thread's interfaces dispensed from it are valid until the thread exits. If ppThreadEnum is
        /// not a valid pointer, the result is undefined. If an error occurs such that it cannot be determined which, if any,
        /// threads are waiting for the monitor, the method returns an HRESULT that indicates failure.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMonitorEventWaitList([MarshalAs(UnmanagedType.Interface)] out ICorDebugThreadEnum ppThreadEnum);
    }
}