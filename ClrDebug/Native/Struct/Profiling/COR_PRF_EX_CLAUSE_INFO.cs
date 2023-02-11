using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Stores information about a specific exception clause instance and its associated frame.
    /// </summary>
    /// <remarks>
    /// When an exception notification is received, <see cref="ICorProfilerInfo2.GetNotifiedExceptionClauseInfo"/> can
    /// be used to get the native address and frame information for the exception clause (catch/finally/filter) that is
    /// about to be run or has just been run. Execution of an exception clause involves these callbacks from the common
    /// language runtime (CLR):
    /// </remarks>
    [DebuggerDisplay("clauseType = {clauseType.ToString(),nq}, programCounter = {programCounter.ToString(),nq}, framePointer = {framePointer.ToString(),nq}, shadowStackPointer = {shadowStackPointer.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_PRF_EX_CLAUSE_INFO
    {
        /// <summary>
        /// A value of the <see cref="COR_PRF_CLAUSE_TYPE"/> enumeration that specifies the type of exception clause the code just entered or left.
        /// </summary>
        public COR_PRF_CLAUSE_TYPE clauseType;

        /// <summary>
        /// The native entry point of the clause handler — for example, the contents of the X86 EIP register.
        /// </summary>
        public IntPtr programCounter;

        /// <summary>
        /// The pointer to the logical frame for the clause handler — for example, the contents of the X86 EBP register.
        /// </summary>
        public IntPtr framePointer;

        /// <summary>
        /// The pointer to the shadow stack. This value is the contents of the BSP register and applies only to IA64.
        /// </summary>
        public IntPtr shadowStackPointer;
    }
}
