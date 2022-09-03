using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("nSize = {nSize}, lpOutputRoutine = {lpOutputRoutine.ToString(),nq}, lpGetExpressionRoutine = {lpGetExpressionRoutine.ToString(),nq}, lpGetSymbolRoutine = {lpGetSymbolRoutine.ToString(),nq}, lpDisasmRoutine = {lpDisasmRoutine.ToString(),nq}, lpCheckControlCRoutine = {lpCheckControlCRoutine.ToString(),nq}, lpReadProcessMemoryRoutine = {lpReadProcessMemoryRoutine.ToString(),nq}, lpWriteProcessMemoryRoutine = {lpWriteProcessMemoryRoutine.ToString(),nq}, lpGetThreadContextRoutine = {lpGetThreadContextRoutine.ToString(),nq}, lpSetThreadContextRoutine = {lpSetThreadContextRoutine.ToString(),nq}, lpIoctlRoutine = {lpIoctlRoutine.ToString(),nq}, lpStackTraceRoutine = {lpStackTraceRoutine.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDBG_EXTENSION_APIS /*32 or 64; both are defined the same in managed code*/
    {
        public int nSize;
        public IntPtr lpOutputRoutine;
        public IntPtr lpGetExpressionRoutine;
        public IntPtr lpGetSymbolRoutine;
        public IntPtr lpDisasmRoutine;
        public IntPtr lpCheckControlCRoutine;
        public IntPtr lpReadProcessMemoryRoutine;
        public IntPtr lpWriteProcessMemoryRoutine;
        public IntPtr lpGetThreadContextRoutine;
        public IntPtr lpSetThreadContextRoutine;
        public IntPtr lpIoctlRoutine;
        public IntPtr lpStackTraceRoutine;
    }
}
