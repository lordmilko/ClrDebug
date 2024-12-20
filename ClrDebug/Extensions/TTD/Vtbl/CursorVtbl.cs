using System;

namespace ClrDebug.TTD
{
#pragma warning disable CS0649
    internal struct CursorVtbl
    {
        public IntPtr QueryMemoryRange;
        public IntPtr QueryMemoryBuffer;
        public IntPtr QueryMemoryBufferWithRanges;
        public IntPtr SetDefaultMemoryPolicy;
        public IntPtr GetDefaultMemoryPolicy;
        public IntPtr UnsafeGetReplayEngine;
        public IntPtr UnsafeAsInterface_Thunk;
        public IntPtr UnsafeAsInterface;
        public IntPtr GetThreadInfo;
        public IntPtr GetTebAddress;
        public IntPtr GetPosition;
        public IntPtr GetPreviousPosition;
        public IntPtr GetProgramCounter;
        public IntPtr GetStackPointer;
        public IntPtr GetFramePointer;
        public IntPtr GetBasicReturnValue;
        public IntPtr GetCrossPlatformContext;
        public IntPtr GetAvxExtendedContext;
        public IntPtr GetModuleCount;
        public IntPtr GetModuleList;
        public IntPtr GetThreadCount;
        public IntPtr GetThreadList;
        public IntPtr SetEventMask;
        public IntPtr GetEventMask;
        public IntPtr SetGapKindMask;
        public IntPtr GetGapKindMask;
        public IntPtr SetGapEventMask;
        public IntPtr GetGapEventMask;
        public IntPtr SetExceptionMask;
        public IntPtr GetExceptionMask;
        public IntPtr SetReplayFlags;
        public IntPtr GetReplayFlags;
        public IntPtr AddMemoryWatchpoint;
        public IntPtr RemoveMemoryWatchpoint;
        public IntPtr AddPositionWatchpoint;
        public IntPtr RemovePositionWatchpoint;
        public IntPtr Clear;
        public IntPtr SetPosition;
        public IntPtr SetPositionOnThread;
        public IntPtr SetMemoryWatchpointCallback;
        public IntPtr SetPositionWatchpointCallback;
        public IntPtr SetGapEventCallback;
        public IntPtr SetThreadContinuityBreakCallback;
        public IntPtr SetReplayProgressCallback;
        public IntPtr SetFallbackCallback;
        public IntPtr SetCallReturnCallback;
        public IntPtr SetIndirectJumpCallback;
        public IntPtr SetRegisterChangedCallback;
        public IntPtr ReplayForward;
        public IntPtr ReplayBackward;
        public IntPtr InterruptReplay;
        public IntPtr GetInternals;
        public IntPtr GetInternals_2;
        public IntPtr GetInternalData;
        public IntPtr vector_deleting_destructor;
        public IntPtr Destroy;
    }
#pragma warning restore CS0649
}
