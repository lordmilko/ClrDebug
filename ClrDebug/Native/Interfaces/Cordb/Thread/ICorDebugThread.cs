using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Represents a thread in a process. The lifetime of an <see cref="ICorDebugThread"/> instance is the same as the lifetime of the thread it represents.
    /// </summary>
    [Guid("938C6D66-7FB6-4F69-B389-425B8987329B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugThread
    {
        /// <summary>
        /// Gets an interface pointer to the process of which this <see cref="ICorDebugThread"/> forms a part.
        /// </summary>
        /// <param name="ppProcess">[out] A pointer to the address of an <see cref="ICorDebugProcess"/> interface object that represents the process.</param>
        [PreserveSig]
        HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        /// <summary>
        /// Gets the current operating system identifier of the active part of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <param name="pdwThreadId">[out] The identifier of the thread.</param>
        /// <remarks>
        /// The operating system identifier can potentially change during execution of a process, and can be a different value
        /// for different parts of the thread.
        /// </remarks>
        [PreserveSig]
        HRESULT GetID(
            [Out] out int pdwThreadId);

        /// <summary>
        /// Gets the current handle for the active part of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <param name="phThreadHandle">[out] A pointer to an HTHREAD that is the handle of the active part of this thread.</param>
        /// <remarks>
        /// The handle may change as the process executes, and may be different for different parts of the thread. This handle
        /// is owned by the debugging API. The debugger should duplicate it before using it.
        /// </remarks>
        [PreserveSig]
        HRESULT GetHandle(
            [Out] out IntPtr phThreadHandle);

        /// <summary>
        /// Gets an interface pointer to the application domain in which this <see cref="ICorDebugThread"/> is currently executing.
        /// </summary>
        /// <param name="ppAppDomain">[out] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which this thread is currently executing.</param>
        [PreserveSig]
        HRESULT GetAppDomain(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugAppDomain ppAppDomain);

        /// <summary>
        /// Sets flags that describe the debugging state of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <param name="state">[in] A bitwise combination of <see cref="CorDebugThreadState"/> enumeration values that specify the debugging state of this thread.</param>
        /// <remarks>
        /// SetDebugState sets the current debug state of the thread. (The "current debug state" represents the debug state
        /// if the process were to be continued, not the actual current state.) The normal value for this is THREAD_RUN. Only
        /// the debugger can affect the debug state of a thread. Debug states do last across continues, so if you want to keep
        /// a thread THREAD_SUSPENDed over multiple continues, you can set it once and thereafter not have to worry about it.
        /// Suspending threads and resuming the process can cause deadlocks, though it's usually unlikely. This is an intrinsic
        /// quality of threads and processes and is by-design. A debugger can asynchronously break and resume the threads to
        /// break the deadlock. If the thread's user state includes USER_UNSAFE_POINT, then the thread may block a garbage
        /// collection (GC). This means the suspended thread has a much higher chance of causing a deadlock. This may not affect
        /// debug events already queued. Thus a debugger should drain the entire event queue (by calling <see cref="ICorDebugController.HasQueuedCallbacks"/>)
        /// before suspending or resuming threads. Else it may get events on a thread that it believes it has already suspended.
        /// </remarks>
        [PreserveSig]
        HRESULT SetDebugState(
            [In] CorDebugThreadState state);

        /// <summary>
        /// Gets the current debug state of this <see cref="ICorDebugThread"/> object.
        /// </summary>
        /// <param name="pState">[out] A pointer to a bitwise combination of <see cref="CorDebugThreadState"/> enumeration values that describes the current debug state of this thread.</param>
        /// <remarks>
        /// If the process is currently stopped, pState represents the debug state that would exist for this thread if the
        /// process were to be continued, not the actual current state of this thread.
        /// </remarks>
        [PreserveSig]
        HRESULT GetDebugState(
            [Out] out CorDebugThreadState pState);

        /// <summary>
        /// Gets the current user state of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <param name="pState">[out] A pointer to a bitwise combination of <see cref="CorDebugUserState"/> enumeration values that describe the current user state of this thread.</param>
        /// <remarks>
        /// The user state of the thread is the state of the thread when it is examined by the program that is being debugged.
        /// A thread may have multiple state bits set.
        /// </remarks>
        [PreserveSig]
        HRESULT GetUserState(
            [Out] out CorDebugUserState pState);

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugValue"/> object that represents an exception that is currently being thrown by managed code.
        /// </summary>
        /// <param name="ppExceptionObject">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the exception that is currently being thrown by managed code.</param>
        /// <remarks>
        /// The exception object will exist from the time the exception is thrown until the end of the catch block. A function
        /// evaluation, which is performed by the <see cref="ICorDebugEval"/> methods, will clear out the exception object on setup and restore
        /// it on completion. Exceptions can be nested (for example, if an exception is thrown in a filter or in a function
        /// evaluation), so there may be multiple outstanding exceptions on a single thread. GetCurrentException returns the
        /// most current exception. The exception object and type may change throughout the life of the exception. For example,
        /// after an exception of type x is thrown, the common language runtime (CLR) may run out of memory and promote it
        /// to an out-of-memory exception.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentException(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppExceptionObject);

        /// <summary>
        /// This method is not implemented. Do not use it.
        /// </summary>
        [PreserveSig]
        HRESULT ClearCurrentException();

        /// <summary>
        /// Creates an <see cref="ICorDebugStepper"/> object that allows stepping through the active frame of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <param name="ppStepper">[out] A pointer to the address of an <see cref="ICorDebugStepper"/> object that allows stepping through the active frame of this thread.</param>
        /// <remarks>
        /// The active frame may be unmanaged code. The <see cref="ICorDebugStepper"/> interface must be used to perform the actual stepping.
        /// </remarks>
        [PreserveSig]
        HRESULT CreateStepper(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugStepper ppStepper);

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugChainEnum"/> enumerator that contains all the stack chains in this <see cref="ICorDebugThread"/> object.
        /// </summary>
        /// <param name="ppChains">[out] A pointer to the address of an <see cref="ICorDebugChainEnum"/> object that allows enumeration of all the stack chains in this thread, starting at the active (that is, the most recent) chain.</param>
        /// <remarks>
        /// The stack chain represents the physical call stack for the thread. The following circumstances create a stack chain
        /// boundary: In the simple case for a thread that is running purely managed code in a single context, a one-to-one
        /// correspondence will exist between threads and stack chains. A debugger may want to rearrange the physical call
        /// stacks of all threads into logical call stacks. This would involve sorting all the threads' chains by their caller/callee
        /// relationships and regrouping them.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumerateChains(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugChainEnum ppChains);

        /// <summary>
        /// Gets an interface pointer to the active (most recent) stack chain on this <see cref="ICorDebugThread"/> object.
        /// </summary>
        /// <param name="ppChain">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the stack chain.</param>
        /// <remarks>
        /// The ppChain parameter is null if no stack chain is currently active.
        /// </remarks>
        [PreserveSig]
        HRESULT GetActiveChain(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);

        /// <summary>
        /// Gets an interface pointer to the active (most recent) frame on this <see cref="ICorDebugThread"/> object.
        /// </summary>
        /// <param name="ppFrame">[out] A pointer to the address of an <see cref="ICorDebugFrame"/> interface object that represents a frame.</param>
        /// <remarks>
        /// The ppFrame parameter is null if no frame is currently active.
        /// </remarks>
        [PreserveSig]
        HRESULT GetActiveFrame(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);

        /// <summary>
        /// Gets an interface pointer to the register set that is associated with the active part of this <see cref="ICorDebugThread"/> object.
        /// </summary>
        /// <param name="ppRegisters">[out] A pointer to the address of an <see cref="ICorDebugRegisterSet"/> interface object that represents the register set for the active part of this thread.</param>
        [PreserveSig]
        HRESULT GetRegisterSet(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugRegisterSet ppRegisters);

        /// <summary>
        /// Creates an <see cref="ICorDebugEval"/> object that collects and exposes the functionality of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <param name="ppEval">[out] A pointer to the address of an <see cref="ICorDebugEval"/> object that collects and exposes the functionality of this thread.</param>
        /// <remarks>
        /// The evaluation object will push a new chain on the thread before doing its computation. This interrupts the computation
        /// currently being performed on the thread until the evaluation completes.
        /// </remarks>
        [PreserveSig]
        HRESULT CreateEval(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugEval ppEval);

        /// <summary>
        /// Gets an interface pointer to the common language runtime (CLR) thread.
        /// </summary>
        /// <param name="ppObject">[out] A pointer to the address of an <see cref="ICorDebugValue"/> interface object that represents the CLR thread.</param>
        [PreserveSig]
        HRESULT GetObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);
    }
}
