using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [DebuggerDisplay("{dwDebugEventCode.ToString(),nq} (dwProcessId = {dwProcessId}, dwThreadId = {dwThreadId})")]
    [StructLayout(LayoutKind.Sequential)]
#if GENERATED_MARSHALLING
    [NativeMarshalling(typeof(Marshaller))]
#endif
    public struct DEBUG_EVENT
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string UnionDebuggerDisplay
        {
            get
            {
                switch (dwDebugEventCode)
                {
                    case DebugEventType.EXCEPTION_DEBUG_EVENT:
                        return u.Exception.DebuggerDisplay;
                    case DebugEventType.CREATE_THREAD_DEBUG_EVENT:
                        return u.CreateThread.DebuggerDisplay;
                    case DebugEventType.CREATE_PROCESS_DEBUG_EVENT:
                        return u.CreateProcess.DebuggerDisplay;
                    case DebugEventType.EXIT_THREAD_DEBUG_EVENT:
                        return u.ExitThread.DebuggerDisplay;
                    case DebugEventType.EXIT_PROCESS_DEBUG_EVENT:
                        return u.ExitProcess.DebuggerDisplay;
                    case DebugEventType.LOAD_DLL_DEBUG_EVENT:
                        return u.LoadDll.DebuggerDisplay;
                    case DebugEventType.UNLOAD_DLL_DEBUG_EVENT:
                        return u.UnloadDll.DebuggerDisplay;
                    case DebugEventType.OUTPUT_DEBUG_STRING_EVENT:
                        return u.DebugString.DebuggerDisplay;
                    case DebugEventType.RIP_EVENT:
                        return u.RipInfo.DebuggerDisplay;
                    default:
                        return u.ToString();
                }
            }
        }

        public DebugEventType dwDebugEventCode;

        public int dwProcessId;

        public int dwThreadId;

        [DebuggerDisplay("{UnionDebuggerDisplay,nq}")]
        public Union u;

        [DebuggerDisplay("Exception = {Exception.ToString(),nq}, CreateThread = {CreateThread.ToString(),nq}, CreateProcessInfo = {CreateProcess.ToString(),nq}, ExitThread = {ExitThread.ToString(),nq}, ExitProcess = {ExitProcess.ToString(),nq}, LoadDll = {LoadDll.ToString(),nq}, UnloadDll = {UnloadDll.ToString(),nq}, DebugString = {DebugString.ToString(),nq}, RipInfo = {RipInfo.ToString(),nq}")]
        [StructLayout(LayoutKind.Explicit)]
        public struct Union
        {
            [FieldOffset(0)]
            public EXCEPTION_DEBUG_INFO Exception;

            [FieldOffset(0)]
            public CREATE_THREAD_DEBUG_INFO CreateThread;

            [FieldOffset(0)]
            public CREATE_PROCESS_DEBUG_INFO CreateProcess;

            [FieldOffset(0)]
            public EXIT_THREAD_DEBUG_INFO ExitThread;

            [FieldOffset(0)]
            public EXIT_PROCESS_DEBUG_INFO ExitProcess;

            [FieldOffset(0)]
            public LOAD_DLL_DEBUG_INFO LoadDll;

            [FieldOffset(0)]
            public UNLOAD_DLL_DEBUG_INFO UnloadDll;

            [FieldOffset(0)]
            public OUTPUT_DEBUG_STRING_INFO DebugString;

            [FieldOffset(0)]
            public RIP_INFO RipInfo;
        }

#if GENERATED_MARSHALLING
        [CustomMarshaller(typeof(DEBUG_EVENT), MarshalMode.UnmanagedToManagedRef, typeof(Bidirectional))]
        [CustomMarshaller(typeof(DEBUG_EVENT), MarshalMode.ManagedToUnmanagedRef, typeof(Bidirectional))]
        public static class Marshaller
        {
            public static class Bidirectional
            {
                public static IntPtr ConvertToUnmanaged(DEBUG_EVENT managed)
                {
                    var unmanaged = Marshal.AllocCoTaskMem(Marshal.SizeOf<DEBUG_EVENT>());

                    Marshal.StructureToPtr(managed, unmanaged, false);

                    return unmanaged;
                }

                public static DEBUG_EVENT ConvertToManaged(IntPtr unmanaged)
                {
                    var managed = Marshal.PtrToStructure<DEBUG_EVENT>(unmanaged);

                    return managed;
                }

                public static void Free(IntPtr unmanaged)
                {
                    if (unmanaged != IntPtr.Zero)
                    {
                        Marshal.DestroyStructure<DEBUG_EVENT>(unmanaged);
                        Marshal.FreeCoTaskMem(unmanaged);
                    }
                }
            }
        }
#endif
    }
}
