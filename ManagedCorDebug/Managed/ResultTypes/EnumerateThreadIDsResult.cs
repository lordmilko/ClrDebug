using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugDataTarget.EnumerateThreadIDs"/> method.
    /// </summary>
    [DebuggerDisplay("pcThreadIds = {pcThreadIds}, pThreadIds = {pThreadIds}")]
    public struct EnumerateThreadIDsResult
    {
        /// <summary>
        /// [out] A pointer to a ULONG32 that indicates the actual number of thread IDs written to the pThreadIds array.
        /// </summary>
        public int pcThreadIds { get; }

        /// <summary>
        /// An array of thread identifiers.
        /// </summary>
        public int[] pThreadIds { get; }

        public EnumerateThreadIDsResult(int pcThreadIds, int[] pThreadIds)
        {
            this.pcThreadIds = pcThreadIds;
            this.pThreadIds = pThreadIds;
        }
    }
}