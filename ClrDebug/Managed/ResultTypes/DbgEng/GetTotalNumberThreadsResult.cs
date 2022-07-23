using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSystemObjects.TotalNumberThreads"/> property.
    /// </summary>
    [DebuggerDisplay("Total = {Total}, LargestProcess = {LargestProcess}")]
    public struct GetTotalNumberThreadsResult
    {
        /// <summary>
        /// Receives the total number of threads for all the processes in the current target.
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Receives the largest number of threads in any process for the current target.
        /// </summary>
        public int LargestProcess { get; }

        public GetTotalNumberThreadsResult(int total, int largestProcess)
        {
            Total = total;
            LargestProcess = largestProcess;
        }
    }
}
