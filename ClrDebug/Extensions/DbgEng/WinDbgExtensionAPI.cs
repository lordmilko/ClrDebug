using System;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.DbgEng
{
    #region Delegates

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WINDBG_OUTPUT_ROUTINE(
        [In, MarshalAs(UnmanagedType.LPStr)] string lpFormat);

    public delegate IntPtr PWINDBG_GET_EXPRESSION(
        [In, MarshalAs(UnmanagedType.LPStr)] string lpExpression);

    public delegate void PWINDBG_GET_SYMBOL(
        [In] IntPtr offset,
        [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1)] char[] pchBuffer,
        [Out] IntPtr pDisplacement);

    public delegate bool PWINDBG_DISASM(
        [In, Out] ref IntPtr lpOffset,
        [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1)] char[] lpBuffer,
        [In] bool fShowEffectiveAddress);

    public delegate bool PWINDBG_CHECK_CONTROL_C();

    public delegate bool PWINDBG_READ_PROCESS_MEMORY_ROUTINE(
        [In] IntPtr offset,
        [In] IntPtr lpBuffer,
        [In] int cb,
        [Out] out int lpcbBytesRead);

    public delegate bool PWINDBG_WRITE_PROCESS_MEMORY_ROUTINE(
        [In] IntPtr offset,
        [In] IntPtr lpBuffer,
        [In] int cb,
        [Out] out int lpcbBytesWritten);

    //Target: thread ID (user mode), process number (kernel mode)
    public delegate bool PWINDBG_GET_THREAD_CONTEXT_ROUTINE(
        [In] int Target,
        [In] IntPtr lpContext,
        [In] int cbSizeOfContext);

    public delegate bool PWINDBG_SET_THREAD_CONTEXT_ROUTINE(
        [In] int Target,
        [In] IntPtr lpContext,
        [In] int cbSizeOfContext);

    //For some calls, the return type will be bool; for others, its actually int
    public delegate int PWINDBG_IOCTL_ROUTINE(
        [In] IG IoctlType,
        [In] IntPtr lpvData,
        [In] int cbSize);

    //Returns the number of frames filled
    public delegate int PWINDBG_STACKTRACE_ROUTINE(
        [In] IntPtr FramePointer,
        [In] IntPtr StackPointer,
        [In] IntPtr ProgramCounter,
        [In, MarshalAs(UnmanagedType.LPArray)] EXTSTACKTRACE[] StackFrames,
        [In] int Frames);

    #endregion

    public class WinDbgExtensionAPI
    {
        WINDBG_EXTENSION_APIS apis;

        public WinDbgExtensionAPI(WINDBG_EXTENSION_APIS apis)
        {
            this.apis = apis;
        }

        public void Output(string lpFormat)
        {
            InitDelegate(ref output, apis.lpOutputRoutine);

            output(lpFormat);
        }

        public IntPtr GetExpression(string lpExpression)
        {
            InitDelegate(ref getExpression, apis.lpGetExpressionRoutine);

            return getExpression(lpExpression);
        }

        public GetSymbolResult GetSymbol(IntPtr offset)
        {
            InitDelegate(ref getSymbol, apis.lpGetSymbolRoutine);

            var buffer = new char[256];
            IntPtr displacement = IntPtr.Zero;

            getSymbol(offset, buffer, displacement);

            return new GetSymbolResult(CreateString(buffer), displacement);
        }

        public bool Disasm(ref IntPtr lpOffset, bool fShowEffectiveAddress)
        {
            InitDelegate(ref disasm, apis.lpDisasmRoutine);

            var buffer = new char[256];

            return disasm(ref lpOffset, buffer, fShowEffectiveAddress);
        }

        public bool CheckControlC()
        {
            InitDelegate(ref checkControlC, apis.lpCheckControlCRoutine);

            return checkControlC();
        }

        public bool ReadProcessMemory(IntPtr offset, IntPtr lpBuffer, int cb, out int lpcbBytesRead)
        {
            InitDelegate(ref readProcessMemory, apis.lpReadProcessMemoryRoutine);

            return readProcessMemory(offset, lpBuffer, cb, out lpcbBytesRead);
        }

        public bool WriteProcessMemory(IntPtr offset, IntPtr lpBuffer, int cb, out int lpcbBytesWritten)
        {
            InitDelegate(ref writeProcessMemory, apis.lpWriteProcessMemoryRoutine);

            return writeProcessMemory(offset, lpBuffer, cb, out lpcbBytesWritten);
        }

        public bool GetThreadContext(int Target, IntPtr lpContext, int cbSizeOfContext)
        {
            InitDelegate(ref getThreadContext, apis.lpGetThreadContextRoutine);

            return getThreadContext(Target, lpContext, cbSizeOfContext);
        }

        public bool SetThreadContext(int Target, IntPtr lpContext, int cbSizeOfContext)
        {
            InitDelegate(ref setThreadContext, apis.lpSetThreadContextRoutine);

            return setThreadContext(Target, lpContext, cbSizeOfContext);
        }

        public int Ioctl(IG IoctlType, IntPtr lpvData, int cbSize)
        {
            InitDelegate(ref ioctl, apis.lpIoctlRoutine);

            return ioctl(IoctlType, lpvData, cbSize);
        }

        public EXTSTACKTRACE[] StackTrace(IntPtr FramePointer, [In] IntPtr StackPointer, IntPtr ProgramCounter)
        {
            InitDelegate(ref stackTrace, apis.lpStackTraceRoutine);

            var frames = new EXTSTACKTRACE[50];

            var filled = stackTrace(FramePointer, StackPointer, ProgramCounter, frames, frames.Length);

            if (filled > frames.Length)
            {
                frames = new EXTSTACKTRACE[filled];

                stackTrace(FramePointer, StackPointer, ProgramCounter, frames, frames.Length);
            }

            return frames;
        }

        private void InitDelegate<T>(ref T @delegate, IntPtr ptr)
        {
            //If we've already initialized this delegate, no need to do it again
            if (@delegate != null)
                return;

            @delegate = Marshal.GetDelegateForFunctionPointer<T>(ptr);
        }

        #region Cached Delegates

        private WINDBG_OUTPUT_ROUTINE output;
        private PWINDBG_GET_EXPRESSION getExpression;
        private PWINDBG_GET_SYMBOL getSymbol;
        private PWINDBG_DISASM disasm;
        private PWINDBG_CHECK_CONTROL_C checkControlC;
        private PWINDBG_READ_PROCESS_MEMORY_ROUTINE readProcessMemory;
        private PWINDBG_WRITE_PROCESS_MEMORY_ROUTINE writeProcessMemory;
        private PWINDBG_GET_THREAD_CONTEXT_ROUTINE getThreadContext;
        private PWINDBG_SET_THREAD_CONTEXT_ROUTINE setThreadContext;
        private PWINDBG_IOCTL_ROUTINE ioctl;
        private PWINDBG_STACKTRACE_ROUTINE stackTrace;

        #endregion
    }
}
