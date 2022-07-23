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
        public int TotalThreads { get; }

        /// <summary>
        /// Receives the total number of processes in all targets.
        /// </summary>
        public int TotalProcesses { get; }

        /// <summary>
        /// Receives the largest number of threads in any process on any target.
        /// </summary>
        public int LargestProcessThreads { get; }

        /// <summary>
        /// Receives the largest number of threads in any target.
        /// </summary>
        public int LargestSystemThreads { get; }

        /// <summary>
        /// Receives the largest number of processes in any target.
        /// </summary>
        public int LargestSystemProcesses { get; }

        public GetTotalNumberThreadsAndProcessesResult(int totalThreads, int totalProcesses, int largestProcessThreads, int largestSystemThreads, int largestSystemProcesses)
        {
            TotalThreads = totalThreads;
            TotalProcesses = totalProcesses;
            LargestProcessThreads = largestProcessThreads;
            LargestSystemThreads = largestSystemThreads;
            LargestSystemProcesses = largestSystemProcesses;
        }
    }
}
