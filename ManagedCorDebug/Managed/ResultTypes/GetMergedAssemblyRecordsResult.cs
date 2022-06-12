using System;

namespace ManagedCorDebug
{
    public struct GetMergedAssemblyRecordsResult
    {
        public int PcFetchedRecords { get; }

        public IntPtr PRecords { get; }

        public GetMergedAssemblyRecordsResult(int pcFetchedRecords, IntPtr pRecords)
        {
            PcFetchedRecords = pcFetchedRecords;
            PRecords = pRecords;
        }
    }
}