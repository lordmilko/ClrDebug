﻿using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using static ClrDebug.Extensions;

namespace ClrDebug
{
    #region Delegates

    /// <summary>
    /// Provides the <see cref="ICLRDebugging"/> interface.
    /// </summary>
    /// <param name="clsid">[in] Supports only the CLSID_CLRDebugging class identifier.</param>
    /// <param name="riid">[in] Supports only the IID_ICLRDebugging interface identifiers.</param>
    /// <param name="ppInterface">[out] A <see cref="ICLRDebugging"/> instance.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT CLRCreateInstanceDelegate(
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid clsid,
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
        [MarshalAs(UnmanagedType.Interface), Out] out object ppInterface);

    /// <summary>
    /// Closes any valid common language runtime (CLR) continue-startup events located in an array of handles returned by the EnumerateCLRs function, and frees the memory for the handle and string path arrays.
    /// </summary>
    /// <param name="pHandleArray">[in] Pointer to the array of event handles returned from the EnumerateCLRs function.</param>
    /// <param name="pStringArray">[in] Pointer to the array of CLR string paths returned from the EnumerateCLRs function.</param>
    /// <param name="dwArrayLength">[in] DWORD that contains the size (length) of either pHandleArray or pStringArray (they are the same).</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT CloseCLREnumerationDelegate(
        [In] IntPtr pHandleArray,
        [In] IntPtr pStringArray,
        [In] int dwArrayLength);

    /// <summary>
    /// Closes the handle returned by the CreateProcessForLaunch function.
    /// </summary>
    /// <param name="hResumeHandle">[in] The resume handle returned by CreateProcessForLaunch function.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT CloseResumeHandleDelegate(
        [In] IntPtr hResumeHandle);

    /// <summary>
    /// Creates a version string from a common language runtime (CLR) path in a target process.
    /// </summary>
    /// <param name="pidDebuggee">[in] Identifier of the process in which the target CLR is loaded.</param>
    /// <param name="szModuleName">[in] Full or relative path to the target CLR that is loaded in the process.</param>
    /// <param name="pBuffer">[out] Return buffer for storing the version string for the target CLR.</param>
    /// <param name="cchBuffer">[in] Size of pBuffer.</param>
    /// <param name="pdwLength">[out] Length of the version string returned by pBuffer.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT CreateVersionStringFromModuleDelegate(
        [In] int pidDebuggee,
        [MarshalAs(UnmanagedType.LPWStr), In] string szModuleName,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3), SRI.Out] char[] pBuffer,
        [In] int cchBuffer,
        [Out] out int pdwLength);

    /// <summary>
    /// Accepts a common language runtime (CLR) version string that is returned from the CreateVersionStringFromModule function, and returns a corresponding debugger interface (typically, <see cref="ICorDebug"/>).
    /// </summary>
    /// <param name="szDebuggeeVersion">[in] Version string of the CLR in the target debuggee, which is returned by the CreateVersionStringFromModule function.</param>
    /// <param name="ppCordb">[out] Pointer to a pointer to a COM object (IUnknown). This object will be cast to an ICorDebug object before it is returned.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT CreateDebuggingInterfaceFromVersionDelegate(
        [MarshalAs(UnmanagedType.LPWStr), In] string szDebuggeeVersion,
        [Out] out IntPtr ppCordb);

    /// <summary>
    /// Accepts a common language runtime (CLR) version string that is returned from the CreateVersionStringFromModule function, and returns a corresponding debugger interface (typically, <see cref="ICorDebug"/>).
    /// </summary>
    /// <param name="iDebuggerVersion">[in] The version of interface the debugger expects.</param>
    /// <param name="szDebuggeeVersion">[in] Version string of the CLR in the target debuggee, which is returned by the CreateVersionStringFromModule function.</param>
    /// <param name="ppCordb">[out] Pointer to a pointer to a COM object (IUnknown). This object will be cast to an <see cref="ICorDebug"/> object before it is returned.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT CreateDebuggingInterfaceFromVersionExDelegate(
        [In] CorDebugInterfaceVersion iDebuggerVersion,
        [MarshalAs(UnmanagedType.LPWStr), In] string szDebuggeeVersion,
        [Out] out IntPtr ppCordb);

    /// <summary>
    /// Accepts a common language runtime (CLR) version string that is returned from the CreateVersionStringFromModule function, and returns a corresponding debugger interface (typically, <see cref="ICorDebug"/>).
    /// </summary>
    /// <param name="iDebuggerVersion">[in] The version of interface the debugger expects.</param>
    /// <param name="szDebuggeeVersion">[in] Version string of the CLR in the target debuggee, which is returned by the CreateVersionStringFromModule function.</param>
    /// <param name="szApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in macOS. Pass NULL if the process is not running in a sandbox on macOS or on other platforms.</param>
    /// <param name="ppCordb">[out] Pointer to a pointer to a COM object (IUnknown). This object will be cast to an <see cref="ICorDebug"/> object before it is returned.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT CreateDebuggingInterfaceFromVersion2Delegate(
        [In] CorDebugInterfaceVersion iDebuggerVersion,
        [MarshalAs(UnmanagedType.LPWStr), In] string szDebuggeeVersion,
        [MarshalAs(UnmanagedType.LPWStr), In] string szApplicationGroupId,
        [Out] out IntPtr ppCordb);

    /// <summary>
    /// Accepts a common language runtime (CLR) version string that is returned from the CreateVersionStringFromModule function, and returns a corresponding debugger interface (typically, <see cref="ICorDebug"/>).
    /// </summary>
    /// <param name="iDebuggerVersion">[in] The version of interface the debugger expects.</param>
    /// <param name="szDebuggeeVersion">[in] Version string of the CLR in the target debuggee, which is returned by the CreateVersionStringFromModule function.</param>
    /// <param name="szApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in macOS. Pass NULL if the process is not running in a sandbox on macOS or on other platforms.</param>
    /// <param name="pLibraryProvider">[in] A callback interface instance for locating DBI and DAC. See <see cref="ICLRDebuggingLibraryProvider3"/> interface.</param>
    /// <param name="ppCordb">[out] Pointer to a pointer to a COM object (IUnknown). This object will be cast to an <see cref="ICorDebug"/> object before it is returned.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT CreateDebuggingInterfaceFromVersion3Delegate(
        [In] CorDebugInterfaceVersion iDebuggerVersion,
        [MarshalAs(UnmanagedType.LPWStr), In] string szDebuggeeVersion,
        [MarshalAs(UnmanagedType.LPWStr), In] string szApplicationGroupId,
        [In, MarshalAs(UnmanagedType.Interface)] ICLRDebuggingLibraryProvider3 pLibraryProvider,
        [Out] out IntPtr ppCordb);

    /// <summary>
    /// A subset of the Windows CreateProcess that can be supported cross-platform.
    /// </summary>
    /// <param name="lpCommandLine">[in] The command line to be executed.</param>
    /// <param name="bSuspendProcess">[in] If this parameter is TRUE, suspend the process for launch.</param>
    /// <param name="lpEnvironment">[in, optional] A pointer to the environment block for the new process. If this parameter is NULL, the new process uses the environment of the calling process.</param>
    /// <param name="lpCurrentDirectory">[in, optional] The full path to the current directory for the process. If this parameter is NULL, the new process will have the same current drive and directory as the calling process.</param>
    /// <param name="pProcessId">[out] The id to identify the process created.</param>
    /// <param name="pResumeHandle">[out] The handle to use with ResumeProcess to resume the process if bSuspendProcess is TRUE.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT CreateProcessForLaunchDelegate(
        [MarshalAs(UnmanagedType.LPWStr), In] string lpCommandLine,
        [In, MarshalAs(UnmanagedType.Bool)] bool bSuspendProcess,
        [In] IntPtr lpEnvironment,
        [MarshalAs(UnmanagedType.LPWStr), In] string lpCurrentDirectory,
        [Out] out int pProcessId,
        [Out] out IntPtr pResumeHandle);

    /// <summary>
    /// Provides a mechanism for enumerating the CLRs in a process.
    /// </summary>
    /// <param name="debuggeePID">[in] Process identifier of the process from which loaded CLRs will be enumerated.</param>
    /// <param name="ppHandleArrayOut">[out] Pointer to an array containing event handles that are used to continue a CLR startup.
    /// Each handle in the array is not guaranteed to be valid. If valid, the handle is to be used as the continue-startup event for the corresponding
    /// runtime located in the same index of <paramref name="ppStringArrayOut"/>.</param>
    /// <param name="ppStringArrayOut">[out] Pointer to an array of strings that specify full paths to CLRs loaded in the process.</param>
    /// <param name="pdwArrayLengthOut">[out] Pointer to a DWORD that contains the length of the equally sized ppHandleArrayOut and pdwArrayLengthOut.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT EnumerateCLRsDelegate(
        [In] int debuggeePID,
        [Out] out IntPtr ppHandleArrayOut,
        [Out] out IntPtr ppStringArrayOut,
        [Out] out int pdwArrayLengthOut);

    /// <summary>
    /// Creates or opens an event handle that will be signaled upon by any common language runtime (CLR) that is loading in the specified target process. This API is Windows only.
    /// </summary>
    /// <param name="debuggeePID">[in] Process identifier of the target process from which to receive CLR startup notifications.</param>
    /// <param name="phStartupEvent">[out] A pointer to a handle that will be signaled by a CLR on startup.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT GetStartupNotificationEventDelegate(
        [In] int debuggeePID,
        [Out] out IntPtr phStartupEvent);

    /// <summary>
    /// Points to a function that is called when the .NET Core runtime has started for the RegisterForRuntimeStartup API.
    /// </summary>
    /// <param name="pCordb">[in] Pointer to a pointer to a COM object (IUnknown). This object will be cast to an <see cref="ICorDebug"/> object before it is returned.</param>
    /// <param name="parameter">[in] The 'parameter' value passed to RegisterForRuntimeStartup.</param>
    /// <param name="hr">[in] The result of the operation.</param>
    public delegate void PSTARTUP_CALLBACK(
        //This type cannot be ICorDebug. In .NET Core, the runtime freaks out when we try to marshal it. You can work around this with an ICustomMarshaler,
        //however there is absolutely no way to marshal the parameter cross-platform in NativeAOT (NativeAOT will only try and use a globally registered ComWrappers
        //type on Windows). As such it's easier if we just marshal the pointer ourselves
        [In] IntPtr pCordb,
        [In] IntPtr parameter,
        [In] HRESULT hr);

    /// <summary>
    /// Executes the callback when the .NET Core runtime starts in the specified process.
    /// </summary>
    /// <param name="dwProcessId">[in] The process id of the target process.</param>
    /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
    /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
    /// <param name="ppUnregisterToken">[out] pointer to return the UnregisterForRuntimeStartup token.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT RegisterForRuntimeStartupDelegate(
        [In] int dwProcessId,
        [MarshalAs(UnmanagedType.FunctionPtr), In] PSTARTUP_CALLBACK pfnCallback,
        [In] IntPtr parameter,
        [Out] out IntPtr ppUnregisterToken);

    /// <summary>
    /// Executes the callback when the .NET Core runtime starts in the specified process.
    /// </summary>
    /// <param name="dwProcessId">[in] The process id of the target process.</param>
    /// <param name="lpApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in Mac. Pass NULL if the process is not running in a sandbox and other platforms.</param>
    /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
    /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
    /// <param name="ppUnregisterToken">[out] pointer to return the UnregisterForRuntimeStartup token.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT RegisterForRuntimeStartupExDelegate(
        [In] int dwProcessId,
        [In, MarshalAs(UnmanagedType.LPWStr)] string lpApplicationGroupId,
        [MarshalAs(UnmanagedType.FunctionPtr), In] PSTARTUP_CALLBACK pfnCallback,
        [In] IntPtr parameter,
        [Out] out IntPtr ppUnregisterToken);

    /// <summary>
    /// Executes the callback when the .NET Core runtime starts in the specified process.
    /// </summary>
    /// <param name="dwProcessId">[in] The process id of the target process.</param>
    /// <param name="lpApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in Mac. Pass NULL if the process is not running in a sandbox and other platforms.</param>
    /// <param name="pLibraryProvider">[in] A callback interface instance for locating DBI and DAC. See ICLRDebuggingLibraryProvider3 interface.</param>
    /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
    /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
    /// <param name="ppUnregisterToken">[out] pointer to return the UnregisterForRuntimeStartup token.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT RegisterForRuntimeStartup3Delegate(
        [In] int dwProcessId,
        [In, MarshalAs(UnmanagedType.LPWStr)] string lpApplicationGroupId,
        [In, MarshalAs(UnmanagedType.Interface)] ICLRDebuggingLibraryProvider3 pLibraryProvider,
        [MarshalAs(UnmanagedType.FunctionPtr), In] PSTARTUP_CALLBACK pfnCallback,
        [In] IntPtr parameter,
        [Out] out IntPtr ppUnregisterToken);

    /// <summary>
    /// Resumes the process using the resume handle returned by the CreateProcessForLaunch function.
    /// </summary>
    /// <param name="hResumeHandle">[in] The resume handle returned by CreateProcessForLaunch function.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT ResumeProcessDelegate(
        [In] IntPtr hResumeHandle);

    /// <summary>
    /// Stops/cancels runtime startup notification.
    /// </summary>
    /// <param name="pUnregisterToken">[in] The token from the RegisterForRuntimeStartup APIs.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    public delegate HRESULT UnregisterForRuntimeStartupDelegate(
        [In] IntPtr pUnregisterToken);

#endregion

#if !GENERATED_MARSHALLING
    /// <summary>
    /// Provides facilities for interacting with the .NET Core DbgShim library.<para/>
    /// The .NET Standard version of this type (that you are using) only supports Windows.
    /// </summary>
#else
    /// <summary>
    /// Provides facilities for interacting with the .NET Core DbgShim library.<para/>
    /// This type is cross-platform compatible.
    /// </summary>
#endif
    public class DbgShim
    {
        //Cache the last PSTARTUP_CALLBACK delegate used on each method to prevent it from being garbage collected
        private PSTARTUP_CALLBACK lastRegisterForRuntimeStartupCallback;
        private PSTARTUP_CALLBACK lastRegisterForRuntimeStartupExCallback;
        private PSTARTUP_CALLBACK lastRegisterForRuntimeStartup3Callback;
        private DelegateProvider delegateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbgShim"/> class.
        /// </summary>
        /// <param name="hModule">A handle to a DbgShim library that has been loaded into the process.</param>
        public DbgShim(IntPtr hModule)
        {
            if (hModule == IntPtr.Zero)
                throw new ArgumentNullException(nameof(hModule));

            delegateProvider = new DelegateProvider(hModule);
        }

        #region CLRCreateInstance

        /// <summary>
        /// Provides the <see cref="ICLRDebugging"/> interface.
        /// </summary>
        /// <param name="clsid">[in] Supports only the CLSID_CLRDebugging class identifier.</param>
        /// <param name="riid">[in] Supports only the IID_ICLRDebugging interface identifiers.</param>
        /// <returns>A <see cref="ICLRDebugging"/> instance.</returns>
        public object CLRCreateInstance(Guid clsid, Guid riid)
        {
            TryCLRCreateInstance(clsid, riid, out var ppInterface).ThrowOnNotOK();
            return ppInterface;
        }

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="CLRCreateInstance(Guid, Guid)"/>.
        /// </summary>
        /// <returns>The common interfaces that can be retrieved from <see cref="CLRCreateInstance(Guid, Guid)"/>.</returns>
        public CLRCreateInstanceInterfaces CLRCreateInstance() => new CLRCreateInstanceInterfaces(this);

        /// <summary>
        /// Tries to provide the <see cref="ICLRDebugging"/> interface.
        /// </summary>
        /// <param name="clsid">[in] Supports only the CLSID_CLRDebugging class identifier.</param>
        /// <param name="riid">[in] Supports only the IID_ICLRDebugging interface identifiers.</param>
        /// <param name="ppInterface">[out] A <see cref="ICLRDebugging"/> instance.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryCLRCreateInstance(Guid clsid, Guid riid, out object ppInterface)
        {
            var @delegate = delegateProvider.CLRCreateInstance;

            return @delegate(clsid, riid, out ppInterface);
        }

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="CLRCreateInstance(Guid, Guid)"/>.
        /// </summary>
        public class CLRCreateInstanceInterfaces
        {
            private DbgShim dbgshim;

            internal CLRCreateInstanceInterfaces(DbgShim dbgshim)
            {
                this.dbgshim = dbgshim;
            }

            /// <summary>
            /// Provides methods that handle loading and unloading modules for debugging.
            /// </summary>
            public CLRDebugging CLRDebugging => new CLRDebugging(CreateInstance<ICLRDebugging>(CLSID_CLRDebugging));

            private T CreateInstance<T>(Guid clsid) => (T)dbgshim.CLRCreateInstance(clsid, typeof(T).GUID);
        }

        #endregion
        #region CloseCLREnumeration

        /// <summary>
        /// Closes any valid common language runtime (CLR) continue-startup events located in an array of handles returned by the EnumerateCLRs function,
        /// and frees the memory for the handle and string path arrays.
        /// </summary>
        /// <param name="result">[in] The data structure that was returned from <see cref="EnumerateCLRs(int)"/> containing the enumerator
        /// details that should be closed.</param>
        public void CloseCLREnumeration(EnumerateCLRsResult result) => TryCloseCLREnumeration(result).ThrowOnNotOK();

        /// <summary>
        /// Closes any valid common language runtime (CLR) continue-startup events located in an array of handles returned by the EnumerateCLRs function, and frees the memory for the handle and string path arrays.
        /// </summary>
        /// <param name="pHandleArray">[in] Pointer to the array of event handles returned from the EnumerateCLRs function.</param>
        /// <param name="pStringArray">[in] Pointer to the array of CLR string paths returned from the EnumerateCLRs function.</param>
        /// <param name="dwArrayLength">[in] DWORD that contains the size (length) of either pHandleArray or pStringArray (they are the same).</param>
        public void CloseCLREnumeration(IntPtr pHandleArray, IntPtr pStringArray, int dwArrayLength)
        {
            TryCloseCLREnumeration(pHandleArray, pStringArray, dwArrayLength).ThrowOnNotOK();
        }

        /// <summary>
        /// Tries to close any valid common language runtime (CLR) continue-startup events located in an array of handles returned by the EnumerateCLRs function, and frees the memory for the handle and string path arrays.
        /// </summary>
        /// <param name="result">[in] The data structure that was returned from <see cref="EnumerateCLRs(int)"/> containing the enumerator
        /// details that should be closed.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryCloseCLREnumeration(EnumerateCLRsResult result) =>
            TryCloseCLREnumeration(result.HandleArrayOut, result.StringArrayOut, result.ArrayLengthOut);

        /// <summary>
        /// Tries to close any valid common language runtime (CLR) continue-startup events located in an array of handles returned by the EnumerateCLRs function, and frees the memory for the handle and string path arrays.
        /// </summary>
        /// <param name="pHandleArray">[in] Pointer to the array of event handles returned from the EnumerateCLRs function.</param>
        /// <param name="pStringArray">[in] Pointer to the array of CLR string paths returned from the EnumerateCLRs function.</param>
        /// <param name="dwArrayLength">[in] DWORD that contains the size (length) of either pHandleArray or pStringArray (they are the same).</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryCloseCLREnumeration(IntPtr pHandleArray, IntPtr pStringArray, int dwArrayLength)
        {
            var @delegate = delegateProvider.CloseCLREnumeration;

            return @delegate(pHandleArray, pStringArray, dwArrayLength);
        }

        #endregion
        #region CloseResumeHandle

        /// <summary>
        /// Closes the handle returned by the CreateProcessForLaunch function.
        /// </summary>
        /// <param name="hResumeHandle">[in] The resume handle returned by CreateProcessForLaunch function.</param>
        public void CloseResumeHandle(IntPtr hResumeHandle)
        {
            TryCloseResumeHandle(hResumeHandle).ThrowOnNotOK();
        }

        /// <summary>
        /// Tries to close the handle returned by the CreateProcessForLaunch function.
        /// </summary>
        /// <param name="hResumeHandle">[in] The resume handle returned by CreateProcessForLaunch function.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryCloseResumeHandle(IntPtr hResumeHandle)
        {
            var @delegate = delegateProvider.CloseResumeHandle;

            return @delegate(hResumeHandle);
        }

        #endregion
        #region CreateVersionStringFromModule

        /// <summary>
        /// Creates a version string from a common language runtime (CLR) path in a target process.
        /// </summary>
        /// <param name="pidDebuggee">[in] Identifier of the process in which the target CLR is loaded.</param>
        /// <param name="szModuleName">[in] Full or relative path to the target CLR that is loaded in the process.</param>
        /// <returns>The version string for the target CLR.</returns>
        public string CreateVersionStringFromModule(int pidDebuggee, string szModuleName)
        {
            TryCreateVersionStringFromModule(pidDebuggee, szModuleName, out var version).ThrowOnNotOK();

            return version;
        }

        /// <summary>
        /// Tries to create a version string from a common language runtime (CLR) path in a target process.
        /// </summary>
        /// <param name="pidDebuggee">[in] Identifier of the process in which the target CLR is loaded.</param>
        /// <param name="szModuleName">[in] Full or relative path to the target CLR that is loaded in the process.</param>
        /// <param name="version">[out] The version string for the target CLR.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateVersionStringFromModule(
            int pidDebuggee,
            string szModuleName,
            out string version)
        {
            var @delegate = delegateProvider.CreateVersionStringFromModule;

            var hr = @delegate(pidDebuggee, szModuleName, null, 0, out var pdwLength);

            if (hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            var pBuffer = new char[pdwLength];

            hr = @delegate(pidDebuggee, szModuleName, pBuffer, pdwLength, out pdwLength);

            if (hr == HRESULT.S_OK)
            {
                version = CreateString(pBuffer, pdwLength);
                return hr;
            }

            fail:
            version = null;
            return hr;
        }

        #endregion
        #region CreateDebuggingInterfaceFromVersion

        /// <summary>
        /// Accepts a common language runtime (CLR) version string that is returned from the CreateVersionStringFromModule function, and returns a corresponding debugger interface (typically, <see cref="ICorDebug"/>).
        /// </summary>
        /// <param name="szDebuggeeVersion">[in] Version string of the CLR in the target debuggee, which is returned by the CreateVersionStringFromModule function.</param>
        /// <returns>Pointer to a pointer to a COM object (IUnknown). This object will be cast to an ICorDebug object before it is returned.</returns>
        public CorDebug CreateDebuggingInterfaceFromVersion(string szDebuggeeVersion)
        {
            TryCreateDebuggingInterfaceFromVersion(szDebuggeeVersion, out var ppCordb).ThrowOnNotOK();
            return ppCordb;
        }

        /// <summary>
        /// Accepts a common language runtime (CLR) version string that is returned from the CreateVersionStringFromModule function, and returns a corresponding debugger interface (typically, <see cref="ICorDebug"/>).
        /// </summary>
        /// <param name="szDebuggeeVersion">[in] Version string of the CLR in the target debuggee, which is returned by the CreateVersionStringFromModule function.</param>
        /// <param name="ppCordb">[out] Pointer to a pointer to a COM object (IUnknown). This object will be cast to an ICorDebug object before it is returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateDebuggingInterfaceFromVersion(string szDebuggeeVersion, out CorDebug ppCordb)
        {
            var @delegate = delegateProvider.CreateDebuggingInterfaceFromVersion;

            var hr = @delegate(szDebuggeeVersion, out var raw);

            if (hr == HRESULT.S_OK)
                ppCordb = new CorDebug(GetObjectForIUnknown<ICorDebug>(raw));
            else
                ppCordb = null;

            return hr;
        }

        #endregion
        #region CreateDebuggingInterfaceFromVersionEx

        /// <summary>
        /// Accepts a common language runtime (CLR) version string that is returned from the CreateVersionStringFromModule function, and returns a corresponding debugger interface (typically, <see cref="ICorDebug"/>).
        /// </summary>
        /// <param name="iDebuggerVersion">[in] The version of interface the debugger expects.</param>
        /// <param name="szDebuggeeVersion">[in] Version string of the CLR in the target debuggee, which is returned by the CreateVersionStringFromModule function.</param>
        /// <returns>Pointer to a pointer to a COM object (IUnknown). This object will be cast to an <see cref="ICorDebug"/> object before it is returned.</returns>
        public CorDebug CreateDebuggingInterfaceFromVersionEx(CorDebugInterfaceVersion iDebuggerVersion, string szDebuggeeVersion)
        {
            TryCreateDebuggingInterfaceFromVersionEx(iDebuggerVersion, szDebuggeeVersion, out var ppCordb).ThrowOnNotOK();
            return ppCordb;
        }

        /// <summary>
        /// Accepts a common language runtime (CLR) version string that is returned from the CreateVersionStringFromModule function, and returns a corresponding debugger interface (typically, <see cref="ICorDebug"/>).
        /// </summary>
        /// <param name="iDebuggerVersion">[in] The version of interface the debugger expects.</param>
        /// <param name="szDebuggeeVersion">[in] Version string of the CLR in the target debuggee, which is returned by the CreateVersionStringFromModule function.</param>
        /// <param name="ppCordb">[out] Pointer to a pointer to a COM object (IUnknown). This object will be cast to an <see cref="ICorDebug"/> object before it is returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateDebuggingInterfaceFromVersionEx(
            CorDebugInterfaceVersion iDebuggerVersion,
            string szDebuggeeVersion,
            out CorDebug ppCordb)
        {
            var @delegate = delegateProvider.CreateDebuggingInterfaceFromVersionEx;

            var hr = @delegate(iDebuggerVersion, szDebuggeeVersion, out var raw);

            if (hr == HRESULT.S_OK)
                ppCordb = new CorDebug(GetObjectForIUnknown<ICorDebug>(raw));
            else
                ppCordb = null;

            return hr;
        }

        #endregion
        #region CreateDebuggingInterfaceFromVersion2

        /// <summary>
        /// Accepts a common language runtime (CLR) version string that is returned from the CreateVersionStringFromModule function, and returns a corresponding debugger interface (typically, <see cref="ICorDebug"/>).
        /// </summary>
        /// <param name="iDebuggerVersion">[in] The version of interface the debugger expects.</param>
        /// <param name="szDebuggeeVersion">[in] Version string of the CLR in the target debuggee, which is returned by the CreateVersionStringFromModule function.</param>
        /// <param name="szApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in macOS. Pass NULL if the process is not running in a sandbox on macOS or on other platforms.</param>
        /// <returns>Pointer to a pointer to a COM object (IUnknown). This object will be cast to an <see cref="ICorDebug"/> object before it is returned.</returns>
        public CorDebug CreateDebuggingInterfaceFromVersion2(CorDebugInterfaceVersion iDebuggerVersion, string szDebuggeeVersion, string szApplicationGroupId)
        {
            TryCreateDebuggingInterfaceFromVersion2(iDebuggerVersion, szDebuggeeVersion, szApplicationGroupId, out var ppCordb).ThrowOnNotOK();
            return ppCordb;
        }

        /// <summary>
        /// Accepts a common language runtime (CLR) version string that is returned from the CreateVersionStringFromModule function, and returns a corresponding debugger interface (typically, <see cref="ICorDebug"/>).
        /// </summary>
        /// <param name="iDebuggerVersion">[in] The version of interface the debugger expects.</param>
        /// <param name="szDebuggeeVersion">[in] Version string of the CLR in the target debuggee, which is returned by the CreateVersionStringFromModule function.</param>
        /// <param name="szApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in macOS. Pass NULL if the process is not running in a sandbox on macOS or on other platforms.</param>
        /// <param name="ppCordb">[out] Pointer to a pointer to a COM object (IUnknown). This object will be cast to an <see cref="ICorDebug"/> object before it is returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateDebuggingInterfaceFromVersion2(
            CorDebugInterfaceVersion iDebuggerVersion,
            string szDebuggeeVersion,
            string szApplicationGroupId,
            out CorDebug ppCordb)
        {
            var @delegate = delegateProvider.CreateDebuggingInterfaceFromVersion2;

            var hr = @delegate(iDebuggerVersion, szDebuggeeVersion, szApplicationGroupId, out var raw);

            if (hr == HRESULT.S_OK)
                ppCordb = new CorDebug(GetObjectForIUnknown<ICorDebug>(raw));
            else
                ppCordb = null;

            return hr;
        }

        #endregion
        #region CreateDebuggingInterfaceFromVersion3

        /// <summary>
        /// Accepts a common language runtime (CLR) version string that is returned from the CreateVersionStringFromModule function, and returns a corresponding debugger interface (typically, <see cref="ICorDebug"/>).
        /// </summary>
        /// <param name="iDebuggerVersion">[in] The version of interface the debugger expects.</param>
        /// <param name="szDebuggeeVersion">[in] Version string of the CLR in the target debuggee, which is returned by the CreateVersionStringFromModule function.</param>
        /// <param name="szApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in macOS. Pass NULL if the process is not running in a sandbox on macOS or on other platforms.</param>
        /// <param name="pLibraryProvider">[in] A callback interface instance for locating DBI and DAC. See <see cref="ICLRDebuggingLibraryProvider3"/> interface.</param>
        /// <returns>Pointer to a pointer to a COM object (IUnknown). This object will be cast to an <see cref="ICorDebug"/> object before it is returned.</returns>
        public CorDebug CreateDebuggingInterfaceFromVersion3(
            CorDebugInterfaceVersion iDebuggerVersion,
            string szDebuggeeVersion,
            string szApplicationGroupId,
            ICLRDebuggingLibraryProvider3 pLibraryProvider)
        {
            TryCreateDebuggingInterfaceFromVersion3(iDebuggerVersion, szDebuggeeVersion, szApplicationGroupId, pLibraryProvider, out var ppCordb).ThrowOnNotOK();
            return ppCordb;
        }

        /// <summary>
        /// Accepts a common language runtime (CLR) version string that is returned from the CreateVersionStringFromModule function, and returns a corresponding debugger interface (typically, <see cref="ICorDebug"/>).
        /// </summary>
        /// <param name="iDebuggerVersion">[in] The version of interface the debugger expects.</param>
        /// <param name="szDebuggeeVersion">[in] Version string of the CLR in the target debuggee, which is returned by the CreateVersionStringFromModule function.</param>
        /// <param name="szApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in macOS. Pass NULL if the process is not running in a sandbox on macOS or on other platforms.</param>
        /// <param name="pLibraryProvider">[in] A callback interface instance for locating DBI and DAC. See <see cref="ICLRDebuggingLibraryProvider3"/> interface.</param>
        /// <param name="ppCordb">[out] Pointer to a pointer to a COM object (IUnknown). This object will be cast to an <see cref="ICorDebug"/> object before it is returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateDebuggingInterfaceFromVersion3(
            CorDebugInterfaceVersion iDebuggerVersion,
            string szDebuggeeVersion,
            string szApplicationGroupId,
            ICLRDebuggingLibraryProvider3 pLibraryProvider,
            out CorDebug ppCordb)
        {
            var @delegate = delegateProvider.CreateDebuggingInterfaceFromVersion3;

            var hr = @delegate(iDebuggerVersion, szDebuggeeVersion, szApplicationGroupId, pLibraryProvider, out var raw);

            if (hr == HRESULT.S_OK)
                ppCordb = new CorDebug(GetObjectForIUnknown<ICorDebug>(raw));
            else
                ppCordb = null;

            return hr;
        }

        #endregion
        #region CreateProcessForLaunch

        /// <summary>
        /// A subset of the Windows CreateProcess that can be supported cross-platform.
        /// </summary>
        /// <param name="lpCommandLine">[in] The command line to be executed.</param>
        /// <param name="bSuspendProcess">[in] If this parameter is TRUE, suspend the process for launch.</param>
        /// <param name="lpEnvironment">[in, optional] A pointer to the environment block for the new process. If this parameter is NULL, the new process uses the environment of the calling process.</param>
        /// <param name="lpCurrentDirectory">[in, optional] The full path to the current directory for the process. If this parameter is NULL, the new process will have the same current drive and directory as the calling process.</param>
        /// <returns>A struct that encapsulates the process ID and resume handle.</returns>
        public CreateProcessForLaunchResult CreateProcessForLaunch(
            string lpCommandLine,
            bool bSuspendProcess,
            IntPtr lpEnvironment = default(IntPtr),
            string lpCurrentDirectory = null)
        {
            TryCreateProcessForLaunch(lpCommandLine, bSuspendProcess, lpEnvironment, lpCurrentDirectory, out var result).ThrowOnNotOK();
            return result;
        }

        /// <summary>
        /// A subset of the Windows CreateProcess that can be supported cross-platform.
        /// </summary>
        /// <param name="lpCommandLine">[in] The command line to be executed.</param>
        /// <param name="bSuspendProcess">[in] If this parameter is TRUE, suspend the process for launch.</param>
        /// <param name="lpEnvironment">[in, optional] A pointer to the environment block for the new process. If this parameter is NULL, the new process uses the environment of the calling process.</param>
        /// <param name="lpCurrentDirectory">[in, optional] The full path to the current directory for the process. If this parameter is NULL, the new process will have the same current drive and directory as the calling process.</param>
        /// <param name="result">A struct that encapsulates the process ID and resume handle.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateProcessForLaunch(
            string lpCommandLine,
            bool bSuspendProcess,
            IntPtr lpEnvironment,
            string lpCurrentDirectory,
            out CreateProcessForLaunchResult result)
        {
            var @delegate = delegateProvider.CreateProcessForLaunch;

            var hr = @delegate(lpCommandLine, bSuspendProcess, lpEnvironment, lpCurrentDirectory, out var pProcessId, out var pResumeHandle);

            if (hr == HRESULT.S_OK)
                result = new CreateProcessForLaunchResult(pProcessId, pResumeHandle);
            else
                result = default(CreateProcessForLaunchResult);

            return hr;
        }

        #endregion
        #region EnumerateCLRs

        /// <summary>
        /// Provides a mechanism for enumerating the CLRs in a process.
        /// </summary>
        /// <param name="debuggeePID">[in] Process identifier of the process from which loaded CLRs will be enumerated.</param>
        /// <returns>A struct that encapsulates the outputs of the function.</returns>
        public EnumerateCLRsResult EnumerateCLRs(int debuggeePID)
        {
            TryEnumerateCLRs(debuggeePID, out var result).ThrowOnNotOK();
            return result;
        }

        /// <summary>
        /// Provides a mechanism for enumerating the CLRs in a process.
        /// </summary>
        /// <param name="debuggeePID">[in] Process identifier of the process from which loaded CLRs will be enumerated.</param>
        /// <param name="result">A struct that encapsulates the outputs of the function.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryEnumerateCLRs(
            int debuggeePID,
            out EnumerateCLRsResult result)
        {
            var @delegate = delegateProvider.EnumerateCLRs;

            var hr = @delegate(debuggeePID, out var ppHandleArrayOut, out var ppStringArrayOut, out var pdwArrayLengthOut);

            //We have to return the raw pointers wrapped in a struct - not just the desired EnumerateCLRsResultItem items - because
            //those pointers will later need to be closed by passing this data structure into CloseCLREnumeration()
            if (hr == HRESULT.S_OK)
                result = new EnumerateCLRsResult(ppHandleArrayOut, ppStringArrayOut, pdwArrayLengthOut);
            else
                result = default(EnumerateCLRsResult);

            return hr;
        }

        #endregion
        #region GetStartupNotificationEvent

        /// <summary>
        /// Creates or opens an event handle that will be signaled upon by any common language runtime (CLR) that is loading in the specified target process. This API is Windows only.
        /// </summary>
        /// <param name="debuggeePID">[in] Process identifier of the target process from which to receive CLR startup notifications.</param>
        /// <returns>A pointer to a handle that will be signaled by a CLR on startup.</returns>
        public IntPtr GetStartupNotificationEvent(int debuggeePID)
        {
            TryGetStartupNotificationEvent(debuggeePID, out var phStartupEvent).ThrowOnNotOK();
            return phStartupEvent;
        }

        /// <summary>
        /// Tries to create or open an event handle that will be signaled upon by any common language runtime (CLR) that is loading in the specified target process. This API is Windows only.
        /// </summary>
        /// <param name="debuggeePID">[in] Process identifier of the target process from which to receive CLR startup notifications.</param>
        /// <param name="phStartupEvent">[out] A pointer to a handle that will be signaled by a CLR on startup.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetStartupNotificationEvent(int debuggeePID, out IntPtr phStartupEvent)
        {
            var @delegate = delegateProvider.GetStartupNotificationEvent;

            return @delegate(debuggeePID, out phStartupEvent);
        }

        #endregion
        #region RegisterForRuntimeStartup

        /// <summary>
        /// Executes the callback when the .NET Core runtime starts in the specified process.
        /// </summary>
        /// <param name="dwProcessId">[in] The process id of the target process.</param>
        /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
        /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
        /// <returns>Pointer to return the UnregisterForRuntimeStartup token.</returns>
        public IntPtr RegisterForRuntimeStartup(
            int dwProcessId,
            PSTARTUP_CALLBACK pfnCallback,
            IntPtr parameter = default(IntPtr))
        {
            TryRegisterForRuntimeStartup(dwProcessId, pfnCallback, parameter, out var ppUnregisterToken).ThrowOnNotOK();
            return ppUnregisterToken;
        }

        /// <summary>
        /// Executes the callback when the .NET Core runtime starts in the specified process.
        /// </summary>
        /// <param name="dwProcessId">[in] The process id of the target process.</param>
        /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
        /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
        /// <param name="ppUnregisterToken">[out] pointer to return the UnregisterForRuntimeStartup token.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryRegisterForRuntimeStartup(
            int dwProcessId,
            PSTARTUP_CALLBACK pfnCallback,
            IntPtr parameter,
            out IntPtr ppUnregisterToken)
        {
            lastRegisterForRuntimeStartupCallback = pfnCallback;

            var @delegate = delegateProvider.RegisterForRuntimeStartup;

            return @delegate(dwProcessId, pfnCallback, parameter, out ppUnregisterToken);
        }

        #endregion
        #region RegisterForRuntimeStartupEx

        /// <summary>
        /// Executes the callback when the .NET Core runtime starts in the specified process.
        /// </summary>
        /// <param name="dwProcessId">[in] The process id of the target process.</param>
        /// <param name="lpApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in Mac. Pass NULL if the process is not running in a sandbox and other platforms.</param>
        /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
        /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
        /// <returns>Pointer to return the UnregisterForRuntimeStartup token.</returns>
        public IntPtr RegisterForRuntimeStartupEx(
            int dwProcessId,
            string lpApplicationGroupId,
            PSTARTUP_CALLBACK pfnCallback,
            IntPtr parameter)
        {
            TryRegisterForRuntimeStartupEx(dwProcessId, lpApplicationGroupId, pfnCallback, parameter, out var ppUnregisterToken).ThrowOnNotOK();
            return ppUnregisterToken;
        }

        /// <summary>
        /// Executes the callback when the .NET Core runtime starts in the specified process.
        /// </summary>
        /// <param name="dwProcessId">[in] The process id of the target process.</param>
        /// <param name="lpApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in Mac. Pass NULL if the process is not running in a sandbox and other platforms.</param>
        /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
        /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
        /// <param name="ppUnregisterToken">[out] pointer to return the UnregisterForRuntimeStartup token.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryRegisterForRuntimeStartupEx(
            int dwProcessId,
            string lpApplicationGroupId,
            PSTARTUP_CALLBACK pfnCallback,
            IntPtr parameter,
            out IntPtr ppUnregisterToken)
        {
            lastRegisterForRuntimeStartupExCallback = pfnCallback;

            var @delegate = delegateProvider.RegisterForRuntimeStartupEx;

            return @delegate(dwProcessId, lpApplicationGroupId, pfnCallback, parameter, out ppUnregisterToken);
        }

        #endregion
        #region RegisterForRuntimeStartup3

        /// <summary>
        /// Executes the callback when the .NET Core runtime starts in the specified process.
        /// </summary>
        /// <param name="dwProcessId">[in] The process id of the target process.</param>
        /// <param name="lpApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in Mac. Pass NULL if the process is not running in a sandbox and other platforms.</param>
        /// <param name="pLibraryProvider">[in] A callback interface instance for locating DBI and DAC. See ICLRDebuggingLibraryProvider3 interface.</param>
        /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
        /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
        /// <returns>Pointer to return the UnregisterForRuntimeStartup token.</returns>
        public IntPtr RegisterForRuntimeStartup3(
            int dwProcessId,
            string lpApplicationGroupId,
            ICLRDebuggingLibraryProvider3 pLibraryProvider,
            PSTARTUP_CALLBACK pfnCallback,
            IntPtr parameter)
        {
            TryRegisterForRuntimeStartup3(dwProcessId, lpApplicationGroupId, pLibraryProvider, pfnCallback, parameter, out var ppUnregisterToken).ThrowOnNotOK();
            return ppUnregisterToken;
        }

        /// <summary>
        /// Executes the callback when the .NET Core runtime starts in the specified process.
        /// </summary>
        /// <param name="dwProcessId">[in] The process id of the target process.</param>
        /// <param name="lpApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in Mac. Pass NULL if the process is not running in a sandbox and other platforms.</param>
        /// <param name="pLibraryProvider">[in] A callback interface instance for locating DBI and DAC. See ICLRDebuggingLibraryProvider3 interface.</param>
        /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
        /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
        /// <param name="ppUnregisterToken">[out] pointer to return the UnregisterForRuntimeStartup token.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryRegisterForRuntimeStartup3(
            int dwProcessId,
            string lpApplicationGroupId,
            ICLRDebuggingLibraryProvider3 pLibraryProvider,
            PSTARTUP_CALLBACK pfnCallback,
            IntPtr parameter,
            out IntPtr ppUnregisterToken)
        {
            lastRegisterForRuntimeStartup3Callback = pfnCallback;

            var @delegate = delegateProvider.RegisterForRuntimeStartup3;

            return @delegate(dwProcessId, lpApplicationGroupId, pLibraryProvider, pfnCallback, parameter, out ppUnregisterToken);
        }

        #endregion
        #region ResumeProcess

        /// <summary>
        /// Resumes the process using the resume handle returned by the CreateProcessForLaunch function.
        /// </summary>
        /// <param name="hResumeHandle">[in] The resume handle returned by CreateProcessForLaunch function.</param>
        public void ResumeProcess(IntPtr hResumeHandle)
        {
            TryResumeProcess(hResumeHandle).ThrowOnNotOK();
        }

        /// <summary>
        /// Tries to resume the process using the resume handle returned by the CreateProcessForLaunch function.
        /// </summary>
        /// <param name="hResumeHandle">[in] The resume handle returned by CreateProcessForLaunch function.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryResumeProcess(IntPtr hResumeHandle)
        {
            var @delegate = delegateProvider.ResumeProcess;

            return @delegate(hResumeHandle);
        }

        #endregion
        #region UnregisterForRuntimeStartup

        /// <summary>
        /// Stops/cancels runtime startup notification.
        /// </summary>
        /// <param name="pUnregisterToken">[in] The token from the RegisterForRuntimeStartup APIs.</param>
        public void UnregisterForRuntimeStartup(IntPtr pUnregisterToken)
        {
            TryUnregisterForRuntimeStartup(pUnregisterToken).ThrowOnNotOK();
        }

        /// <summary>
        /// Stops/cancels runtime startup notification.
        /// </summary>
        /// <param name="pUnregisterToken">[in] The token from the RegisterForRuntimeStartup APIs.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryUnregisterForRuntimeStartup(IntPtr pUnregisterToken)
        {
            var @delegate = delegateProvider.UnregisterForRuntimeStartup;

            return @delegate(pUnregisterToken);
        }

        #endregion
    }

    /// <summary>
    /// Points to a function that is called when the .NET Core runtime has started for the RegisterForRuntimeStartup API.
    /// </summary>
    /// <param name="pCordb">If <paramref name="hr"/> is <see cref="HRESULT.S_OK"/>, a <see cref="CorDebug"/> object that encapsulates an underlying <see cref="ICorDebug"/> interface. Otherwise, <see langword="null"/>.</param>
    /// <param name="parameter">The 'parameter' value passed to RegisterForRuntimeStartup.</param>
    /// <param name="hr">The result of the operation.</param>
    public delegate void RuntimeStartupCallback(CorDebug pCordb, IntPtr parameter, HRESULT hr);

    public static partial class Extensions
    {
        #region RegisterForRuntimeStartup

        /// <summary>
        /// Executes the callback when the .NET Core runtime starts in the specified process.
        /// </summary>
        /// <param name="dbgShim">The <see cref="DbgShim"/> instance that should be used to register for runtime startup.</param>
        /// <param name="dwProcessId">[in] The process id of the target process.</param>
        /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
        /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
        /// <returns>Pointer to return the UnregisterForRuntimeStartup token.</returns>
        public static IntPtr RegisterForRuntimeStartup(
            this DbgShim dbgShim,
            int dwProcessId,
            RuntimeStartupCallback pfnCallback,
            IntPtr parameter = default(IntPtr)) =>
            dbgShim.RegisterForRuntimeStartup(dwProcessId, NativeToManagedCallback(pfnCallback), parameter);

        /// <summary>
        /// Executes the callback when the .NET Core runtime starts in the specified process.
        /// </summary>
        /// <param name="dbgShim">The <see cref="DbgShim"/> instance that should be used to register for runtime startup.</param>
        /// <param name="dwProcessId">[in] The process id of the target process.</param>
        /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
        /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
        /// <param name="ppUnregisterToken">[out] pointer to return the UnregisterForRuntimeStartup token.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryRegisterForRuntimeStartup(
            this DbgShim dbgShim,
            int dwProcessId,
            RuntimeStartupCallback pfnCallback,
            IntPtr parameter,
            out IntPtr ppUnregisterToken) =>
            dbgShim.TryRegisterForRuntimeStartup(dwProcessId, NativeToManagedCallback(pfnCallback), parameter, out ppUnregisterToken);

        #endregion
        #region RegisterForRuntimeStartupEx

        /// <summary>
        /// Executes the callback when the .NET Core runtime starts in the specified process.
        /// </summary>
        /// <param name="dbgShim">The <see cref="DbgShim"/> instance that should be used to register for runtime startup.</param>
        /// <param name="dwProcessId">[in] The process id of the target process.</param>
        /// <param name="lpApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in Mac. Pass NULL if the process is not running in a sandbox and other platforms.</param>
        /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
        /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
        /// <returns>Pointer to return the UnregisterForRuntimeStartup token.</returns>
        public static IntPtr RegisterForRuntimeStartupEx(
            this DbgShim dbgShim,
            int dwProcessId,
            string lpApplicationGroupId,
            RuntimeStartupCallback pfnCallback,
            IntPtr parameter) => dbgShim.RegisterForRuntimeStartupEx(dwProcessId, lpApplicationGroupId, NativeToManagedCallback(pfnCallback), parameter);

        /// <summary>
        /// Executes the callback when the .NET Core runtime starts in the specified process.
        /// </summary>
        /// <param name="dbgShim">The <see cref="DbgShim"/> instance that should be used to register for runtime startup.</param>
        /// <param name="dwProcessId">[in] The process id of the target process.</param>
        /// <param name="lpApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in Mac. Pass NULL if the process is not running in a sandbox and other platforms.</param>
        /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
        /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
        /// <param name="ppUnregisterToken">[out] pointer to return the UnregisterForRuntimeStartup token.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryRegisterForRuntimeStartupEx(
            this DbgShim dbgShim,
            int dwProcessId,
            string lpApplicationGroupId,
            RuntimeStartupCallback pfnCallback,
            IntPtr parameter,
            out IntPtr ppUnregisterToken) => dbgShim.TryRegisterForRuntimeStartupEx(dwProcessId, lpApplicationGroupId, NativeToManagedCallback(pfnCallback), parameter, out ppUnregisterToken);

        #endregion
        #region RegisterForRuntimeStartup3

        /// <summary>
        /// Executes the callback when the .NET Core runtime starts in the specified process.
        /// </summary>
        /// <param name="dbgShim">The <see cref="DbgShim"/> instance that should be used to register for runtime startup.</param>
        /// <param name="dwProcessId">[in] The process id of the target process.</param>
        /// <param name="lpApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in Mac. Pass NULL if the process is not running in a sandbox and other platforms.</param>
        /// <param name="pLibraryProvider">[in] A callback interface instance for locating DBI and DAC. See ICLRDebuggingLibraryProvider3 interface.</param>
        /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
        /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
        /// <returns>Pointer to return the UnregisterForRuntimeStartup token.</returns>
        public static IntPtr RegisterForRuntimeStartup3(
            this DbgShim dbgShim,
            int dwProcessId,
            string lpApplicationGroupId,
            ICLRDebuggingLibraryProvider3 pLibraryProvider,
            RuntimeStartupCallback pfnCallback,
            IntPtr parameter) => dbgShim.RegisterForRuntimeStartup3(dwProcessId, lpApplicationGroupId, pLibraryProvider, NativeToManagedCallback(pfnCallback), parameter);

        /// <summary>
        /// Executes the callback when the .NET Core runtime starts in the specified process.
        /// </summary>
        /// <param name="dbgShim">The <see cref="DbgShim"/> instance that should be used to register for runtime startup.</param>
        /// <param name="dwProcessId">[in] The process id of the target process.</param>
        /// <param name="lpApplicationGroupId">[in] A string representing the application group ID of a sandboxed process running in Mac. Pass NULL if the process is not running in a sandbox and other platforms.</param>
        /// <param name="pLibraryProvider">[in] A callback interface instance for locating DBI and DAC. See ICLRDebuggingLibraryProvider3 interface.</param>
        /// <param name="pfnCallback">[in] A callback that is invoked when the runtime starts. See <see cref="PSTARTUP_CALLBACK"/> function pointer.</param>
        /// <param name="parameter">[in] data pointer passed to pfnCallback.</param>
        /// <param name="ppUnregisterToken">[out] pointer to return the UnregisterForRuntimeStartup token.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryRegisterForRuntimeStartup3(this DbgShim dbgShim,
            int dwProcessId,
            string lpApplicationGroupId,
            ICLRDebuggingLibraryProvider3 pLibraryProvider,
            RuntimeStartupCallback pfnCallback,
            IntPtr parameter,
            out IntPtr ppUnregisterToken) => dbgShim.TryRegisterForRuntimeStartup3(dwProcessId, lpApplicationGroupId, pLibraryProvider, NativeToManagedCallback(pfnCallback), parameter, out ppUnregisterToken);

        #endregion

        private static PSTARTUP_CALLBACK NativeToManagedCallback(RuntimeStartupCallback callback)
        {
            return (pCordb, parameter, hr) =>
            {
                CorDebug corDebug = null;

                if (hr == HRESULT.S_OK)
                    corDebug = new CorDebug(GetObjectForIUnknown<ICorDebug>(pCordb));

                callback?.Invoke(corDebug, parameter, hr);
            };
        }
    }
}
