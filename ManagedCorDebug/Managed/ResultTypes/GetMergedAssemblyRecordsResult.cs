using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetMergedAssemblyRecords"/> method.
    /// </summary>
    [DebuggerDisplay("pcFetchedRecords = {pcFetchedRecords}, pRecords = {pRecords}")]
    public struct GetMergedAssemblyRecordsResult
    {
        /// <summary>
        /// A pointer to the number of symbol records retrieved by the method.
        /// </summary>
        public int pcFetchedRecords { get; }

        /// <summary>
        /// A pointer to an array of <see cref="ICorDebugMergedAssemblyRecord"/> objects.
        /// </summary>
        public IntPtr pRecords { get; }

        public GetMergedAssemblyRecordsResult(int pcFetchedRecords, IntPtr pRecords)
        {
            this.pcFetchedRecords = pcFetchedRecords;
            this.pRecords = pRecords;
        }
    }
}