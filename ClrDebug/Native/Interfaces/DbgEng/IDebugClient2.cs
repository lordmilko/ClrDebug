using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("edbed635-372e-4dab-bbfe-ed0d2f63be81")]
    [ComImport]
    public interface IDebugClient2 : IDebugClient
    {
        #region IDebugClient

        /// <summary>
        /// The AttachKernel methods connect the debugger engine to a kernel target.
        /// </summary>
        /// <param name="Flags">[in] Specifies the flags that control how the debugger attaches to the kernel target. The possible values are:</param>
        /// <param name="ConnectOptions">[in, optional] Specifies the connection settings for communicating with the computer running the kernel target.<para/>
        /// The interpretation of ConnectOptions depends on the value of Flags. ConnectOptions will be interpreted the same way as the options that follow the -k switch on the WinDbg and KD command lines.<para/>
        /// Environment variables affect ConnectOptions in the same way they affect the -k switch. eXDI drivers are not described in this documentation.<para/>
        /// If you have an eXDI interface to your hardware probe or hardware simulator, please contact Microsoft for debugging information.<para/>
        /// eXDI drivers are not described in this documentation. If you have an eXDI interface to your hardware probe or hardware simulator, please contact Microsoft for debugging information.<para/>
        /// ConnectOptions will be interpreted the same way as the options that follow the -k switch on the WinDbg and KD command lines.<para/>
        /// Environment variables affect ConnectOptions in the same way they affect the -k switch.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        new HRESULT AttachKernel(
            [In] DEBUG_ATTACH Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string ConnectOptions);

        /// <summary>
        /// The GetKernelConnectionOptions method returns the connection options for the current kernel target.
        /// </summary>
        /// <param name="Buffer">[out, optional] Specifies the buffer to receive the connection options.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer Buffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="OptionsSize">[out, optional] Receives the size in characters of the connection options. This size includes the space for the '\0' terminating character.<para/>
        /// If OptionsSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live kernel targets that are not local and not connected through eXDI. The connection
        /// options returned are the same options used to connect to the kernel. For more information about connecting to live
        /// kernel-mode targets, see Live Kernel-Mode Targets.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetKernelConnectionOptions(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out int OptionsSize);

        /// <summary>
        /// The SetKernelConnectionOptions method updates some of the connection options for a live kernel target.
        /// </summary>
        /// <param name="Options">[in] Specifies the connection options to update. The possible values are:</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live kernel targets that are not local and not connected through eXDI. This method
        /// is reentrant. For more information about connecting to live kernel-mode targets, see Live Kernel-Mode Targets.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetKernelConnectionOptions(
            [In, MarshalAs(UnmanagedType.LPStr)] string Options);

        /// <summary>
        /// The StartProcessServer method starts a process server.
        /// </summary>
        /// <param name="Flags">[in] Specifies the class of the targets that will be available through the process server. This must be set to DEBUG_CLASS_USER_WINDOWS.</param>
        /// <param name="Options">[in] Specifies the connections options for this process server. These are the same options given to the -t option of the DbgSrv command line.<para/>
        /// For details on the syntax of this string, see Activating a Process Server.</param>
        /// <param name="Reserved">[in, optional] Set to NULL.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The process server that is started will be accessible by remote clients through the transport specified in the
        /// Options parameter. To stop the process server from the smart client, use the <see cref="EndProcessServer"/> method.
        /// To shut down the process server from the computer that it is running on, use Task Manager to end the process. If
        /// the instance of the debugger engine that used StartProcessServer is still running, it can use <see cref="IDebugControl.Execute"/>
        /// to issue the debugger command .endsrv 0, which will end the process server (this is an exception to the usual behavior
        /// of .endsrv, which generally does not affect process servers). For more information about process servers and remote
        /// debugging, see Process Servers, Kernel Connection Servers, and Smart Clients.
        /// </remarks>
        [PreserveSig]
        new HRESULT StartProcessServer(
            [In] DEBUG_CLASS Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Options,
            [In] IntPtr Reserved);

        /// <summary>
        /// The ConnectProcessServer methods connect to a process server.
        /// </summary>
        /// <param name="RemoteOptions">[in] Specifies how the debugger engine will connect with the process server. These are the same options passed to the -premote option on the WinDbg and CDB command lines.<para/>
        /// For details on the syntax of this string, see Activating a Smart Client.</param>
        /// <param name="Server">[out] Receives a handle for the process server. This handle is used when creating or attaching to processes by using the process server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about process servers and remote debugging, see Process Servers, Kernel Connection Servers,
        /// and Smart Clients.
        /// </remarks>
        [PreserveSig]
        new HRESULT ConnectProcessServer(
            [In, MarshalAs(UnmanagedType.LPStr)] string RemoteOptions,
            [Out] out long Server);

        /// <summary>
        /// The DisconnectProcessServer method disconnects the debugger engine from a process server.
        /// </summary>
        /// <param name="Server">[in] Specifies the server from which to disconnect. This handle must have been previously returned by <see cref="ConnectProcessServer"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about process servers and remote debugging, see Process Servers, Kernel Connection Servers,
        /// and Smart Clients.
        /// </remarks>
        [PreserveSig]
        new HRESULT DisconnectProcessServer(
            [In] long Server);

        /// <summary>
        /// The GetRunningProcessSystemIds method returns the process IDs for each running process.
        /// </summary>
        /// <param name="Server">[in] Specifies the process server to query for process IDs. If Server is zero, the engine will return the process IDs of the processes running on the local computer.</param>
        /// <param name="Ids">[out, optional] Receives the process IDs. The size of this array is Count. If Ids is NULL, this information is not returned.</param>
        /// <param name="Count">[in] Specifies the number of process IDs the array Ids can hold.</param>
        /// <param name="ActualCount">[out, optional] Receives the actual number of process IDs returned in Ids.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetRunningProcessSystemIds(
            [In] long Server,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            int[] Ids,
            [In] int Count,
            [Out] out int ActualCount);

        /// <summary>
        /// The GetRunningProcessSystemIdByExecutableName method searches for a process with a given executable file name and return its process ID.
        /// </summary>
        /// <param name="Server">[in] Specifies the process server to search for the executable name. If Server is zero, the engine will search for the executable name among the processes running on the local computer.</param>
        /// <param name="ExeName">[in] Specifies the executable file name for which to search.</param>
        /// <param name="Flags">[in] Specifies a bit-set that controls how the executable name is matched. The following flags may be present: If this flag is not set, this method will not use path names when searching for the process.</param>
        /// <param name="Id">[out] Receives the process ID of the first process to match ExeName.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetRunningProcessSystemIdByExecutableName(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string ExeName,
            [In] DEBUG_GET_PROC Flags,
            [Out] out int Id);

        /// <summary>
        /// The GetRunningProcessDescription method returns a description of the process that includes the executable image name, the service names, the MTS package names, and the command line.
        /// </summary>
        /// <param name="Server">[in] Specifies the process server to query for the process description. If Server is zero, the engine will query information about the local process directly.</param>
        /// <param name="SystemId">[in] Specifies the process ID of the process whose description is desired.</param>
        /// <param name="Flags">[in] Specifies a bit-set containing options that affect the behavior of this method. Flags can contain the following bit flags:</param>
        /// <param name="ExeName">[out, optional] Receives the name of the executable file used to start the process. If ExeName is NULL, this information is not returned.</param>
        /// <param name="ExeNameSize">[in] Specifies the size in characters of the buffer ExeNameSize. This size includes the space for the '\0' terminating character.</param>
        /// <param name="ActualExeNameSize">[out, optional] Receives the size in characters of the executable file name. This size includes the space for the '\0' terminating character.<para/>
        /// If ExeNameSize is NULL, this information is not returned.</param>
        /// <param name="Description">[out, optional] Receives extra information about the process, including service names, MTS package names, and the command line.<para/>
        /// If Description is NULL, this information is not returned.</param>
        /// <param name="DescriptionSize">[in] Specifies the size in characters of the buffer Description. This size includes the space for the '\0' terminating character.</param>
        /// <param name="ActualDescriptionSize">[out, optional] Receives the size in characters of the extra information. This size includes the space for the '\0' terminating character.<para/>
        /// If ActualDescriptionSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetRunningProcessDescription(
            [In] long Server,
            [In] int SystemId,
            [In] DEBUG_PROC_DESC Flags,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder ExeName,
            [In] int ExeNameSize,
            [Out] out int ActualExeNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Description,
            [In] int DescriptionSize,
            [Out] out int ActualDescriptionSize);

        /// <summary>
        /// The AttachProcess method connects the debugger engine to a user-modeprocess.
        /// </summary>
        /// <param name="Server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to a local process without using a process server.</param>
        /// <param name="ProcessID">[in] Specifies the process ID of the target process the debugger will attach to.</param>
        /// <param name="AttachFlags">[in] Specifies the flags that control how the debugger attaches to the target process. For details on these flags, see Remarks.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. The DEBUG_ATTACH_XXX bit-flags control how the debugger
        /// engine attaches to a user-mode process. For the DEBUG_ATTACH_XXX options used when attaching to a kernel target,
        /// see <see cref="AttachKernel"/>. The following table describes the possible flag values. If this flag is set, then
        /// the flags DEBUG_ATTACH_EXISTING, DEBUG_ATTACH_INVASIVE_NO_INITIAL_BREAK, and DEBUG_ATTACH_INVASIVE_RESUME_PROCESS
        /// must not be set. If this flag is set, then the other DEBUG_ATTACH_XXX flags must not be set. If this flag is set,
        /// then the flag DEBUG_ATTACH_NONINVASIVE must also be set. If this flag is set, then the flags DEBUG_ATTACH_NONINVASIVE
        /// and DEBUG_ATTACH_EXISTING must not be set.
        /// </remarks>
        [PreserveSig]
        new HRESULT AttachProcess(
            [In] long Server,
            [In] int ProcessID,
            [In] DEBUG_ATTACH AttachFlags);

        /// <summary>
        /// The CreateProcess method creates a process from the specified command line.
        /// </summary>
        /// <param name="Server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will create a local process without using a process server.</param>
        /// <param name="CommandLine">[in] Specifies the command line to execute to create the new process.</param>
        /// <param name="Flags">[in] Specifies the flags to use when creating the process. For details on these flags, see the CreateFlags member of the <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CreateFlags contains either of the flags DEBUG_PROCESS
        /// or DEBUG_ONLY_THIS_PROCESS, the engine will also attach to the newly created process; this is similar to the behavior
        /// of <see cref="IDebugClient5.CreateProcessAndAttach2"/> with its argument ProcessId set to zero. For more information
        /// about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        [PreserveSig]
        new HRESULT CreateProcess(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS Flags);

        /// <summary>
        /// The CreateProcessAndAttach method creates a process from a specified command line, then attach to another user-mode process.<para/>
        /// The created process is suspended and only allowed to execute when the attach has completed. This allows rough synchronization when debugging both, client and server processes.
        /// </summary>
        /// <param name="Server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="CommandLine">[in, optional] Specifies the command line to execute to create the new process. If CommandLine is NULL, then no process is created and these methods attach to an existing process, as <see cref="AttachProcess"/> does.</param>
        /// <param name="Flags">[in] Specifies the flags to use when creating the process. For details on these flags, see <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/>.CreateFlags.</param>
        /// <param name="ProcessId">[in] Specifies the process ID of the target process the debugger will attach to. If ProcessId is zero, the debugger will attach to the process it created from CommandLine.</param>
        /// <param name="AttachFlags">[in] Specifies the flags that control how the debugger attaches to the target process. For details on these flags, see DEBUG_ATTACH_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CommandLine is not NULL and ProcessId is not zero,
        /// then the engine will create the process in a suspended state. The engine will resume this newly created process
        /// after it successfully connects to the process specified in ProcessId.
        /// </remarks>
        [PreserveSig]
        new HRESULT CreateProcessAndAttach(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS Flags,
            [In] int ProcessId,
            [In] DEBUG_ATTACH AttachFlags);

        /// <summary>
        /// The GetProcessOptions method retrieves the process options affecting the current process.
        /// </summary>
        /// <param name="Options">[out] Receives a set of flags representing the process options for the current process. For details on these options, see DEBUG_PROCESS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in live user-mode debugging. Some of the process options are global options, others
        /// are specific to the current process. For more information about creating and attaching to live user-mode targets,
        /// see Live User-Mode Targets.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetProcessOptions(
            [Out] out DEBUG_PROCESS Options);

        /// <summary>
        /// The AddProcessOptions method adds the process options to those options that affect the current process.
        /// </summary>
        /// <param name="Options">[in] Specifies the process options to add to those affecting the current process. For details on these process options, see DEBUG_PROCESS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only in live user-mode debugging. Some of the process options are global options, others
        /// are specific to the current process. If any process options are modified, the engine will notify the event callbacks
        /// by calling their <see cref="IDebugEventCallbacks.ChangeEngineState"/> method with the DEBUG_CES_PROCESS_OPTIONS
        /// flag set. For more information about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        [PreserveSig]
        new HRESULT AddProcessOptions(
            [In] DEBUG_PROCESS Options);

        /// <summary>
        /// The RemoveProcessOptions method removes process options from those options that affect the current process.
        /// </summary>
        /// <param name="Options">[in] Specifies the process options to remove from those affecting the current process. For details on these options, see DEBUG_PROCESS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only in live user-mode debugging. Some of the process options are global options, others
        /// are specific to the current process. If any process options are modified, the engine will notify the event callbacks
        /// by calling their <see cref="IDebugEventCallbacks.ChangeEngineState"/> method with the DEBUG_CES_PROCESS_OPTIONS
        /// flag set. For more information about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        [PreserveSig]
        new HRESULT RemoveProcessOptions(
            [In] DEBUG_PROCESS Options);

        /// <summary>
        /// The SetProcessOptions method sets the process options affecting the current process.
        /// </summary>
        /// <param name="Options">[in] Specifies a set of flags that will become the new process options for the current process. For details on these options, see DEBUG_PROCESS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only in live user-mode debugging. Some of the process options are global options, others
        /// are specific to the current process. If any process options are modified, the engine will notify the event callbacks
        /// by calling their <see cref="IDebugEventCallbacks.ChangeEngineState"/> method with the DEBUG_CES_PROCESS_OPTIONS
        /// flag set. For more information about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetProcessOptions(
            [In] DEBUG_PROCESS Options);

        /// <summary>
        /// The OpenDumpFile method opens a dump file as a debugger target.
        /// </summary>
        /// <param name="DumpFile">[in] Specifies the name of the dump file to open. DumpFile must include the file name extension. DumpFile can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// DumpFile can have the form of a file URL, starting with "file://". If DumpFile specifies a cabinet (.cab) file, the cabinet file is searched for the first file with extension .kdmp, then .hdmp, then .mdmp, and finally .dmp.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The Unicode version of this method is <see cref="IDebugClient4.OpenDumpFileWide"/>.
        /// </remarks>
        [PreserveSig]
        new HRESULT OpenDumpFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile);

        /// <summary>
        /// The WriteDumpFile method creates a user-mode or kernel-modecrash dump file.
        /// </summary>
        /// <param name="DumpFile">[in] Specifies the name of the dump file to create. DumpFile must include the file name extension. DumpFile can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.</param>
        /// <param name="Qualifier">[in] Specifies the type of dump file to create. For possible values, see Remarks.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The DEBUG_DUMP_XXX constants are used by the methods WriteDumpFile, <see cref="WriteDumpFile2"/>, and <see cref="IDebugClient4.WriteDumpFileWide"/>
        /// to specify the type of crash dump file to create. The possible values include the following. Creates a Complete
        /// Memory Dump (kernel-mode only). To specify the formatting of the file and--for user-mode minidumps--the information
        /// to include in the file, use <see cref="WriteDumpFile2"/> or <see cref="IDebugClient4.WriteDumpFileWide"/>. For
        /// more information about crash dump files, see Dump-File Targets. Moreover, the following aliases are available for
        /// kernel-mode debugging. Additionally, the following aliases are available for user-mode debugging. For a description
        /// of kernel-mode dump files, see Varieties of Kernel-Mode Dump Files. For a description of user-mode dump files,
        /// see Varieties of User-Mode Dump Files.
        /// </remarks>
        [PreserveSig]
        new HRESULT WriteDumpFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile,
            [In] DEBUG_DUMP Qualifier);

        /// <summary>
        /// The ConnectSession method joins the client to an existing debugger session.
        /// </summary>
        /// <param name="Flags">[in] Specifies a bit-set of option flags for connecting to the session. The possible values of these flags are:</param>
        /// <param name="HistoryLimit">[in] Specifies the maximum number of characters from the session's history to send to this client's output upon connection.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When the client object connects to a session, the most recent output from the session is sent to the client. If
        /// the session is currently waiting on input, the client object is given the opportunity to provide input. Thus, the
        /// client object synchronizes with the session's input and output. The client becomes a primary client and will appear
        /// among the list of clients in the output of the .clients debugger command. For more information about debugging
        /// clients, see Debugging Server and Debugging Client. For more information about debugger sessions, see Debugging
        /// Session and Execution Model.
        /// </remarks>
        [PreserveSig]
        new HRESULT ConnectSession(
            [In] DEBUG_CONNECT_SESSION Flags,
            [In] int HistoryLimit);

        /// <summary>
        /// The StartServer method starts a debugging server.
        /// </summary>
        /// <param name="Options">[in] Specifies the connections options for this server. These are the same options given to the .server debugger command or the WinDbg and CDB -server command-line option.<para/>
        /// For details on the syntax of this string, see Activating a Debugging Server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The server that is started will be accessible by other debuggers through the transport specified in the Options
        /// parameter. For more information about debugging servers, see Debugging Server and Debugging Client.
        /// </remarks>
        [PreserveSig]
        new HRESULT StartServer(
            [In, MarshalAs(UnmanagedType.LPStr)] string Options);

        [PreserveSig]
        new HRESULT OutputServer(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Machine,
            [In] DEBUG_SERVERS Flags);

        /// <summary>
        /// The TerminateProcesses method attempts to terminate all processes in all targets.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Only live user-mode processes are terminated by this method. For other targets, the target is detached from the
        /// debugger without terminating. For more information about creating and attaching to live user-mode targets, see
        /// Live User-Mode Targets.
        /// </remarks>
        [PreserveSig]
        new HRESULT TerminateProcesses();

        /// <summary>
        /// The DetachProcesses method detaches the debugger engine from all processes in all targets, resuming all their threads.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The targets must be running on Windows XP or a later version of Windows. For more information about creating and
        /// attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        [PreserveSig]
        new HRESULT DetachProcesses();

        /// <summary>
        /// The EndSession method ends the current debugger session.
        /// </summary>
        /// <param name="Flags">[in] Specifies how to end the session. Flags can be one of the following values: This flag is intended for when remote clients disconnect.<para/>
        /// It generates a server message about the disconnection.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method may be called at any time with Flags set to DEBUG_END_REENTRANT. If, for example, the application needs
        /// to exit but another thread is using the engine, this method can be used to perform as much cleanup as possible.
        /// Using DEBUG_END_REENTRANT may leave the engine in an indeterminate state. If this flag is used, no subsequent calls
        /// should be made to the engine. For more information about debugger sessions, see Debugging Session and Execution
        /// Model.
        /// </remarks>
        [PreserveSig]
        new HRESULT EndSession(
            [In] DEBUG_END Flags);

        /// <summary>
        /// The GetExitCode method returns the exit code of the current process if that process has already run through to completion.
        /// </summary>
        /// <param name="Code">[out] Receives the exit code of the process. If the process is still running, Code will be set to STILL_ACTIVE.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetExitCode(
            [Out] out int Code);

        /// <summary>
        /// The DispatchCallbacks method lets the debugger engine use the current thread for callbacks.
        /// </summary>
        /// <param name="Timeout">[in] Specifies how many milliseconds to wait before this method will return. If Timeout is INFINITE, this method will not return until <see cref="ExitDispatch"/> is called or an error occurs.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method returns when Timeout milliseconds have elapsed, <see cref="ExitDispatch"/> is called, or an error occurs.
        /// Almost all client methods must be called from the thread in which the client was created; callback objects registered
        /// with the client are also called from this thread. When DispatchCallbacks is called the engine can use the current
        /// thread to make callback calls. Client threads should call this method whenever possible to allow the callbacks
        /// to be called, unless the thread was the same thread used to start the debugger session, in which case the callbacks
        /// are called when <see cref="IDebugControl.WaitForEvent"/> is called. For more information about callbacks, see Callbacks.
        /// </remarks>
        [PreserveSig]
        new HRESULT DispatchCallbacks(
            [In] int Timeout);

        /// <summary>
        /// The ExitDispatch method causes the <see cref="DispatchCallbacks"/> method to return.
        /// </summary>
        /// <param name="Client">[in] Specifies the client whose <see cref="DispatchCallbacks"/> method should return.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is reentrant and may be called from any thread. This method can be used to interrupt a thread waiting
        /// in <see cref="DispatchCallbacks"/>. For more information about callbacks, see Callbacks.
        /// </remarks>
        [PreserveSig]
        new HRESULT ExitDispatch(
            [In] IntPtr Client);

        /// <summary>
        /// The CreateClient method creates a new client object for the current thread.
        /// </summary>
        /// <param name="Client">[out] Receives an interface pointer for the new client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method creates a client that may be used in the current thread. Clients are specific to the thread that created
        /// them. Calls from other threads fail immediately. The CreateClient method is a notable exception; it allows creation
        /// of a new client for a new thread. All callbacks for a client are made in the thread with which the client was created.
        /// For more information about client objects and how they are used in the debugger engine, see Client Objects.
        /// </remarks>
        [PreserveSig]
        new HRESULT CreateClient(
            [Out] IntPtr Client);

        /// <summary>
        /// The GetInputCallbacks method returns the input callbacks object registered with this client.
        /// </summary>
        /// <param name="Callbacks">[out] Receives an interface pointer for the <see cref="IDebugInputCallbacks"/> object registered with the client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugInputCallbacks"/> object registered with it to receive requests
        /// for input. If no IDebugInputCallbacks object is registered with the client, the value of Callbacks will be set
        /// to NULL. The IDebugInputCallbacks interface extends the COM interface IUnknown. Before returning the IDebugInputCallbacks
        /// object specified by Callbacks, the engine calls its IUnknown::AddRef method. When this object is no longer needed,
        /// its IUnknown::Release method should be called. For more information about callbacks, see Callbacks.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetInputCallbacks(
            [Out, MarshalAs(UnmanagedType.Interface)]
            out IDebugInputCallbacks Callbacks);

        /// <summary>
        /// The SetInputCallbacks method registers an input callbacks object with the client.
        /// </summary>
        /// <param name="Callbacks">[in, optional] Specifies the interface pointer to the input callbacks object to register with this client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugInputCallbacks"/> object registered with it to receive requests
        /// for input. The IDebugInputCallbacks interface extends the COM interface IUnknown. SetInputCallbacks will call the
        /// IUnknown::AddRef method of the object specified by Callbacks. The IUnknown::Release method of this interface will
        /// be called the next time SetInputCallbacks is called on this client, or when this client is deleted.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetInputCallbacks(
            [In, MarshalAs(UnmanagedType.Interface)]
            IDebugInputCallbacks Callbacks);

        /// <summary>
        /// The GetOutputCallbacks method returns the output callbacks object registered with the client.
        /// </summary>
        /// <param name="Callbacks">[out] Receives an interface pointer to the <see cref="IDebugOutputCallbacks"/> object registered with the client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugOutputCallbacks"/> or IDebugOutputCallbacksWide object registered
        /// with it for output. If no output callbacks object is registered with the client, the value of Callbacks will be
        /// set to NULL. The IDebugOutputCallbacks interface extends the COM interface IUnknown. Before returning the IDebugOutputCallbacks
        /// object specified by Callbacks, the engine calls its IUnknown::AddRef method. When this object is no longer needed,
        /// its IUnknown::Release method should be called. For more information about callbacks, see Callbacks.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetOutputCallbacks(
            [Out] out IDebugOutputCallbacks Callbacks);

        /// <summary>
        /// The SetOutputCallbacks method registers an output callbacks object with this client.
        /// </summary>
        /// <param name="Callbacks">[in, optional] Specifies the interface pointer to the output callbacks object to register with this client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugOutputCallbacks"/> or IDebugOutputCallbacks object registered
        /// with it for output. The IDebugOutputCallbacks interface extends the COM interface IUnknown. SetOutputCallbacks
        /// and SetOutputCAllbacksWide call the IUnknown::AddRef method in the object specified by Callbacks. The IUnknown::Release
        /// method of this interface will be called the next time SetOutputCallbacks or SetOutputCallbacksWide is called on
        /// this client, or when this client is deleted. For more information about callbacks, see Callbacks.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetOutputCallbacks(
            [In] IDebugOutputCallbacks Callbacks);

        /// <summary>
        /// The GetOutputMask method returns the output mask currently set for the client.
        /// </summary>
        /// <param name="Mask">[out] Receives the output mask for the client. See DEBUG_OUTPUT_XXX for details on how to interpret this value.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of output in the debugger engine, see Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetOutputMask(
            [Out] out DEBUG_OUTPUT Mask);

        /// <summary>
        /// The SetOutputMask method sets the output mask for the client.
        /// </summary>
        /// <param name="Mask">[in] Specifies the new output mask for the client. See DEBUG_OUTPUT_XXX for a description of the possible values for Mask.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of output in the debugger engine, see Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetOutputMask(
            [In] DEBUG_OUTPUT Mask);

        /// <summary>
        /// The GetOtherOutputMask method returns the output mask for another client.
        /// </summary>
        /// <param name="Client">[in] Specifies the client whose output mask is desired.</param>
        /// <param name="Mask">[out] Receives the output mask for the client. See DEBUG_OUTPUT_XXX for details on how to interpret this value.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of output in the debugger engine, see Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetOtherOutputMask(
            [In] IntPtr Client,
            [Out] out DEBUG_OUTPUT Mask);

        /// <summary>
        /// The SetOtherOutputMask method sets the output mask for another client.
        /// </summary>
        /// <param name="Client">[in] Specifies the client whose output mask will be set.</param>
        /// <param name="Mask">[in] Specifies the new output mask for the client. See DEBUG_OUTPUT_XXX for a description of the possible values for Mask.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of output in the debugger engine, see Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetOtherOutputMask(
            [In] IntPtr Client,
            [In] DEBUG_OUTPUT Mask);

        /// <summary>
        /// Gets the width of an output line forcommands that produce formatted output.
        /// </summary>
        /// <param name="Columns">[out] The number of columns in the output.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This setting is a suggestion that can be overridden by other settings.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetOutputWidth(
            [Out] out int Columns);

        /// <param name="Columns">[in] The number of columns in the output.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This setting is a suggestion that can be overridden by other settings.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetOutputWidth(
            [In] int Columns);

        /// <param name="Buffer">[out] A pointer to the buffer to get the prefix.</param>
        /// <param name="BufferSize">[in] The size of the buffer.</param>
        /// <param name="PrefixSize">[out, optional] A pointer to the size of the buffer.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Some of the engine commands producemultiple lines of output. A prefix can be added to each line. The prefix value
        /// is not a general setting for any outputthat contains a newline. Methods which usethe line prefix are marked in
        /// their documentation.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetOutputLinePrefix(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out int PrefixSize);

        /// <param name="Prefix">[in, optional] A pointer to the prefix value.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Some of the engine commands producemultiple lines of output. This function sets a prefix that the engine adds to
        /// each line. This function allows the caller to control indentation or identifying marks. The prefix value is not
        /// a general setting for any outputthat contains a newline. Methods which usethe line prefix are marked in their documentation.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetOutputLinePrefix(
            [In, MarshalAs(UnmanagedType.LPStr)] string Prefix);

        /// <summary>
        /// The GetIdentity method returns a string describing the computer and user this client represents.
        /// </summary>
        /// <param name="Buffer">[out, optional] Specifies the buffer to receive the string. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size of the buffer Buffer.</param>
        /// <param name="IdentitySize">[out, optional] Receives the size of the string. If IdentitySize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The specific content of the string varies with the operating system. If the client is remotely connected, some
        /// network information may also be present. For more information about client objects, see Client Objects.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetIdentity(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out int IdentitySize);

        /// <summary>
        /// The OutputIdentity method formats and outputs a string describing the computer and user this client represents.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="Flags">[in] Set to zero.</param>
        /// <param name="Format">[in] Specifies a format string similar to the printf format string. However, this format string must only contain one formatting directive, %s, which will be replaced by a description of the computer and user this client represents.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The specific content of the string varies with the operating system. If the client is remotely connected, some
        /// network information may also be present. For more information about client objects, see Client Objects.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputIdentity(
            [In] DEBUG_OUTCTL OutputControl,
            [In] int Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        /// <summary>
        /// The GetEventCallbacks method returns the event callbacks object registered with this client.
        /// </summary>
        /// <param name="Callbacks">[out] Receives an interface pointer to the event callbacks object registered with this client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugEventCallbacks"/> or IDebugEventCallbacksWide object registered
        /// with it for receiving events. If no event callbacks object is registered with the client, the value of Callbacks
        /// will be set to NULL. The IDebugEventCallbacks interface extends the COM interface IUnknown. Before returning the
        /// IDebugEventCallbacks object specified by Callbacks, the engine calls its IUnknown::AddRef method. When this object
        /// is no longer needed, its IUnknown::Release method should be called. For more information about callbacks, see Callbacks.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetEventCallbacks(
            [Out] out IDebugEventCallbacks Callbacks);

        /// <summary>
        /// The SetEventCallbacks method registers an event callbacks object with this client.
        /// </summary>
        /// <param name="Callbacks">[in, optional] Specifies the interface pointer to the event callbacks object to register with this client.</param>
        /// <returns>Depending on the implementation of the method <see cref="IDebugEventCallbacks.GetInterestMask"/> in the object specified by Callbacks, other values may be returned, as described in the Remarks section.</returns>
        /// <remarks>
        /// If the value of Callbacks is not NULL, the method IDebugEventCallbacks::GetInterestMask is called. If the return
        /// value is not S_OK, SetEventCallbacks and SetEventCallbacksWide have no effect and they return this value. Each
        /// client can have at most one <see cref="IDebugEventCallbacks"/> or IDebugEventCallbacksWide object registered with
        /// it for receiving events. The IDebugEventCallbacks interface extends the COM interface IUnknown. When SetEventCallbacks
        /// and SetEventCallbacksWide are successful, they call the IUnknown::AddRef method of the object specified by Callbacks.
        /// The IUnknown::Release method of this object will be called the next time SetEventCallbacks or SetEventCallbacksWide
        /// is called on this client, or when this client is deleted. For more information about callbacks, see Callbacks.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetEventCallbacks(
            [In] IDebugEventCallbacks Callbacks);

        /// <summary>
        /// The FlushCallbacks method forces any remaining buffered output to be delivered to the <see cref="IDebugOutputCallbacks"/> object registered with this client.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine sometimes merges compatible callback requests to reduce callback overhead; small pieces of output are
        /// collected into larger groups to reduce the number of <see cref="IDebugOutputCallbacks.Output"/> calls. Using FlushCallbacks
        /// is necessary for a client to guarantee that all pending callbacks have been processed at a particular point. For
        /// example, a caller can flush callbacks before starting a lengthy operation outside of the engine so that pending
        /// callbacks are not delayed until after the operation. For more information about callbacks, see Callbacks.
        /// </remarks>
        [PreserveSig]
        new HRESULT FlushCallbacks();

        #endregion
        #region IDebugClient2

        /// <summary>
        /// The WriteDumpFile2 method creates a user-mode or kernel-modecrash dump file.
        /// </summary>
        /// <param name="DumpFile">[in] Specifies the name of the dump file to create. DumpFile must include the file name extension. DumpFile can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.</param>
        /// <param name="Qualifier">[in] Specifies the type of dump file to create. For possible values, see DEBUG_DUMP_XXX.</param>
        /// <param name="FormatFlags">[in] Specifies flags that determine the format of the dump file and--for user-mode minidumps--what information to include in the file.<para/>
        /// For details, see Remarks.</param>
        /// <param name="Comment">[in, optional] Specifies a comment string to be included in the crash dump file. This string is displayed in the debugger console when the dump file is loaded.<para/>
        /// Some dump file formats do not support the storing of comment strings.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The DEBUG_FORMAT_XXX bit-flags are used by WriteDumpFile2 and <see cref="IDebugClient4.WriteDumpFileWide"/> to
        /// determine the format of a crash dump file and, for user-mode Minidumps, what information to include in the file.
        /// The following bit-flags apply to all crash dump files. The following bit-flags can also be included for user-mode
        /// Minidumps. For more information about crash dump files, see Dump-File Targets.
        /// </remarks>
        [PreserveSig]
        HRESULT WriteDumpFile2(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile,
            [In] DEBUG_DUMP Qualifier,
            [In] DEBUG_FORMAT FormatFlags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Comment);

        /// <summary>
        /// The AddDumpInformationFile method registers additional files containing supporting information that will be used when opening a dump file.<para/>
        /// The Unicode version of this method is <see cref="IDebugClient4.AddDumpInformationFileWide"/>.
        /// </summary>
        /// <param name="InfoFile">[in] Specifies the name of the file containing the supporting information.</param>
        /// <param name="Type">[in] Specifies the type of the file InfoFile. Currently, only files containing paging file information are supported, and Type must be set to DEBUG_DUMP_FILE_PAGE_FILE_DUMP.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If supporting information is to be used when opening a dump file, this method or <see cref="IDebugClient4.AddDumpInformationFileWide"/>
        /// must be called before <see cref="OpenDumpFile"/> is called. If a session has already started, this method cannot
        /// be used. For more information about crash dump files, see Dump File Targets.
        /// </remarks>
        [PreserveSig]
        HRESULT AddDumpInformationFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string InfoFile,
            [In] DEBUG_DUMP_FILE Type);

        /// <summary>
        /// The EndProcessServer method requests that a process server be shut down.
        /// </summary>
        /// <param name="Server">[in] Specifies the process server to shut down. This handle must have been previously returned by <see cref="ConnectProcessServer"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about process servers and remote debugging, see Process Servers, Kernel Connection Servers,
        /// and Smart Clients.
        /// </remarks>
        [PreserveSig]
        HRESULT EndProcessServer(
            [In] long Server);

        /// <summary>
        /// The WaitForProcessServerEnd method waits for a local process server to exit.
        /// </summary>
        /// <param name="Timeout">[in] Specifies how long in milliseconds to wait for a process server to exit. If Timeout is INFINITE, this method will not return until a process server has ended.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method will only wait for the first local process server to end. After a process server has ended, subsequent
        /// calls to this method will return immediately. For more information about process servers and remote debugging,
        /// see Process Servers, Kernel Connection Servers, and Smart Clients. The constant INFINITE is defined in Winbase.h.
        /// </remarks>
        [PreserveSig]
        HRESULT WaitForProcessServerEnd(
            [In] int Timeout);

        /// <summary>
        /// The IsKernelDebuggerEnabled method checks whether kernel debugging is enabled for the local kernel.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Kernel debugging is available for the local computer if the computer was booted by using the /debug boot switch.
        /// In some Windows installations, local kernel debugging is supported when other switches--such as /debugport--are
        /// used, but this is not a guaranteed feature of Windows and should not be relied on. For more information about kernel
        /// debugging on a single computer, see Performing Local Kernel Debugging. For more information about connecting to
        /// live kernel-mode targets, see Live Kernel-Mode Targets.
        /// </remarks>
        [PreserveSig]
        HRESULT IsKernelDebuggerEnabled();

        /// <summary>
        /// The TerminateCurrentProcess method attempts to terminate the current process.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Only live user-modeprocesses are terminated by this method. For other targets, the target is detached from the
        /// debugger engine without terminating. For more information about creating and attaching to live user-mode targets,
        /// see Live User-Mode Targets.
        /// </remarks>
        [PreserveSig]
        HRESULT TerminateCurrentProcess();

        /// <summary>
        /// The DetachCurrentProcess method detaches the debugger engine from the current process, resuming all its threads.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The target must be running on Windows XP or a later versions of Windows. For more information about creating and
        /// attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        [PreserveSig]
        HRESULT DetachCurrentProcess();

        /// <summary>
        /// The AbandonCurrentProcess method removes the current process from the debugger engine's process list without detaching or terminating the process.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available for live user-mode debugging. The target must be running on Windows XP or a later
        /// version of Windows. Windows will continue to consider this process as being debugged, and so the process will remain
        /// suspended. This method allows the debugger to be shut down and a new debugger to attach to the process. See Live
        /// User-Mode Targets and Re-attaching to the Target Application for more information.
        /// </remarks>
        [PreserveSig]
        HRESULT AbandonCurrentProcess();

        #endregion
    }
}
