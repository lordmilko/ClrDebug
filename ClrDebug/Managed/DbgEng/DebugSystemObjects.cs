using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;
using static ClrDebug.Extensions;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugSystemObjects : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugSystemObjects = new Guid("6b86fe2c-2c4f-4f0c-9da2-174311acc327");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugSystemObjectsVtbl* Vtbl => (IDebugSystemObjectsVtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugSystemObjects2Vtbl* Vtbl2 => (IDebugSystemObjects2Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugSystemObjects3Vtbl* Vtbl3 => (IDebugSystemObjects3Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugSystemObjects4Vtbl* Vtbl4 => (IDebugSystemObjects4Vtbl*) base.Vtbl;

        #endregion
        
        public DebugSystemObjects(IntPtr raw) : base(raw, IID_IDebugSystemObjects)
        {
        }

        public DebugSystemObjects(IDebugSystemObjects raw) : base(raw)
        {
        }

        #region IDebugSystemObjects
        #region EventThread

        /// <summary>
        /// The GetEventThread method returns the engine thread ID for the thread on which the last event occurred.
        /// </summary>
        public int EventThread
        {
            get
            {
                int id;
                TryGetEventThread(out id).ThrowDbgEngNotOK();

                return id;
            }
        }

        /// <summary>
        /// The GetEventThread method returns the engine thread ID for the thread on which the last event occurred.
        /// </summary>
        /// <param name="id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, the engine thread ID for the virtual thread representing the processor on which the event
        /// occurred is returned. For more information about threads, see Threads and Processes. For details about debugger
        /// engine events, see Monitoring Events.
        /// </remarks>
        public HRESULT TryGetEventThread(out int id)
        {
            InitDelegate(ref getEventThread, Vtbl->GetEventThread);

            /*HRESULT GetEventThread(
            [Out] out int Id);*/
            return getEventThread(Raw, out id);
        }

        #endregion
        #region EventProcess

        /// <summary>
        /// The GetEventProcess method returns the engine process ID for the process on which the last event occurred.
        /// </summary>
        public int EventProcess
        {
            get
            {
                int id;
                TryGetEventProcess(out id).ThrowDbgEngNotOK();

                return id;
            }
        }

        /// <summary>
        /// The GetEventProcess method returns the engine process ID for the process on which the last event occurred.
        /// </summary>
        /// <param name="id">[out] Receives the engine process ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, the engine process ID for the virtual process representing the kernel is returned. For
        /// more information about processes, see Threads and Processes. For details about debugger engine events, see Monitoring
        /// Events.
        /// </remarks>
        public HRESULT TryGetEventProcess(out int id)
        {
            InitDelegate(ref getEventProcess, Vtbl->GetEventProcess);

            /*HRESULT GetEventProcess(
            [Out] out int Id);*/
            return getEventProcess(Raw, out id);
        }

        #endregion
        #region CurrentThreadId

        /// <summary>
        /// The GetCurrentThreadId method returns the engine thread ID for the current thread.
        /// </summary>
        public int CurrentThreadId
        {
            get
            {
                int id;
                TryGetCurrentThreadId(out id).ThrowDbgEngNotOK();

                return id;
            }
            set
            {
                TrySetCurrentThreadId(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetCurrentThreadId method returns the engine thread ID for the current thread.
        /// </summary>
        /// <param name="id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about threads, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetCurrentThreadId(out int id)
        {
            InitDelegate(ref getCurrentThreadId, Vtbl->GetCurrentThreadId);

            /*HRESULT GetCurrentThreadId(
            [Out] out int Id);*/
            return getCurrentThreadId(Raw, out id);
        }

        /// <summary>
        /// The SetCurrentThreadId method makes the specified thread the current thread.
        /// </summary>
        /// <param name="id">[in] Specifies the engine thread ID of the thread that is to become the current thread.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method may also change the current process, current target, and current computer. If the thread is changed,
        /// the callback <see cref="IDebugEventCallbacks.ChangeEngineState"/> will be called with the DEBUG_CES_CURRENT_THREAD
        /// bit set.
        /// </remarks>
        public HRESULT TrySetCurrentThreadId(int id)
        {
            InitDelegate(ref setCurrentThreadId, Vtbl->SetCurrentThreadId);

            /*HRESULT SetCurrentThreadId(
            [In] int Id);*/
            return setCurrentThreadId(Raw, id);
        }

        #endregion
        #region CurrentProcessId

        /// <summary>
        /// The GetCurrentProcessId method returns the engine process ID for the current process.
        /// </summary>
        public int CurrentProcessId
        {
            get
            {
                int id;
                TryGetCurrentProcessId(out id).ThrowDbgEngNotOK();

                return id;
            }
            set
            {
                TrySetCurrentProcessId(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetCurrentProcessId method returns the engine process ID for the current process.
        /// </summary>
        /// <param name="id">[out] Receives the engine process ID for the current process.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about processes, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetCurrentProcessId(out int id)
        {
            InitDelegate(ref getCurrentProcessId, Vtbl->GetCurrentProcessId);

            /*HRESULT GetCurrentProcessId(
            [Out] out int Id);*/
            return getCurrentProcessId(Raw, out id);
        }

        /// <summary>
        /// The SetCurrentProcessId method makes the specified process the current process.
        /// </summary>
        /// <param name="id">[in] Specifies the engine process ID for the process that is to become the current process.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method also changes the current thread, and may change the current target and current computer. If the process
        /// is changed, the callback <see cref="IDebugEventCallbacks.ChangeEngineState"/> will be called with the DEBUG_CES_CURRENT_THREAD
        /// bit set.
        /// </remarks>
        public HRESULT TrySetCurrentProcessId(int id)
        {
            InitDelegate(ref setCurrentProcessId, Vtbl->SetCurrentProcessId);

            /*HRESULT SetCurrentProcessId(
            [In] int Id);*/
            return setCurrentProcessId(Raw, id);
        }

        #endregion
        #region NumberThreads

        /// <summary>
        /// The GetNumberThreads method returns the number of threads in the current process.
        /// </summary>
        public int NumberThreads
        {
            get
            {
                int number;
                TryGetNumberThreads(out number).ThrowDbgEngNotOK();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberThreads method returns the number of threads in the current process.
        /// </summary>
        /// <param name="number">[out] Receives the number of threads in the current process.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, there is a virtual thread representing each processor. In user-mode debugging, the number
        /// of threads changes with the <see cref="IDebugEventCallbacks.CreateThread"/> and <see cref="IDebugEventCallbacks.ExitThread"/>
        /// events. For more information about threads, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetNumberThreads(out int number)
        {
            InitDelegate(ref getNumberThreads, Vtbl->GetNumberThreads);

            /*HRESULT GetNumberThreads(
            [Out] out int Number);*/
            return getNumberThreads(Raw, out number);
        }

        #endregion
        #region TotalNumberThreads

        /// <summary>
        /// The GetTotalNumberThreads method returns the total number of threads for all the processes in the current target, in addition to the largest number of threads in any process for the current target.
        /// </summary>
        public GetTotalNumberThreadsResult TotalNumberThreads
        {
            get
            {
                GetTotalNumberThreadsResult result;
                TryGetTotalNumberThreads(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetTotalNumberThreads method returns the total number of threads for all the processes in the current target, in addition to the largest number of threads in any process for the current target.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about threads, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetTotalNumberThreads(out GetTotalNumberThreadsResult result)
        {
            InitDelegate(ref getTotalNumberThreads, Vtbl->GetTotalNumberThreads);
            /*HRESULT GetTotalNumberThreads(
            [Out] out int Total,
            [Out] out int LargestProcess);*/
            int total;
            int largestProcess;
            HRESULT hr = getTotalNumberThreads(Raw, out total, out largestProcess);

            if (hr == HRESULT.S_OK)
                result = new GetTotalNumberThreadsResult(total, largestProcess);
            else
                result = default(GetTotalNumberThreadsResult);

            return hr;
        }

        #endregion
        #region CurrentThreadDataOffset

        /// <summary>
        /// The GetCurrentThreadDataOffset method returns the location of the system data structure for the current thread.
        /// </summary>
        public long CurrentThreadDataOffset
        {
            get
            {
                long offset;
                TryGetCurrentThreadDataOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
        }

        /// <summary>
        /// The GetCurrentThreadDataOffset method returns the location of the system data structure for the current thread.
        /// </summary>
        /// <param name="offset">[out] Receives the location of the system data structure for the current thread.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In user-mode debugging, the location returned is of the thread environment block (TEB) for the current thread.
        /// This is the same location returned by <see cref="CurrentThreadTeb"/>. In kernel-mode debugging, the location
        /// returned is of the KTHREAD structure of the system thread that was executing on the processor represented by the
        /// current thread when the last event occurred.
        /// </remarks>
        public HRESULT TryGetCurrentThreadDataOffset(out long offset)
        {
            InitDelegate(ref getCurrentThreadDataOffset, Vtbl->GetCurrentThreadDataOffset);

            /*HRESULT GetCurrentThreadDataOffset(
            [Out] out long Offset);*/
            return getCurrentThreadDataOffset(Raw, out offset);
        }

        #endregion
        #region CurrentThreadTeb

        /// <summary>
        /// The GetCurrentThreadTeb method returns the location of the thread environment block (TEB) for the current thread.
        /// </summary>
        public long CurrentThreadTeb
        {
            get
            {
                long offset;
                TryGetCurrentThreadTeb(out offset).ThrowDbgEngNotOK();

                return offset;
            }
        }

        /// <summary>
        /// The GetCurrentThreadTeb method returns the location of the thread environment block (TEB) for the current thread.
        /// </summary>
        /// <param name="offset">[out] Receives the location in the target's virtual address space of the TEB for the current thread.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In user-mode debugging, this method provides the same information as <see cref="CurrentThreadDataOffset"/>.
        /// In kernel-mode debugging, the location returned is of the TEB structure of the system thread that was executing
        /// on the processor represented by the current thread when the last event occurred.
        /// </remarks>
        public HRESULT TryGetCurrentThreadTeb(out long offset)
        {
            InitDelegate(ref getCurrentThreadTeb, Vtbl->GetCurrentThreadTeb);

            /*HRESULT GetCurrentThreadTeb(
            [Out] out long Offset);*/
            return getCurrentThreadTeb(Raw, out offset);
        }

        #endregion
        #region CurrentThreadSystemId

        /// <summary>
        /// The GetCurrentThreadSystemId method returns the system thread ID of the current thread.
        /// </summary>
        public int CurrentThreadSystemId
        {
            get
            {
                int sysId;
                TryGetCurrentThreadSystemId(out sysId).ThrowDbgEngNotOK();

                return sysId;
            }
        }

        /// <summary>
        /// The GetCurrentThreadSystemId method returns the system thread ID of the current thread.
        /// </summary>
        /// <param name="sysId">[out] Receives the system thread ID.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging. For more information about threads, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetCurrentThreadSystemId(out int sysId)
        {
            InitDelegate(ref getCurrentThreadSystemId, Vtbl->GetCurrentThreadSystemId);

            /*HRESULT GetCurrentThreadSystemId(
            [Out] out int SysId);*/
            return getCurrentThreadSystemId(Raw, out sysId);
        }

        #endregion
        #region CurrentThreadHandle

        /// <summary>
        /// The GetCurrentThreadHandle method returns the system handle for the current thread.
        /// </summary>
        public long CurrentThreadHandle
        {
            get
            {
                long handle;
                TryGetCurrentThreadHandle(out handle).ThrowDbgEngNotOK();

                return handle;
            }
        }

        /// <summary>
        /// The GetCurrentThreadHandle method returns the system handle for the current thread.
        /// </summary>
        /// <param name="handle">[out] Receives the current thread's system handle.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, an artificial handle is created because the threads are virtual threads. For more information
        /// about threads, see Threads and Processes. For details on system handles, see Handles.
        /// </remarks>
        public HRESULT TryGetCurrentThreadHandle(out long handle)
        {
            InitDelegate(ref getCurrentThreadHandle, Vtbl->GetCurrentThreadHandle);

            /*HRESULT GetCurrentThreadHandle(
            [Out] out long Handle);*/
            return getCurrentThreadHandle(Raw, out handle);
        }

        #endregion
        #region NumberProcesses

        /// <summary>
        /// The GetNumberProcesses method returns the number of processes for the current target.
        /// </summary>
        public int NumberProcesses
        {
            get
            {
                int number;
                TryGetNumberProcesses(out number).ThrowDbgEngNotOK();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberProcesses method returns the number of processes for the current target.
        /// </summary>
        /// <param name="number">[out] Receives the number of processes.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, there is only a single virtual process representing the kernel. In user-mode debugging,
        /// the number of processes changes with the create-process and exit-process debugging events. For more information
        /// about processes, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetNumberProcesses(out int number)
        {
            InitDelegate(ref getNumberProcesses, Vtbl->GetNumberProcesses);

            /*HRESULT GetNumberProcesses(
            [Out] out int Number);*/
            return getNumberProcesses(Raw, out number);
        }

        #endregion
        #region CurrentProcessDataOffset

        /// <summary>
        /// The GetCurrentProcessDataOffset method returns the location of the system data structure describing the current process.
        /// </summary>
        public long CurrentProcessDataOffset
        {
            get
            {
                long offset;
                TryGetCurrentProcessDataOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
        }

        /// <summary>
        /// The GetCurrentProcessDataOffset method returns the location of the system data structure describing the current process.
        /// </summary>
        /// <param name="offset">[out] Receives the location in the target's virtual address space of the system data structure describing the current process.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In user-mode debugging, the location returned is of the process environment block (PEB) for the current process.
        /// This is the same location returned by <see cref="CurrentProcessPeb"/>. In kernel-mode debugging, the location
        /// returned is of the KPROCESS structure for the system process in which the last event occurred.
        /// </remarks>
        public HRESULT TryGetCurrentProcessDataOffset(out long offset)
        {
            InitDelegate(ref getCurrentProcessDataOffset, Vtbl->GetCurrentProcessDataOffset);

            /*HRESULT GetCurrentProcessDataOffset(
            [Out] out long Offset);*/
            return getCurrentProcessDataOffset(Raw, out offset);
        }

        #endregion
        #region CurrentProcessPeb

        /// <summary>
        /// The GetCurrentProcessPeb method returns the process environment block (PEB) of the current process.
        /// </summary>
        public long CurrentProcessPeb
        {
            get
            {
                long offset;
                TryGetCurrentProcessPeb(out offset).ThrowDbgEngNotOK();

                return offset;
            }
        }

        /// <summary>
        /// The GetCurrentProcessPeb method returns the process environment block (PEB) of the current process.
        /// </summary>
        /// <param name="offset">[out] Receives the location in the target's virtual address space of the PEB of the current process.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In user-mode debugging, this method provides the same information as <see cref="CurrentProcessDataOffset"/>.
        /// In kernel-mode debugging, the location returned is that of the PEB structure for the system process in which the
        /// last event occurred.
        /// </remarks>
        public HRESULT TryGetCurrentProcessPeb(out long offset)
        {
            InitDelegate(ref getCurrentProcessPeb, Vtbl->GetCurrentProcessPeb);

            /*HRESULT GetCurrentProcessPeb(
            [Out] out long Offset);*/
            return getCurrentProcessPeb(Raw, out offset);
        }

        #endregion
        #region CurrentProcessSystemId

        /// <summary>
        /// The GetCurrentProcessSystemId method returns the system process ID of the current process.
        /// </summary>
        public int CurrentProcessSystemId
        {
            get
            {
                int sysId;
                TryGetCurrentProcessSystemId(out sysId).ThrowDbgEngNotOK();

                return sysId;
            }
        }

        /// <summary>
        /// The GetCurrentProcessSystemId method returns the system process ID of the current process.
        /// </summary>
        /// <param name="sysId">[out] Receives the system process ID.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging. For more information about processes, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetCurrentProcessSystemId(out int sysId)
        {
            InitDelegate(ref getCurrentProcessSystemId, Vtbl->GetCurrentProcessSystemId);

            /*HRESULT GetCurrentProcessSystemId(
            [Out] out int SysId);*/
            return getCurrentProcessSystemId(Raw, out sysId);
        }

        #endregion
        #region CurrentProcessHandle

        /// <summary>
        /// The GetCurrentProcessHandle method returns the system handle for the current process.
        /// </summary>
        public long CurrentProcessHandle
        {
            get
            {
                long handle;
                TryGetCurrentProcessHandle(out handle).ThrowDbgEngNotOK();

                return handle;
            }
        }

        /// <summary>
        /// The GetCurrentProcessHandle method returns the system handle for the current process.
        /// </summary>
        /// <param name="handle">[out] Receives the system handle of the current process.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, the only process in the target is the virtual process created for the kernel. In this
        /// case, an artificial handle is created. The artificial handle can only be used with the debugger engine API. For
        /// more information about processes, see Threads and Processes. For details on system handles, see Handles.
        /// </remarks>
        public HRESULT TryGetCurrentProcessHandle(out long handle)
        {
            InitDelegate(ref getCurrentProcessHandle, Vtbl->GetCurrentProcessHandle);

            /*HRESULT GetCurrentProcessHandle(
            [Out] out long Handle);*/
            return getCurrentProcessHandle(Raw, out handle);
        }

        #endregion
        #region CurrentProcessExecutableName

        /// <summary>
        /// The GetCurrentProcessExecutableName method returns the name of executable file loaded in the current process.
        /// </summary>
        public string CurrentProcessExecutableName
        {
            get
            {
                string bufferResult;
                TryGetCurrentProcessExecutableName(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
        }

        /// <summary>
        /// The GetCurrentProcessExecutableName method returns the name of executable file loaded in the current process.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Receives the name of the executable file. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// These methods are only available in user-mode debugging. If the engine cannot determine the name of the executable
        /// file, it writes the string "?NoImage?" to the buffer. For more information about processes, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetCurrentProcessExecutableName(out string bufferResult)
        {
            InitDelegate(ref getCurrentProcessExecutableName, Vtbl->GetCurrentProcessExecutableName);
            /*HRESULT GetCurrentProcessExecutableName(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int ExeSize);*/
            char[] buffer;
            int bufferSize = 0;
            int exeSize;
            HRESULT hr = getCurrentProcessExecutableName(Raw, null, bufferSize, out exeSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = exeSize;
            buffer = new char[bufferSize];
            hr = getCurrentProcessExecutableName(Raw, buffer, bufferSize, out exeSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, exeSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetThreadIdsByIndex

        /// <summary>
        /// The GetThreadIdsByIndex method returns the engine and system thread IDs for the specified threads in the current process.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first thread whose IDs are requested.</param>
        /// <param name="count">[in] Specifies the number of threads whose IDs are requested.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The index of the first thread is zero. The index of the last thread is the number of threads returned by <see cref="NumberThreads"/>
        /// minus one. For more information about threads, see Threads and Processes.
        /// </remarks>
        public GetThreadIdsByIndexResult GetThreadIdsByIndex(int start, int count)
        {
            GetThreadIdsByIndexResult result;
            TryGetThreadIdsByIndex(start, count, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetThreadIdsByIndex method returns the engine and system thread IDs for the specified threads in the current process.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first thread whose IDs are requested.</param>
        /// <param name="count">[in] Specifies the number of threads whose IDs are requested.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The index of the first thread is zero. The index of the last thread is the number of threads returned by <see cref="NumberThreads"/>
        /// minus one. For more information about threads, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetThreadIdsByIndex(int start, int count, out GetThreadIdsByIndexResult result)
        {
            InitDelegate(ref getThreadIdsByIndex, Vtbl->GetThreadIdsByIndex);
            /*HRESULT GetThreadIdsByIndex(
            [In] int Start,
            [In] int Count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Ids,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] SysIds);*/
            int[] ids = new int[count];
            int[] sysIds = new int[count];
            HRESULT hr = getThreadIdsByIndex(Raw, start, count, ids, sysIds);

            if (hr == HRESULT.S_OK)
                result = new GetThreadIdsByIndexResult(ids, sysIds);
            else
                result = default(GetThreadIdsByIndexResult);

            return hr;
        }

        #endregion
        #region GetThreadIdByProcessor

        /// <summary>
        /// The GetThreadIdByProcessor method returns the engine thread ID for the kernel-mode virtual thread corresponding to the specified processor.
        /// </summary>
        /// <param name="processor">[in] Specifies the processor corresponding to the desired thread.</param>
        /// <returns>[out] Receives the engine thread ID.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For more information about threads, see Threads and Processes.
        /// </remarks>
        public int GetThreadIdByProcessor(int processor)
        {
            int id;
            TryGetThreadIdByProcessor(processor, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// The GetThreadIdByProcessor method returns the engine thread ID for the kernel-mode virtual thread corresponding to the specified processor.
        /// </summary>
        /// <param name="processor">[in] Specifies the processor corresponding to the desired thread.</param>
        /// <param name="id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For more information about threads, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetThreadIdByProcessor(int processor, out int id)
        {
            InitDelegate(ref getThreadIdByProcessor, Vtbl->GetThreadIdByProcessor);

            /*HRESULT GetThreadIdByProcessor(
            [In] int Processor,
            [Out] out int Id);*/
            return getThreadIdByProcessor(Raw, processor, out id);
        }

        #endregion
        #region GetThreadIdByDataOffset

        /// <summary>
        /// The GetThreadIdByDataOffset method returns the engine thread ID for the specified thread. The thread is specified by its system data structure.
        /// </summary>
        /// <param name="offset">[in] Specifies the location of the system data structure for the thread.</param>
        /// <returns>[out] Receives the engine thread ID.</returns>
        /// <remarks>
        /// In kernel-mode debugging, this method returns the engine thread ID for the virtual thread representing the processor
        /// on which the specified thread is executing. If the thread is not executing on a processor, this method will fail.
        /// For more information about threads, see Threads and Processes.
        /// </remarks>
        public int GetThreadIdByDataOffset(long offset)
        {
            int id;
            TryGetThreadIdByDataOffset(offset, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// The GetThreadIdByDataOffset method returns the engine thread ID for the specified thread. The thread is specified by its system data structure.
        /// </summary>
        /// <param name="offset">[in] Specifies the location of the system data structure for the thread.</param>
        /// <param name="id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, this method returns the engine thread ID for the virtual thread representing the processor
        /// on which the specified thread is executing. If the thread is not executing on a processor, this method will fail.
        /// For more information about threads, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetThreadIdByDataOffset(long offset, out int id)
        {
            InitDelegate(ref getThreadIdByDataOffset, Vtbl->GetThreadIdByDataOffset);

            /*HRESULT GetThreadIdByDataOffset(
            [In] long Offset,
            [Out] out int Id);*/
            return getThreadIdByDataOffset(Raw, offset, out id);
        }

        #endregion
        #region GetThreadIdByTeb

        /// <summary>
        /// The GetThreadIdByTeb method returns the engine thread ID of the specified thread. The thread is specified by its thread environment block (TEB).
        /// </summary>
        /// <param name="offset">[in] Specifies the location of the thread's TEB.</param>
        /// <returns>[out] Receives the engine thread ID.</returns>
        /// <remarks>
        /// In kernel-mode debugging, this method returns the engine thread ID for the virtual thread representing the processor
        /// on which the specified thread is executing. If the thread is not executing on a processor, this method will fail.
        /// For more information about threads, see Threads and Processes.
        /// </remarks>
        public int GetThreadIdByTeb(long offset)
        {
            int id;
            TryGetThreadIdByTeb(offset, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// The GetThreadIdByTeb method returns the engine thread ID of the specified thread. The thread is specified by its thread environment block (TEB).
        /// </summary>
        /// <param name="offset">[in] Specifies the location of the thread's TEB.</param>
        /// <param name="id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, this method returns the engine thread ID for the virtual thread representing the processor
        /// on which the specified thread is executing. If the thread is not executing on a processor, this method will fail.
        /// For more information about threads, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetThreadIdByTeb(long offset, out int id)
        {
            InitDelegate(ref getThreadIdByTeb, Vtbl->GetThreadIdByTeb);

            /*HRESULT GetThreadIdByTeb(
            [In] long Offset,
            [Out] out int Id);*/
            return getThreadIdByTeb(Raw, offset, out id);
        }

        #endregion
        #region GetThreadIdBySystemId

        /// <summary>
        /// The GetThreadIdBySystemId method returns the engine thread ID for the specified thread. The thread is specified by its system thread ID.
        /// </summary>
        /// <param name="sysId">[in] Specifies the system thread ID.</param>
        /// <returns>[out] Receives the engine thread ID.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging. For more information about threads, see Threads and Processes.
        /// </remarks>
        public int GetThreadIdBySystemId(int sysId)
        {
            int id;
            TryGetThreadIdBySystemId(sysId, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// The GetThreadIdBySystemId method returns the engine thread ID for the specified thread. The thread is specified by its system thread ID.
        /// </summary>
        /// <param name="sysId">[in] Specifies the system thread ID.</param>
        /// <param name="id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging. For more information about threads, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetThreadIdBySystemId(int sysId, out int id)
        {
            InitDelegate(ref getThreadIdBySystemId, Vtbl->GetThreadIdBySystemId);

            /*HRESULT GetThreadIdBySystemId(
            [In] int SysId,
            [Out] out int Id);*/
            return getThreadIdBySystemId(Raw, sysId, out id);
        }

        #endregion
        #region GetThreadIdByHandle

        /// <summary>
        /// The GetThreadIdByHandle method returns the engine thread ID for the specified thread. The thread is specified by its system handle.
        /// </summary>
        /// <param name="handle">[in] Specifies the system handle of the thread whose thread ID is requested.</param>
        /// <returns>[out] Receives the engine thread ID.</returns>
        /// <remarks>
        /// In kernel-mode debugging, because the handle is an artificial handle for a processor, this method returns the engine
        /// thread ID for the virtual thread representing that processor. For more information about threads, see Threads and
        /// Processes. For details on system handles, see Handles.
        /// </remarks>
        public int GetThreadIdByHandle(long handle)
        {
            int id;
            TryGetThreadIdByHandle(handle, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// The GetThreadIdByHandle method returns the engine thread ID for the specified thread. The thread is specified by its system handle.
        /// </summary>
        /// <param name="handle">[in] Specifies the system handle of the thread whose thread ID is requested.</param>
        /// <param name="id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, because the handle is an artificial handle for a processor, this method returns the engine
        /// thread ID for the virtual thread representing that processor. For more information about threads, see Threads and
        /// Processes. For details on system handles, see Handles.
        /// </remarks>
        public HRESULT TryGetThreadIdByHandle(long handle, out int id)
        {
            InitDelegate(ref getThreadIdByHandle, Vtbl->GetThreadIdByHandle);

            /*HRESULT GetThreadIdByHandle(
            [In] long Handle,
            [Out] out int Id);*/
            return getThreadIdByHandle(Raw, handle, out id);
        }

        #endregion
        #region GetProcessIdsByIndex

        /// <summary>
        /// The GetProcessIdsByIndex method returns the engine process ID and system process ID for the specified processes in the current target.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first process whose ID is requested.</param>
        /// <param name="count">[in] Specifies the number of processes whose IDs are requested.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The index of the first process is zero. The index of the last process is the number of processes returned by <see
        /// cref="NumberProcesses"/> minus one. For more information about processes, see Threads and Processes.
        /// </remarks>
        public GetProcessIdsByIndexResult GetProcessIdsByIndex(int start, int count)
        {
            GetProcessIdsByIndexResult result;
            TryGetProcessIdsByIndex(start, count, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetProcessIdsByIndex method returns the engine process ID and system process ID for the specified processes in the current target.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first process whose ID is requested.</param>
        /// <param name="count">[in] Specifies the number of processes whose IDs are requested.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The index of the first process is zero. The index of the last process is the number of processes returned by <see
        /// cref="NumberProcesses"/> minus one. For more information about processes, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetProcessIdsByIndex(int start, int count, out GetProcessIdsByIndexResult result)
        {
            InitDelegate(ref getProcessIdsByIndex, Vtbl->GetProcessIdsByIndex);
            /*HRESULT GetProcessIdsByIndex(
            [In] int Start,
            [In] int Count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Ids,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] SysIds);*/
            int[] ids = new int[count];
            int[] sysIds = new int[count];
            HRESULT hr = getProcessIdsByIndex(Raw, start, count, ids, sysIds);

            if (hr == HRESULT.S_OK)
                result = new GetProcessIdsByIndexResult(ids, sysIds);
            else
                result = default(GetProcessIdsByIndexResult);

            return hr;
        }

        #endregion
        #region GetProcessIdByDataOffset

        /// <summary>
        /// The GetProcessIdByDataOffset method returns the engine process ID for the specified process. The process is specified by its data offset.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the data offset of the process.</param>
        /// <returns>[out] Receives the engine process ID for the process.</returns>
        /// <remarks>
        /// This method is currently not available in kernel-mode debugging. In user-mode debugging, this method behaves the
        /// same as <see cref="GetProcessIdByPeb"/>. For more information about processes, see Threads and Processes.
        /// </remarks>
        public int GetProcessIdByDataOffset(long offset)
        {
            int id;
            TryGetProcessIdByDataOffset(offset, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// The GetProcessIdByDataOffset method returns the engine process ID for the specified process. The process is specified by its data offset.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the data offset of the process.</param>
        /// <param name="id">[out] Receives the engine process ID for the process.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is currently not available in kernel-mode debugging. In user-mode debugging, this method behaves the
        /// same as <see cref="GetProcessIdByPeb"/>. For more information about processes, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetProcessIdByDataOffset(long offset, out int id)
        {
            InitDelegate(ref getProcessIdByDataOffset, Vtbl->GetProcessIdByDataOffset);

            /*HRESULT GetProcessIdByDataOffset(
            [In] long Offset,
            [Out] out int Id);*/
            return getProcessIdByDataOffset(Raw, offset, out id);
        }

        #endregion
        #region GetProcessIdByPeb

        /// <summary>
        /// The GetProcessIdByPeb method returns the engine process ID for the specified process. The process is specified by its process environment block (PEB).
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the PEB of the process whose process ID is requested.</param>
        /// <returns>[out] Receives the engine process ID.</returns>
        /// <remarks>
        /// This method is not available in kernel-mode debugging. For more information about processes, see Threads and Processes.
        /// </remarks>
        public int GetProcessIdByPeb(long offset)
        {
            int id;
            TryGetProcessIdByPeb(offset, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// The GetProcessIdByPeb method returns the engine process ID for the specified process. The process is specified by its process environment block (PEB).
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the PEB of the process whose process ID is requested.</param>
        /// <param name="id">[out] Receives the engine process ID.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is not available in kernel-mode debugging. For more information about processes, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetProcessIdByPeb(long offset, out int id)
        {
            InitDelegate(ref getProcessIdByPeb, Vtbl->GetProcessIdByPeb);

            /*HRESULT GetProcessIdByPeb(
            [In] long Offset,
            [Out] out int Id);*/
            return getProcessIdByPeb(Raw, offset, out id);
        }

        #endregion
        #region GetProcessIdBySystemId

        /// <summary>
        /// The GetProcessIdBySystemId method returns the engine process ID for a process specified by its system process ID.
        /// </summary>
        /// <param name="sysId">[in] Specifies the system process ID.</param>
        /// <returns>[out] Receives the engine process ID.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging. For more information about processes, see Threads and Processes.
        /// </remarks>
        public int GetProcessIdBySystemId(int sysId)
        {
            int id;
            TryGetProcessIdBySystemId(sysId, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// The GetProcessIdBySystemId method returns the engine process ID for a process specified by its system process ID.
        /// </summary>
        /// <param name="sysId">[in] Specifies the system process ID.</param>
        /// <param name="id">[out] Receives the engine process ID.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging. For more information about processes, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetProcessIdBySystemId(int sysId, out int id)
        {
            InitDelegate(ref getProcessIdBySystemId, Vtbl->GetProcessIdBySystemId);

            /*HRESULT GetProcessIdBySystemId(
            [In] int SysId,
            [Out] out int Id);*/
            return getProcessIdBySystemId(Raw, sysId, out id);
        }

        #endregion
        #region GetProcessIdByHandle

        /// <summary>
        /// The GetProcessIdByHandle method returns the engine process ID for the specified process. The process is specified by its system handle.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the process whose process ID is requested. This handle must be a process handle previously retrieved from the debugger engine.</param>
        /// <returns>[out] Receives the engine process ID.</returns>
        /// <remarks>
        /// For more information about processes, see Threads and Processes. For details on system handles, see Handles.
        /// </remarks>
        public int GetProcessIdByHandle(long handle)
        {
            int id;
            TryGetProcessIdByHandle(handle, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// The GetProcessIdByHandle method returns the engine process ID for the specified process. The process is specified by its system handle.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the process whose process ID is requested. This handle must be a process handle previously retrieved from the debugger engine.</param>
        /// <param name="id">[out] Receives the engine process ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about processes, see Threads and Processes. For details on system handles, see Handles.
        /// </remarks>
        public HRESULT TryGetProcessIdByHandle(long handle, out int id)
        {
            InitDelegate(ref getProcessIdByHandle, Vtbl->GetProcessIdByHandle);

            /*HRESULT GetProcessIdByHandle(
            [In] long Handle,
            [Out] out int Id);*/
            return getProcessIdByHandle(Raw, handle, out id);
        }

        #endregion
        #endregion
        #region IDebugSystemObjects2
        #region CurrentProcessUpTime

        /// <summary>
        /// The GetCurrentProcessUpTime method returns the length of time the current process has been running.
        /// </summary>
        public int CurrentProcessUpTime
        {
            get
            {
                int upTime;
                TryGetCurrentProcessUpTime(out upTime).ThrowDbgEngNotOK();

                return upTime;
            }
        }

        /// <summary>
        /// The GetCurrentProcessUpTime method returns the length of time the current process has been running.
        /// </summary>
        /// <param name="upTime">[out] Receives the number of seconds the current process has been running.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetCurrentProcessUpTime(out int upTime)
        {
            InitDelegate(ref getCurrentProcessUpTime, Vtbl2->GetCurrentProcessUpTime);

            /*HRESULT GetCurrentProcessUpTime(
            [Out] out int UpTime);*/
            return getCurrentProcessUpTime(Raw, out upTime);
        }

        #endregion
        #region ImplicitThreadDataOffset

        /// <summary>
        /// The GetImplicitThreadDataOffset method returns the implicit thread for the current process.
        /// </summary>
        public long ImplicitThreadDataOffset
        {
            get
            {
                long offset;
                TryGetImplicitThreadDataOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
            set
            {
                TrySetImplicitThreadDataOffset(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetImplicitThreadDataOffset method returns the implicit thread for the current process.
        /// </summary>
        /// <param name="offset">[out] Receives the location in the target's memory address space of the data structure of the system thread that is the implicit thread for the current process.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, the data structure is the KTHREAD structure for the process. In user-mode debugging,
        /// the data structure is the thread environment block (TEB) for the process. For more information about the implicit
        /// thread, see Threads and Processes. For details on the KTHREAD structure and TEB, see Microsoft Windows Internals
        /// by David Solomon and Mark Russinovich.
        /// </remarks>
        public HRESULT TryGetImplicitThreadDataOffset(out long offset)
        {
            InitDelegate(ref getImplicitThreadDataOffset, Vtbl2->GetImplicitThreadDataOffset);

            /*HRESULT GetImplicitThreadDataOffset(
            [Out] out long Offset);*/
            return getImplicitThreadDataOffset(Raw, out offset);
        }

        /// <summary>
        /// The SetImplicitThreadDataOffset method sets the implicit thread for the current process.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's memory address space of the data structure of the system thread that is to become the implicit thread for the current process.<para/>
        /// If this is zero, the implicit thread for the current process is set to the default implicit thread.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, the data structure is the KTHREAD structure for the process. In user-mode debugging,
        /// the data structure is the thread environment block (TEB) for the process.
        /// </remarks>
        public HRESULT TrySetImplicitThreadDataOffset(long offset)
        {
            InitDelegate(ref setImplicitThreadDataOffset, Vtbl2->SetImplicitThreadDataOffset);

            /*HRESULT SetImplicitThreadDataOffset(
            [In] long Offset);*/
            return setImplicitThreadDataOffset(Raw, offset);
        }

        #endregion
        #region ImplicitProcessDataOffset

        /// <summary>
        /// The GetImplicitProcessDataOffset method returns the implicit process for the current target.
        /// </summary>
        public long ImplicitProcessDataOffset
        {
            get
            {
                long offset;
                TryGetImplicitProcessDataOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
            set
            {
                TrySetImplicitProcessDataOffset(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetImplicitProcessDataOffset method returns the implicit process for the current target.
        /// </summary>
        /// <param name="offset">[out] Receives the location in the target's memory address space of the data structure of the system process that is the implicit process for the current target.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, the data structure is the KPROCESS structure for the process. In user-mode debugging,
        /// the data structure is the process environment block (PEB) for the process. For more information about the implicit
        /// process, see Threads and Processes. For details on the KPROCESS and PEB structures, see Microsoft Windows Internals
        /// by David Solomon and Mark Russinovich.
        /// </remarks>
        public HRESULT TryGetImplicitProcessDataOffset(out long offset)
        {
            InitDelegate(ref getImplicitProcessDataOffset, Vtbl2->GetImplicitProcessDataOffset);

            /*HRESULT GetImplicitProcessDataOffset(
            [Out] out long Offset);*/
            return getImplicitProcessDataOffset(Raw, out offset);
        }

        /// <summary>
        /// The SetImplicitProcessDataOffset method sets the implicit process for the current target.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's memory address space of the data structure of the system process that is to become the implicit process for the current target.<para/>
        /// If this is zero, the implicit process for the current target is set to the default implicit process.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, the data structure is the KPROCESS structure for the process. In user-mode debugging,
        /// the data structure is the process environment block (PEB) for the process.
        /// </remarks>
        public HRESULT TrySetImplicitProcessDataOffset(long offset)
        {
            InitDelegate(ref setImplicitProcessDataOffset, Vtbl2->SetImplicitProcessDataOffset);

            /*HRESULT SetImplicitProcessDataOffset(
            [In] long Offset);*/
            return setImplicitProcessDataOffset(Raw, offset);
        }

        #endregion
        #endregion
        #region IDebugSystemObjects3
        #region EventSystem

        /// <summary>
        /// The GetEventSystem method returns the engine target ID for the target in which the last event occurred.
        /// </summary>
        public int EventSystem
        {
            get
            {
                int id;
                TryGetEventSystem(out id).ThrowDbgEngNotOK();

                return id;
            }
        }

        /// <summary>
        /// The GetEventSystem method returns the engine target ID for the target in which the last event occurred.
        /// </summary>
        /// <param name="id">[out] Receives the engine target ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetEventSystem(out int id)
        {
            InitDelegate(ref getEventSystem, Vtbl3->GetEventSystem);

            /*HRESULT GetEventSystem(
            [Out] out int Id);*/
            return getEventSystem(Raw, out id);
        }

        #endregion
        #region CurrentSystemId

        /// <summary>
        /// The GetCurrentSystemId method returns the engine target ID for the current process.
        /// </summary>
        public int CurrentSystemId
        {
            get
            {
                int id;
                TryGetCurrentSystemId(out id).ThrowDbgEngNotOK();

                return id;
            }
            set
            {
                TrySetCurrentSystemId(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetCurrentSystemId method returns the engine target ID for the current process.
        /// </summary>
        /// <param name="id">[out] Receives the engine target ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetCurrentSystemId(out int id)
        {
            InitDelegate(ref getCurrentSystemId, Vtbl3->GetCurrentSystemId);

            /*HRESULT GetCurrentSystemId(
            [Out] out int Id);*/
            return getCurrentSystemId(Raw, out id);
        }

        /// <summary>
        /// The SetCurrentSystemId method makes the specified target the current target.
        /// </summary>
        /// <param name="id">[in] Specifies the engine target ID for the target that is to become the current target.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method also sets the current thread and current process, and may change the current computer. If the current
        /// target is changed, the callback <see cref="IDebugEventCallbacks.ChangeEngineState"/> will be called with the DEBUG_CES_CURRENT_THREAD
        /// bit set.
        /// </remarks>
        public HRESULT TrySetCurrentSystemId(int id)
        {
            InitDelegate(ref setCurrentSystemId, Vtbl3->SetCurrentSystemId);

            /*HRESULT SetCurrentSystemId(
            [In] int Id);*/
            return setCurrentSystemId(Raw, id);
        }

        #endregion
        #region NumberSystems

        /// <summary>
        /// The GetNumberSystems method returns the number of targets to which the engine is currently connected.
        /// </summary>
        public int NumberSystems
        {
            get
            {
                int count;
                TryGetNumberSystems(out count).ThrowDbgEngNotOK();

                return count;
            }
        }

        /// <summary>
        /// The GetNumberSystems method returns the number of targets to which the engine is currently connected.
        /// </summary>
        /// <param name="count">[out] Receives the number of targets.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetNumberSystems(out int count)
        {
            InitDelegate(ref getNumberSystems, Vtbl3->GetNumberSystems);

            /*HRESULT GetNumberSystems(
            [Out] out int Count);*/
            return getNumberSystems(Raw, out count);
        }

        #endregion
        #region TotalNumberThreadsAndProcesses

        /// <summary>
        /// The GetTotalNumberThreadsAndProcesses method returns the total number of threads and processes in all the targets the engine is attached to, in addition to the largest number of threads and processes in a target.
        /// </summary>
        public GetTotalNumberThreadsAndProcessesResult TotalNumberThreadsAndProcesses
        {
            get
            {
                GetTotalNumberThreadsAndProcessesResult result;
                TryGetTotalNumberThreadsAndProcesses(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetTotalNumberThreadsAndProcesses method returns the total number of threads and processes in all the targets the engine is attached to, in addition to the largest number of threads and processes in a target.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If no target is found, all the values are set to zero.
        /// </remarks>
        public HRESULT TryGetTotalNumberThreadsAndProcesses(out GetTotalNumberThreadsAndProcessesResult result)
        {
            InitDelegate(ref getTotalNumberThreadsAndProcesses, Vtbl3->GetTotalNumberThreadsAndProcesses);
            /*HRESULT GetTotalNumberThreadsAndProcesses(
            [Out] out int TotalThreads,
            [Out] out int TotalProcesses,
            [Out] out int LargestProcessThreads,
            [Out] out int LargestSystemThreads,
            [Out] out int LargestSystemProcesses);*/
            int totalThreads;
            int totalProcesses;
            int largestProcessThreads;
            int largestSystemThreads;
            int largestSystemProcesses;
            HRESULT hr = getTotalNumberThreadsAndProcesses(Raw, out totalThreads, out totalProcesses, out largestProcessThreads, out largestSystemThreads, out largestSystemProcesses);

            if (hr == HRESULT.S_OK)
                result = new GetTotalNumberThreadsAndProcessesResult(totalThreads, totalProcesses, largestProcessThreads, largestSystemThreads, largestSystemProcesses);
            else
                result = default(GetTotalNumberThreadsAndProcessesResult);

            return hr;
        }

        #endregion
        #region CurrentSystemServer

        /// <summary>
        /// Gets the server for the current process.
        /// </summary>
        public long CurrentSystemServer
        {
            get
            {
                long server;
                TryGetCurrentSystemServer(out server).ThrowDbgEngNotOK();

                return server;
            }
        }

        /// <summary>
        /// Gets the server for the current process.
        /// </summary>
        /// <param name="server">[out] A pointer to the returned server value.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetCurrentSystemServer(out long server)
        {
            InitDelegate(ref getCurrentSystemServer, Vtbl3->GetCurrentSystemServer);

            /*HRESULT GetCurrentSystemServer(
            [Out] out long server);*/
            return getCurrentSystemServer(Raw, out server);
        }

        #endregion
        #region CurrentSystemServerName

        /// <summary>
        /// Gets the server name for the current process.
        /// </summary>
        public string CurrentSystemServerName
        {
            get
            {
                string bufferResult;
                TryGetCurrentSystemServerName(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
        }

        /// <summary>
        /// Gets the server name for the current process.
        /// </summary>
        /// <param name="bufferResult">[out] A pointer to an output buffer.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetCurrentSystemServerName(out string bufferResult)
        {
            InitDelegate(ref getCurrentSystemServerName, Vtbl3->GetCurrentSystemServerName);
            /*HRESULT GetCurrentSystemServerName(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int Size,
            [Out] out int Needed);*/
            char[] buffer;
            int size = 0;
            int needed;
            HRESULT hr = getCurrentSystemServerName(Raw, null, size, out needed);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            size = needed;
            buffer = new char[size];
            hr = getCurrentSystemServerName(Raw, buffer, size, out needed);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, needed);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetSystemIdsByIndex

        /// <summary>
        /// The GetSystemIdsByIndex method returns the engine target IDs for the specified targets.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first target whose target ID is requested.</param>
        /// <param name="count">[in] Specifies the number of processes whose IDs are requested.</param>
        /// <returns>[out] Receives the engine target IDs. If Ids is NULL, this information is not returned; otherwise, Ids is treated as an array of Count ULONG values.</returns>
        /// <remarks>
        /// The index of the first target is zero. The index of the last target is the number of targets returned by <see cref="NumberSystems"/>
        /// minus one.
        /// </remarks>
        public int[] GetSystemIdsByIndex(int start, int count)
        {
            int[] ids;
            TryGetSystemIdsByIndex(start, count, out ids).ThrowDbgEngNotOK();

            return ids;
        }

        /// <summary>
        /// The GetSystemIdsByIndex method returns the engine target IDs for the specified targets.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first target whose target ID is requested.</param>
        /// <param name="count">[in] Specifies the number of processes whose IDs are requested.</param>
        /// <param name="ids">[out] Receives the engine target IDs. If Ids is NULL, this information is not returned; otherwise, Ids is treated as an array of Count ULONG values.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The index of the first target is zero. The index of the last target is the number of targets returned by <see cref="NumberSystems"/>
        /// minus one.
        /// </remarks>
        public HRESULT TryGetSystemIdsByIndex(int start, int count, out int[] ids)
        {
            InitDelegate(ref getSystemIdsByIndex, Vtbl3->GetSystemIdsByIndex);
            /*HRESULT GetSystemIdsByIndex(
            [In] int Start,
            [In] int Count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Ids);*/
            ids = new int[count];
            HRESULT hr = getSystemIdsByIndex(Raw, start, count, ids);

            return hr;
        }

        #endregion
        #region GetSystemByServer

        /// <summary>
        /// Gets the system for a server.
        /// </summary>
        public int GetSystemByServer(long server)
        {
            int id;
            TryGetSystemByServer(server, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// Gets the system for a server.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetSystemByServer(long server, out int id)
        {
            InitDelegate(ref getSystemByServer, Vtbl3->GetSystemByServer);

            /*HRESULT GetSystemByServer(
            [In] long Server,
            [Out] out int Id);*/
            return getSystemByServer(Raw, server, out id);
        }

        #endregion
        #endregion
        #region IDebugSystemObjects4
        #region CurrentProcessExecutableNameWide

        /// <summary>
        /// The GetCurrentProcessExecutableNameWide method returns the name of executable file loaded in the current process.
        /// </summary>
        public string CurrentProcessExecutableNameWide
        {
            get
            {
                string bufferResult;
                TryGetCurrentProcessExecutableNameWide(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
        }

        /// <summary>
        /// The GetCurrentProcessExecutableNameWide method returns the name of executable file loaded in the current process.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Receives the name of the executable file. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// These methods are only available in user-mode debugging. If the engine cannot determine the name of the executable
        /// file, it writes the string "?NoImage?" to the buffer. For more information about processes, see Threads and Processes.
        /// </remarks>
        public HRESULT TryGetCurrentProcessExecutableNameWide(out string bufferResult)
        {
            InitDelegate(ref getCurrentProcessExecutableNameWide, Vtbl4->GetCurrentProcessExecutableNameWide);
            /*HRESULT GetCurrentProcessExecutableNameWide(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int ExeSize);*/
            char[] buffer;
            int bufferSize = 0;
            int exeSize;
            HRESULT hr = getCurrentProcessExecutableNameWide(Raw, null, bufferSize, out exeSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = exeSize;
            buffer = new char[bufferSize];
            hr = getCurrentProcessExecutableNameWide(Raw, buffer, bufferSize, out exeSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, exeSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region CurrentSystemServerNameWide

        /// <summary>
        /// Gets the server name for the current process.
        /// </summary>
        public string CurrentSystemServerNameWide
        {
            get
            {
                string bufferResult;
                TryGetCurrentSystemServerNameWide(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
        }

        /// <summary>
        /// Gets the server name for the current process.
        /// </summary>
        /// <param name="bufferResult">[out] A pointer to an output buffer as a Unicode character string.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetCurrentSystemServerNameWide(out string bufferResult)
        {
            InitDelegate(ref getCurrentSystemServerNameWide, Vtbl4->GetCurrentSystemServerNameWide);
            /*HRESULT GetCurrentSystemServerNameWide(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);*/
            char[] buffer;
            int bufferSize = 0;
            int nameSize;
            HRESULT hr = getCurrentSystemServerNameWide(Raw, null, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = nameSize;
            buffer = new char[bufferSize];
            hr = getCurrentSystemServerNameWide(Raw, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, nameSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugSystemObjects

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEventThreadDelegate getEventThread;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEventProcessDelegate getEventProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentThreadIdDelegate getCurrentThreadId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetCurrentThreadIdDelegate setCurrentThreadId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentProcessIdDelegate getCurrentProcessId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetCurrentProcessIdDelegate setCurrentProcessId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberThreadsDelegate getNumberThreads;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTotalNumberThreadsDelegate getTotalNumberThreads;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentThreadDataOffsetDelegate getCurrentThreadDataOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentThreadTebDelegate getCurrentThreadTeb;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentThreadSystemIdDelegate getCurrentThreadSystemId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentThreadHandleDelegate getCurrentThreadHandle;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberProcessesDelegate getNumberProcesses;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentProcessDataOffsetDelegate getCurrentProcessDataOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentProcessPebDelegate getCurrentProcessPeb;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentProcessSystemIdDelegate getCurrentProcessSystemId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentProcessHandleDelegate getCurrentProcessHandle;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentProcessExecutableNameDelegate getCurrentProcessExecutableName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadIdsByIndexDelegate getThreadIdsByIndex;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadIdByProcessorDelegate getThreadIdByProcessor;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadIdByDataOffsetDelegate getThreadIdByDataOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadIdByTebDelegate getThreadIdByTeb;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadIdBySystemIdDelegate getThreadIdBySystemId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadIdByHandleDelegate getThreadIdByHandle;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetProcessIdsByIndexDelegate getProcessIdsByIndex;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetProcessIdByDataOffsetDelegate getProcessIdByDataOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetProcessIdByPebDelegate getProcessIdByPeb;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetProcessIdBySystemIdDelegate getProcessIdBySystemId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetProcessIdByHandleDelegate getProcessIdByHandle;

        #endregion
        #region IDebugSystemObjects2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentProcessUpTimeDelegate getCurrentProcessUpTime;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetImplicitThreadDataOffsetDelegate getImplicitThreadDataOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetImplicitThreadDataOffsetDelegate setImplicitThreadDataOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetImplicitProcessDataOffsetDelegate getImplicitProcessDataOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetImplicitProcessDataOffsetDelegate setImplicitProcessDataOffset;

        #endregion
        #region IDebugSystemObjects3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEventSystemDelegate getEventSystem;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentSystemIdDelegate getCurrentSystemId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetCurrentSystemIdDelegate setCurrentSystemId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberSystemsDelegate getNumberSystems;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTotalNumberThreadsAndProcessesDelegate getTotalNumberThreadsAndProcesses;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentSystemServerDelegate getCurrentSystemServer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentSystemServerNameDelegate getCurrentSystemServerName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSystemIdsByIndexDelegate getSystemIdsByIndex;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSystemByServerDelegate getSystemByServer;

        #endregion
        #region IDebugSystemObjects4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentProcessExecutableNameWideDelegate getCurrentProcessExecutableNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentSystemServerNameWideDelegate getCurrentSystemServerNameWide;

        #endregion
        #endregion
        #region Delegates
        #region IDebugSystemObjects

        private delegate HRESULT GetEventThreadDelegate(IntPtr self, [Out] out int Id);
        private delegate HRESULT GetEventProcessDelegate(IntPtr self, [Out] out int Id);
        private delegate HRESULT GetCurrentThreadIdDelegate(IntPtr self, [Out] out int Id);
        private delegate HRESULT SetCurrentThreadIdDelegate(IntPtr self, [In] int Id);
        private delegate HRESULT GetCurrentProcessIdDelegate(IntPtr self, [Out] out int Id);
        private delegate HRESULT SetCurrentProcessIdDelegate(IntPtr self, [In] int Id);
        private delegate HRESULT GetNumberThreadsDelegate(IntPtr self, [Out] out int Number);
        private delegate HRESULT GetTotalNumberThreadsDelegate(IntPtr self, [Out] out int Total, [Out] out int LargestProcess);
        private delegate HRESULT GetCurrentThreadDataOffsetDelegate(IntPtr self, [Out] out long Offset);
        private delegate HRESULT GetCurrentThreadTebDelegate(IntPtr self, [Out] out long Offset);
        private delegate HRESULT GetCurrentThreadSystemIdDelegate(IntPtr self, [Out] out int SysId);
        private delegate HRESULT GetCurrentThreadHandleDelegate(IntPtr self, [Out] out long Handle);
        private delegate HRESULT GetNumberProcessesDelegate(IntPtr self, [Out] out int Number);
        private delegate HRESULT GetCurrentProcessDataOffsetDelegate(IntPtr self, [Out] out long Offset);
        private delegate HRESULT GetCurrentProcessPebDelegate(IntPtr self, [Out] out long Offset);
        private delegate HRESULT GetCurrentProcessSystemIdDelegate(IntPtr self, [Out] out int SysId);
        private delegate HRESULT GetCurrentProcessHandleDelegate(IntPtr self, [Out] out long Handle);
        private delegate HRESULT GetCurrentProcessExecutableNameDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int ExeSize);
        private delegate HRESULT GetThreadIdsByIndexDelegate(IntPtr self, [In] int Start, [In] int Count, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Ids, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] SysIds);
        private delegate HRESULT GetThreadIdByProcessorDelegate(IntPtr self, [In] int Processor, [Out] out int Id);
        private delegate HRESULT GetThreadIdByDataOffsetDelegate(IntPtr self, [In] long Offset, [Out] out int Id);
        private delegate HRESULT GetThreadIdByTebDelegate(IntPtr self, [In] long Offset, [Out] out int Id);
        private delegate HRESULT GetThreadIdBySystemIdDelegate(IntPtr self, [In] int SysId, [Out] out int Id);
        private delegate HRESULT GetThreadIdByHandleDelegate(IntPtr self, [In] long Handle, [Out] out int Id);
        private delegate HRESULT GetProcessIdsByIndexDelegate(IntPtr self, [In] int Start, [In] int Count, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Ids, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] SysIds);
        private delegate HRESULT GetProcessIdByDataOffsetDelegate(IntPtr self, [In] long Offset, [Out] out int Id);
        private delegate HRESULT GetProcessIdByPebDelegate(IntPtr self, [In] long Offset, [Out] out int Id);
        private delegate HRESULT GetProcessIdBySystemIdDelegate(IntPtr self, [In] int SysId, [Out] out int Id);
        private delegate HRESULT GetProcessIdByHandleDelegate(IntPtr self, [In] long Handle, [Out] out int Id);

        #endregion
        #region IDebugSystemObjects2

        private delegate HRESULT GetCurrentProcessUpTimeDelegate(IntPtr self, [Out] out int UpTime);
        private delegate HRESULT GetImplicitThreadDataOffsetDelegate(IntPtr self, [Out] out long Offset);
        private delegate HRESULT SetImplicitThreadDataOffsetDelegate(IntPtr self, [In] long Offset);
        private delegate HRESULT GetImplicitProcessDataOffsetDelegate(IntPtr self, [Out] out long Offset);
        private delegate HRESULT SetImplicitProcessDataOffsetDelegate(IntPtr self, [In] long Offset);

        #endregion
        #region IDebugSystemObjects3

        private delegate HRESULT GetEventSystemDelegate(IntPtr self, [Out] out int Id);
        private delegate HRESULT GetCurrentSystemIdDelegate(IntPtr self, [Out] out int Id);
        private delegate HRESULT SetCurrentSystemIdDelegate(IntPtr self, [In] int Id);
        private delegate HRESULT GetNumberSystemsDelegate(IntPtr self, [Out] out int Count);
        private delegate HRESULT GetTotalNumberThreadsAndProcessesDelegate(IntPtr self, [Out] out int TotalThreads, [Out] out int TotalProcesses, [Out] out int LargestProcessThreads, [Out] out int LargestSystemThreads, [Out] out int LargestSystemProcesses);
        private delegate HRESULT GetCurrentSystemServerDelegate(IntPtr self, [Out] out long server);
        private delegate HRESULT GetCurrentSystemServerNameDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer, [In] int Size, [Out] out int Needed);
        private delegate HRESULT GetSystemIdsByIndexDelegate(IntPtr self, [In] int Start, [In] int Count, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Ids);
        private delegate HRESULT GetSystemByServerDelegate(IntPtr self, [In] long Server, [Out] out int Id);

        #endregion
        #region IDebugSystemObjects4

        private delegate HRESULT GetCurrentProcessExecutableNameWideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int ExeSize);
        private delegate HRESULT GetCurrentSystemServerNameWideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int NameSize);

        #endregion
        #endregion
    }
}
