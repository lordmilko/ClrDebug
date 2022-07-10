using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSystemObjects.TotalNumberThreadsAndProcesses"/> property.
    /// </summary>
    [DebuggerDisplay("TotalThreads = {TotalThreads}, TotalProcesses = {TotalProcesses}, LargestProcessThreads = {LargestProcessThreads}, LargestSystemThreads = {LargestSystemThreads}, LargestSystemProcesses = {LargestSystemProcesses}")]
    public struct GetTotalNumberThreadsAndProcessesResult
    {
        /// <summary>
        /// Receives the total number of threads in all processes in all targets.
        /// </summary>
        public uint TotalThreads { get; }

        /// <summary>
        /// Receives the total number of processes in all targets.
        /// </summary>
        public uint TotalProcesses { get; }

        /// <summary>
        /// Receives the largest number of threads in any process on any target.
        /// </summary>
        public uint LargestProcessThreads { get; }

        /// <summary>
        /// Receives the largest number of threads in any target.
        /// </summary>
        public uint LargestSystemThreads { get; }

        /// <summary>
        /// Receives the largest number of processes in any target.
        /// </summary>
        public uint LargestSystemProcesses { get; }

        public GetTotalNumberThreadsAndProcessesResult(uint totalThreads, uint totalProcesses, uint largestProcessThreads, uint largestSystemThreads, uint largestSystemProcesses)
        {
            TotalThreads = totalThreads;
            TotalProcesses = totalProcesses;
            LargestProcessThreads = largestProcessThreads;
            LargestSystemThreads = largestSystemThreads;
            LargestSystemProcesses = largestSystemProcesses;
        }
    }
}
