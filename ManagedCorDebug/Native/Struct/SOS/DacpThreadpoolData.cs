using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("cpuUtilization = {cpuUtilization}, NumIdleWorkerThreads = {NumIdleWorkerThreads}, NumWorkingWorkerThreads = {NumWorkingWorkerThreads}, NumRetiredWorkerThreads = {NumRetiredWorkerThreads}, MinLimitTotalWorkerThreads = {MinLimitTotalWorkerThreads}, MaxLimitTotalWorkerThreads = {MaxLimitTotalWorkerThreads}, FirstUnmanagedWorkRequest = {FirstUnmanagedWorkRequest.ToString(),nq}, HillClimbingLog = {HillClimbingLog.ToString(),nq}, HillClimbingLogFirstIndex = {HillClimbingLogFirstIndex}, HillClimbingLogSize = {HillClimbingLogSize}, NumTimers = {NumTimers}, NumCPThreads = {NumCPThreads}, NumFreeCPThreads = {NumFreeCPThreads}, MaxFreeCPThreads = {MaxFreeCPThreads}, NumRetiredCPThreads = {NumRetiredCPThreads}, MaxLimitTotalCPThreads = {MaxLimitTotalCPThreads}, CurrentLimitTotalCPThreads = {CurrentLimitTotalCPThreads}, MinLimitTotalCPThreads = {MinLimitTotalCPThreads}, AsyncTimerCallbackCompletionFPtr = {AsyncTimerCallbackCompletionFPtr.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpThreadpoolData
    {
        public int cpuUtilization;
        public int NumIdleWorkerThreads;
        public int NumWorkingWorkerThreads;
        public int NumRetiredWorkerThreads;
        public int MinLimitTotalWorkerThreads;
        public int MaxLimitTotalWorkerThreads;
        public CLRDATA_ADDRESS FirstUnmanagedWorkRequest;
        public CLRDATA_ADDRESS HillClimbingLog;
        public int HillClimbingLogFirstIndex;
        public int HillClimbingLogSize;
        public int NumTimers;
        public int NumCPThreads;
        public int NumFreeCPThreads;
        public int MaxFreeCPThreads;
        public int NumRetiredCPThreads;
        public int MaxLimitTotalCPThreads;
        public int CurrentLimitTotalCPThreads;
        public int MinLimitTotalCPThreads;
        public CLRDATA_ADDRESS AsyncTimerCallbackCompletionFPtr;

        public HRESULT Request(ISOSDacInterface sos)
        {
            return sos.GetThreadpoolData(out this);
        }
    }
}
