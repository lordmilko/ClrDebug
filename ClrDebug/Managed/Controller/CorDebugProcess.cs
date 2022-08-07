using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents a process that is executing managed code. This interface is a subclass of <see cref="ICorDebugController"/>.
    /// </summary>
    public class CorDebugProcess : CorDebugController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugProcess"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugProcess(ICorDebugProcess raw) : base(raw)
        {
        }

        #region ICorDebugProcess

        public new ICorDebugProcess Raw => (ICorDebugProcess) base.Raw;

        #region Id

        /// <summary>
        /// Gets the operating system (OS) ID of the process.
        /// </summary>
        public int Id
        {
            get
            {
                int pdwProcessId;
                TryGetID(out pdwProcessId).ThrowOnNotOK();

                return pdwProcessId;
            }
        }

        /// <summary>
        /// Gets the operating system (OS) ID of the process.
        /// </summary>
        /// <param name="pdwProcessId">[out] The unique ID of the process.</param>
        public HRESULT TryGetID(out int pdwProcessId)
        {
            /*HRESULT GetID([Out] out int pdwProcessId);*/
            return Raw.GetID(out pdwProcessId);
        }

        #endregion
        #region Handle

        /// <summary>
        /// Gets a handle to the process.
        /// </summary>
        public IntPtr Handle
        {
            get
            {
                IntPtr phProcessHandle;
                TryGetHandle(out phProcessHandle).ThrowOnNotOK();

                return phProcessHandle;
            }
        }

        /// <summary>
        /// Gets a handle to the process.
        /// </summary>
        /// <param name="phProcessHandle">[out] A pointer to an HPROCESS that is the handle to the process.</param>
        /// <remarks>
        /// The retrieved handle is owned by the debugging interface. The debugger should duplicate the handle before using
        /// it.
        /// </remarks>
        public HRESULT TryGetHandle(out IntPtr phProcessHandle)
        {
            /*HRESULT GetHandle([Out] out IntPtr phProcessHandle);*/
            return Raw.GetHandle(out phProcessHandle);
        }

        #endregion
        #region Object

        /// <summary>
        /// This method has not been implemented.
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
        /// This method has not been implemented.
        /// </summary>
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
        #region HelperThreadID

        /// <summary>
        /// Gets the operating system (OS) thread ID of the debugger's internal helper thread.
        /// </summary>
        public int HelperThreadID
        {
            get
            {
                int pThreadID;
                TryGetHelperThreadID(out pThreadID).ThrowOnNotOK();

                return pThreadID;
            }
        }

        /// <summary>
        /// Gets the operating system (OS) thread ID of the debugger's internal helper thread.
        /// </summary>
        /// <param name="pThreadID">[out] A pointer to the OS thread ID of the debugger's internal helper thread.</param>
        /// <remarks>
        /// During managed and unmanaged debugging, it is the debugger's responsibility to ensure that the thread with the
        /// specified ID remains running if it hits a breakpoint placed by the debugger. A debugger may also wish to hide this
        /// thread from the user. If no helper thread exists in the process yet, the GetHelperThreadID method returns zero
        /// in *pThreadID. You cannot cache the thread ID of the helper thread, because it may change over time. You must re-query
        /// the thread ID at every stopping event. The thread ID of the debugger's helper thread will be correct on every unmanaged
        /// <see cref="ICorDebugManagedCallback.CreateThread"/> event, thus allowing a debugger to determine the thread ID
        /// of its helper thread and hide it from the user. A thread that is identified as a helper thread during an unmanaged
        /// <see cref="ICorDebugManagedCallback.CreateThread"/> event will never run managed user code.
        /// </remarks>
        public HRESULT TryGetHelperThreadID(out int pThreadID)
        {
            /*HRESULT GetHelperThreadID([Out] out int pThreadID);*/
            return Raw.GetHelperThreadID(out pThreadID);
        }

        #endregion
        #region GetThread

        /// <summary>
        /// Gets this process's thread that has the specified operating system (OS) thread ID.
        /// </summary>
        /// <param name="dwThreadId">[in] The OS thread ID of the thread to be retrieved.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugThread"/> object that represents the thread.</returns>
        public CorDebugThread GetThread(int dwThreadId)
        {
            CorDebugThread ppThreadResult;
            TryGetThread(dwThreadId, out ppThreadResult).ThrowOnNotOK();

            return ppThreadResult;
        }

        /// <summary>
        /// Gets this process's thread that has the specified operating system (OS) thread ID.
        /// </summary>
        /// <param name="dwThreadId">[in] The OS thread ID of the thread to be retrieved.</param>
        /// <param name="ppThreadResult">[out] A pointer to the address of an <see cref="ICorDebugThread"/> object that represents the thread.</param>
        public HRESULT TryGetThread(int dwThreadId, out CorDebugThread ppThreadResult)
        {
            /*HRESULT GetThread([In] int dwThreadId, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);*/
            ICorDebugThread ppThread;
            HRESULT hr = Raw.GetThread(dwThreadId, out ppThread);

            if (hr == HRESULT.S_OK)
                ppThreadResult = new CorDebugThread(ppThread);
            else
                ppThreadResult = default(CorDebugThread);

            return hr;
        }

        #endregion
        #region EnumerateObjects

        /// <summary>
        /// This method has not been implemented.
        /// </summary>
        public CORDB_ADDRESS[] Objects => EnumerateObjects().ToArray();

        /// <summary>
        /// This method has not been implemented.
        /// </summary>
        public CorDebugObjectEnum EnumerateObjects()
        {
            CorDebugObjectEnum ppObjectsResult;
            TryEnumerateObjects(out ppObjectsResult).ThrowOnNotOK();

            return ppObjectsResult;
        }

        /// <summary>
        /// This method has not been implemented.
        /// </summary>
        public HRESULT TryEnumerateObjects(out CorDebugObjectEnum ppObjectsResult)
        {
            /*HRESULT EnumerateObjects([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugObjectEnum ppObjects);*/
            ICorDebugObjectEnum ppObjects;
            HRESULT hr = Raw.EnumerateObjects(out ppObjects);

            if (hr == HRESULT.S_OK)
                ppObjectsResult = new CorDebugObjectEnum(ppObjects);
            else
                ppObjectsResult = default(CorDebugObjectEnum);

            return hr;
        }

        #endregion
        #region IsTransitionStub

        /// <summary>
        /// Gets a value that indicates whether an address is inside a stub that will cause a transition to managed code.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the address in question.</param>
        /// <returns>[out] A pointer to a Boolean value that is true if the specified address is inside a stub that will cause a transition to managed code; otherwise *pbTransitionStub is false.</returns>
        /// <remarks>
        /// The IsTransitionStub method can be used by unmanaged stepping code to decide when to return stepping control to
        /// the managed stepper. You can also identity transition stubs by looking at information in the portable executable
        /// (PE) file.
        /// </remarks>
        public bool IsTransitionStub(CORDB_ADDRESS address)
        {
            bool pbTransitionStub;
            TryIsTransitionStub(address, out pbTransitionStub).ThrowOnNotOK();

            return pbTransitionStub;
        }

        /// <summary>
        /// Gets a value that indicates whether an address is inside a stub that will cause a transition to managed code.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the address in question.</param>
        /// <param name="pbTransitionStub">[out] A pointer to a Boolean value that is true if the specified address is inside a stub that will cause a transition to managed code; otherwise *pbTransitionStub is false.</param>
        /// <remarks>
        /// The IsTransitionStub method can be used by unmanaged stepping code to decide when to return stepping control to
        /// the managed stepper. You can also identity transition stubs by looking at information in the portable executable
        /// (PE) file.
        /// </remarks>
        public HRESULT TryIsTransitionStub(CORDB_ADDRESS address, out bool pbTransitionStub)
        {
            /*HRESULT IsTransitionStub([In] CORDB_ADDRESS address, [Out] out bool pbTransitionStub);*/
            return Raw.IsTransitionStub(address, out pbTransitionStub);
        }

        #endregion
        #region IsOSSuspended

        /// <summary>
        /// Gets a value that indicates whether the specified thread has been suspended as a result of the debugger stopping this process.
        /// </summary>
        /// <param name="threadID">[in] The ID of thread in question.</param>
        /// <returns>[out] A pointer to a Boolean value that is true if the specified thread has been suspended; otherwise *pbSuspended is false.</returns>
        /// <remarks>
        /// When the specified thread has been suspended as a result of the debugger stopping this process, the specified thread's
        /// Win32 suspend count is incremented by one. The debugger user interface (UI) may want to take this information into
        /// account if it displays the operating system (OS) suspend count of the thread to the user. The IsOSSuspended method
        /// makes sense only in the context of unmanaged debugging. During managed debugging, threads are cooperatively suspended
        /// rather than OS-suspended.
        /// </remarks>
        public bool IsOSSuspended(int threadID)
        {
            bool pbSuspended;
            TryIsOSSuspended(threadID, out pbSuspended).ThrowOnNotOK();

            return pbSuspended;
        }

        /// <summary>
        /// Gets a value that indicates whether the specified thread has been suspended as a result of the debugger stopping this process.
        /// </summary>
        /// <param name="threadID">[in] The ID of thread in question.</param>
        /// <param name="pbSuspended">[out] A pointer to a Boolean value that is true if the specified thread has been suspended; otherwise *pbSuspended is false.</param>
        /// <remarks>
        /// When the specified thread has been suspended as a result of the debugger stopping this process, the specified thread's
        /// Win32 suspend count is incremented by one. The debugger user interface (UI) may want to take this information into
        /// account if it displays the operating system (OS) suspend count of the thread to the user. The IsOSSuspended method
        /// makes sense only in the context of unmanaged debugging. During managed debugging, threads are cooperatively suspended
        /// rather than OS-suspended.
        /// </remarks>
        public HRESULT TryIsOSSuspended(int threadID, out bool pbSuspended)
        {
            /*HRESULT IsOSSuspended([In] int threadID, [Out] out bool pbSuspended);*/
            return Raw.IsOSSuspended(threadID, out pbSuspended);
        }

        #endregion
        #region GetThreadContext

        /// <summary>
        /// Gets the context for the given thread in this process.
        /// </summary>
        /// <param name="threadID">[in] The ID of the thread for which to retrieve the context.</param>
        /// <param name="contextSize">[in] The size of the context array.</param>
        /// <param name="context">[in, out] An array of bytes that describe the thread's context. The context specifies the architecture of the processor on which the thread is executing.</param>
        /// <remarks>
        /// The debugger should call this method rather than the Win32 GetThreadContext method, because the thread may actually
        /// be in a "hijacked" state, in which its context has been temporarily changed. This method should be used only when
        /// a thread is in native code. Use <see cref="ICorDebugRegisterSet"/> for threads in managed code. The data returned
        /// is a context structure for the current platform. Just as with the Win32 GetThreadContext method, the caller should
        /// initialize the context parameter before calling this method.
        /// </remarks>
        public void GetThreadContext(int threadID, int contextSize, IntPtr context)
        {
            TryGetThreadContext(threadID, contextSize, context).ThrowOnNotOK();
        }

        /// <summary>
        /// Gets the context for the given thread in this process.
        /// </summary>
        /// <param name="threadID">[in] The ID of the thread for which to retrieve the context.</param>
        /// <param name="contextSize">[in] The size of the context array.</param>
        /// <param name="context">[in, out] An array of bytes that describe the thread's context. The context specifies the architecture of the processor on which the thread is executing.</param>
        /// <remarks>
        /// The debugger should call this method rather than the Win32 GetThreadContext method, because the thread may actually
        /// be in a "hijacked" state, in which its context has been temporarily changed. This method should be used only when
        /// a thread is in native code. Use <see cref="ICorDebugRegisterSet"/> for threads in managed code. The data returned
        /// is a context structure for the current platform. Just as with the Win32 GetThreadContext method, the caller should
        /// initialize the context parameter before calling this method.
        /// </remarks>
        public HRESULT TryGetThreadContext(int threadID, int contextSize, IntPtr context)
        {
            /*HRESULT GetThreadContext([In] int threadID, [In] int contextSize, [Out] IntPtr context);*/
            return Raw.GetThreadContext(threadID, contextSize, context);
        }

        #endregion
        #region SetThreadContext

        /// <summary>
        /// Sets the context for the given thread in this process.
        /// </summary>
        /// <param name="threadID">[in] The ID of the thread for which to set the context.</param>
        /// <param name="contextSize">[in] The size of the context array.</param>
        /// <param name="context">[in] An array of bytes that describe the thread's context. The context specifies the architecture of the processor on which the thread is executing.</param>
        /// <remarks>
        /// The debugger should call this method rather than the Win32 SetThreadContext function, because the thread may actually
        /// be in a "hijacked" state, in which its context has been temporarily changed. This method should be used only when
        /// a thread is in native code. Use <see cref="ICorDebugRegisterSet"/> for threads in managed code. You should never
        /// need to modify the context of a thread during an out-of-band (OOB) debug event. The data passed must be a context
        /// structure for the current platform. This method can corrupt the runtime if used improperly.
        /// </remarks>
        public void SetThreadContext(int threadID, int contextSize, IntPtr context)
        {
            TrySetThreadContext(threadID, contextSize, context).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the context for the given thread in this process.
        /// </summary>
        /// <param name="threadID">[in] The ID of the thread for which to set the context.</param>
        /// <param name="contextSize">[in] The size of the context array.</param>
        /// <param name="context">[in] An array of bytes that describe the thread's context. The context specifies the architecture of the processor on which the thread is executing.</param>
        /// <remarks>
        /// The debugger should call this method rather than the Win32 SetThreadContext function, because the thread may actually
        /// be in a "hijacked" state, in which its context has been temporarily changed. This method should be used only when
        /// a thread is in native code. Use <see cref="ICorDebugRegisterSet"/> for threads in managed code. You should never
        /// need to modify the context of a thread during an out-of-band (OOB) debug event. The data passed must be a context
        /// structure for the current platform. This method can corrupt the runtime if used improperly.
        /// </remarks>
        public HRESULT TrySetThreadContext(int threadID, int contextSize, IntPtr context)
        {
            /*HRESULT SetThreadContext([In] int threadID, [In] int contextSize, [In] IntPtr context);*/
            return Raw.SetThreadContext(threadID, contextSize, context);
        }

        #endregion
        #region ReadMemory

        /// <summary>
        /// Reads a specified area of memory for this process.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the base address of the memory to be read.</param>
        /// <param name="size">[in] The number of bytes to be read from memory.</param>
        /// <param name="buffer">[out] A buffer that receives the contents of the memory.</param>
        /// <returns>[out] A pointer to the number of bytes transferred into the specified buffer.</returns>
        /// <remarks>
        /// The ReadMemory method is primarily intended to be used by interop debugging to inspect memory regions that are
        /// being used by the unmanaged portion of the debuggee. This method can also be used to read Microsoft intermediate
        /// language (MSIL) code and native JIT-compiled code. Any managed breakpoints will be removed from the data that is
        /// returned in the buffer parameter. No adjustments will be made for native breakpoints set by <see cref="SetUnmanagedBreakpoint"/>.
        /// No caching of process memory is performed.
        /// </remarks>
        public int ReadMemory(CORDB_ADDRESS address, int size, IntPtr buffer)
        {
            int read;
            TryReadMemory(address, size, buffer, out read).ThrowOnNotOK();

            return read;
        }

        /// <summary>
        /// Reads a specified area of memory for this process.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the base address of the memory to be read.</param>
        /// <param name="size">[in] The number of bytes to be read from memory.</param>
        /// <param name="buffer">[out] A buffer that receives the contents of the memory.</param>
        /// <param name="read">[out] A pointer to the number of bytes transferred into the specified buffer.</param>
        /// <remarks>
        /// The ReadMemory method is primarily intended to be used by interop debugging to inspect memory regions that are
        /// being used by the unmanaged portion of the debuggee. This method can also be used to read Microsoft intermediate
        /// language (MSIL) code and native JIT-compiled code. Any managed breakpoints will be removed from the data that is
        /// returned in the buffer parameter. No adjustments will be made for native breakpoints set by <see cref="SetUnmanagedBreakpoint"/>.
        /// No caching of process memory is performed.
        /// </remarks>
        public HRESULT TryReadMemory(CORDB_ADDRESS address, int size, IntPtr buffer, out int read)
        {
            /*HRESULT ReadMemory([In] CORDB_ADDRESS address, [In] int size, [Out] IntPtr buffer, [Out] out int read);*/
            return Raw.ReadMemory(address, size, buffer, out read);
        }

        #endregion
        #region WriteMemory

        /// <summary>
        /// Writes data to an area of memory in this process.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that is the base address of the memory area to which data is written. Before data transfer occurs, the system verifies that the memory area of the specified size, beginning at the base address, is accessible for writing.<para/>
        /// If it is not accessible, the method fails.</param>
        /// <param name="size">[in] The number of bytes to be written to the memory area.</param>
        /// <param name="buffer">[in] A buffer that contains data to be written.</param>
        /// <returns>[out] A pointer to a variable that receives the number of bytes written to the memory area in this process. If written is NULL, this parameter is ignored.</returns>
        /// <remarks>
        /// Data is automatically written behind any breakpoints. In the .NET Framework version 2.0, native debuggers should
        /// not use this method to inject breakpoints into the instruction stream. Use <see cref="SetUnmanagedBreakpoint"/>
        /// instead. The WriteMemory method should be used only outside of managed code. This method can corrupt the runtime
        /// if used improperly.
        /// </remarks>
        public int WriteMemory(CORDB_ADDRESS address, int size, IntPtr buffer)
        {
            int written;
            TryWriteMemory(address, size, buffer, out written).ThrowOnNotOK();

            return written;
        }

        /// <summary>
        /// Writes data to an area of memory in this process.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that is the base address of the memory area to which data is written. Before data transfer occurs, the system verifies that the memory area of the specified size, beginning at the base address, is accessible for writing.<para/>
        /// If it is not accessible, the method fails.</param>
        /// <param name="size">[in] The number of bytes to be written to the memory area.</param>
        /// <param name="buffer">[in] A buffer that contains data to be written.</param>
        /// <param name="written">[out] A pointer to a variable that receives the number of bytes written to the memory area in this process. If written is NULL, this parameter is ignored.</param>
        /// <remarks>
        /// Data is automatically written behind any breakpoints. In the .NET Framework version 2.0, native debuggers should
        /// not use this method to inject breakpoints into the instruction stream. Use <see cref="SetUnmanagedBreakpoint"/>
        /// instead. The WriteMemory method should be used only outside of managed code. This method can corrupt the runtime
        /// if used improperly.
        /// </remarks>
        public HRESULT TryWriteMemory(CORDB_ADDRESS address, int size, IntPtr buffer, out int written)
        {
            /*HRESULT WriteMemory([In] CORDB_ADDRESS address, [In] int size, [In] IntPtr buffer,
            [Out] out int written);*/
            return Raw.WriteMemory(address, size, buffer, out written);
        }

        #endregion
        #region ClearCurrentException

        /// <summary>
        /// Clears the current unmanaged exception on the given thread.
        /// </summary>
        /// <param name="threadID">[in] The ID of the thread on which the current unmanaged exception will be cleared.</param>
        /// <remarks>
        /// Call this method before calling <see cref="CorDebugController.Continue"/> when a thread has reported an unmanaged
        /// exception that should be ignored by the debuggee. This will clear both the outstanding in-band (IB) and out-of-band
        /// (OOB) events on the given thread. All OOB breakpoints and single-step exceptions are automatically cleared. Use
        /// <see cref="CorDebugThread.InterceptCurrentException"/> to intercept the current managed exception on a thread.
        /// </remarks>
        public void ClearCurrentException(int threadID)
        {
            TryClearCurrentException(threadID).ThrowOnNotOK();
        }

        /// <summary>
        /// Clears the current unmanaged exception on the given thread.
        /// </summary>
        /// <param name="threadID">[in] The ID of the thread on which the current unmanaged exception will be cleared.</param>
        /// <remarks>
        /// Call this method before calling <see cref="CorDebugController.Continue"/> when a thread has reported an unmanaged
        /// exception that should be ignored by the debuggee. This will clear both the outstanding in-band (IB) and out-of-band
        /// (OOB) events on the given thread. All OOB breakpoints and single-step exceptions are automatically cleared. Use
        /// <see cref="CorDebugThread.InterceptCurrentException"/> to intercept the current managed exception on a thread.
        /// </remarks>
        public HRESULT TryClearCurrentException(int threadID)
        {
            /*HRESULT ClearCurrentException([In] int threadID);*/
            return Raw.ClearCurrentException(threadID);
        }

        #endregion
        #region EnableLogMessages

        /// <summary>
        /// Enables and disables the transmission of log messages to the debugger.
        /// </summary>
        /// <param name="fOnOff">[in] true enables the transmission of log messages; false disables the transmission.</param>
        /// <remarks>
        /// This method is valid only after the <see cref="ICorDebugManagedCallback.CreateProcess"/> callback occurs.
        /// </remarks>
        public void EnableLogMessages(bool fOnOff)
        {
            TryEnableLogMessages(fOnOff).ThrowOnNotOK();
        }

        /// <summary>
        /// Enables and disables the transmission of log messages to the debugger.
        /// </summary>
        /// <param name="fOnOff">[in] true enables the transmission of log messages; false disables the transmission.</param>
        /// <remarks>
        /// This method is valid only after the <see cref="ICorDebugManagedCallback.CreateProcess"/> callback occurs.
        /// </remarks>
        public HRESULT TryEnableLogMessages(bool fOnOff)
        {
            /*HRESULT EnableLogMessages([In] bool fOnOff);*/
            return Raw.EnableLogMessages(fOnOff);
        }

        #endregion
        #region ModifyLogSwitch

        /// <summary>
        /// Sets the severity level of the specified log switch.
        /// </summary>
        /// <param name="pLogSwitchName">[in] A pointer to a string that specifies the name of the log switch.</param>
        /// <param name="lLevel">[in] The severity level to be set for the specified log switch.</param>
        /// <remarks>
        /// This method is valid only after the <see cref="ICorDebugManagedCallback.CreateProcess"/> callback has occurred.
        /// </remarks>
        public void ModifyLogSwitch(string pLogSwitchName, int lLevel)
        {
            TryModifyLogSwitch(pLogSwitchName, lLevel).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the severity level of the specified log switch.
        /// </summary>
        /// <param name="pLogSwitchName">[in] A pointer to a string that specifies the name of the log switch.</param>
        /// <param name="lLevel">[in] The severity level to be set for the specified log switch.</param>
        /// <remarks>
        /// This method is valid only after the <see cref="ICorDebugManagedCallback.CreateProcess"/> callback has occurred.
        /// </remarks>
        public HRESULT TryModifyLogSwitch(string pLogSwitchName, int lLevel)
        {
            /*HRESULT ModifyLogSwitch([In, MarshalAs(UnmanagedType.LPWStr)] string pLogSwitchName, [In] int lLevel);*/
            return Raw.ModifyLogSwitch(pLogSwitchName, lLevel);
        }

        #endregion
        #region EnumerateAppDomains

        /// <summary>
        /// Enumerates all the application domains in this process.
        /// </summary>
        public CorDebugAppDomain[] AppDomains => EnumerateAppDomains().ToArray();

        /// <summary>
        /// Enumerates all the application domains in this process.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugAppDomainEnum"/> that is an enumerator for the application domains in this process.</returns>
        /// <remarks>
        /// This method can be used before the <see cref="ICorDebugManagedCallback.CreateProcess"/> callback.
        /// </remarks>
        public CorDebugAppDomainEnum EnumerateAppDomains()
        {
            CorDebugAppDomainEnum ppAppDomainsResult;
            TryEnumerateAppDomains(out ppAppDomainsResult).ThrowOnNotOK();

            return ppAppDomainsResult;
        }

        /// <summary>
        /// Enumerates all the application domains in this process.
        /// </summary>
        /// <param name="ppAppDomainsResult">[out] A pointer to the address of an <see cref="ICorDebugAppDomainEnum"/> that is an enumerator for the application domains in this process.</param>
        /// <remarks>
        /// This method can be used before the <see cref="ICorDebugManagedCallback.CreateProcess"/> callback.
        /// </remarks>
        public HRESULT TryEnumerateAppDomains(out CorDebugAppDomainEnum ppAppDomainsResult)
        {
            /*HRESULT EnumerateAppDomains([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugAppDomainEnum ppAppDomains);*/
            ICorDebugAppDomainEnum ppAppDomains;
            HRESULT hr = Raw.EnumerateAppDomains(out ppAppDomains);

            if (hr == HRESULT.S_OK)
                ppAppDomainsResult = new CorDebugAppDomainEnum(ppAppDomains);
            else
                ppAppDomainsResult = default(CorDebugAppDomainEnum);

            return hr;
        }

        #endregion
        #region ThreadForFiberCookie

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        public CorDebugThread ThreadForFiberCookie(int fiberCookie)
        {
            CorDebugThread ppThreadResult;
            TryThreadForFiberCookie(fiberCookie, out ppThreadResult).ThrowOnNotOK();

            return ppThreadResult;
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        public HRESULT TryThreadForFiberCookie(int fiberCookie, out CorDebugThread ppThreadResult)
        {
            /*HRESULT ThreadForFiberCookie([In] int fiberCookie,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);*/
            ICorDebugThread ppThread;
            HRESULT hr = Raw.ThreadForFiberCookie(fiberCookie, out ppThread);

            if (hr == HRESULT.S_OK)
                ppThreadResult = new CorDebugThread(ppThread);
            else
                ppThreadResult = default(CorDebugThread);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugProcess2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugProcess2 Raw2 => (ICorDebugProcess2) Raw;

        #region Version

        /// <summary>
        /// Gets the version number of the common language runtime (CLR) that is running in this process.
        /// </summary>
        public COR_VERSION Version
        {
            get
            {
                COR_VERSION version;
                TryGetVersion(out version).ThrowOnNotOK();

                return version;
            }
        }

        /// <summary>
        /// Gets the version number of the common language runtime (CLR) that is running in this process.
        /// </summary>
        /// <param name="version">[out] A pointer to a <see cref="COR_VERSION"/> structure that stores the version number of the runtime.</param>
        /// <remarks>
        /// The GetVersion method returns an error code if no runtime has been loaded in the process.
        /// </remarks>
        public HRESULT TryGetVersion(out COR_VERSION version)
        {
            /*HRESULT GetVersion([Out] out COR_VERSION version);*/
            return Raw2.GetVersion(out version);
        }

        #endregion
        #region DesiredNGENCompilerFlags

        /// <summary>
        /// Gets or sets the current compiler flag settings that the common language runtime (CLR) uses to select the correct precompiled (that is, native) image to be loaded into this process.
        /// </summary>
        public CorDebugJITCompilerFlags DesiredNGENCompilerFlags
        {
            get
            {
                CorDebugJITCompilerFlags pdwFlags;
                TryGetDesiredNGENCompilerFlags(out pdwFlags).ThrowOnNotOK();

                return pdwFlags;
            }
            set
            {
                TrySetDesiredNGENCompilerFlags(value).ThrowOnNotOK();
            }
        }

        /// <summary>
        /// Gets the current compiler flag settings that the common language runtime (CLR) uses to select the correct precompiled (that is, native) image to be loaded into this process.
        /// </summary>
        /// <param name="pdwFlags">[out] A pointer to a bitwise combination of the <see cref="CorDebugJITCompilerFlags"/> enumeration values that are used to select the correct precompiled image to be loaded.</param>
        /// <remarks>
        /// Use the <see cref="DesiredNGENCompilerFlags"/> property to set the flags that the CLR will use to select the correct
        /// pre-compiled image to load.
        /// </remarks>
        public HRESULT TryGetDesiredNGENCompilerFlags(out CorDebugJITCompilerFlags pdwFlags)
        {
            /*HRESULT GetDesiredNGENCompilerFlags([Out] out CorDebugJITCompilerFlags pdwFlags);*/
            return Raw2.GetDesiredNGENCompilerFlags(out pdwFlags);
        }

        /// <summary>
        /// Sets the flags that must be embedded in a precompiled image in order for the runtime to load that image into the current process.
        /// </summary>
        /// <param name="pdwFlags">[in] A value of the <see cref="CorDebugJITCompilerFlags"/> enumeration that specifies the compiler flags used to select the correct pre-compiled image.</param>
        /// <remarks>
        /// The SetDesiredNGENCompilerFlags method specifies the flags that must be embedded in a precompiled image so that
        /// the runtime will load that image into this process. The flags set by this method are used only to select the correct
        /// precompiled image. If no such image exists, the runtime will load the Microsoft intermediate language (MSIL) image
        /// and the just-in-time (JIT) compiler instead. In that case, the debugger must still use the <see cref="CorDebugModule.JITCompilerFlags"/>
        /// property to set the flags as desired for the JIT compilation. If an image is loaded, but some JIT compiling must
        /// take place for that image (which will be the case if the image contains generics), the compiler flags specified
        /// by the SetDesiredNGENCompilerFlags method will apply to the extra JIT compilation. The SetDesiredNGENCompilerFlags
        /// method must be called during the <see cref="ICorDebugManagedCallback.CreateProcess"/> callback. Attempts to call
        /// the SetDesiredNGENCompilerFlags method afterwards will fail. Also, attempts to set flags that are either not defined
        /// in the <see cref="CorDebugJITCompilerFlags"/> enumeration or are not legal for the given process will fail.
        /// </remarks>
        public HRESULT TrySetDesiredNGENCompilerFlags(CorDebugJITCompilerFlags pdwFlags)
        {
            /*HRESULT SetDesiredNGENCompilerFlags([In] CorDebugJITCompilerFlags pdwFlags);*/
            return Raw2.SetDesiredNGENCompilerFlags(pdwFlags);
        }

        #endregion
        #region GetThreadForTaskID

        /// <summary>
        /// Gets the thread on which the task with the specified identifier is executing.
        /// </summary>
        /// <param name="taskid">[in] The identifier of the task.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugThread2"/> object that represents the thread to be retrieved.</returns>
        /// <remarks>
        /// The host can set the task identifier by using the <see cref="CLRTask.SetTaskIdentifier"/> method.
        /// </remarks>
        public CorDebugThread GetThreadForTaskID(long taskid)
        {
            CorDebugThread ppThreadResult;
            TryGetThreadForTaskID(taskid, out ppThreadResult).ThrowOnNotOK();

            return ppThreadResult;
        }

        /// <summary>
        /// Gets the thread on which the task with the specified identifier is executing.
        /// </summary>
        /// <param name="taskid">[in] The identifier of the task.</param>
        /// <param name="ppThreadResult">[out] A pointer to the address of an <see cref="ICorDebugThread2"/> object that represents the thread to be retrieved.</param>
        /// <remarks>
        /// The host can set the task identifier by using the <see cref="CLRTask.SetTaskIdentifier"/> method.
        /// </remarks>
        public HRESULT TryGetThreadForTaskID(long taskid, out CorDebugThread ppThreadResult)
        {
            /*HRESULT GetThreadForTaskID([In] long taskid, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugThread2 ppThread);*/
            ICorDebugThread2 ppThread;
            HRESULT hr = Raw2.GetThreadForTaskID(taskid, out ppThread);

            if (hr == HRESULT.S_OK)
                ppThreadResult = new CorDebugThread((ICorDebugThread) ppThread);
            else
                ppThreadResult = default(CorDebugThread);

            return hr;
        }

        #endregion
        #region SetUnmanagedBreakpoint

        /// <summary>
        /// Sets an unmanaged breakpoint at the specified native image offset.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> object that specifies the native image offset.</param>
        /// <returns>[out] An array that contains the opcode that is replaced by the breakpoint.</returns>
        /// <remarks>
        /// If the native image offset is within the common language runtime (CLR), the breakpoint will be ignored. This allows
        /// the CLR to avoid dispatching an out-of-band breakpoint, when the breakpoint is set by the debugger.
        /// </remarks>
        public byte[] SetUnmanagedBreakpoint(CORDB_ADDRESS address)
        {
            byte[] buffer;
            TrySetUnmanagedBreakpoint(address, out buffer).ThrowOnNotOK();

            return buffer;
        }

        /// <summary>
        /// Sets an unmanaged breakpoint at the specified native image offset.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> object that specifies the native image offset.</param>
        /// <param name="buffer">[out] An array that contains the opcode that is replaced by the breakpoint.</param>
        /// <remarks>
        /// If the native image offset is within the common language runtime (CLR), the breakpoint will be ignored. This allows
        /// the CLR to avoid dispatching an out-of-band breakpoint, when the breakpoint is set by the debugger.
        /// </remarks>
        public HRESULT TrySetUnmanagedBreakpoint(CORDB_ADDRESS address, out byte[] buffer)
        {
            /*HRESULT SetUnmanagedBreakpoint(
            [In] CORDB_ADDRESS address,
            [In] int bufsize,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] buffer,
            [Out] out int bufLen);*/
            int bufsize = 0;
            buffer = null;
            int bufLen;
            HRESULT hr = Raw2.SetUnmanagedBreakpoint(address, bufsize, null, out bufLen);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufsize = bufLen;
            buffer = new byte[bufsize];
            hr = Raw2.SetUnmanagedBreakpoint(address, bufsize, buffer, out bufLen);
            fail:
            return hr;
        }

        #endregion
        #region ClearUnmanagedBreakpoint

        /// <summary>
        /// Removes a previously set breakpoint at the given address.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the address at which the breakpoint was set.</param>
        /// <remarks>
        /// The specified breakpoint would have been previously set by an earlier call to <see cref="SetUnmanagedBreakpoint"/>.
        /// The ClearUnmanagedBreakpoint method can be called while the process being debugged is running. The ClearUnmanagedBreakpoint
        /// method returns a failure code if the debugger is attached in managed-only mode or if no breakpoint exists at the
        /// specified address.
        /// </remarks>
        public void ClearUnmanagedBreakpoint(CORDB_ADDRESS address)
        {
            TryClearUnmanagedBreakpoint(address).ThrowOnNotOK();
        }

        /// <summary>
        /// Removes a previously set breakpoint at the given address.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the address at which the breakpoint was set.</param>
        /// <remarks>
        /// The specified breakpoint would have been previously set by an earlier call to <see cref="SetUnmanagedBreakpoint"/>.
        /// The ClearUnmanagedBreakpoint method can be called while the process being debugged is running. The ClearUnmanagedBreakpoint
        /// method returns a failure code if the debugger is attached in managed-only mode or if no breakpoint exists at the
        /// specified address.
        /// </remarks>
        public HRESULT TryClearUnmanagedBreakpoint(CORDB_ADDRESS address)
        {
            /*HRESULT ClearUnmanagedBreakpoint([In] CORDB_ADDRESS address);*/
            return Raw2.ClearUnmanagedBreakpoint(address);
        }

        #endregion
        #region GetReferenceValueFromGCHandle

        /// <summary>
        /// Gets a reference pointer to the specified managed object that has a garbage collection handle.
        /// </summary>
        /// <param name="handle">[in] A pointer to a managed object that has a garbage collection handle. This value is a <see cref="IntPtr"/> object and can be retrieved from the <see cref="GCHandle"/> for the managed object.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugReferenceValue"/> object that represents a reference to the specified managed object.</returns>
        /// <remarks>
        /// Do not confuse the returned reference value with a garbage collection reference value. The returned reference behaves
        /// like a normal reference. It is disabled when code execution continues after a breakpoint. The lifetime of the target
        /// object is not affected by the lifetime of the reference value.
        /// </remarks>
        public CorDebugReferenceValue GetReferenceValueFromGCHandle(IntPtr handle)
        {
            CorDebugReferenceValue pOutValueResult;
            TryGetReferenceValueFromGCHandle(handle, out pOutValueResult).ThrowOnNotOK();

            return pOutValueResult;
        }

        /// <summary>
        /// Gets a reference pointer to the specified managed object that has a garbage collection handle.
        /// </summary>
        /// <param name="handle">[in] A pointer to a managed object that has a garbage collection handle. This value is a <see cref="IntPtr"/> object and can be retrieved from the <see cref="GCHandle"/> for the managed object.</param>
        /// <param name="pOutValueResult">[out] A pointer to the address of an <see cref="ICorDebugReferenceValue"/> object that represents a reference to the specified managed object.</param>
        /// <remarks>
        /// Do not confuse the returned reference value with a garbage collection reference value. The returned reference behaves
        /// like a normal reference. It is disabled when code execution continues after a breakpoint. The lifetime of the target
        /// object is not affected by the lifetime of the reference value.
        /// </remarks>
        public HRESULT TryGetReferenceValueFromGCHandle(IntPtr handle, out CorDebugReferenceValue pOutValueResult)
        {
            /*HRESULT GetReferenceValueFromGCHandle([In] IntPtr handle, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugReferenceValue pOutValue);*/
            ICorDebugReferenceValue pOutValue;
            HRESULT hr = Raw2.GetReferenceValueFromGCHandle(handle, out pOutValue);

            if (hr == HRESULT.S_OK)
                pOutValueResult = new CorDebugReferenceValue(pOutValue);
            else
                pOutValueResult = default(CorDebugReferenceValue);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugProcess3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugProcess3 Raw3 => (ICorDebugProcess3) Raw;

        #region SetEnableCustomNotification

        /// <summary>
        /// Enables and disables custom debugger notifications of the specified type.
        /// </summary>
        /// <param name="pClass">[in] The type that specifies custom debugger notifications.</param>
        /// <param name="fEnable">[in] true to enable custom debugger notifications; false to disable notifications. The default value is false.</param>
        /// <remarks>
        /// When fEnable is set to true, calls to the <see cref="Debugger.NotifyOfCrossThreadDependency"/> method trigger an
        /// <see cref="ICorDebugManagedCallback3.CustomNotification"/> callback. Notifications are disabled by default; therefore,
        /// the debugger must specify any notification types it knows about and wants to handle. Because the <see cref="ICorDebug"/>
        /// class is scoped by application domain, the debugger must call SetEnableCustomNotification for every application
        /// domain in the process if it wants to receive the notification across the entire process. Starting with the .NET
        /// Framework 4, the only supported notification is a cross-thread dependency notification.
        /// </remarks>
        public void SetEnableCustomNotification(ICorDebugClass pClass, bool fEnable)
        {
            TrySetEnableCustomNotification(pClass, fEnable).ThrowOnNotOK();
        }

        /// <summary>
        /// Enables and disables custom debugger notifications of the specified type.
        /// </summary>
        /// <param name="pClass">[in] The type that specifies custom debugger notifications.</param>
        /// <param name="fEnable">[in] true to enable custom debugger notifications; false to disable notifications. The default value is false.</param>
        /// <remarks>
        /// When fEnable is set to true, calls to the <see cref="Debugger.NotifyOfCrossThreadDependency"/> method trigger an
        /// <see cref="ICorDebugManagedCallback3.CustomNotification"/> callback. Notifications are disabled by default; therefore,
        /// the debugger must specify any notification types it knows about and wants to handle. Because the <see cref="ICorDebug"/>
        /// class is scoped by application domain, the debugger must call SetEnableCustomNotification for every application
        /// domain in the process if it wants to receive the notification across the entire process. Starting with the .NET
        /// Framework 4, the only supported notification is a cross-thread dependency notification.
        /// </remarks>
        public HRESULT TrySetEnableCustomNotification(ICorDebugClass pClass, bool fEnable)
        {
            /*HRESULT SetEnableCustomNotification([In, MarshalAs(UnmanagedType.Interface)] ICorDebugClass pClass, [In] bool fEnable);*/
            return Raw3.SetEnableCustomNotification(pClass, fEnable);
        }

        #endregion
        #endregion
        #region ICorDebugProcess4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugProcess4 Raw4 => (ICorDebugProcess4) Raw;

        #region Filter

        public CorDebugDebugEvent Filter(byte[] pRecord, int countBytes, CorDebugRecordFormat format, int dwFlags, int dwThreadId, ref int pContinueStatus)
        {
            CorDebugDebugEvent ppEventResult;
            TryFilter(pRecord, countBytes, format, dwFlags, dwThreadId, ref pContinueStatus, out ppEventResult).ThrowOnNotOK();

            return ppEventResult;
        }

        public HRESULT TryFilter(byte[] pRecord, int countBytes, CorDebugRecordFormat format, int dwFlags, int dwThreadId, ref int pContinueStatus, out CorDebugDebugEvent ppEventResult)
        {
            /*HRESULT Filter(
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pRecord,
            [In] int countBytes,
            [In] CorDebugRecordFormat format,
            [In] int dwFlags,
            [In] int dwThreadId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugDebugEvent ppEvent,
            [In, Out] ref int pContinueStatus);*/
            ICorDebugDebugEvent ppEvent;
            HRESULT hr = Raw4.Filter(pRecord, countBytes, format, dwFlags, dwThreadId, out ppEvent, ref pContinueStatus);

            if (hr == HRESULT.S_OK)
                ppEventResult = CorDebugDebugEvent.New(ppEvent);
            else
                ppEventResult = default(CorDebugDebugEvent);

            return hr;
        }

        #endregion
        #region ProcessStateChanged

        /// <summary>
        /// Notifies the ICorDebug pipeline that the out of process debugger is continuing the debugee's execution.
        /// </summary>
        /// <param name="change">[in] A member of the <see cref="CorDebugStateChange"/> describing a change in the process's execution state.</param>
        /// <remarks>
        /// The provided method is part of the ICorDebugProcess4 interface and corresponds to the fourth slot of the virtual
        /// method table.
        /// </remarks>
        public void ProcessStateChanged(CorDebugStateChange change)
        {
            TryProcessStateChanged(change).ThrowOnNotOK();
        }

        /// <summary>
        /// Notifies the ICorDebug pipeline that the out of process debugger is continuing the debugee's execution.
        /// </summary>
        /// <param name="change">[in] A member of the <see cref="CorDebugStateChange"/> describing a change in the process's execution state.</param>
        /// <remarks>
        /// The provided method is part of the ICorDebugProcess4 interface and corresponds to the fourth slot of the virtual
        /// method table.
        /// </remarks>
        public HRESULT TryProcessStateChanged(CorDebugStateChange change)
        {
            /*HRESULT ProcessStateChanged([In] CorDebugStateChange change);*/
            return Raw4.ProcessStateChanged(change);
        }

        #endregion
        #endregion
        #region ICorDebugProcess5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugProcess5 Raw5 => (ICorDebugProcess5) Raw;

        #region GCHeapInformation

        /// <summary>
        /// Provides general information about the garbage collection heap, including whether it is currently enumerable.
        /// </summary>
        public COR_HEAPINFO GCHeapInformation
        {
            get
            {
                COR_HEAPINFO pHeapInfo;
                TryGetGCHeapInformation(out pHeapInfo).ThrowOnNotOK();

                return pHeapInfo;
            }
        }

        /// <summary>
        /// Provides general information about the garbage collection heap, including whether it is currently enumerable.
        /// </summary>
        /// <param name="pHeapInfo">[out] A pointer to a <see cref="COR_HEAPINFO"/> value that provides general information about the garbage collection heap.</param>
        /// <remarks>
        /// The <see cref="GCHeapInformation"/> property must be called before enumerating the heap or individual heap
        /// regions to ensure that the garbage collection structures in the process are currently valid. The garbage collection
        /// heap cannot be walked while a collection is in progress. Otherwise, the enumeration may capture garbage collection
        /// structures that are invalid.
        /// </remarks>
        public HRESULT TryGetGCHeapInformation(out COR_HEAPINFO pHeapInfo)
        {
            /*HRESULT GetGCHeapInformation([Out] out COR_HEAPINFO pHeapInfo);*/
            return Raw5.GetGCHeapInformation(out pHeapInfo);
        }

        #endregion
        #region EnumerateHeap

        /// <summary>
        /// Gets an enumerator for the objects on the managed heap.
        /// </summary>
        public COR_HEAPOBJECT[] Heaps => EnumerateHeap().ToArray();

        /// <summary>
        /// Gets an enumerator for the objects on the managed heap.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugHeapEnum"/> interface object that is an enumerator for the objects that reside on the managed heap.</returns>
        /// <remarks>
        /// Before calling the <see cref="EnumerateHeap"/> method, you should call the <see cref="GCHeapInformation"/>
        /// property and examine the value of the areGCStructuresValid field of the returned <see cref="COR_HEAPINFO"/> object
        /// to ensure that the garbage collection heap in its current state is enumerable. In addition, the ICorDebugProcess5::EnumerateHeap
        /// returns E_FAIL if you attach too early in the lifetime of the process, before memory for the managed heap is allocated.
        /// The <see cref="ICorDebugHeapEnum"/> interface object is a standard enumerator derived from the <see cref="ICorDebugEnum"/> interface
        /// that allows you to enumerate <see cref="COR_HEAPOBJECT"/> objects. This method populates the <see cref="ICorDebugHeapEnum"/>
        /// collection object with <see cref="COR_HEAPOBJECT"/> instances that provide information about all objects. The collection
        /// may also include <see cref="COR_HEAPOBJECT"/> instances that provide information about objects that are not rooted
        /// by any object but have not yet been collected by the garbage collector.
        /// </remarks>
        public CorDebugHeapEnum EnumerateHeap()
        {
            CorDebugHeapEnum ppObjectsResult;
            TryEnumerateHeap(out ppObjectsResult).ThrowOnNotOK();

            return ppObjectsResult;
        }

        /// <summary>
        /// Gets an enumerator for the objects on the managed heap.
        /// </summary>
        /// <param name="ppObjectsResult">[out] A pointer to the address of an <see cref="ICorDebugHeapEnum"/> interface object that is an enumerator for the objects that reside on the managed heap.</param>
        /// <remarks>
        /// Before calling the <see cref="EnumerateHeap"/> method, you should call the <see cref="GCHeapInformation"/>
        /// property and examine the value of the areGCStructuresValid field of the returned <see cref="COR_HEAPINFO"/> object
        /// to ensure that the garbage collection heap in its current state is enumerable. In addition, the ICorDebugProcess5::EnumerateHeap
        /// returns E_FAIL if you attach too early in the lifetime of the process, before memory for the managed heap is allocated.
        /// The <see cref="ICorDebugHeapEnum"/> interface object is a standard enumerator derived from the <see cref="ICorDebugEnum"/> interface
        /// that allows you to enumerate <see cref="COR_HEAPOBJECT"/> objects. This method populates the <see cref="ICorDebugHeapEnum"/>
        /// collection object with <see cref="COR_HEAPOBJECT"/> instances that provide information about all objects. The collection
        /// may also include <see cref="COR_HEAPOBJECT"/> instances that provide information about objects that are not rooted
        /// by any object but have not yet been collected by the garbage collector.
        /// </remarks>
        public HRESULT TryEnumerateHeap(out CorDebugHeapEnum ppObjectsResult)
        {
            /*HRESULT EnumerateHeap([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugHeapEnum ppObjects);*/
            ICorDebugHeapEnum ppObjects;
            HRESULT hr = Raw5.EnumerateHeap(out ppObjects);

            if (hr == HRESULT.S_OK)
                ppObjectsResult = new CorDebugHeapEnum(ppObjects);
            else
                ppObjectsResult = default(CorDebugHeapEnum);

            return hr;
        }

        #endregion
        #region EnumerateHeapRegions

        /// <summary>
        /// Gets an enumerator for the memory ranges of the managed heap.
        /// </summary>
        public COR_SEGMENT[] HeapRegions => EnumerateHeapRegions().ToArray();

        /// <summary>
        /// Gets an enumerator for the memory ranges of the managed heap.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugHeapSegmentEnum"/> interface object that is an enumerator for the ranges of memory in which objects reside in the managed heap.</returns>
        /// <remarks>
        /// Before calling the <see cref="EnumerateHeapRegions"/> method, you should call the <see cref="GCHeapInformation"/>
        /// property and examine the value of the areGCStructuresValid field of the returned <see cref="COR_HEAPINFO"/> object
        /// to ensure that the garbage collection heap in its current state is enumerable. In addition, the ICorDebugProcess5::EnumerateHeapRegions
        /// method returns E_FAIL if you attach too early in the lifetime of the process, before memory regions are created.
        /// This method is guaranteed to enumerate all memory regions that may contain managed objects, but it does not guarantee
        /// that managed objects actually reside in those regions. The <see cref="ICorDebugHeapSegmentEnum"/> collection object
        /// may include empty or reserved memory regions. The <see cref="ICorDebugHeapSegmentEnum"/> interface object is a
        /// standard enumerator derived from the <see cref="ICorDebugEnum"/> interface that allows you to enumerate <see cref="COR_SEGMENT"/>
        /// objects. Each <see cref="COR_SEGMENT"/> object provides information about the memory range of a particular segment,
        /// along with the generation of the objects in that segment.
        /// </remarks>
        public CorDebugHeapSegmentEnum EnumerateHeapRegions()
        {
            CorDebugHeapSegmentEnum ppRegionsResult;
            TryEnumerateHeapRegions(out ppRegionsResult).ThrowOnNotOK();

            return ppRegionsResult;
        }

        /// <summary>
        /// Gets an enumerator for the memory ranges of the managed heap.
        /// </summary>
        /// <param name="ppRegionsResult">[out] A pointer to the address of an <see cref="ICorDebugHeapSegmentEnum"/> interface object that is an enumerator for the ranges of memory in which objects reside in the managed heap.</param>
        /// <remarks>
        /// Before calling the <see cref="EnumerateHeapRegions"/> method, you should call the <see cref="GCHeapInformation"/>
        /// property and examine the value of the areGCStructuresValid field of the returned <see cref="COR_HEAPINFO"/> object
        /// to ensure that the garbage collection heap in its current state is enumerable. In addition, the ICorDebugProcess5::EnumerateHeapRegions
        /// method returns E_FAIL if you attach too early in the lifetime of the process, before memory regions are created.
        /// This method is guaranteed to enumerate all memory regions that may contain managed objects, but it does not guarantee
        /// that managed objects actually reside in those regions. The <see cref="ICorDebugHeapSegmentEnum"/> collection object
        /// may include empty or reserved memory regions. The <see cref="ICorDebugHeapSegmentEnum"/> interface object is a
        /// standard enumerator derived from the <see cref="ICorDebugEnum"/> interface that allows you to enumerate <see cref="COR_SEGMENT"/>
        /// objects. Each <see cref="COR_SEGMENT"/> object provides information about the memory range of a particular segment,
        /// along with the generation of the objects in that segment.
        /// </remarks>
        public HRESULT TryEnumerateHeapRegions(out CorDebugHeapSegmentEnum ppRegionsResult)
        {
            /*HRESULT EnumerateHeapRegions([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugHeapSegmentEnum ppRegions);*/
            ICorDebugHeapSegmentEnum ppRegions;
            HRESULT hr = Raw5.EnumerateHeapRegions(out ppRegions);

            if (hr == HRESULT.S_OK)
                ppRegionsResult = new CorDebugHeapSegmentEnum(ppRegions);
            else
                ppRegionsResult = default(CorDebugHeapSegmentEnum);

            return hr;
        }

        #endregion
        #region GetObject

        /// <summary>
        /// Converts an object address to an "ICorDebugObjectValue" object.
        /// </summary>
        /// <param name="addr">[in] The object address.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugObjectValue" object.</returns>
        /// <remarks>
        /// If addr does not point to a valid managed object, the GetObject method returns E_FAIL.
        /// </remarks>
        public CorDebugObjectValue GetObject(CORDB_ADDRESS addr)
        {
            CorDebugObjectValue pObjectResult;
            TryGetObject(addr, out pObjectResult).ThrowOnNotOK();

            return pObjectResult;
        }

        /// <summary>
        /// Converts an object address to an "ICorDebugObjectValue" object.
        /// </summary>
        /// <param name="addr">[in] The object address.</param>
        /// <param name="pObjectResult">[out] A pointer to the address of an "ICorDebugObjectValue" object.</param>
        /// <remarks>
        /// If addr does not point to a valid managed object, the GetObject method returns E_FAIL.
        /// </remarks>
        public HRESULT TryGetObject(CORDB_ADDRESS addr, out CorDebugObjectValue pObjectResult)
        {
            /*HRESULT GetObject([In] CORDB_ADDRESS addr, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugObjectValue pObject);*/
            ICorDebugObjectValue pObject;
            HRESULT hr = Raw5.GetObject(addr, out pObject);

            if (hr == HRESULT.S_OK)
                pObjectResult = CorDebugObjectValue.New(pObject);
            else
                pObjectResult = default(CorDebugObjectValue);

            return hr;
        }

        #endregion
        #region EnumerateGCReferences

        /// <summary>
        /// Gets an enumerator for all objects that are to be garbage-collected in a process.
        /// </summary>
        /// <param name="enumerateWeakReferences">[in] A Boolean value that indicates whether weak references are also to be enumerated. If enumerateWeakReferences is true, the ppEnum enumerator includes both strong references and weak references.<para/>
        /// If enumerateWeakReferences is false, the enumerator includes only strong references.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugGCReferenceEnum"/> that is an enumerator for the objects to be garbage-collected.</returns>
        /// <remarks>
        /// This method provides a way to determine the full rooting chain for any managed object in a process and can be used
        /// to determine why an object is still alive.
        /// </remarks>
        public CorDebugGCReferenceEnum EnumerateGCReferences(int enumerateWeakReferences)
        {
            CorDebugGCReferenceEnum ppEnumResult;
            TryEnumerateGCReferences(enumerateWeakReferences, out ppEnumResult).ThrowOnNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// Gets an enumerator for all objects that are to be garbage-collected in a process.
        /// </summary>
        /// <param name="enumerateWeakReferences">[in] A Boolean value that indicates whether weak references are also to be enumerated. If enumerateWeakReferences is true, the ppEnum enumerator includes both strong references and weak references.<para/>
        /// If enumerateWeakReferences is false, the enumerator includes only strong references.</param>
        /// <param name="ppEnumResult">[out] A pointer to the address of an <see cref="ICorDebugGCReferenceEnum"/> that is an enumerator for the objects to be garbage-collected.</param>
        /// <remarks>
        /// This method provides a way to determine the full rooting chain for any managed object in a process and can be used
        /// to determine why an object is still alive.
        /// </remarks>
        public HRESULT TryEnumerateGCReferences(int enumerateWeakReferences, out CorDebugGCReferenceEnum ppEnumResult)
        {
            /*HRESULT EnumerateGCReferences([In] int enumerateWeakReferences,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugGCReferenceEnum ppEnum);*/
            ICorDebugGCReferenceEnum ppEnum;
            HRESULT hr = Raw5.EnumerateGCReferences(enumerateWeakReferences, out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = new CorDebugGCReferenceEnum(ppEnum);
            else
                ppEnumResult = default(CorDebugGCReferenceEnum);

            return hr;
        }

        #endregion
        #region EnumerateHandles

        /// <summary>
        /// Gets an enumerator for object handles in a process.
        /// </summary>
        /// <param name="types">[in] A bitwise combination of <see cref="CorGCReferenceType"/> values that specifies the type of handles to include in the collection.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugGCReferenceEnum"/> that is an enumerator for the objects to be garbage-collected.</returns>
        /// <remarks>
        /// EnumerateHandles is a helper function that supports inspection of the handle table. It is similar to the <see cref="EnumerateGCReferences"/>
        /// method, except that rather than populating an <see cref="ICorDebugGCReferenceEnum"/> collection with all objects
        /// to be garbage-collected, it includes only objects that have handles from the handle table. The types parameter
        /// specifies the handle types to include in the collection. types can be any of the following three members of the
        /// <see cref="CorGCReferenceType"/> enumeration:
        /// </remarks>
        public CorDebugGCReferenceEnum EnumerateHandles(CorGCReferenceType types)
        {
            CorDebugGCReferenceEnum ppEnumResult;
            TryEnumerateHandles(types, out ppEnumResult).ThrowOnNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// Gets an enumerator for object handles in a process.
        /// </summary>
        /// <param name="types">[in] A bitwise combination of <see cref="CorGCReferenceType"/> values that specifies the type of handles to include in the collection.</param>
        /// <param name="ppEnumResult">[out] A pointer to the address of an <see cref="ICorDebugGCReferenceEnum"/> that is an enumerator for the objects to be garbage-collected.</param>
        /// <remarks>
        /// EnumerateHandles is a helper function that supports inspection of the handle table. It is similar to the <see cref="EnumerateGCReferences"/>
        /// method, except that rather than populating an <see cref="ICorDebugGCReferenceEnum"/> collection with all objects
        /// to be garbage-collected, it includes only objects that have handles from the handle table. The types parameter
        /// specifies the handle types to include in the collection. types can be any of the following three members of the
        /// <see cref="CorGCReferenceType"/> enumeration:
        /// </remarks>
        public HRESULT TryEnumerateHandles(CorGCReferenceType types, out CorDebugGCReferenceEnum ppEnumResult)
        {
            /*HRESULT EnumerateHandles([In] CorGCReferenceType types,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugGCReferenceEnum ppEnum);*/
            ICorDebugGCReferenceEnum ppEnum;
            HRESULT hr = Raw5.EnumerateHandles(types, out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = new CorDebugGCReferenceEnum(ppEnum);
            else
                ppEnumResult = default(CorDebugGCReferenceEnum);

            return hr;
        }

        #endregion
        #region GetTypeID

        /// <summary>
        /// Converts an object address to a <see cref="COR_TYPEID"/> identifier.
        /// </summary>
        /// <param name="obj">[in] The object address.</param>
        /// <returns>A pointer to the <see cref="COR_TYPEID"/> value that identifies the object.</returns>
        public COR_TYPEID GetTypeID(CORDB_ADDRESS obj)
        {
            COR_TYPEID pId;
            TryGetTypeID(obj, out pId).ThrowOnNotOK();

            return pId;
        }

        /// <summary>
        /// Converts an object address to a <see cref="COR_TYPEID"/> identifier.
        /// </summary>
        /// <param name="obj">[in] The object address.</param>
        /// <param name="pId">A pointer to the <see cref="COR_TYPEID"/> value that identifies the object.</param>
        public HRESULT TryGetTypeID(CORDB_ADDRESS obj, out COR_TYPEID pId)
        {
            /*HRESULT GetTypeID([In] CORDB_ADDRESS obj, [Out] out COR_TYPEID pId);*/
            return Raw5.GetTypeID(obj, out pId);
        }

        #endregion
        #region GetTypeForTypeID

        /// <summary>
        /// Converts a type identifier to an <see cref="ICorDebugType"/> value.
        /// </summary>
        /// <param name="id">[in] The type identifier.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugType"/> object.</returns>
        /// <remarks>
        /// In some cases, methods that return a type identifier may return a null <see cref="COR_TYPEID"/> value. If this value is passed
        /// as the id argument, the GetTypeForTypeID method will fail and return E_FAIL.
        /// </remarks>
        public CorDebugType GetTypeForTypeID(COR_TYPEID id)
        {
            CorDebugType ppTypeResult;
            TryGetTypeForTypeID(id, out ppTypeResult).ThrowOnNotOK();

            return ppTypeResult;
        }

        /// <summary>
        /// Converts a type identifier to an <see cref="ICorDebugType"/> value.
        /// </summary>
        /// <param name="id">[in] The type identifier.</param>
        /// <param name="ppTypeResult">[out] A pointer to the address of an <see cref="ICorDebugType"/> object.</param>
        /// <remarks>
        /// In some cases, methods that return a type identifier may return a null <see cref="COR_TYPEID"/> value. If this value is passed
        /// as the id argument, the GetTypeForTypeID method will fail and return E_FAIL.
        /// </remarks>
        public HRESULT TryGetTypeForTypeID(COR_TYPEID id, out CorDebugType ppTypeResult)
        {
            /*HRESULT GetTypeForTypeID([In] COR_TYPEID id, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);*/
            ICorDebugType ppType;
            HRESULT hr = Raw5.GetTypeForTypeID(id, out ppType);

            if (hr == HRESULT.S_OK)
                ppTypeResult = new CorDebugType(ppType);
            else
                ppTypeResult = default(CorDebugType);

            return hr;
        }

        #endregion
        #region GetArrayLayout

        /// <summary>
        /// Provides information about the layout of array types.
        /// </summary>
        /// <param name="id">[in] A <see cref="COR_TYPEID"/> token that specifies the array whose layout is desired.</param>
        /// <returns>[out] A pointer to a <see cref="COR_ARRAY_LAYOUT"/> structure that contains information about the layout of the array in memory.</returns>
        public COR_ARRAY_LAYOUT GetArrayLayout(COR_TYPEID id)
        {
            COR_ARRAY_LAYOUT pLayout;
            TryGetArrayLayout(id, out pLayout).ThrowOnNotOK();

            return pLayout;
        }

        /// <summary>
        /// Provides information about the layout of array types.
        /// </summary>
        /// <param name="id">[in] A <see cref="COR_TYPEID"/> token that specifies the array whose layout is desired.</param>
        /// <param name="pLayout">[out] A pointer to a <see cref="COR_ARRAY_LAYOUT"/> structure that contains information about the layout of the array in memory.</param>
        public HRESULT TryGetArrayLayout(COR_TYPEID id, out COR_ARRAY_LAYOUT pLayout)
        {
            /*HRESULT GetArrayLayout([In] COR_TYPEID id, [Out] out COR_ARRAY_LAYOUT pLayout);*/
            return Raw5.GetArrayLayout(id, out pLayout);
        }

        #endregion
        #region GetTypeLayout

        /// <summary>
        /// Gets information about the layout of an object in memory based on its type identifier.
        /// </summary>
        /// <param name="id">[in] A <see cref="COR_TYPEID"/> token that specifies the type whose layout is desired.</param>
        /// <returns>[out] A pointer to a <see cref="COR_TYPE_LAYOUT"/> structure that contains information about the layout of the object in memory.</returns>
        /// <remarks>
        /// The <see cref="GetTypeLayout"/> method provides information about an object based on its <see cref="COR_TYPEID"/>,
        /// which is returned by a number of other <see cref="ICorDebugProcess5"/> methods. The information is provided by
        /// a <see cref="COR_TYPE_LAYOUT"/> structure that is populated by the method.
        /// </remarks>
        public COR_TYPE_LAYOUT GetTypeLayout(COR_TYPEID id)
        {
            COR_TYPE_LAYOUT pLayout;
            TryGetTypeLayout(id, out pLayout).ThrowOnNotOK();

            return pLayout;
        }

        /// <summary>
        /// Gets information about the layout of an object in memory based on its type identifier.
        /// </summary>
        /// <param name="id">[in] A <see cref="COR_TYPEID"/> token that specifies the type whose layout is desired.</param>
        /// <param name="pLayout">[out] A pointer to a <see cref="COR_TYPE_LAYOUT"/> structure that contains information about the layout of the object in memory.</param>
        /// <remarks>
        /// The <see cref="GetTypeLayout"/> method provides information about an object based on its <see cref="COR_TYPEID"/>,
        /// which is returned by a number of other <see cref="ICorDebugProcess5"/> methods. The information is provided by
        /// a <see cref="COR_TYPE_LAYOUT"/> structure that is populated by the method.
        /// </remarks>
        public HRESULT TryGetTypeLayout(COR_TYPEID id, out COR_TYPE_LAYOUT pLayout)
        {
            /*HRESULT GetTypeLayout([In] COR_TYPEID id, [Out] out COR_TYPE_LAYOUT pLayout);*/
            return Raw5.GetTypeLayout(id, out pLayout);
        }

        #endregion
        #region GetTypeFields

        /// <summary>
        /// Provides information about the fields that belong to a type.
        /// </summary>
        /// <param name="id">[in] The identifier of the type whose field information is retrieved.</param>
        /// <returns>[out] An array of <see cref="COR_FIELD"/> objects that provide information about the fields that belong to the type.</returns>
        /// <remarks>
        /// The celt parameter, which specifies the number of fields whose field information the method uses to populate fields,
        /// should correspond to the value of the <see cref="COR_TYPE_LAYOUT.numFields"/> field.
        /// </remarks>
        public COR_FIELD[] GetTypeFields(COR_TYPEID id)
        {
            COR_FIELD[] fields;
            TryGetTypeFields(id, out fields).ThrowOnNotOK();

            return fields;
        }

        /// <summary>
        /// Provides information about the fields that belong to a type.
        /// </summary>
        /// <param name="id">[in] The identifier of the type whose field information is retrieved.</param>
        /// <param name="fields">[out] An array of <see cref="COR_FIELD"/> objects that provide information about the fields that belong to the type.</param>
        /// <remarks>
        /// The celt parameter, which specifies the number of fields whose field information the method uses to populate fields,
        /// should correspond to the value of the <see cref="COR_TYPE_LAYOUT.numFields"/> field.
        /// </remarks>
        public HRESULT TryGetTypeFields(COR_TYPEID id, out COR_FIELD[] fields)
        {
            /*HRESULT GetTypeFields([In] COR_TYPEID id, [In] int celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] COR_FIELD[] fields, [Out] out int pceltNeeded);*/
            int celt = 0;
            fields = null;
            int pceltNeeded;
            HRESULT hr = Raw5.GetTypeFields(id, celt, null, out pceltNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            celt = pceltNeeded;
            fields = new COR_FIELD[celt];
            hr = Raw5.GetTypeFields(id, celt, fields, out pceltNeeded);
            fail:
            return hr;
        }

        #endregion
        #region EnableNGENPolicy

        /// <summary>
        /// Sets a value that determines how an application loads native images while running under a managed debugger.
        /// </summary>
        /// <param name="ePolicy">[in] A <see cref="CorDebugNGenPolicy"/> constant that determines how an application loads native images while running under a managed debugger.</param>
        /// <remarks>
        /// If the policy is set successfully, the method returns S_OK. If ePolicy is outside the range of the enumerated values
        /// defined by <see cref="CorDebugNGenPolicy"/>, the method returns E_INVALIDARG and the method call has no effect.
        /// If the policy of the Native Image Generator (Ngen.exe) cannot be updated, the method returns E_FAIL. The ICorDebugProcess5::EnableNGenPolicy
        /// method can be called at any time during the lifetime of the process. The policy is in effect for any modules that
        /// are loaded after the policy is set.
        /// </remarks>
        public void EnableNGENPolicy(CorDebugNGenPolicy ePolicy)
        {
            TryEnableNGENPolicy(ePolicy).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a value that determines how an application loads native images while running under a managed debugger.
        /// </summary>
        /// <param name="ePolicy">[in] A <see cref="CorDebugNGenPolicy"/> constant that determines how an application loads native images while running under a managed debugger.</param>
        /// <remarks>
        /// If the policy is set successfully, the method returns S_OK. If ePolicy is outside the range of the enumerated values
        /// defined by <see cref="CorDebugNGenPolicy"/>, the method returns E_INVALIDARG and the method call has no effect.
        /// If the policy of the Native Image Generator (Ngen.exe) cannot be updated, the method returns E_FAIL. The ICorDebugProcess5::EnableNGenPolicy
        /// method can be called at any time during the lifetime of the process. The policy is in effect for any modules that
        /// are loaded after the policy is set.
        /// </remarks>
        public HRESULT TryEnableNGENPolicy(CorDebugNGenPolicy ePolicy)
        {
            /*HRESULT EnableNGENPolicy([In] CorDebugNGenPolicy ePolicy);*/
            return Raw5.EnableNGENPolicy(ePolicy);
        }

        #endregion
        #endregion
        #region ICorDebugProcess6

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugProcess6 Raw6 => (ICorDebugProcess6) Raw;

        #region DecodeEvent

        /// <summary>
        /// Decodes managed debug events that have been encapsulated in the payload of specially crafted native exception debug events.
        /// </summary>
        /// <param name="pRecord">[in] A pointer to a byte array from a native exception debug event that includes information about a managed debug event.</param>
        /// <param name="countBytes">[in] The number of elements in the pRecord byte array.</param>
        /// <param name="format">[in] A <see cref="CorDebugRecordFormat"/> enumeration member that specifies the format of the unmanaged debug event.</param>
        /// <param name="dwFlags">[in] A bit field that depends on the target architecture and that specifies additional information about the debug event.<para/>
        /// For Windows systems, it can be a member of the <see cref="CorDebugDecodeEventFlagsWindows"/> enumeration.</param>
        /// <param name="dwThreadId">[in] The operating system identifier of the thread on which the exception was thrown.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugDebugEvent"/> object that represents a decoded managed debug event.</returns>
        public CorDebugDebugEvent DecodeEvent(byte[] pRecord, int countBytes, CorDebugRecordFormat format, int dwFlags, int dwThreadId)
        {
            CorDebugDebugEvent ppEventResult;
            TryDecodeEvent(pRecord, countBytes, format, dwFlags, dwThreadId, out ppEventResult).ThrowOnNotOK();

            return ppEventResult;
        }

        /// <summary>
        /// Decodes managed debug events that have been encapsulated in the payload of specially crafted native exception debug events.
        /// </summary>
        /// <param name="pRecord">[in] A pointer to a byte array from a native exception debug event that includes information about a managed debug event.</param>
        /// <param name="countBytes">[in] The number of elements in the pRecord byte array.</param>
        /// <param name="format">[in] A <see cref="CorDebugRecordFormat"/> enumeration member that specifies the format of the unmanaged debug event.</param>
        /// <param name="dwFlags">[in] A bit field that depends on the target architecture and that specifies additional information about the debug event.<para/>
        /// For Windows systems, it can be a member of the <see cref="CorDebugDecodeEventFlagsWindows"/> enumeration.</param>
        /// <param name="dwThreadId">[in] The operating system identifier of the thread on which the exception was thrown.</param>
        /// <param name="ppEventResult">[out] A pointer to the address of an <see cref="ICorDebugDebugEvent"/> object that represents a decoded managed debug event.</param>
        public HRESULT TryDecodeEvent(byte[] pRecord, int countBytes, CorDebugRecordFormat format, int dwFlags, int dwThreadId, out CorDebugDebugEvent ppEventResult)
        {
            /*HRESULT DecodeEvent(
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pRecord,
            [In] int countBytes,
            [In] CorDebugRecordFormat format,
            [In] int dwFlags,
            [In] int dwThreadId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugDebugEvent ppEvent);*/
            ICorDebugDebugEvent ppEvent;
            HRESULT hr = Raw6.DecodeEvent(pRecord, countBytes, format, dwFlags, dwThreadId, out ppEvent);

            if (hr == HRESULT.S_OK)
                ppEventResult = CorDebugDebugEvent.New(ppEvent);
            else
                ppEventResult = default(CorDebugDebugEvent);

            return hr;
        }

        #endregion
        #region GetCode

        /// <summary>
        /// Gets information about the managed code at a particular code address.
        /// </summary>
        /// <param name="codeAddress">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the starting address of the managed code segment.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugCode" object that represents a segment of managed code.</returns>
        public CorDebugCode GetCode(CORDB_ADDRESS codeAddress)
        {
            CorDebugCode ppCodeResult;
            TryGetCode(codeAddress, out ppCodeResult).ThrowOnNotOK();

            return ppCodeResult;
        }

        /// <summary>
        /// Gets information about the managed code at a particular code address.
        /// </summary>
        /// <param name="codeAddress">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the starting address of the managed code segment.</param>
        /// <param name="ppCodeResult">[out] A pointer to the address of an "ICorDebugCode" object that represents a segment of managed code.</param>
        public HRESULT TryGetCode(CORDB_ADDRESS codeAddress, out CorDebugCode ppCodeResult)
        {
            /*HRESULT GetCode([In] CORDB_ADDRESS codeAddress, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);*/
            ICorDebugCode ppCode;
            HRESULT hr = Raw6.GetCode(codeAddress, out ppCode);

            if (hr == HRESULT.S_OK)
                ppCodeResult = new CorDebugCode(ppCode);
            else
                ppCodeResult = default(CorDebugCode);

            return hr;
        }

        #endregion
        #region EnableVirtualModuleSplitting

        /// <summary>
        /// Enables or disables virtual module splitting.
        /// </summary>
        /// <param name="enableSplitting">true to enable virtual module splitting; false to disable it.</param>
        /// <remarks>
        /// Virtual module splitting causes <see cref="ICorDebug"/> to recognize modules that were merged together during the
        /// build process and present them as a group of separate modules rather than a single large module. Doing this changes
        /// the behavior of various <see cref="ICorDebug"/> methods described below. This method can be called and the value
        /// of enableSplitting can be changed at any time. It does not cause any stateful functional changes in an <see cref="ICorDebug"/>
        /// object, other than altering the behavior of the methods listed in the Virtual module splitting and the unmanaged
        /// debugging APIs section at the time they are called. Using virtual modules does incur a performance penalty when
        /// calling those methods. In addition, significant in-memory caching of the virtualized metadata may be required to
        /// correctly implement the <see cref="IMetaDataImport"/> APIs, and these caches may be retained even after virtual
        /// module splitting has been turned off.
        /// </remarks>
        public void EnableVirtualModuleSplitting(int enableSplitting)
        {
            TryEnableVirtualModuleSplitting(enableSplitting).ThrowOnNotOK();
        }

        /// <summary>
        /// Enables or disables virtual module splitting.
        /// </summary>
        /// <param name="enableSplitting">true to enable virtual module splitting; false to disable it.</param>
        /// <remarks>
        /// Virtual module splitting causes <see cref="ICorDebug"/> to recognize modules that were merged together during the
        /// build process and present them as a group of separate modules rather than a single large module. Doing this changes
        /// the behavior of various <see cref="ICorDebug"/> methods described below. This method can be called and the value
        /// of enableSplitting can be changed at any time. It does not cause any stateful functional changes in an <see cref="ICorDebug"/>
        /// object, other than altering the behavior of the methods listed in the Virtual module splitting and the unmanaged
        /// debugging APIs section at the time they are called. Using virtual modules does incur a performance penalty when
        /// calling those methods. In addition, significant in-memory caching of the virtualized metadata may be required to
        /// correctly implement the <see cref="IMetaDataImport"/> APIs, and these caches may be retained even after virtual
        /// module splitting has been turned off.
        /// </remarks>
        public HRESULT TryEnableVirtualModuleSplitting(int enableSplitting)
        {
            /*HRESULT EnableVirtualModuleSplitting([In] int enableSplitting);*/
            return Raw6.EnableVirtualModuleSplitting(enableSplitting);
        }

        #endregion
        #region MarkDebuggerAttached

        /// <summary>
        /// Changes the internal state of the debugee so that the <see cref="Debugger.IsAttached"/> method in the .NET Framework Class Library returns true.
        /// </summary>
        /// <param name="fIsAttached">true if the <see cref="Debugger.IsAttached"/> method should indicate that a debugger is attached; false otherwise.</param>
        public void MarkDebuggerAttached(bool fIsAttached)
        {
            TryMarkDebuggerAttached(fIsAttached).ThrowOnNotOK();
        }

        /// <summary>
        /// Changes the internal state of the debugee so that the <see cref="Debugger.IsAttached"/> method in the .NET Framework Class Library returns true.
        /// </summary>
        /// <param name="fIsAttached">true if the <see cref="Debugger.IsAttached"/> method should indicate that a debugger is attached; false otherwise.</param>
        /// <returns>
        /// The method can return the values listed in the following table.
        /// 
        /// | Return value                  | Description                                                                                                                                                                                                                                                                      |
        /// | ----------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                          | The debuggee was successfully updated.                                                                                                                                                                                                                                           |
        /// | CORDBG_E_MODULE_NOT_LOADED    | The assembly that contains the <see cref="Debugger.IsAttached"/> method is not loaded, or some other error, such as missing metadata, is preventing it from being recognized. This error is common and benign. You should call the method again when additional assemblies load. |
        /// | Other failing HRESULT values. | Other values likely indicate misbehaving debugger or compiler components.                                                                                                                                                                                                        |
        /// </returns>
        public HRESULT TryMarkDebuggerAttached(bool fIsAttached)
        {
            /*HRESULT MarkDebuggerAttached([In] bool fIsAttached);*/
            return Raw6.MarkDebuggerAttached(fIsAttached);
        }

        #endregion
        #region GetExportStepInfo

        /// <summary>
        /// Provides information on runtime exported functions to help step through managed code.
        /// </summary>
        /// <param name="pszExportName">[in] The name of a runtime export function as written in the PE export table.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetExportStepInfoResult GetExportStepInfo(string pszExportName)
        {
            GetExportStepInfoResult result;
            TryGetExportStepInfo(pszExportName, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Provides information on runtime exported functions to help step through managed code.
        /// </summary>
        /// <param name="pszExportName">[in] The name of a runtime export function as written in the PE export table.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// The method can return the values listed in the following table.
        /// 
        /// | Return value                  | Description                            |
        /// | ----------------------------- | -------------------------------------- |
        /// | S_OK                          | The method call was successful.        |
        /// | E_POINTER                     | pInvokeKind or pInvokePurpose is null. |
        /// | Other failing HRESULT values. | As appropriate.                        |
        /// </returns>
        public HRESULT TryGetExportStepInfo(string pszExportName, out GetExportStepInfoResult result)
        {
            /*HRESULT GetExportStepInfo(
            [MarshalAs(UnmanagedType.LPWStr), In] string pszExportName,
            [Out] out CorDebugCodeInvokeKind pInvokeKind,
            [Out] out CorDebugCodeInvokePurpose pInvokePurpose);*/
            CorDebugCodeInvokeKind pInvokeKind;
            CorDebugCodeInvokePurpose pInvokePurpose;
            HRESULT hr = Raw6.GetExportStepInfo(pszExportName, out pInvokeKind, out pInvokePurpose);

            if (hr == HRESULT.S_OK)
                result = new GetExportStepInfoResult(pInvokeKind, pInvokePurpose);
            else
                result = default(GetExportStepInfoResult);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugProcess7

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugProcess7 Raw7 => (ICorDebugProcess7) Raw;

        #region SetWriteableMetadataUpdateMode

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Configures how the debugger handles in-memory updates to metadata within the target process.
        /// </summary>
        /// <param name="flags">A <see cref="WriteableMetadataUpdateMode"/> enumeration value that specifies whether in-memory updates to metadata in the target process are visible (WriteableMetadataUpdateMode::AlwaysShowUpdates) or not visible (WriteableMetadataUpdateMode::LegacyCompatPolicy) to the debugger.</param>
        /// <remarks>
        /// Updates to the metadata of the target process can come from Edit and Continue, a profiler, or <see cref="System.Reflection.Emit"/>.
        /// </remarks>
        public void SetWriteableMetadataUpdateMode(WriteableMetadataUpdateMode flags)
        {
            TrySetWriteableMetadataUpdateMode(flags).ThrowOnNotOK();
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Configures how the debugger handles in-memory updates to metadata within the target process.
        /// </summary>
        /// <param name="flags">A <see cref="WriteableMetadataUpdateMode"/> enumeration value that specifies whether in-memory updates to metadata in the target process are visible (WriteableMetadataUpdateMode::AlwaysShowUpdates) or not visible (WriteableMetadataUpdateMode::LegacyCompatPolicy) to the debugger.</param>
        /// <remarks>
        /// Updates to the metadata of the target process can come from Edit and Continue, a profiler, or <see cref="System.Reflection.Emit"/>.
        /// </remarks>
        public HRESULT TrySetWriteableMetadataUpdateMode(WriteableMetadataUpdateMode flags)
        {
            /*HRESULT SetWriteableMetadataUpdateMode([In] WriteableMetadataUpdateMode flags);*/
            return Raw7.SetWriteableMetadataUpdateMode(flags);
        }

        #endregion
        #endregion
        #region ICorDebugProcess8

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugProcess8 Raw8 => (ICorDebugProcess8) Raw;

        #region EnableExceptionCallbacksOutsideOfMyCode

        /// <summary>
        /// [Supported in the .NET Framework 4.6 and later versions] Enables or disables certain types of <see cref="ICorDebugManagedCallback2"/> exception callbacks.
        /// </summary>
        /// <param name="enableExceptionsOutsideOfJMC">[in]</param>
        /// <remarks>
        /// If the value of enableExceptionsOutsideOfJMC is false: The default value of enableExceptionsOutsideOfJMC is true.
        /// </remarks>
        public void EnableExceptionCallbacksOutsideOfMyCode(int enableExceptionsOutsideOfJMC)
        {
            TryEnableExceptionCallbacksOutsideOfMyCode(enableExceptionsOutsideOfJMC).ThrowOnNotOK();
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.6 and later versions] Enables or disables certain types of <see cref="ICorDebugManagedCallback2"/> exception callbacks.
        /// </summary>
        /// <param name="enableExceptionsOutsideOfJMC">[in]</param>
        /// <remarks>
        /// If the value of enableExceptionsOutsideOfJMC is false: The default value of enableExceptionsOutsideOfJMC is true.
        /// </remarks>
        public HRESULT TryEnableExceptionCallbacksOutsideOfMyCode(int enableExceptionsOutsideOfJMC)
        {
            /*HRESULT EnableExceptionCallbacksOutsideOfMyCode([In] int enableExceptionsOutsideOfJMC);*/
            return Raw8.EnableExceptionCallbacksOutsideOfMyCode(enableExceptionsOutsideOfJMC);
        }

        #endregion
        #endregion
        #region ICorDebugProcess10

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugProcess10 Raw10 => (ICorDebugProcess10) Raw;

        #region EnableGCNotificationEvents

        public void EnableGCNotificationEvents(bool fEnable)
        {
            TryEnableGCNotificationEvents(fEnable).ThrowOnNotOK();
        }

        public HRESULT TryEnableGCNotificationEvents(bool fEnable)
        {
            /*HRESULT EnableGCNotificationEvents(bool fEnable);*/
            return Raw10.EnableGCNotificationEvents(fEnable);
        }

        #endregion
        #endregion
        #region ICorDebugProcess11

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugProcess11 Raw11 => (ICorDebugProcess11) Raw;

        #region EnumerateLoaderHeapMemoryRegions

        public COR_MEMORY_RANGE[] LoaderHeapMemoryRegions => EnumerateLoaderHeapMemoryRegions().ToArray();

        public CorDebugMemoryRangeEnum EnumerateLoaderHeapMemoryRegions()
        {
            CorDebugMemoryRangeEnum ppRangesResult;
            TryEnumerateLoaderHeapMemoryRegions(out ppRangesResult).ThrowOnNotOK();

            return ppRangesResult;
        }

        public HRESULT TryEnumerateLoaderHeapMemoryRegions(out CorDebugMemoryRangeEnum ppRangesResult)
        {
            /*HRESULT EnumerateLoaderHeapMemoryRegions([MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryRangeEnum ppRanges);*/
            ICorDebugMemoryRangeEnum ppRanges;
            HRESULT hr = Raw11.EnumerateLoaderHeapMemoryRegions(out ppRanges);

            if (hr == HRESULT.S_OK)
                ppRangesResult = new CorDebugMemoryRangeEnum(ppRanges);
            else
                ppRangesResult = default(CorDebugMemoryRangeEnum);

            return hr;
        }

        #endregion
        #endregion
    }
}
