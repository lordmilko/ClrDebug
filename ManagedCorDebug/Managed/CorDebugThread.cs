using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a thread in a process. The lifetime of an <see cref="ICorDebugThread"/> instance is the same as the lifetime of the thread it represents.
    /// </summary>
    public class CorDebugThread : ComObject<ICorDebugThread>
    {
        public CorDebugThread(ICorDebugThread raw) : base(raw)
        {
        }

        #region ICorDebugThread
        #region GetProcess

        /// <summary>
        /// Gets an interface pointer to the process of which this <see cref="ICorDebugThread"/> forms a part.
        /// </summary>
        public CorDebugProcess Process
        {
            get
            {
                HRESULT hr;
                CorDebugProcess ppProcessResult;

                if ((hr = TryGetProcess(out ppProcessResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppProcessResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to the process of which this <see cref="ICorDebugThread"/> forms a part.
        /// </summary>
        /// <param name="ppProcessResult">[out] A pointer to the address of an <see cref="ICorDebugProcess"/> interface object that represents the process.</param>
        public HRESULT TryGetProcess(out CorDebugProcess ppProcessResult)
        {
            /*HRESULT GetProcess([MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.GetProcess(out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region GetID

        /// <summary>
        /// Gets the current operating system identifier of the active part of this <see cref="ICorDebugThread"/>.
        /// </summary>
        public int Id
        {
            get
            {
                HRESULT hr;
                int pdwThreadId;

                if ((hr = TryGetID(out pdwThreadId)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwThreadId;
            }
        }

        /// <summary>
        /// Gets the current operating system identifier of the active part of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <param name="pdwThreadId">[out] The identifier of the thread.</param>
        /// <remarks>
        /// The operating system identifier can potentially change during execution of a process, and can be a different value
        /// for different parts of the thread.
        /// </remarks>
        public HRESULT TryGetID(out int pdwThreadId)
        {
            /*HRESULT GetID(out int pdwThreadId);*/
            return Raw.GetID(out pdwThreadId);
        }

        #endregion
        #region GetHandle

        /// <summary>
        /// Gets the current handle for the active part of this <see cref="ICorDebugThread"/>.
        /// </summary>
        public IntPtr Handle
        {
            get
            {
                HRESULT hr;
                IntPtr phThreadHandle;

                if ((hr = TryGetHandle(out phThreadHandle)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return phThreadHandle;
            }
        }

        /// <summary>
        /// Gets the current handle for the active part of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <param name="phThreadHandle">[out] A pointer to an HTHREAD that is the handle of the active part of this thread.</param>
        /// <remarks>
        /// The handle may change as the process executes, and may be different for different parts of the thread. This handle
        /// is owned by the debugging API. The debugger should duplicate it before using it.
        /// </remarks>
        public HRESULT TryGetHandle(out IntPtr phThreadHandle)
        {
            /*HRESULT GetHandle(out IntPtr phThreadHandle);*/
            return Raw.GetHandle(out phThreadHandle);
        }

        #endregion
        #region GetAppDomain

        /// <summary>
        /// Gets an interface pointer to the application domain in which this <see cref="ICorDebugThread"/> is currently executing.
        /// </summary>
        public CorDebugAppDomain AppDomain
        {
            get
            {
                HRESULT hr;
                CorDebugAppDomain ppAppDomainResult;

                if ((hr = TryGetAppDomain(out ppAppDomainResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppAppDomainResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to the application domain in which this <see cref="ICorDebugThread"/> is currently executing.
        /// </summary>
        /// <param name="ppAppDomainResult">[out] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which this thread is currently executing.</param>
        public HRESULT TryGetAppDomain(out CorDebugAppDomain ppAppDomainResult)
        {
            /*HRESULT GetAppDomain([MarshalAs(UnmanagedType.Interface)] out ICorDebugAppDomain ppAppDomain);*/
            ICorDebugAppDomain ppAppDomain;
            HRESULT hr = Raw.GetAppDomain(out ppAppDomain);

            if (hr == HRESULT.S_OK)
                ppAppDomainResult = new CorDebugAppDomain(ppAppDomain);
            else
                ppAppDomainResult = default(CorDebugAppDomain);

            return hr;
        }

        #endregion
        #region GetDebugState

        /// <summary>
        /// Gets or sets the current debug state of this <see cref="ICorDebugThread"/> object.
        /// </summary>
        public CorDebugThreadState DebugState
        {
            get
            {
                HRESULT hr;
                CorDebugThreadState pState;

                if ((hr = TryGetDebugState(out pState)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pState;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetDebugState(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        /// <summary>
        /// Gets the current debug state of this <see cref="ICorDebugThread"/> object.
        /// </summary>
        /// <param name="pState">[out] A pointer to a bitwise combination of <see cref="CorDebugThreadState"/> enumeration values that describes the current debug state of this thread.</param>
        /// <remarks>
        /// If the process is currently stopped, pState represents the debug state that would exist for this thread if the
        /// process were to be continued, not the actual current state of this thread.
        /// </remarks>
        public HRESULT TryGetDebugState(out CorDebugThreadState pState)
        {
            /*HRESULT GetDebugState(out CorDebugThreadState pState);*/
            return Raw.GetDebugState(out pState);
        }

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
        /// debug events already queued. Thus a debugger should drain the entire event queue (by calling <see cref="CorDebugController.HasQueuedCallbacks"/>)
        /// before suspending or resuming threads. Else it may get events on a thread that it believes it has already suspended.
        /// </remarks>
        public HRESULT TrySetDebugState(CorDebugThreadState state)
        {
            /*HRESULT SetDebugState([In] CorDebugThreadState state);*/
            return Raw.SetDebugState(state);
        }

        #endregion
        #region GetUserState

        /// <summary>
        /// Gets the current user state of this <see cref="ICorDebugThread"/>.
        /// </summary>
        public CorDebugUserState UserState
        {
            get
            {
                HRESULT hr;
                CorDebugUserState pState;

                if ((hr = TryGetUserState(out pState)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pState;
            }
        }

        /// <summary>
        /// Gets the current user state of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <param name="pState">[out] A pointer to a bitwise combination of <see cref="CorDebugUserState"/> enumeration values that describe the current user state of this thread.</param>
        /// <remarks>
        /// The user state of the thread is the state of the thread when it is examined by the program that is being debugged.
        /// A thread may have multiple state bits set.
        /// </remarks>
        public HRESULT TryGetUserState(out CorDebugUserState pState)
        {
            /*HRESULT GetUserState(out CorDebugUserState pState);*/
            return Raw.GetUserState(out pState);
        }

        #endregion
        #region GetCurrentException

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugValue"/> object that represents an exception that is currently being thrown by managed code.
        /// </summary>
        public CorDebugValue CurrentException
        {
            get
            {
                HRESULT hr;
                CorDebugValue ppExceptionObjectResult;

                if ((hr = TryGetCurrentException(out ppExceptionObjectResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppExceptionObjectResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugValue"/> object that represents an exception that is currently being thrown by managed code.
        /// </summary>
        /// <param name="ppExceptionObjectResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the exception that is currently being thrown by managed code.</param>
        /// <remarks>
        /// The exception object will exist from the time the exception is thrown until the end of the catch block. A function
        /// evaluation, which is performed by the <see cref="ICorDebugEval"/> methods, will clear out the exception object on setup and restore
        /// it on completion. Exceptions can be nested (for example, if an exception is thrown in a filter or in a function
        /// evaluation), so there may be multiple outstanding exceptions on a single thread. GetCurrentException returns the
        /// most current exception. The exception object and type may change throughout the life of the exception. For example,
        /// after an exception of type x is thrown, the common language runtime (CLR) may run out of memory and promote it
        /// to an out-of-memory exception.
        /// </remarks>
        public HRESULT TryGetCurrentException(out CorDebugValue ppExceptionObjectResult)
        {
            /*HRESULT GetCurrentException([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppExceptionObject);*/
            ICorDebugValue ppExceptionObject;
            HRESULT hr = Raw.GetCurrentException(out ppExceptionObject);

            if (hr == HRESULT.S_OK)
                ppExceptionObjectResult = CorDebugValue.New(ppExceptionObject);
            else
                ppExceptionObjectResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetActiveChain

        /// <summary>
        /// Gets an interface pointer to the active (most recent) stack chain on this <see cref="ICorDebugThread"/> object.
        /// </summary>
        public CorDebugChain ActiveChain
        {
            get
            {
                HRESULT hr;
                CorDebugChain ppChainResult;

                if ((hr = TryGetActiveChain(out ppChainResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppChainResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to the active (most recent) stack chain on this <see cref="ICorDebugThread"/> object.
        /// </summary>
        /// <param name="ppChainResult">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the stack chain.</param>
        /// <remarks>
        /// The ppChain parameter is null if no stack chain is currently active.
        /// </remarks>
        public HRESULT TryGetActiveChain(out CorDebugChain ppChainResult)
        {
            /*HRESULT GetActiveChain([MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);*/
            ICorDebugChain ppChain;
            HRESULT hr = Raw.GetActiveChain(out ppChain);

            if (hr == HRESULT.S_OK)
                ppChainResult = new CorDebugChain(ppChain);
            else
                ppChainResult = default(CorDebugChain);

            return hr;
        }

        #endregion
        #region GetActiveFrame

        /// <summary>
        /// Gets an interface pointer to the active (most recent) frame on this <see cref="ICorDebugThread"/> object.
        /// </summary>
        public CorDebugFrame ActiveFrame
        {
            get
            {
                HRESULT hr;
                CorDebugFrame ppFrameResult;

                if ((hr = TryGetActiveFrame(out ppFrameResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppFrameResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to the active (most recent) frame on this <see cref="ICorDebugThread"/> object.
        /// </summary>
        /// <param name="ppFrameResult">[out] A pointer to the address of an <see cref="ICorDebugFrame"/> interface object that represents a frame.</param>
        /// <remarks>
        /// The ppFrame parameter is null if no frame is currently active.
        /// </remarks>
        public HRESULT TryGetActiveFrame(out CorDebugFrame ppFrameResult)
        {
            /*HRESULT GetActiveFrame([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);*/
            ICorDebugFrame ppFrame;
            HRESULT hr = Raw.GetActiveFrame(out ppFrame);

            if (hr == HRESULT.S_OK)
                ppFrameResult = CorDebugFrame.New(ppFrame);
            else
                ppFrameResult = default(CorDebugFrame);

            return hr;
        }

        #endregion
        #region GetRegisterSet

        /// <summary>
        /// Gets an interface pointer to the register set that is associated with the active part of this <see cref="ICorDebugThread"/> object.
        /// </summary>
        public CorDebugRegisterSet RegisterSet
        {
            get
            {
                HRESULT hr;
                CorDebugRegisterSet ppRegistersResult;

                if ((hr = TryGetRegisterSet(out ppRegistersResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppRegistersResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to the register set that is associated with the active part of this <see cref="ICorDebugThread"/> object.
        /// </summary>
        /// <param name="ppRegistersResult">[out] A pointer to the address of an <see cref="ICorDebugRegisterSet"/> interface object that represents the register set for the active part of this thread.</param>
        public HRESULT TryGetRegisterSet(out CorDebugRegisterSet ppRegistersResult)
        {
            /*HRESULT GetRegisterSet([MarshalAs(UnmanagedType.Interface)] out ICorDebugRegisterSet ppRegisters);*/
            ICorDebugRegisterSet ppRegisters;
            HRESULT hr = Raw.GetRegisterSet(out ppRegisters);

            if (hr == HRESULT.S_OK)
                ppRegistersResult = new CorDebugRegisterSet(ppRegisters);
            else
                ppRegistersResult = default(CorDebugRegisterSet);

            return hr;
        }

        #endregion
        #region GetObject

        /// <summary>
        /// Gets an interface pointer to the common language runtime (CLR) thread.
        /// </summary>
        public CorDebugValue Object
        {
            get
            {
                HRESULT hr;
                CorDebugValue ppObjectResult;

                if ((hr = TryGetObject(out ppObjectResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppObjectResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to the common language runtime (CLR) thread.
        /// </summary>
        /// <param name="ppObjectResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> interface object that represents the CLR thread.</param>
        public HRESULT TryGetObject(out CorDebugValue ppObjectResult)
        {
            /*HRESULT GetObject([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);*/
            ICorDebugValue ppObject;
            HRESULT hr = Raw.GetObject(out ppObject);

            if (hr == HRESULT.S_OK)
                ppObjectResult = CorDebugValue.New(ppObject);
            else
                ppObjectResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region ClearCurrentException

        /// <summary>
        /// This method is not implemented. Do not use it.
        /// </summary>
        public void ClearCurrentException()
        {
            HRESULT hr;

            if ((hr = TryClearCurrentException()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// This method is not implemented. Do not use it.
        /// </summary>
        public HRESULT TryClearCurrentException()
        {
            /*HRESULT ClearCurrentException();*/
            return Raw.ClearCurrentException();
        }

        #endregion
        #region CreateStepper

        /// <summary>
        /// Creates an <see cref="ICorDebugStepper"/> object that allows stepping through the active frame of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugStepper"/> object that allows stepping through the active frame of this thread.</returns>
        /// <remarks>
        /// The active frame may be unmanaged code. The <see cref="ICorDebugStepper"/> interface must be used to perform the actual stepping.
        /// </remarks>
        public CorDebugStepper CreateStepper()
        {
            HRESULT hr;
            CorDebugStepper ppStepperResult;

            if ((hr = TryCreateStepper(out ppStepperResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppStepperResult;
        }

        /// <summary>
        /// Creates an <see cref="ICorDebugStepper"/> object that allows stepping through the active frame of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <param name="ppStepperResult">[out] A pointer to the address of an <see cref="ICorDebugStepper"/> object that allows stepping through the active frame of this thread.</param>
        /// <remarks>
        /// The active frame may be unmanaged code. The <see cref="ICorDebugStepper"/> interface must be used to perform the actual stepping.
        /// </remarks>
        public HRESULT TryCreateStepper(out CorDebugStepper ppStepperResult)
        {
            /*HRESULT CreateStepper([MarshalAs(UnmanagedType.Interface)] out ICorDebugStepper ppStepper);*/
            ICorDebugStepper ppStepper;
            HRESULT hr = Raw.CreateStepper(out ppStepper);

            if (hr == HRESULT.S_OK)
                ppStepperResult = new CorDebugStepper(ppStepper);
            else
                ppStepperResult = default(CorDebugStepper);

            return hr;
        }

        #endregion
        #region EnumerateChains

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugChainEnum"/> enumerator that contains all the stack chains in this <see cref="ICorDebugThread"/> object.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugChainEnum"/> object that allows enumeration of all the stack chains in this thread, starting at the active (that is, the most recent) chain.</returns>
        /// <remarks>
        /// The stack chain represents the physical call stack for the thread. The following circumstances create a stack chain
        /// boundary: In the simple case for a thread that is running purely managed code in a single context, a one-to-one
        /// correspondence will exist between threads and stack chains. A debugger may want to rearrange the physical call
        /// stacks of all threads into logical call stacks. This would involve sorting all the threads' chains by their caller/callee
        /// relationships and regrouping them.
        /// </remarks>
        public CorDebugChainEnum EnumerateChains()
        {
            HRESULT hr;
            CorDebugChainEnum ppChainsResult;

            if ((hr = TryEnumerateChains(out ppChainsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppChainsResult;
        }

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugChainEnum"/> enumerator that contains all the stack chains in this <see cref="ICorDebugThread"/> object.
        /// </summary>
        /// <param name="ppChainsResult">[out] A pointer to the address of an <see cref="ICorDebugChainEnum"/> object that allows enumeration of all the stack chains in this thread, starting at the active (that is, the most recent) chain.</param>
        /// <remarks>
        /// The stack chain represents the physical call stack for the thread. The following circumstances create a stack chain
        /// boundary: In the simple case for a thread that is running purely managed code in a single context, a one-to-one
        /// correspondence will exist between threads and stack chains. A debugger may want to rearrange the physical call
        /// stacks of all threads into logical call stacks. This would involve sorting all the threads' chains by their caller/callee
        /// relationships and regrouping them.
        /// </remarks>
        public HRESULT TryEnumerateChains(out CorDebugChainEnum ppChainsResult)
        {
            /*HRESULT EnumerateChains([MarshalAs(UnmanagedType.Interface)] out ICorDebugChainEnum ppChains);*/
            ICorDebugChainEnum ppChains;
            HRESULT hr = Raw.EnumerateChains(out ppChains);

            if (hr == HRESULT.S_OK)
                ppChainsResult = new CorDebugChainEnum(ppChains);
            else
                ppChainsResult = default(CorDebugChainEnum);

            return hr;
        }

        #endregion
        #region CreateEval

        /// <summary>
        /// Creates an <see cref="ICorDebugEval"/> object that collects and exposes the functionality of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugEval"/> object that collects and exposes the functionality of this thread.</returns>
        /// <remarks>
        /// The evaluation object will push a new chain on the thread before doing its computation. This interrupts the computation
        /// currently being performed on the thread until the evaluation completes.
        /// </remarks>
        public CorDebugEval CreateEval()
        {
            HRESULT hr;
            CorDebugEval ppEvalResult;

            if ((hr = TryCreateEval(out ppEvalResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppEvalResult;
        }

        /// <summary>
        /// Creates an <see cref="ICorDebugEval"/> object that collects and exposes the functionality of this <see cref="ICorDebugThread"/>.
        /// </summary>
        /// <param name="ppEvalResult">[out] A pointer to the address of an <see cref="ICorDebugEval"/> object that collects and exposes the functionality of this thread.</param>
        /// <remarks>
        /// The evaluation object will push a new chain on the thread before doing its computation. This interrupts the computation
        /// currently being performed on the thread until the evaluation completes.
        /// </remarks>
        public HRESULT TryCreateEval(out CorDebugEval ppEvalResult)
        {
            /*HRESULT CreateEval([MarshalAs(UnmanagedType.Interface)] out ICorDebugEval ppEval);*/
            ICorDebugEval ppEval;
            HRESULT hr = Raw.CreateEval(out ppEval);

            if (hr == HRESULT.S_OK)
                ppEvalResult = new CorDebugEval(ppEval);
            else
                ppEvalResult = default(CorDebugEval);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugThread2

        public ICorDebugThread2 Raw2 => (ICorDebugThread2) Raw;

        #region GetConnectionID

        /// <summary>
        /// Gets the connection identifier for this <see cref="ICorDebugThread2"/> object.
        /// </summary>
        public int ConnectionID
        {
            get
            {
                HRESULT hr;
                int pdwConnectionId;

                if ((hr = TryGetConnectionID(out pdwConnectionId)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwConnectionId;
            }
        }

        /// <summary>
        /// Gets the connection identifier for this <see cref="ICorDebugThread2"/> object.
        /// </summary>
        /// <param name="pdwConnectionId">[out] A CONNID that represents the connection identifier.</param>
        /// <remarks>
        /// The GetConnectionID method returns zero in the pdwConnectionId parameter, if this thread is not part of a connection.
        /// If this thread is connected to an instance of Microsoft SQL Server 2005 Analysis Services (SSAS), the CONNID maps
        /// to a server process identifier (SPID).
        /// </remarks>
        public HRESULT TryGetConnectionID(out int pdwConnectionId)
        {
            /*HRESULT GetConnectionID(out int pdwConnectionId);*/
            return Raw2.GetConnectionID(out pdwConnectionId);
        }

        #endregion
        #region GetTaskID

        /// <summary>
        /// Gets the identifier of the task running on this thread.
        /// </summary>
        public long TaskID
        {
            get
            {
                HRESULT hr;
                long pTaskId;

                if ((hr = TryGetTaskID(out pTaskId)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pTaskId;
            }
        }

        /// <summary>
        /// Gets the identifier of the task running on this thread.
        /// </summary>
        /// <param name="pTaskId">[out] A pointer to the identifier of the task running on the thread represented by this <see cref="ICorDebugThread2"/> object.</param>
        /// <remarks>
        /// A task can only be running on the thread if the thread is associated with a connection. GetTaskID returns zero
        /// in pTaskId if the thread is not associated with a connection.
        /// </remarks>
        public HRESULT TryGetTaskID(out long pTaskId)
        {
            /*HRESULT GetTaskID(out long pTaskId);*/
            return Raw2.GetTaskID(out pTaskId);
        }

        #endregion
        #region GetVolatileOSThreadID

        /// <summary>
        /// Gets the operating system thread identifier for this <see cref="ICorDebugThread2"/>.
        /// </summary>
        public int VolatileOSThreadID
        {
            get
            {
                HRESULT hr;
                int pdwTid;

                if ((hr = TryGetVolatileOSThreadID(out pdwTid)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwTid;
            }
        }

        /// <summary>
        /// Gets the operating system thread identifier for this <see cref="ICorDebugThread2"/>.
        /// </summary>
        /// <param name="pdwTid">[out] The operating system thread identifier for this thread.</param>
        public HRESULT TryGetVolatileOSThreadID(out int pdwTid)
        {
            /*HRESULT GetVolatileOSThreadID(out int pdwTid);*/
            return Raw2.GetVolatileOSThreadID(out pdwTid);
        }

        #endregion
        #region GetActiveFunctions

        /// <summary>
        /// Gets information about the active function in each of this thread's frames.
        /// </summary>
        /// <param name="cFunctions">[in] The size of the pFunctions array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// If pFunctions is null on input, GetActiveFunctions returns only the number of functions that are on the stack.
        /// That is, If pFunctions is null on input, GetActiveFunctions returns a value only in pcFunctions. The GetActiveFunctions
        /// method is intended as an optimization over getting the same information from frames in a stack trace, and includes
        /// only frames that would have had an <see cref="ICorDebugILFrame"/> object for them in the full stack trace.
        /// </remarks>
        public GetActiveFunctionsResult GetActiveFunctions(int cFunctions)
        {
            HRESULT hr;
            GetActiveFunctionsResult result;

            if ((hr = TryGetActiveFunctions(cFunctions, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets information about the active function in each of this thread's frames.
        /// </summary>
        /// <param name="cFunctions">[in] The size of the pFunctions array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// If pFunctions is null on input, GetActiveFunctions returns only the number of functions that are on the stack.
        /// That is, If pFunctions is null on input, GetActiveFunctions returns a value only in pcFunctions. The GetActiveFunctions
        /// method is intended as an optimization over getting the same information from frames in a stack trace, and includes
        /// only frames that would have had an <see cref="ICorDebugILFrame"/> object for them in the full stack trace.
        /// </remarks>
        public HRESULT TryGetActiveFunctions(int cFunctions, out GetActiveFunctionsResult result)
        {
            /*HRESULT GetActiveFunctions([In] int cFunctions, out int pcFunctions,
            [MarshalAs(UnmanagedType.LPArray), In, Out] COR_ACTIVE_FUNCTION[] pFunctions);*/
            int pcFunctions;
            COR_ACTIVE_FUNCTION[] pFunctions = null;
            HRESULT hr = Raw2.GetActiveFunctions(cFunctions, out pcFunctions, pFunctions);

            if (hr == HRESULT.S_OK)
                result = new GetActiveFunctionsResult(pcFunctions, pFunctions);
            else
                result = default(GetActiveFunctionsResult);

            return hr;
        }

        #endregion
        #region InterceptCurrentException

        /// <summary>
        /// Allows a debugger to intercept the current exception on this thread.
        /// </summary>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> that represents the active stack frame.</param>
        /// <remarks>
        /// The InterceptCurrentException method can be called between an exception callback (<see cref="CorDebugManagedCallback.Exception(ICorDebugAppDomain, ICorDebugThread, int)"/>
        /// or <see cref="CorDebugManagedCallback.Exception(ICorDebugAppDomain, ICorDebugThread, ICorDebugFrame, int, CorDebugExceptionCallbackType, int)"/>) and the associated call to <see cref="CorDebugController.Continue"/>.
        /// </remarks>
        public void InterceptCurrentException(ICorDebugFrame pFrame)
        {
            HRESULT hr;

            if ((hr = TryInterceptCurrentException(pFrame)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Allows a debugger to intercept the current exception on this thread.
        /// </summary>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> that represents the active stack frame.</param>
        /// <remarks>
        /// The InterceptCurrentException method can be called between an exception callback (<see cref="CorDebugManagedCallback.Exception(ICorDebugAppDomain, ICorDebugThread, int)"/>
        /// or <see cref="CorDebugManagedCallback.Exception(ICorDebugAppDomain, ICorDebugThread, ICorDebugFrame, int, CorDebugExceptionCallbackType, int)"/>) and the associated call to <see cref="CorDebugController.Continue"/>.
        /// </remarks>
        public HRESULT TryInterceptCurrentException(ICorDebugFrame pFrame)
        {
            /*HRESULT InterceptCurrentException([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame);*/
            return Raw2.InterceptCurrentException(pFrame);
        }

        #endregion
        #endregion
        #region ICorDebugThread3

        public ICorDebugThread3 Raw3 => (ICorDebugThread3) Raw;

        #region CreateStackWalk

        /// <summary>
        /// Creates an <see cref="ICorDebugStackWalk"/> object for the thread whose stack you want to unwind.
        /// </summary>
        /// <returns>[out] A pointer to address of the <see cref="ICorDebugStackWalk"/> object for the thread whose stack you want to unwind.</returns>
        /// <remarks>
        /// If the CreateStackWalk method succeeds, the returned <see cref="ICorDebugStackWalk"/> object's context is set to the thread's
        /// current context.
        /// </remarks>
        public CorDebugStackWalk CreateStackWalk()
        {
            HRESULT hr;
            CorDebugStackWalk ppStackWalkResult;

            if ((hr = TryCreateStackWalk(out ppStackWalkResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppStackWalkResult;
        }

        /// <summary>
        /// Creates an <see cref="ICorDebugStackWalk"/> object for the thread whose stack you want to unwind.
        /// </summary>
        /// <param name="ppStackWalkResult">[out] A pointer to address of the <see cref="ICorDebugStackWalk"/> object for the thread whose stack you want to unwind.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                                             |
        /// | ------- | ------------------------------------------------------- |
        /// | S_OK    | The ICorDebugStackWalk object was successfully created. |
        /// | E_FAIL  | The ICorDebugStackWalk object was not created.          |
        /// </returns>
        /// <remarks>
        /// If the CreateStackWalk method succeeds, the returned <see cref="ICorDebugStackWalk"/> object's context is set to the thread's
        /// current context.
        /// </remarks>
        public HRESULT TryCreateStackWalk(out CorDebugStackWalk ppStackWalkResult)
        {
            /*HRESULT CreateStackWalk([MarshalAs(UnmanagedType.Interface)] out ICorDebugStackWalk ppStackWalk);*/
            ICorDebugStackWalk ppStackWalk;
            HRESULT hr = Raw3.CreateStackWalk(out ppStackWalk);

            if (hr == HRESULT.S_OK)
                ppStackWalkResult = new CorDebugStackWalk(ppStackWalk);
            else
                ppStackWalkResult = default(CorDebugStackWalk);

            return hr;
        }

        #endregion
        #region GetActiveInternalFrames

        /// <summary>
        /// Returns an array of internal frames (<see cref="ICorDebugInternalFrame2"/> objects) on the stack.
        /// </summary>
        /// <param name="cInternalFrames">[in] The number of internal frames expected in ppInternalFrames.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Internal frames are data structures pushed onto the stack by the runtime to store temporary data. When you first
        /// call GetActiveInternalFrames, you should set the cInternalFrames parameter to 0 (zero), and the ppInternalFrames
        /// parameter to null. When GetActiveInternalFrames first returns, pcInternalFrames contains the count of the internal
        /// frames on the stack. GetActiveInternalFrames should then be called a second time. You should pass the proper count
        /// (pcInternalFrames) in the cInternalFrames parameter, and specify a pointer to an appropriately sized array in ppInternalFrames.
        /// Use the <see cref="GetActiveInternalFrames"/> method to return actual stack frames.
        /// </remarks>
        public GetActiveInternalFramesResult GetActiveInternalFrames(int cInternalFrames)
        {
            HRESULT hr;
            GetActiveInternalFramesResult result;

            if ((hr = TryGetActiveInternalFrames(cInternalFrames, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Returns an array of internal frames (<see cref="ICorDebugInternalFrame2"/> objects) on the stack.
        /// </summary>
        /// <param name="cInternalFrames">[in] The number of internal frames expected in ppInternalFrames.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                                       | Description                                                                            |
        /// | --------------------------------------------- | -------------------------------------------------------------------------------------- |
        /// | S_OK                                          | The <see cref="ICorDebugInternalFrame2"/> object was successfully created.             |
        /// | E_INVALIDARG                                  | cInternalFrames is not zero and ppInternalFrames is null, or pcInternalFrames is null. |
        /// | HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) | ppInternalFrames is smaller than the count of internal frames.                         |
        /// </returns>
        /// <remarks>
        /// Internal frames are data structures pushed onto the stack by the runtime to store temporary data. When you first
        /// call GetActiveInternalFrames, you should set the cInternalFrames parameter to 0 (zero), and the ppInternalFrames
        /// parameter to null. When GetActiveInternalFrames first returns, pcInternalFrames contains the count of the internal
        /// frames on the stack. GetActiveInternalFrames should then be called a second time. You should pass the proper count
        /// (pcInternalFrames) in the cInternalFrames parameter, and specify a pointer to an appropriately sized array in ppInternalFrames.
        /// Use the <see cref="GetActiveInternalFrames"/> method to return actual stack frames.
        /// </remarks>
        public HRESULT TryGetActiveInternalFrames(int cInternalFrames, out GetActiveInternalFramesResult result)
        {
            /*HRESULT GetActiveInternalFrames(
            [In] int cInternalFrames,
            out int pcInternalFrames,
            [In, Out] IntPtr ppInternalFrames);*/
            int pcInternalFrames;
            IntPtr ppInternalFrames = default(IntPtr);
            HRESULT hr = Raw3.GetActiveInternalFrames(cInternalFrames, out pcInternalFrames, ppInternalFrames);

            if (hr == HRESULT.S_OK)
                result = new GetActiveInternalFramesResult(pcInternalFrames, ppInternalFrames);
            else
                result = default(GetActiveInternalFramesResult);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugThread4

        public ICorDebugThread4 Raw4 => (ICorDebugThread4) Raw;

        #region GetBlockingObjects

        /// <summary>
        /// Provides an ordered enumeration of <see cref="CorDebugBlockingObject"/> structures that provide thread blocking information.
        /// </summary>
        public CorDebugBlockingObjectEnum BlockingObjects
        {
            get
            {
                HRESULT hr;
                CorDebugBlockingObjectEnum ppBlockingObjectEnumResult;

                if ((hr = TryGetBlockingObjects(out ppBlockingObjectEnumResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppBlockingObjectEnumResult;
            }
        }

        /// <summary>
        /// Provides an ordered enumeration of <see cref="CorDebugBlockingObject"/> structures that provide thread blocking information.
        /// </summary>
        /// <param name="ppBlockingObjectEnumResult">[out] A pointer to an ordered enumeration of <see cref="CorDebugBlockingObject"/> structures.</param>
        /// <remarks>
        /// The first element in the returned enumeration corresponds to the first structure that is blocking the thread. The
        /// second element corresponds to a blocking item that is encountered while running an asynchronous procedure call
        /// (APC) when blocked on the first, and so on. The enumeration is valid only for the duration of the current synchronized
        /// state. This method must be called while the debuggee is in a synchronized state. If ppBlockingObjectEnum is not
        /// a valid pointer, the result is undefined. If a thread is blocked and the error cannot be determined, the method
        /// returns an <see cref="HRESULT"/> that indicates failure; otherwise, it returns S_OK.
        /// </remarks>
        public HRESULT TryGetBlockingObjects(out CorDebugBlockingObjectEnum ppBlockingObjectEnumResult)
        {
            /*HRESULT GetBlockingObjects(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugBlockingObjectEnum ppBlockingObjectEnum);*/
            ICorDebugBlockingObjectEnum ppBlockingObjectEnum;
            HRESULT hr = Raw4.GetBlockingObjects(out ppBlockingObjectEnum);

            if (hr == HRESULT.S_OK)
                ppBlockingObjectEnumResult = new CorDebugBlockingObjectEnum(ppBlockingObjectEnum);
            else
                ppBlockingObjectEnumResult = default(CorDebugBlockingObjectEnum);

            return hr;
        }

        #endregion
        #region GetCurrentCustomDebuggerNotification

        /// <summary>
        /// Gets the current <see cref="CorDebugManagedCallback.CustomNotification"/> object on the current thread.
        /// </summary>
        public CorDebugValue CurrentCustomDebuggerNotification
        {
            get
            {
                HRESULT hr;
                CorDebugValue ppNotificationObjectResult;

                if ((hr = TryGetCurrentCustomDebuggerNotification(out ppNotificationObjectResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppNotificationObjectResult;
            }
        }

        /// <summary>
        /// Gets the current <see cref="CorDebugManagedCallback.CustomNotification"/> object on the current thread.
        /// </summary>
        /// <param name="ppNotificationObjectResult">[out] A pointer to the current <see cref="CorDebugManagedCallback.CustomNotification"/> object on the current thread.</param>
        /// <remarks>
        /// The value of ppNotificationObject is null if the method is not called from within a ICorDebugManagedCallback3::CustomNotification
        /// callback, or if no current notification object exists.
        /// </remarks>
        public HRESULT TryGetCurrentCustomDebuggerNotification(out CorDebugValue ppNotificationObjectResult)
        {
            /*HRESULT GetCurrentCustomDebuggerNotification(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppNotificationObject);*/
            ICorDebugValue ppNotificationObject;
            HRESULT hr = Raw4.GetCurrentCustomDebuggerNotification(out ppNotificationObject);

            if (hr == HRESULT.S_OK)
                ppNotificationObjectResult = CorDebugValue.New(ppNotificationObject);
            else
                ppNotificationObjectResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region HasUnhandledException

        public void HasUnhandledException()
        {
            HRESULT hr;

            if ((hr = TryHasUnhandledException()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryHasUnhandledException()
        {
            /*HRESULT HasUnhandledException();*/
            return Raw4.HasUnhandledException();
        }

        #endregion
        #endregion
    }
}