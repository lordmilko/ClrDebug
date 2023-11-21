using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using ClrDebug;
using static ClrDebug.Extensions;

#if NET8_0_OR_GREATER
using System.Runtime.InteropServices.Marshalling;

//You don't need to disable runtime marshalling, however this sample also supports compiling to NativeAOT, and we'd like to test that
//things still work when runtime marshalling is disabled
[assembly: DisableRuntimeMarshalling]
#endif

namespace NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbgTargetPath = "C:\\Program Files\\PowerShell\\7\\pwsh.exe";

            if (!File.Exists(dbgTargetPath))
                throw new InvalidOperationException($"Cannot find '{dbgTargetPath}'. Please specify another .NET Core application to test with");

            //Try and find a dbgshim.dll to use under C:\Program Files\dotnet
            //In a real application you should probably ship dbgshim with your program (see README.md for further details)
            var dbgShimPath = DbgShimResolver.Resolve();

            var dbgshim = new DbgShim(
#if NET8_0_OR_GREATER
                NativeLibrary.Load(dbgShimPath)
#else
                NativeMethods.LoadLibrary(dbgShimPath)
#endif
            );

            /* The disadvantage of using CreateProcessForLaunch is that you can't specify CreateProcessFlags
             * like CREATE_NEW_CONSOLE. If the process is allowed to fully start before GetStartupNotificationEvent() is called,
             * WaitForSingleObject() will never trigger the event. As such it's a good idea to start the process suspended, and only resume
             * it after the notification event is in place. The values emitted from this function are the dwProcessId
             * and hThread from the PROCESS_INFORMATION */
            var process = dbgshim.CreateProcessForLaunch(dbgTargetPath, true);

            try
            {
                //Switch between the following methods to test each one
                Manual(dbgshim, process.ProcessId, process.ResumeHandle);
                //Automatic(dbgshim, process.ProcessId, process.ResumeHandle);
            }
            finally
            {
                /* You must close the resume handle (PROCESS_INFORMATION.hThread) once you're done with it. You could do this immediately,
                 * but in the event your process creation fails and an exception is thrown but we want our process to stay alive, we need to make
                 * sure the handle is closed */
                dbgshim.CloseResumeHandle(process.ResumeHandle);
            }
        }

        private static void Manual(DbgShim dbgshim, int pid, IntPtr resumeHandle)
        {
            /* If the process initializes the CLR before GetStartupNotificationEvent is called (e.g. because you were playing in the debugger between launching
             * the process and reaching this line of code) then WaitForSingleObject below will hang indefinitely. You can prevent this by starting the process suspended.
             * This event is signalled by debugger.cpp!OpenStartupNotificationEvent() which is called by NotifyDebuggerOfStartup(). Immediately after the startup event
             * is signalled, the CLR waits on g_hContinueStartupEvent which is one of the three components that comprise the global CLR_ENGINE_METRICS g_CLREngineMetrics! */
            var startupEvent = dbgshim.GetStartupNotificationEvent(pid);

            //The event WaitForSingleObject is waiting on won't occur unless the process is resumed
            dbgshim.ResumeProcess(resumeHandle);

            //As stated above, if you started the process suspended, you need to resume the process otherwise the CLR will never be loaded.
            var waitResult = NativeMethods.WaitForSingleObject(startupEvent, -1);

            if (waitResult != 0)
                throw new InvalidOperationException($"Failed to get startup event. Is the target process a .NET Core application? Wait Result: {waitResult}");

            var enumResult = dbgshim.EnumerateCLRs(pid);

            try
            {
                var runtime = enumResult.Items.Single();

                //Version String is a comma delimited value containing dbiVersion, pidDebuggee, hmodTargetCLR
                var versionStr = dbgshim.CreateVersionStringFromModule(pid, runtime.Path);

                /* Cordb::CheckCompatibility seems to be the only place where our debugger version is actually used,
                 * and it says that if the version is 4, its major version 4. Version 4.5 is treated as an "unrecognized future version"
                 * and is assigned major version 5, which is wrong. Cordb::CheckCompatibility then calls CordbProcess::IsCompatibleWith
                 * which doesn't actually seem to do anything either, despite what all the docs in it would imply. */
                var cordebug = dbgshim.CreateDebuggingInterfaceFromVersionEx(CorDebugInterfaceVersion.CorDebugVersion_4_0, versionStr);

                //Initialize ICorDebug, setup our managed callback and attach to the existing process. We attach while the CLR is blocked waiting for the "continue" event to be called
                InitCorDebug(cordebug, pid);

                /* There exists a structure CLR_ENGINE_METRICS within in coreclr.dll which is exported at ordinal 2. This structure indicates the RVA of the actual continue event that should be signalled
                 * to indicate the CLR can continue starting. But how does the CLR know to wait on this event at all? In debugger.cpp!NotifyDebuggerOfStartup() it calls
                 * OpenStartupNotificationEvent(). If that returns the event that was created by GetStartupNotificationEvent() then that event is set and closed,
                 * and then g_hContinueStartupEvent is waited on infinitely. g_hContinueStartupEvent is one of the components that make up the CLR_ENGINE_METRICS g_CLREngineMetrics,
                 * hence it all comes full circle. */
                NativeMethods.SetEvent(runtime.Handle);
            }
            finally
            {
                //CloseCLREnumeration does not call WakeRuntimes(), hence we MUST call SetEvent above.
                //WakeRuntimes is called in InvokeStartupCallback() and UnregisterForRuntimeStartup() -> Unregister()
                dbgshim.CloseCLREnumeration(enumResult);
            }

            while (true)
                Thread.Sleep(1);
        }

        private static void Automatic(DbgShim dbgshim, int pid, IntPtr resumeHandle)
        {
            IntPtr unregisterToken = IntPtr.Zero;

            CorDebug cordebug = null;
            HRESULT hr = HRESULT.E_FAIL;
            var wait = new AutoResetEvent(false);

            try
            {
                /* If the process starts before GetStartupNotificationEvent inside RegisterForRuntimeStartup is called (e.g. because you were playing
                 * in the debugger between launching the process and reaching this line of code) then WaitForSingleObject inside RegisterForRuntimeStartup
                 * will hang indefinitely. You can prevent this by starting the process suspended.  In the Manual example, we call GetStartupNotificationEvent
                 * ourselves, however in the Automatic example, RegisterForRuntimeStartup calls GetStartupNotificationEvent itself internally. In the latter scenario,
                 * technically speaking there is the possibility of a race occurring even without us stepping in the debugger, but that's the risk you take when
                 * you use RegisterForRuntimeStartup */

                dbgshim.ResumeProcess(resumeHandle);     //Do not step! the CLR may initialize while you're stepping! Either set a breakpoint in the PSTARTUP_CALLBACK or AFTER RegisterForRuntimeStartup

                //Do not step! the CLR may initialize while you're stepping! Either set a breakpoint in the PSTARTUP_CALLBACK or AFTER RegisterForRuntimeStartup

                //Our DbgShim object will cache the last delegate passed to native code to prevent it being garbage collected.
                //As such there is no need to GC.KeepAlive() anything
                unregisterToken = dbgshim.RegisterForRuntimeStartup(pid, (pCordb, parameter, callbackHR) =>
                {
                    /* DbgShim provides two overloads of RegisterForRuntimeStartup: one that takes a PSTARTUP_CALLBACK and one
                     * that takes a RuntimeStartupCallback. As it is not possible to easily marshal the ICorDebug parameter on the PSTARTUP_CALLBACK
                     * in all scenarios (.NET Core is buggy and NativeAOT is impossible on non-Windows platforms) we work around this by defining an
                     * RegisterForRuntimeStartup extension method that takes a "RuntimeStartupCallback" instead. This extension method defers to the "real"
                     * RegisterForRuntimeStartup internally and handles the marshalling/wrapping of the ICorDebug interface for us. If the HRESULT parameter
                     * passed to the callback is not S_OK, "pCordb" will be null. If the delegate type or delegate parameter types on the callback passed to
                     * RegisterForRuntimeStartup have not been explicitly specified, the compiler can still figure out which RegisterForRuntimeStartup
                     * overload to use based on the type of value "pCordb" is assigned to. */
                    cordebug = pCordb;

                    hr = callbackHR;

                    wait.Set();
                });

                wait.WaitOne();
            }
            finally
            {
                if (unregisterToken != IntPtr.Zero)
                    dbgshim.UnregisterForRuntimeStartup(unregisterToken);
            }

            //if callbackHR was not S_OK, an error occurred while attempting to register for runtime startup
            if (cordebug == null)
                throw new DebugException(hr);

            //Initialize ICorDebug, setup our managed callback and attach to the existing process
            InitCorDebug(cordebug, pid);

            while (true)
                Thread.Sleep(1);
        }

        private static void InitCorDebug(CorDebug cordebug, int pid)
        {
            cordebug.Initialize();

            var cb = new CorDebugManagedCallback();
            cb.OnAnyEvent += (s, e) => e.Controller.Continue(false);
            cb.OnLoadModule += LoadModule;

            cordebug.SetManagedHandler(cb);

            cordebug.DebugActiveProcess(pid, false);
        }

        private static void LoadModule(object sender, LoadModuleCorDebugManagedCallbackEventArgs e)
        {
            Console.WriteLine($"Loaded {e.Module.Name}");
        }
    }
}
