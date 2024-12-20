using System;

namespace ClrDebug.TTD
{
#pragma warning disable CS0649
    internal struct ReplayEngineVtbl
    {
        public IntPtr UnsafeAsInterface_Thunk;
        public IntPtr UnsafeAsInterface;
        public IntPtr GetPebAddress;
        public IntPtr GetSystemInfo;
        public IntPtr GetFirstPosition;
        public IntPtr GetLastPosition;
        public IntPtr GetFirstPosition_2; //Points to the same function as GetFirstPosition
        public IntPtr GetRecordingType;
        public IntPtr GetThreadInfo;
        public IntPtr GetThreadCount;
        public IntPtr GetThreadList;
        public IntPtr GetThreadFirstPositionIndex;
        public IntPtr GetThreadLastPositionIndex;
        public IntPtr GetThreadLifetimeFirstPositionIndex;
        public IntPtr GetThreadLifetimeLastPositionIndex;
        public IntPtr GetThreadCreatedEventCount;
        public IntPtr GetThreadCreatedEventList;
        public IntPtr GetThreadTerminatedEventCount;
        public IntPtr GetThreadTerminatedEventList;
        public IntPtr GetModuleCount;
        public IntPtr GetModuleList;
        public IntPtr GetModuleInstanceCount;
        public IntPtr GetModuleInstanceList;
        public IntPtr GetModuleInstanceUnloadIndex;
        public IntPtr GetModuleLoadedEventCount;
        public IntPtr GetModuleLoadedEventList;
        public IntPtr GetModuleUnloadedEventCount;
        public IntPtr GetModuleUnloadedEventList;
        public IntPtr GetExceptionEventCount;
        public IntPtr GetExceptionEventList;
        public IntPtr GetExceptionAtOrAfterPosition;
        public IntPtr GetKeyframeCount;
        public IntPtr GetKeyframeList;
        public IntPtr GetRecordClientCount;
        public IntPtr GetRecordClientList;
        public IntPtr GetRecordClient;
        public IntPtr GetCustomEventCount;
        public IntPtr GetCustomEventList;
        public IntPtr GetActivityCount;
        public IntPtr GetActivityList;
        public IntPtr GetIslandCount;
        public IntPtr GetIslandList;
        public IntPtr NewCursor;
        public IntPtr BuildIndex;
        public IntPtr GetIndexStatus;
        public IntPtr GetIndexFileStats;
        public IntPtr RegisterDebugModeAndLogging;
        public IntPtr GetInternals;
        public IntPtr GetInternals_2; //Points to the same function as GetInternals
        public IntPtr vector_deleting_destructor;
        public IntPtr Destroy;
        public IntPtr Initialize;
    }
#pragma warning restore CS0649
}
