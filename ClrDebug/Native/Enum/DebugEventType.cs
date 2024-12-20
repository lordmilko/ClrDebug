namespace ClrDebug
{
    public enum DebugEventType
    {
        /// <summary>
        /// Reports an exception debugging event. The value of u.Exception specifies an EXCEPTION_DEBUG_INFO structure.
        /// </summary>
        EXCEPTION_DEBUG_EVENT = 1,

        /// <summary>
        /// Reports a create-thread debugging event (does not include the main thread of a process, see <see cref="CREATE_PROCESS_DEBUG_EVENT"/>).
        /// The value of DEBUG_EVENT.u.CreateThread specifies a <see cref="CREATE_THREAD_DEBUG_INFO"/> structure.
        /// </summary>
        CREATE_THREAD_DEBUG_EVENT = 2,

        /// <summary>
        /// Reports a create-process debugging event (includes both a process and its main thread).
        /// The value of DEBUG_EVENT.u.CreateProcessInfo specifies a <see cref="CREATE_PROCESS_DEBUG_INFO"/> structure.
        /// </summary>
        CREATE_PROCESS_DEBUG_EVENT = 3,

        /// <summary>
        /// Reports an exit-thread debugging event. The value of DEBUG_EVENT.u.ExitThread specifies an <see cref="EXIT_THREAD_DEBUG_INFO"/> structure.
        /// </summary>
        EXIT_THREAD_DEBUG_EVENT = 4,

        /// <summary>
        /// Reports an exit-process debugging event. The value of DEBUG_EVENT.u.ExitProcess specifies an <see cref="EXIT_PROCESS_DEBUG_INFO"/> structure.
        /// </summary>
        EXIT_PROCESS_DEBUG_EVENT = 5,

        /// <summary>
        /// Reports a load-dynamic-link-library (DLL) debugging event. The value of DEBUG_EVENT.u.LoadDll specifies a <see cref="LOAD_DLL_DEBUG_INFO"/> structure.
        /// </summary>
        LOAD_DLL_DEBUG_EVENT = 6,

        /// <summary>
        /// Reports an unload-DLL debugging event. The value of DEBUG_EVENT.u.UnloadDll specifies an <see cref="UNLOAD_DLL_DEBUG_INFO"/> structure.
        /// </summary>
        UNLOAD_DLL_DEBUG_EVENT = 7,

        /// <summary>
        /// Reports an output-debugging-string debugging event. The value of DEBUG_EVENT.u.DebugString specifies an <see cref="OUTPUT_DEBUG_STRING_INFO"/> structure.
        /// </summary>
        OUTPUT_DEBUG_STRING_EVENT = 8,

        /// <summary>
        /// Reports a RIP-debugging event (system debugging error). The value of DEBUG_EVENT.u.RipInfo specifies a <see cref="RIP_INFO"/> structure.
        /// </summary>
        RIP_EVENT = 9
    }
}
