using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_THREAD_BASIC_INFORMATION structure describes an operating system thread.
    /// </summary>
    [DebuggerDisplay("Valid = {Valid.ToString(),nq}, ExitStatus = {ExitStatus}, PriorityClass = {PriorityClass}, Priority = {Priority}, CreateTime = {CreateTime}, ExitTime = {ExitTime}, KernelTime = {KernelTime}, UserTime = {UserTime}, StartOffset = {StartOffset}, Affinity = {Affinity}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_THREAD_BASIC_INFORMATION
    {
        /// <summary>
        /// A bitset that specifies which other members of the structure contain valid information. A member of the structure is valid if the corresponding bit flag is set in Valid.
        /// </summary>
        public DEBUG_TBINFO Valid;

        /// <summary>
        /// The exit code of the thread. If the thread is still running, ExitStatus is set to STILL_ACTIVE. ExitStatus is only valid if the DEBUG_TBINFO_EXIT_STATUS bit flag is set in Valid.
        /// </summary>
        public int ExitStatus;

        /// <summary>
        /// The priority class of the thread. The priority classes are defined by the XXX_PRIORITY_CLASS constants in WinBase.h.<para/>
        /// For more information about thread priority classes, see the Platform SDK. PriorityClass is only valid if the DEBUG_TBINFO_PRIORITY_CLASS bit flag is set in Valid.
        /// </summary>
        public int PriorityClass;

        /// <summary>
        /// The priority of the thread relative to the priority class. Some thread priorities are defined by the THREAD_PRIORITY_XXX constants in WinBase.h.<para/>
        /// For more information about thread priorities, see the Platform SDK. Priority is only valid if the DEBUG_TBINFO_PRIORITY bit flag is set in Valid.
        /// </summary>
        public int Priority;

        /// <summary>
        /// The creation time of the thread. CreateTime is only valid if the DEBUG_TBINFO_TIMES bit flag is set in Valid.
        /// </summary>
        public long CreateTime;

        /// <summary>
        /// The exit time of the thread. ExitTime is only valid if the DEBUG_TBINFO_TIMES bit flag is set in Valid.
        /// </summary>
        public long ExitTime;

        /// <summary>
        /// The amount of time the thread has executed in kernel mode. KernelTime is only valid if the DEBUG_TBINFO_TIMES bit flag is set in Valid.
        /// </summary>
        public long KernelTime;

        /// <summary>
        /// The amount of time the thread has executed in user-mode. UserTime is only valid if the DEBUG_TBINFO_TIMES bit flag is set in Valid.
        /// </summary>
        public long UserTime;

        /// <summary>
        /// The starting address of the thread. StartOffset is only valid if the DEBUG_TBINFO_START_OFFSET bit flag is set in Valid.
        /// </summary>
        public long StartOffset;

        /// <summary>
        /// The thread affinity mask for the thread in a Symmetric Multiple Processor (SMP) computer. For more information about the thread affinity mask, see the Platform SDK.<para/>
        /// Affinity is only valid if the DEBUG_TBINFO_AFFINITY bit flag is set in Valid.
        /// </summary>
        public long Affinity;
    }
}
