using System;

namespace ManagedCorDebug
{
    public struct GetMergedAssemblyRecordsResult
    {
        public uint PcFetchedRecords { get; }

        public IntPtr PRecords { get; }

        public GetMergedAssemblyRecordsResult(uint pcFetchedRecords, IntPtr pRecords)
        {
            PcFetchedRecords = pcFetchedRecords;
            PRecords = pRecords;
        }
    }
}