using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
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
