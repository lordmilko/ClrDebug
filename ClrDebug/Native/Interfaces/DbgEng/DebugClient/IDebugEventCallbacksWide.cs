using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0690e046-9c23-45ac-a04f-987ac29ad0d3")]
    [ComImport]
    public interface IDebugEventCallbacksWide
    {
        /// <summary>
        /// The GetInterestMask callback method is called to determine which events the IDebugEventCallbacksWide object is interested in.<para/>
        /// The engine calls GetInterestMask when the object is registered with a client by using <see cref="IDebugClient.SetEventCallbacks"/>.
        /// </summary>
        /// <param name="mask">[out] Receives a bitmask that indicates which events the object is interested in. The engine will call only those methods that correspond to the bit flags set by GetInterestMask.<para/>
        /// For a description of the bit flags and their corresponding methods, see DEBUG_EVENT_XXX.</param>
        /// <returns>The return value S_OK indicates the method was successful. All other return values indicate an error occurred, in which case the SetEventCallbacks call will fail and the callback object will not be used nor will it receive events.</returns>
        /// <remarks>
        /// For more information about handling events, see Monitoring Events.
        /// </remarks>
        [PreserveSig]
        HRESULT GetInterestMask(
            [Out] out DEBUG_EVENT_TYPE mask);

        /// <summary>
        /// The Breakpoint callback method is called by the engine when the target issues a breakpointexception.
        /// </summary>
        /// <param name="bp">[in] Specifies a pointer to the <see cref="IDebugBreakpoint"/> object corresponding to the breakpoint that was triggered.</param>
        /// <returns>This method returns a DEBUG_STATUS_XXX value, which indicates how the execution of the target should proceed after the engine processes this event.<para/>
        /// For details on how the engine treats this value, see Monitoring Events.</returns>
        /// <remarks>
        /// If the breakpoint has an associated command, the engine executes that command before calling this method. The engine
        /// will only call this method if an <see cref="IDebugBreakpoint"/> object corresponding to the breakpoint exists in
        /// the engine, and--if the breakpoint is a private breakpoint--this <see cref="IDebugEventCallbacksWide"/> object
        /// was registered with the client that added the breakpoint. The engine calls this method only if the DEBUG_EVENT_BREAKPOINT
        /// flag is set in the mask returned by <see cref="GetInterestMask"/>. Because the engine deletes the corresponding
        /// IDebugBreakpoint object when a breakpoint is removed (for example, by using <see cref="IDebugControl.RemoveBreakpoint"/>),
        /// the value of Bp might be invalid after Breakpoint returns. Therefore, implementations of IDebugEventCallbacksWide
        /// should not access Bp after Breakpoint returns. For more information about handling events, see Monitoring Events.
        /// For information about managing breakpoints, see Breakpoints.
        /// </remarks>
        [PreserveSig]
        DEBUG_STATUS Breakpoint(
            [In, ComAliasName("IDebugBreakpoint2")] IntPtr bp);

        /// <summary>
        /// The Exception callback method is called by the engine when an exceptiondebugging event occurs in the target.
        /// </summary>
        /// <param name="exception">[in] Specifies the nature of the exception. EXCEPTION_RECORD64 is defined in Winnt.h.</param>
        /// <param name="firstChance">[in] Specifies whether this exception has been previously encountered. A nonzero value means that this is the first time the exception has been encountered ("first chance").<para/>
        /// A zero value means that the exception has already been offered to all possible handlers, and each one declined to handle it ("second chance").</param>
        /// <returns>This method returns a DEBUG_STATUS_XXX value, which indicates how the execution of the target should proceed after the engine processes this event.<para/>
        /// For details on how the engine treats this value, see Monitoring Events.</returns>
        /// <remarks>
        /// This method is only called by the engine if the DEBUG_EVENT_EXCEPTION flag is set in the mask returned by <see
        /// cref="GetInterestMask"/>. Because the structure that Exception points to might be deleted after this method returns,
        /// implementations of IDebugEventCallbacksWide should not access this structure after returning. For more information
        /// about handling events, see Monitoring Events.
        /// </remarks>
        [PreserveSig]
        DEBUG_STATUS Exception(
            [In] ref EXCEPTION_RECORD64 exception,
            [In] int firstChance);

        /// <summary>
        /// The CreateThread callback method is called by the engine when a create-thread debugging event occurs in the target.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle for the thread whose creation caused the event. If this information is not available, Handle will be NULL.</param>
        /// <param name="dataOffset">[in] Specifies a block of data that the operating system maintains for this thread. The actual data in the block is operating system-specific.<para/>
        /// If the operating system does not have such a block, DataOffset will be NULL.</param>
        /// <param name="startOffset">[in] Specifies the starting location in the target's virtual address space of the thread. If this information is not available, StartOffset will be NULL.</param>
        /// <returns>This method returns a DEBUG_STATUS_XXX value, which indicates how the execution of the target should proceed after the engine processes this event.<para/>
        /// For details on how the engine treats this value, see Monitoring Events.</returns>
        /// <remarks>
        /// This method is only called by the engine if the DEBUG_EVENT_CREATE_THREAD flag is set in the mask returned by <see
        /// cref="GetInterestMask"/>. For more information about handling events, see Monitoring Events. For information about
        /// threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        DEBUG_STATUS CreateThread(
            [In] long handle,
            [In] long dataOffset,
            [In] long startOffset);

        /// <summary>
        /// The ExitThread callback method is called by the engine when an exit-threaddebugging event occurs in the target.
        /// </summary>
        /// <param name="exitCode">[in] Specifies the exit code for the thread.</param>
        /// <returns>This method returns a DEBUG_STATUS_XXX value, which indicates how the execution of the target should proceed after the engine processes this event.<para/>
        /// For details on how the engine treats this value, see Monitoring Events.</returns>
        /// <remarks>
        /// This method is only called by the engine if the DEBUG_EVENT_EXIT_THREAD flag is set in the mask returned by <see
        /// cref="GetInterestMask"/>. For more information about handling events, see Monitoring Events. For information about
        /// threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        DEBUG_STATUS ExitThread(
            [In] int exitCode);

        /// <summary>
        /// The CreateProcess callback method is called by the engine when a create-process debugging event occurs in the target.
        /// </summary>
        /// <param name="imageFileHandle">[in] Specifies the handle to the process's image file. If this information is not available, ImageFileHandle will be NULL.</param>
        /// <param name="handle">[in] Specifies the handle to the process. This parameter corresponds to the hProcess field in the CREATE_PROCESS_DEBUG_INFO structure.<para/>
        /// If this information is not available, ImageFileHandle will be NULL.</param>
        /// <param name="baseOffset">[in] Specifies the base address of the process's executable image in the target's memory address space. If this information is not available, BaseOffset will be NULL.</param>
        /// <param name="moduleSize">[in] Specifies the process's executable image size in bytes. If this information is not available, ModuleSize will be zero.</param>
        /// <param name="moduleName">[in, optional] Specifies the simplified module name that is used by the debugger engine. In most cases, this matches the image file name excluding the extension.<para/>
        /// If this information is not available, ModuleName will be NULL.</param>
        /// <param name="imageName">[in, optional] Specifies the process's executable-image file name, which can include the path. If this information is not available, ImageName will be NULL.</param>
        /// <param name="checkSum">[in] Specifies the checksum of the process's executable image. If this information is not available, CheckSum will be zero.</param>
        /// <param name="timeDateStamp">[in] Specifies the time and date stamp of the process's executable-image file. If this information is not available, TimeDateStamp will be zero.</param>
        /// <param name="initialThreadHandle">[in] Specifies the handle to the process's initial thread. This parameter corresponds to the hThread field in the CREATE_PROCESS_DEBUG_INFO structure.<para/>
        /// If this information is not available, InitialThreadHandle will be NULL.</param>
        /// <param name="threadDataOffset">[in] Specifies a block of data that the operating system maintains for this thread. The actual data in the block is operating system-specific.<para/>
        /// If this information is not available, ThreadDataOffset will be NULL.</param>
        /// <param name="startOffset">[in] Specifies the starting address of the thread in the process's virtual address space. If this information is not available, StartOffset will be NULL.</param>
        /// <returns>This method returns a DEBUG_STATUS_XXX value, which indicates how the execution of the target should proceed after the engine processes this event.<para/>
        /// For details on how the engine treats this value, see Monitoring Events.</returns>
        /// <remarks>
        /// This method is only called by the engine if the DEBUG_EVENT_CREATE_PROCESS flag is set in the mask returned by
        /// <see cref="GetInterestMask"/>. For more information about handling events, see Monitoring Events. For information
        /// about threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        DEBUG_STATUS CreateProcess(
            [In] long imageFileHandle,
            [In] long handle,
            [In] long baseOffset,
            [In] int moduleSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string imageName,
            [In] int checkSum,
            [In] int timeDateStamp,
            [In] long initialThreadHandle,
            [In] long threadDataOffset,
            [In] long startOffset);

        /// <summary>
        /// The ExitProcess callback method is called by the engine when an exit-processdebugging event occurs in the target.
        /// </summary>
        /// <param name="exitCode">[in] Specifies the exit code for the process.</param>
        /// <returns>This method returns a DEBUG_STATUS_XXX value, which indicates how the execution of the target should proceed after the engine processes this event.<para/>
        /// For details on how the engine treats this value, see Monitoring Events.</returns>
        /// <remarks>
        /// This method is only called by the engine if the DEBUG_EVENT_EXIT_PROCESS flag is set in the mask returned by <see
        /// cref="GetInterestMask"/>. For more information about handling events, see Monitoring Events. For information about
        /// threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        DEBUG_STATUS ExitProcess(
            [In] int exitCode);

        /// <summary>
        /// The LoadModule callback method is called by the engine when a module-load debugging event occurs in the target.
        /// </summary>
        /// <param name="imageFileHandle">[in] Specifies the handle to the module's image file. If this information is not available, ImageFileHandle will be NULL.</param>
        /// <param name="baseOffset">[in] Specifies the base address of the module in the target's memory address space. If this information is not available, BaseOffset will be NULL.</param>
        /// <param name="moduleSize">[in] Specifies the module's image size in bytes. If this information is not available, ModuleSize will be NULL.</param>
        /// <param name="moduleName">[in, optional] Specifies the simplified module name that is used by the debugger engine. In most cases, this matches the image file name excluding the extension.<para/>
        /// If this information is not available, ModuleName will be NULL.</param>
        /// <param name="imageName">[in, optional] Specifies the module's image file name, which can include the path. If this information is not available, ImageName will be NULL.</param>
        /// <param name="checkSum">[in] Specifies the checksum of the module's image file. If this information is not available, CheckSum will be NULL.</param>
        /// <param name="timeDateStamp">[in] Specifies the time and date stamp of the module's image file. If this information is not available, TimeDateStamp will be zero.</param>
        /// <returns>This method returns a DEBUG_STATUS_XXX value, which indicates how the execution of the target should proceed after the engine processes this event.<para/>
        /// For details on how the engine treats this value, see Monitoring Events.</returns>
        /// <remarks>
        /// This method is only called by the engine if the DEBUG_EVENT_LOAD_MODULE flag is set in the mask returned by <see
        /// cref="GetInterestMask"/>. After calling this method, the engine will call <see cref="ChangeSymbolState"/>, with
        /// the Flags parameter containing the bit flag DEBUG_CSS_LOADS. For more information about handling events, see Monitoring
        /// Events.
        /// </remarks>
        [PreserveSig]
        DEBUG_STATUS LoadModule(
            [In] long imageFileHandle,
            [In] long baseOffset,
            [In] int moduleSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string imageName,
            [In] int checkSum,
            [In] int timeDateStamp);

        /// <summary>
        /// The UnloadModule callback method is called by the engine when a module-unload debugging event occurs in the target.
        /// </summary>
        /// <param name="imageBaseName">[in, optional] Specifies the name of the module's image file, which can include the path. If this information is not available, ImageBaseName will be NULL.</param>
        /// <param name="baseOffset">[in] Specifies the base address of the module in the target's memory address space. If this information is not available, BaseOffset will be NULL.</param>
        /// <returns>This method returns a DEBUG_STATUS_XXX value, which indicates how the execution of the target should proceed after the engine processes this event.<para/>
        /// For details on how the engine treats this value, see Monitoring Events.</returns>
        /// <remarks>
        /// This method is only called by the engine if the DEBUG_EVENT_UNLOAD_MODULE flag is set in the mask returned by <see
        /// cref="GetInterestMask"/>. After calling this method, the engine will call <see cref="ChangeSymbolState"/>, with
        /// the Flags parameter containing the bit flag DEBUG_CSS_UNLOADS. For more information about handling events, see
        /// Monitoring Events.
        /// </remarks>
        [PreserveSig]
        DEBUG_STATUS UnloadModule(
            [In, MarshalAs(UnmanagedType.LPWStr)] string imageBaseName,
            [In] long baseOffset);

        /// <summary>
        /// The SystemError callback method is called by the engine when a system error occurs in the target.
        /// </summary>
        /// <param name="error">[in] Specifies the error that caused the event.</param>
        /// <param name="level">[in] Specifies the severity of the error.</param>
        /// <returns>This method returns a DEBUG_STATUS_XXX value, which indicates how the execution of the target should proceed after the engine processes this event.<para/>
        /// For details on how the engine treats this value, see Monitoring Events.</returns>
        /// <remarks>
        /// This method is only called by the engine if the DEBUG_EVENT_SYSTEM_ERROR flag is set in the mask returned by <see
        /// cref="GetInterestMask"/>. For more information about handling events, see Monitoring Events.
        /// </remarks>
        [PreserveSig]
        DEBUG_STATUS SystemError(
            [In] int error,
            [In] int level);

        /// <summary>
        /// The SessionStatus callback method is called by the engine when a change occurs in the debugger session.
        /// </summary>
        /// <param name="status">[in] Specifies the new status of the debugger session. The following table describes the possible values.</param>
        /// <returns>This method's return value is ignored by the engine.</returns>
        /// <remarks>
        /// This method is only called by the engine if the DEBUG_EVENT_SESSION_STATUS flag is set in the mask returned by
        /// <see cref="GetInterestMask"/>. After the engine has notified all the event callbacks of the change in the session
        /// status, it will also notify any loaded extensions that export the DebugExtensionNotify callback method. The value
        /// that it passes to the extensions depends on the value of Status. If Status is DEBUG_SESSION_ACTIVE, it passes DEBUG_SESSION_ACTIVE;
        /// otherwise, it passes DEBUG_SESSION_INACTIVE. In the DEBUG_SESSION_ACTIVE case, the engine follows the debugger
        /// session change notification with a target state change notification by calling <see cref="ChangeDebuggeeState"/>
        /// on the event callbacks and passing DEBUG_CDS_ALL in the Flags parameter. In all other cases, the engine precedes
        /// this notification with an engine state change notification by calling <see cref="ChangeEngineState"/> on the event
        /// callbacks and passing DEBUG_CES_EXECUTION_STATUS in the Flags parameter. For more information about handling events,
        /// see Monitoring Events. For information about debugger sessions, see Debugging Session and Execution Model.
        /// </remarks>
        [PreserveSig]
        HRESULT SessionStatus(
            [In] DEBUG_SESSION status);

        /// <summary>
        /// The ChangeDebuggeeState callback method is called by the engine when it makes or detects changes to the target.
        /// </summary>
        /// <param name="flags">[in] Specifies the type of changes made to the target. Flags may take one of the following values:</param>
        /// <param name="argument">[in] Provides additional information about the change in the target. The interpretation of the value of Argument depends on the value of Flags:</param>
        /// <returns>The return value is ignored by the engine unless it indicates a remote procedure call error; in this case the client, with which this IDebugEventCallbacksWide object is registered, is disabled.</returns>
        /// <remarks>
        /// The engine calls ChangeDebuggeeState only if the DEBUG_EVENT_CHANGE_DEBUGGEE_STATE flag is set in the mask returned
        /// by <see cref="GetInterestMask"/>. For more information about handling events, see Monitoring Events. For information
        /// about managing the target's memory, including registers and data spaces, see Memory Access. For information about
        /// the target's virtual and physical memory, see Virtual and Physical Memory. For information about the target's control
        /// memory, I/O ports, MSR, and bus memory, see Other Data Spaces.
        /// </remarks>
        [PreserveSig]
        HRESULT ChangeDebuggeeState(
            [In] DEBUG_CDS flags,
            [In] long argument);

        /// <summary>
        /// The ChangeEngineState callback method is called by the engine when its state has changed.
        /// </summary>
        /// <param name="flags">[in] Specifies a bit-set indicating the type of changes that occurred in the engine's state. The following bit flags might be set:</param>
        /// <param name="argument">[in] Provides additional information about the change to the engine's state. If more than one bit flag is set in the Flags parameter, the Argument parameter is not used.<para/>
        /// Otherwise, the interpretation of the value of Argument depends on the value of Flags: The value of Argument is the current engine thread ID or--if there is no current thread--DEBUG_ANY_ID.<para/>
        /// For more information, see Threads and Processes. The value of Argument is the type of the effective processor. The value of Argument is the breakpoint ID of the breakpoint that was changed or--if more than one breakpoint was changed--DEBUG_ANY_ID.<para/>
        /// For more information, see Breakpoints. The value of Argument is the code interpretation level. The value of Argument is the execution status (as described in the DEBUG_STATUS_XXX topic) possibly combined with the bit flag <see cref="DEBUG_STATUS_FLAGS.INSIDE_WAIT"/>.<para/>
        /// <see cref="DEBUG_STATUS_FLAGS.INSIDE_WAIT"/> is set when a WaitForEvent call is pending. For more information, see Debugging Session and Execution Model.<para/>
        /// The value of Argument is the engine options. The value of Argument is TRUE if the log file was opened and FALSE if the log file was closed.<para/>
        /// The value of Argument is the default radix. The value of Argument is the index of the event filter that was changed or--if more than one event filter was changed--DEBUG_ANY_ID.<para/>
        /// The value of Argument is the process options for the current process. The value of Argument is zero. The value of Argument is the target ID of the target that was added or--if a target was removed--DEBUG_ANY_ID.<para/>
        /// The value of Argument is the assemble options. The value of Argument is the default expression syntax. The value of Argument is DEBUG_ANY_ID.</param>
        /// <returns>The return value is ignored by the engine unless it indicates a remote procedure call error; in this case the client, with which this IDebugEventCallbacksWide object is registered, is disabled.</returns>
        /// <remarks>
        /// This method is only called by the engine if the DEBUG_EVENT_CHANGE_ENGINE_STATE flag is set in the mask returned
        /// by <see cref="GetInterestMask"/>. For more information about handling events, see Monitoring Events.
        /// </remarks>
        [PreserveSig]
        HRESULT ChangeEngineState(
            [In] DEBUG_CES flags,
            [In] long argument);

        /// <summary>
        /// The ChangeSymbolState callback method is called by the engine when the symbol state changes.
        /// </summary>
        /// <param name="flags">[in] Specifies a bit-set indicating the nature of the change to the symbol state. The following bit flags might be set.</param>
        /// <param name="argument">[in] Provides additional information about the change to the symbol state. If more than one bit flag is set in the Flags parameter, the Argument parameter is not used.<para/>
        /// Otherwise, the value of Argument depends on the value of Flags: The value of Argument is the base location (in the target's memory address space) of the module image that the engine loaded symbols for.<para/>
        /// The value of Argument is the base location (in the target's memory address space) of the module image that the engine unloaded symbols for.<para/>
        /// If the engine unloaded symbols for more than one image, the value of Argument is zero. The value of Argument is zero.<para/>
        /// The value of Argument is zero. The value of Argument is the symbol options. The value of Argument is zero.</param>
        /// <returns>The return value is ignored by the engine unless it indicates a remote procedure call error; in this case the client, with which this IDebugEventCallbacksWide object is registered, is disabled.</returns>
        /// <remarks>
        /// This method is only called by the engine if the DEBUG_EVENT_CHANGE_SYMBOL_STATE flag is set in the mask returned
        /// by <see cref="GetInterestMask"/>. For more information about handling events, see Monitoring Events.
        /// </remarks>
        [PreserveSig]
        HRESULT ChangeSymbolState(
            [In] DEBUG_CSS flags,
            [In] long argument);
    }
}
