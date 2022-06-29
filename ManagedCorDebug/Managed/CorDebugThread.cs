using System;
using System.Diagnostics;
using System.Linq;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a thread in a process. The lifetime of an <see cref="ICorDebugThread"/> instance is the same as the lifetime of the thread it represents.
    /// </summary>
    public class CorDebugThread : ComObject<ICorDebugThread>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugThread"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugThread(ICorDebugThread raw) : base(raw)
        {
        }

        #region ICorDebugThread
        #region Process

        /// <summary>
        /// Gets an interface pointer to the process of which this <see cref="ICorDebugThread"/> forms a part.
        /// </summary>
        public CorDebugProcess Process
        {
            get
            {
                CorDebugProcess ppProcessResult;
                TryGetProcess(out ppProcessResult).ThrowOnNotOK();

                return ppProcessResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to the process of which this <see cref="ICorDebugThread"/> forms a part.
        /// </summary>
        /// <param name="ppProcessResult">[out] A pointer to the address of an <see cref="ICorDebugProcess"/> interface object that represents the process.</param>
        public HRESULT TryGetProcess(out CorDebugProcess ppProcessResult)
        {
            /*HRESULT GetProcess([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.GetProcess(out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region Id

        /// <summary>
        /// Gets the current operating system identifier of the active part of this <see cref="ICorDebugThread"/>.
        /// </summary>
        public int Id
        {
            get
            {
                int pdwThreadId;
                TryGetID(out pdwThreadId).ThrowOnNotOK();

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
            /*HRESULT GetID([Out] out int pdwThreadId);*/
            return Raw.GetID(out pdwThreadId);
        }

        #endregion
        #region Handle

        /// <summary>
        /// Gets the current handle for the active part of this <see cref="ICorDebugThread"/>.
        /// </summary>
        public IntPtr Handle
        {
            get
            {
                IntPtr phThreadHandle;
                TryGetHandle(out phThreadHandle).ThrowOnNotOK();

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
            /*HRESULT GetHandle([Out] out IntPtr phThreadHandle);*/
            return Raw.GetHandle(out phThreadHandle);
        }

        #endregion
        #region AppDomain

        /// <summary>
        /// Gets an interface pointer to the application domain in which this <see cref="ICorDebugThread"/> is currently executing.
        /// </summary>
        public CorDebugAppDomain AppDomain
        {
            get
            {
                CorDebugAppDomain ppAppDomainResult;
                TryGetAppDomain(out ppAppDomainResult).ThrowOnNotOK();

                return ppAppDomainResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to the application domain in which this <see cref="ICorDebugThread"/> is currently executing.
        /// </summary>
        /// <param name="ppAppDomainResult">[out] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which this thread is currently executing.</param>
        public HRESULT TryGetAppDomain(out CorDebugAppDomain ppAppDomainResult)
        {
            /*HRESULT GetAppDomain([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugAppDomain ppAppDomain);*/
            ICorDebugAppDomain ppAppDomain;
            HRESULT hr = Raw.GetAppDomain(out ppAppDomain);

            if (hr == HRESULT.S_OK)
                ppAppDomainResult = new CorDebugAppDomain(ppAppDomain);
            else
                ppAppDomainResult = default(CorDebugAppDomain);

            return hr;
        }

        #endregion
        #region DebugState

        /// <summary>
        /// Gets or sets the current debug state of this <see cref="ICorDebugThread"/> object.
        /// </summary>
        public CorDebugThreadState DebugState
        {
            get
            {
                CorDebugThreadState pState;
                TryGetDebugState(out pState).ThrowOnNotOK();

                return pState;
            }
            set
            {
                TrySetDebugState(value).ThrowOnNotOK();
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
            /*HRESULT GetDebugState([Out] out CorDebugThreadState pState);*/
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
        #region UserState

        /// <summary>
        /// Gets the current user state of this <see cref="ICorDebugThread"/>.
        /// </summary>
        public CorDebugUserState UserState
        {
            get
            {
                CorDebugUserState pState;
                TryGetUserState(out pState).ThrowOnNotOK();

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
            /*HRESULT GetUserState([Out] out CorDebugUserState pState);*/
            return Raw.GetUserState(out pState);
        }

        #endregion
        #region CurrentException

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugValue"/> object that represents an exception that is currently being thrown by managed code.
        /// </summary>
        public CorDebugValue CurrentException
        {
            get
            {
                CorDebugValue ppExceptionObjectResult;
                TryGetCurrentException(out ppExceptionObjectResult).ThrowOnNotOK();

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
            /*HRESULT GetCurrentException([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppExceptionObject);*/
            ICorDebugValue ppExceptionObject;
            HRESULT hr = Raw.GetCurrentException(out ppExceptionObject);

            if (hr == HRESULT.S_OK)
                ppExceptionObjectResult = CorDebugValue.New(ppExceptionObject);
            else
                ppExceptionObjectResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region ActiveChain

        /// <summary>
        /// Gets an interface pointer to the active (most recent) stack chain on this <see cref="ICorDebugThread"/> object.
        /// </summary>
        public CorDebugChain ActiveChain
        {
            get
            {
                CorDebugChain ppChainResult;
                TryGetActiveChain(out ppChainResult).ThrowOnNotOK();

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
            /*HRESULT GetActiveChain([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);*/
            ICorDebugChain ppChain;
            HRESULT hr = Raw.GetActiveChain(out ppChain);

            if (hr == HRESULT.S_OK)
                ppChainResult = new CorDebugChain(ppChain);
            else
                ppChainResult = default(CorDebugChain);

            return hr;
        }

        #endregion
        #region ActiveFrame

        /// <summary>
        /// Gets an interface pointer to the active (most recent) frame on this <see cref="ICorDebugThread"/> object.
        /// </summary>
        public CorDebugFrame ActiveFrame
        {
            get
            {
                CorDebugFrame ppFrameResult;
                TryGetActiveFrame(out ppFrameResult).ThrowOnNotOK();

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
            /*HRESULT GetActiveFrame([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);*/
            ICorDebugFrame ppFrame;
            HRESULT hr = Raw.GetActiveFrame(out ppFrame);

            if (hr == HRESULT.S_OK)
                ppFrameResult = CorDebugFrame.New(ppFrame);
            else
                ppFrameResult = default(CorDebugFrame);

            return hr;
        }

        #endregion
        #region RegisterSet

        /// <summary>
        /// Gets an interface pointer to the register set that is associated with the active part of this <see cref="ICorDebugThread"/> object.
        /// </summary>
        public CorDebugRegisterSet RegisterSet
        {
            get
            {
                CorDebugRegisterSet ppRegistersResult;
                TryGetRegisterSet(out ppRegistersResult).ThrowOnNotOK();

                return ppRegistersResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to the register set that is associated with the active part of this <see cref="ICorDebugThread"/> object.
        /// </summary>
        /// <param name="ppRegistersResult">[out] A pointer to the address of an <see cref="ICorDebugRegisterSet"/> interface object that represents the register set for the active part of this thread.</param>
        public HRESULT TryGetRegisterSet(out CorDebugRegisterSet ppRegistersResult)
        {
            /*HRESULT GetRegisterSet([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugRegisterSet ppRegisters);*/
            ICorDebugRegisterSet ppRegisters;
            HRESULT hr = Raw.GetRegisterSet(out ppRegisters);

            if (hr == HRESULT.S_OK)
                ppRegistersResult = new CorDebugRegisterSet(ppRegisters);
            else
                ppRegistersResult = default(CorDebugRegisterSet);

            return hr;
        }

        #endregion
        #region Object

        /// <summary>
        /// Gets an interface pointer to the common language runtime (CLR) thread.
        /// </summary>
        public CorDebugValue Object
        {
            get
            {
                CorDebugValue ppObjectResult;
                TryGetObject(out ppObjectResult).ThrowOnNotOK();

                return ppObjectResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to the common language runtime (CLR) thread.
        /// </summary>
        /// <param name="ppObjectResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> interface object that represents the CLR thread.</param>
        public HRESULT TryGetObject(out CorDebugValue ppObjectResult)
        {
            /*HRESULT GetObject([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);*/
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
            TryClearCurrentException().ThrowOnNotOK();
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
            CorDebugStepper ppStepperResult;
            TryCreateStepper(out ppStepperResult).ThrowOnNotOK();

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
            /*HRESULT CreateStepper([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugStepper ppStepper);*/
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
        public CorDebugChain[] Chains => EnumerateChains().ToArray();

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
            CorDebugChainEnum ppChainsResult;
            TryEnumerateChains(out ppChainsResult).ThrowOnNotOK();

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
            /*HRESULT EnumerateChains([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugChainEnum ppChains);*/
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
            CorDebugEval ppEvalResult;
            TryCreateEval(out ppEvalResult).ThrowOnNotOK();

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
            /*HRESULT CreateEval([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugEval ppEval);*/
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugThread2 Raw2 => (ICorDebugThread2) Raw;

        #region ActiveFunctions

        /// <summary>
        /// Gets information about the active function in each of this thread's frames.
        /// </summary>
        public COR_ACTIVE_FUNCTION[] ActiveFunctions
        {
            get
            {
                COR_ACTIVE_FUNCTION[] pFunctions;
                TryGetActiveFunctions(out pFunctions).ThrowOnNotOK();

                return pFunctions;
            }
        }

        /// <summary>
        /// Gets information about the active function in each of this thread's frames.
        /// </summary>
        /// <param name="pFunctions">[in, out] An array of <see cref="COR_ACTIVE_FUNCTION"/> objects, each of which contains information about the active functions in this thread's frames.<para/>
        /// The first element will be used for the leaf frame, and so on back to the root of the stack.</param>
        /// <remarks>
        /// If pFunctions is null on input, GetActiveFunctions returns only the number of functions that are on the stack.
        /// That is, If pFunctions is null on input, GetActiveFunctions returns a value only in pcFunctions. The GetActiveFunctions
        /// method is intended as an optimization over getting the same information from frames in a stack trace, and includes
        /// only frames that would have had an <see cref="ICorDebugILFrame"/> object for them in the full stack trace.
        /// </remarks>
        public HRESULT TryGetActiveFunctions(out COR_ACTIVE_FUNCTION[] pFunctions)
        {
            /*HRESULT GetActiveFunctions([In] int cFunctions, [Out] out int pcFunctions,
            [MarshalAs(UnmanagedType.LPArray), In, Out] COR_ACTIVE_FUNCTION[] pFunctions);*/
            int cFunctions = 0;
            int pcFunctions;
            pFunctions = null;
            HRESULT hr = Raw2.GetActiveFunctions(cFunctions, out pcFunctions, pFunctions);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cFunctions = pcFunctions;
            pFunctions = new COR_ACTIVE_FUNCTION[cFunctions];
            hr = Raw2.GetActiveFunctions(cFunctions, out pcFunctions, pFunctions);
            fail:
            return hr;
        }

        #endregion
        #region ConnectionID

        /// <summary>
        /// Gets the connection identifier for this <see cref="ICorDebugThread2"/> object.
        /// </summary>
        public int ConnectionID
        {
            get
            {
                int pdwConnectionId;
                TryGetConnectionID(out pdwConnectionId).ThrowOnNotOK();

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
            /*HRESULT GetConnectionID([Out] out int pdwConnectionId);*/
            return Raw2.GetConnectionID(out pdwConnectionId);
        }

        #endregion
        #region TaskID

        /// <summary>
        /// Gets the identifier of the task running on this thread.
        /// </summary>
        public long TaskID
        {
            get
            {
                long pTaskId;
                TryGetTaskID(out pTaskId).ThrowOnNotOK();

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
            /*HRESULT GetTaskID([Out] out long pTaskId);*/
            return Raw2.GetTaskID(out pTaskId);
        }

        #endregion
        #region VolatileOSThreadID

        /// <summary>
        /// Gets the operating system thread identifier for this <see cref="ICorDebugThread2"/>.
        /// </summary>
        public int VolatileOSThreadID
        {
            get
            {
                int pdwTid;
                TryGetVolatileOSThreadID(out pdwTid).ThrowOnNotOK();

                return pdwTid;
            }
        }

        /// <summary>
        /// Gets the operating system thread identifier for this <see cref="ICorDebugThread2"/>.
        /// </summary>
        /// <param name="pdwTid">[out] The operating system thread identifier for this thread.</param>
        public HRESULT TryGetVolatileOSThreadID(out int pdwTid)
        {
            /*HRESULT GetVolatileOSThreadID([Out] out int pdwTid);*/
            return Raw2.GetVolatileOSThreadID(out pdwTid);
        }

        #endregion
        #region InterceptCurrentException

        /// <summary>
        /// Allows a debugger to intercept the current exception on this thread.
        /// </summary>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> that represents the active stack frame.</param>
        /// <remarks>
        /// The InterceptCurrentException method can be called between an exception callback (<see cref="ICorDebugManagedCallback.Exception"/>
        /// or <see cref="ICorDebugManagedCallback2.Exception"/>) and the associated call to <see cref="CorDebugController.Continue"/>.
        /// </remarks>
        public void InterceptCurrentException(ICorDebugFrame pFrame)
        {
            TryInterceptCurrentException(pFrame).ThrowOnNotOK();
        }

        /// <summary>
        /// Allows a debugger to intercept the current exception on this thread.
        /// </summary>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> that represents the active stack frame.</param>
        /// <remarks>
        /// The InterceptCurrentException method can be called between an exception callback (<see cref="ICorDebugManagedCallback.Exception"/>
        /// or <see cref="ICorDebugManagedCallback2.Exception"/>) and the associated call to <see cref="CorDebugController.Continue"/>.
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugThread3 Raw3 => (ICorDebugThread3) Raw;

        #region ActiveInternalFrames

        /// <summary>
        /// Returns an array of internal frames (<see cref="ICorDebugInternalFrame2"/> objects) on the stack.
        /// </summary>
        public CorDebugInternalFrame[] ActiveInternalFrames
        {
            get
            {
                CorDebugInternalFrame[] ppInternalFramesResult;
                TryGetActiveInternalFrames(out ppInternalFramesResult).ThrowOnNotOK();

                return ppInternalFramesResult;
            }
        }

        /// <summary>
        /// Returns an array of internal frames (<see cref="ICorDebugInternalFrame2"/> objects) on the stack.
        /// </summary>
        /// <param name="ppInternalFramesResult">[in, out] A pointer to the address of an array of internal frames on the stack.</param>
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
        /// Use the <see cref="ActiveInternalFrames"/> property to return actual stack frames.
        /// </remarks>
        public HRESULT TryGetActiveInternalFrames(out CorDebugInternalFrame[] ppInternalFramesResult)
        {
            /*HRESULT GetActiveInternalFrames(
            [In] int cInternalFrames,
            [Out] out int pcInternalFrames,
            [Out, MarshalAs(UnmanagedType.LPArray)] ICorDebugInternalFrame2[] ppInternalFrames);*/
            int cInternalFrames = 0;
            int pcInternalFrames;
            ICorDebugInternalFrame2[] ppInternalFrames = null;
            HRESULT hr = Raw3.GetActiveInternalFrames(cInternalFrames, out pcInternalFrames, ppInternalFrames);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cInternalFrames = pcInternalFrames;
            ppInternalFrames = new ICorDebugInternalFrame2[cInternalFrames];
            hr = Raw3.GetActiveInternalFrames(cInternalFrames, out pcInternalFrames, ppInternalFrames);

            if (hr == HRESULT.S_OK)
            {
                ppInternalFramesResult = ppInternalFrames.Select(v => new CorDebugInternalFrame((ICorDebugInternalFrame) v)).ToArray();

                return hr;
            }

            fail:
            ppInternalFramesResult = default(CorDebugInternalFrame[]);

            return hr;
        }

        #endregion
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
            CorDebugStackWalk ppStackWalkResult;
            TryCreateStackWalk(out ppStackWalkResult).ThrowOnNotOK();

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
            /*HRESULT CreateStackWalk([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugStackWalk ppStackWalk);*/
            ICorDebugStackWalk ppStackWalk;
            HRESULT hr = Raw3.CreateStackWalk(out ppStackWalk);

            if (hr == HRESULT.S_OK)
                ppStackWalkResult = new CorDebugStackWalk(ppStackWalk);
            else
                ppStackWalkResult = default(CorDebugStackWalk);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugThread4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugThread4 Raw4 => (ICorDebugThread4) Raw;

        #region BlockingObjects

        /// <summary>
        /// Provides an ordered enumeration of <see cref="CorDebugBlockingObject"/> structures that provide thread blocking information.
        /// </summary>
        public CorDebugBlockingObjectEnum BlockingObjects
        {
            get
            {
                CorDebugBlockingObjectEnum ppBlockingObjectEnumResult;
                TryGetBlockingObjects(out ppBlockingObjectEnumResult).ThrowOnNotOK();

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
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugBlockingObjectEnum ppBlockingObjectEnum);*/
            ICorDebugBlockingObjectEnum ppBlockingObjectEnum;
            HRESULT hr = Raw4.GetBlockingObjects(out ppBlockingObjectEnum);

            if (hr == HRESULT.S_OK)
                ppBlockingObjectEnumResult = new CorDebugBlockingObjectEnum(ppBlockingObjectEnum);
            else
                ppBlockingObjectEnumResult = default(CorDebugBlockingObjectEnum);

            return hr;
        }

        #endregion
        #region CurrentCustomDebuggerNotification

        /// <summary>
        /// Gets the current <see cref="ICorDebugManagedCallback3.CustomNotification"/> object on the current thread.
        /// </summary>
        public CorDebugValue CurrentCustomDebuggerNotification
        {
            get
            {
                CorDebugValue ppNotificationObjectResult;
                TryGetCurrentCustomDebuggerNotification(out ppNotificationObjectResult).ThrowOnNotOK();

                return ppNotificationObjectResult;
            }
        }

        /// <summary>
        /// Gets the current <see cref="ICorDebugManagedCallback3.CustomNotification"/> object on the current thread.
        /// </summary>
        /// <param name="ppNotificationObjectResult">[out] A pointer to the current <see cref="ICorDebugManagedCallback3.CustomNotification"/> object on the current thread.</param>
        /// <remarks>
        /// The value of ppNotificationObject is null if the method is not called from within a ICorDebugManagedCallback3::CustomNotification
        /// callback, or if no current notification object exists.
        /// </remarks>
        public HRESULT TryGetCurrentCustomDebuggerNotification(out CorDebugValue ppNotificationObjectResult)
        {
            /*HRESULT GetCurrentCustomDebuggerNotification(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppNotificationObject);*/
            ICorDebugValue ppNotificationObject;
            HRESULT hr = Raw4.GetCurrentCustomDebuggerNotification(out ppNotificationObject);

            if (hr == HRESULT.S_OK)
                ppNotificationObjectResult = CorDebugValue.New(ppNotificationObject);
            else
                ppNotificationObjectResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region HadUnhandledException

        /// <summary>
        /// Indicates whether the thread has ever had an unhandled exception.
        /// </summary>
        /// <remarks>
        /// This method indicates whether the thread has ever had an unhandled exception. By the time the unhandled exception
        /// callback is triggered or native JIT-attach is initiated, this method is guaranteed to return S_OK. There is no
        /// guarantee that the <see cref="CurrentException"/> property will return the unhandled exception; however, it
        /// will if the process has not yet been continued after getting the unhandled exception callback or upon native JIT-attach.
        /// Furthermore, it is possible (although unlikely) to have more than one thread with an unhandled exception at the
        /// time native JIT-attach is triggered. In such a case there is no way to determine which exception triggered the
        /// JIT-attach.
        /// </remarks>
        public void HadUnhandledException()
        {
            TryHadUnhandledException().ThrowOnNotOK();
        }

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
        /// guarantee that the <see cref="CurrentException"/> property will return the unhandled exception; however, it
        /// will if the process has not yet been continued after getting the unhandled exception callback or upon native JIT-attach.
        /// Furthermore, it is possible (although unlikely) to have more than one thread with an unhandled exception at the
        /// time native JIT-attach is triggered. In such a case there is no way to determine which exception triggered the
        /// JIT-attach.
        /// </remarks>
        public HRESULT TryHadUnhandledException()
        {
            /*HRESULT HadUnhandledException();*/
            return Raw4.HadUnhandledException();
        }

        #endregion
        #endregion
    }
}