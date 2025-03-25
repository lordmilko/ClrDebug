using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static ClrDebug.Extensions;

namespace ClrDebug.TTD
{
    
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public unsafe delegate bool MemoryWatchpointCallbackRaw(long context, MemoryWatchpointResult* b, IntPtr pThreadView);
    public unsafe delegate bool MemoryWatchpointCallback(long context, MemoryWatchpointResult* b, ThreadView pThreadView);

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public unsafe delegate bool PositionWatchpointCallbackRaw(long a, Position* b, IntPtr pThreadView);
    public unsafe delegate bool PositionWatchpointCallback(long a, Position* b, ThreadView pThreadView);

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate bool GapEventCallbackRaw(long a, GapKind b, GapEventType c, IntPtr pThreadView);
    public delegate bool GapEventCallback(long a, GapKind b, GapEventType c, ThreadView pThreadView);

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate void ThreadContinuityBreakCallback(long a);

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public unsafe delegate void ReplayProgressCallback(long a, Position* b);

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate void FallbackCallbackRaw(long a, bool b, GuestAddress c, long d, IntPtr pThreadView);
    public delegate void FallbackCallback(long a, bool b, GuestAddress c, long d, ThreadView pThreadView);

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate void CallReturnCallbackRaw(long context, GuestAddress b, IntPtr c, IntPtr pThreadView);
    public delegate void CallReturnCallback(long context, GuestAddress b, IntPtr c, ThreadView pThreadView);

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate void IndirectJumpCallbackRaw(long context, GuestAddress b, IntPtr pThreadView);
    public delegate void IndirectJumpCallback(long context, GuestAddress b, ThreadView pThreadView);

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate void RegisterChangedCallbackRaw(long context, byte b, IntPtr c, IntPtr d, long e, IntPtr pThreadView);
    public delegate void RegisterChangedCallback(long context, byte b, IntPtr c, IntPtr d, long e, ThreadView pThreadView);

    public unsafe class Cursor
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CursorVtbl* vtbl;

        private MemoryWatchpointCallbackRaw lastSetMemoryWatchpointCallback;
        private PositionWatchpointCallbackRaw lastSetPositionWatchpointCallback;
        private GapEventCallbackRaw lastSetGapEventCallback;
        private ThreadContinuityBreakCallback lastSetThreadContinuityBreakCallback;
        private ReplayProgressCallback lastSetReplayProgressCallback;
        private FallbackCallbackRaw lastSetFallbackCallback;
        private CallReturnCallbackRaw lastSetCallReturnCallback;
        private IndirectJumpCallbackRaw lastSetIndirectJumpCallback;
        private RegisterChangedCallbackRaw lastSetRegisterChangedCallback;

        #region QueryMemoryRange

        //TTD::Replay::Cursor::QueryMemoryRange(Nirvana::GuestAddress,TTD::Replay::QueryMemoryPolicy)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate MemoryRange* QueryMemoryRangeDelegate(
            [In] IntPtr @this,
            [In] IntPtr _unknown1,
            [In] IntPtr _unknown2,
            [In] IntPtr _unknown3);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryMemoryRangeDelegate queryMemoryRange;

        public MemoryRange* QueryMemoryRange(IntPtr _unknown1, IntPtr _unknown2, IntPtr _unknown3, IntPtr _unknown4)
        {
            InitDelegate(ref queryMemoryRange, vtbl->QueryMemoryRange);

            return queryMemoryRange(Raw, _unknown2, _unknown3, _unknown4);
        }

        #endregion
        #region QueryMemoryBuffer

        //TTD::Replay::Cursor::QueryMemoryBuffer(Nirvana::GuestAddress,TTD::TBufferView<0>,TTD::Replay::QueryMemoryPolicy)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate MemoryBuffer* QueryMemoryBufferDelegate(
            [In] IntPtr @this,
            [In] IntPtr resultBuffer,
            [In] GuestAddress address,
            [In] IntPtr bufferView,
            [In] QueryMemoryPolicy queryMemoryPolicy);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryMemoryBufferDelegate queryMemoryBuffer;

        public void QueryMemoryBuffer(
            GuestAddress address,
            IntPtr buffer,
            long bytesRequested,
            out long bytesRead,
            QueryMemoryPolicy queryMemoryPolicy)
        {
            InitDelegate(ref queryMemoryBuffer, vtbl->QueryMemoryBuffer);

            TBufferView bufferView = new TBufferView
            {
                buffer = buffer,
                size = bytesRequested
            };

            //MemoryBuffer's data apparently points to the buffer we created. We're going to free that, and it's bad practice to "surprise" the caller with
            //memory to be free'd. As such, we implement a pattern similar to other ReadVirtual methods
            MemoryBuffer resultBuffer;
            var result = *queryMemoryBuffer(Raw, (IntPtr) (&resultBuffer), address, (IntPtr) (&bufferView), queryMemoryPolicy);

            bytesRead = result.size;
        }

        #endregion
        #region QueryMemoryBufferWithRanges

        //TTD::Replay::Cursor::QueryMemoryBufferWithRanges(Nirvana::GuestAddress,TTD::TBufferView<0>,unsigned __int64,TTD::Replay::MemoryRange *,TTD::Replay::QueryMemoryPolicy)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate MemoryBufferWithRanges QueryMemoryBufferWithRangesDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryMemoryBufferWithRangesDelegate queryMemoryBufferWithRanges;

        public MemoryBufferWithRanges QueryMemoryBufferWithRanges()
        {
            InitDelegate(ref queryMemoryBufferWithRanges, vtbl->QueryMemoryBufferWithRanges);

            return queryMemoryBufferWithRanges(Raw);
        }

        #endregion
        #region DefaultMemoryPolicy

        //TTD::Replay::Cursor::GetDefaultMemoryPolicy(void)
        //TTD::Replay::Cursor::SetDefaultMemoryPolicy(TTD::Replay::QueryMemoryPolicy)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate QueryMemoryPolicy GetDefaultMemoryPolicyDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDefaultMemoryPolicyDelegate getDefaultMemoryPolicy;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetDefaultMemoryPolicyDelegate(
            [In] IntPtr @this,
            [In] QueryMemoryPolicy queryMemoryPolicy);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetDefaultMemoryPolicyDelegate setDefaultMemoryPolicy;

        public QueryMemoryPolicy DefaultMemoryPolicy
        {
            get
            {
                InitDelegate(ref getDefaultMemoryPolicy, vtbl->GetDefaultMemoryPolicy);

                return getDefaultMemoryPolicy(Raw);
            }
            set
            {
                InitDelegate(ref setDefaultMemoryPolicy, vtbl->SetDefaultMemoryPolicy);

                setDefaultMemoryPolicy(Raw, value);
            }
        }

        #endregion
        #region UnsafeGetReplayEngine

        //TTD::Replay::Cursor::UnsafeGetReplayEngine(_GUID const &)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr UnsafeGetReplayEngineDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private UnsafeGetReplayEngineDelegate unsafeGetReplayEngine;

        public IntPtr UnsafeGetReplayEngine(Guid guid)
        {
            InitDelegate(ref unsafeGetReplayEngine, vtbl->UnsafeGetReplayEngine);

            return unsafeGetReplayEngine(Raw, guid);
        }

        #endregion
        #region UnsafeAsInterface

        //TTD::Replay::Cursor::UnsafeAsInterface(_GUID const &)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr UnsafeAsInterfaceDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private UnsafeAsInterfaceDelegate unsafeAsInterface;

        public IntPtr UnsafeAsInterface(Guid guid)
        {
            InitDelegate(ref unsafeAsInterface, vtbl->UnsafeAsInterface);

            return unsafeAsInterface(Raw, guid);
        }

        #endregion
        #region GetThreadInfo

        //TTD::Replay::Cursor::GetThreadInfo(TTD::ThreadId)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ThreadInfo* GetThreadInfoDelegate(
            [In] IntPtr @this,
            [In] ThreadId threadId);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadInfoDelegate getThreadInfo;

        public ThreadInfo GetThreadInfo(ThreadId threadId)
        {
            InitDelegate(ref getThreadInfo, vtbl->GetThreadInfo);

            return *getThreadInfo(Raw, threadId);
        }

        #endregion
        #region GetTebAddress

        //TTD::Replay::Cursor::GetTebAddress(TTD::ThreadId)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate GuestAddress GetTebAddressDelegate(
            [In] IntPtr @this,
            [In] ThreadId threadId);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTebAddressDelegate getTebAddress;

        public GuestAddress GetTebAddress(ThreadId threadId)
        {
            InitDelegate(ref getTebAddress, vtbl->GetTebAddress);

            return getTebAddress(Raw, threadId);
        }

        #endregion
        #region GetPosition

        //TTD::Replay::Cursor::GetPosition(TTD::ThreadId)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate Position* GetPositionDelegate(
            [In] IntPtr @this,
            [In] ThreadId threadId);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPositionDelegate getPosition;

        public Position GetPosition(ThreadId threadId)
        {
            InitDelegate(ref getPosition, vtbl->GetPosition);

            return *getPosition(Raw, threadId);
        }

        #endregion
        #region GetPreviousPosition

        //TTD::Replay::Cursor::GetPreviousPosition(TTD::ThreadId)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate Position* GetPreviousPositionDelegate(
            [In] IntPtr @this,
            [In] ThreadId threadId);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPreviousPositionDelegate getPreviousPosition;

        public Position* GetPreviousPosition(ThreadId threadId)
        {
            InitDelegate(ref getPreviousPosition, vtbl->GetPreviousPosition);

            return getPreviousPosition(Raw, threadId);
        }

        #endregion
        #region GetProgramCounter

        //TTD::Replay::Cursor::GetProgramCounter(TTD::ThreadId)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate GuestAddress GetProgramCounterDelegate(
            [In] IntPtr @this,
            [In] ThreadId threadId);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetProgramCounterDelegate getProgramCounter;

        public GuestAddress GetProgramCounter(ThreadId threadId)
        {
            InitDelegate(ref getProgramCounter, vtbl->GetProgramCounter);

            return getProgramCounter(Raw, threadId);
        }

        #endregion
        #region GetStackPointer

        //TTD::Replay::Cursor::GetStackPointer(TTD::ThreadId)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate GuestAddress GetStackPointerDelegate(
            [In] IntPtr @this,
            [In] ThreadId threadId);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetStackPointerDelegate getStackPointer;

        public GuestAddress GetStackPointer(ThreadId threadId)
        {
            InitDelegate(ref getStackPointer, vtbl->GetStackPointer);

            return getStackPointer(Raw, threadId);
        }

        #endregion
        #region GetFramePointer

        //TTD::Replay::Cursor::GetFramePointer(TTD::ThreadId)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate GuestAddress GetFramePointerDelegate(
            [In] IntPtr @this,
            [In] ThreadId threadId);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFramePointerDelegate getFramePointer;

        public GuestAddress GetFramePointer(ThreadId threadId)
        {
            InitDelegate(ref getFramePointer, vtbl->GetFramePointer);

            return getFramePointer(Raw, threadId);
        }

        #endregion
        #region GetBasicReturnValue

        //TTD::Replay::Cursor::GetBasicReturnValue(TTD::ThreadId)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetBasicReturnValueDelegate(
            [In] IntPtr @this,
            [In] ThreadId threadId);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetBasicReturnValueDelegate getBasicReturnValue;

        public long GetBasicReturnValue(ThreadId threadId)
        {
            InitDelegate(ref getBasicReturnValue, vtbl->GetBasicReturnValue);

            return getBasicReturnValue(Raw, threadId);
        }

        #endregion
        #region GetCrossPlatformContext

        //TTD::Replay::Cursor::GetCrossPlatformContext(TTD::ThreadId)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr GetCrossPlatformContextDelegate(
            [In] IntPtr @this,
            [In] IntPtr buffer,
            [In] ThreadId threadId);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCrossPlatformContextDelegate getCrossPlatformContext;

        public IntPtr GetCrossPlatformContext(IntPtr buffer, ThreadId threadId)
        {
            InitDelegate(ref getCrossPlatformContext, vtbl->GetCrossPlatformContext);

            //From TTD::Replay::GuestContextBase<TTD::Replay::GuestContext>::GetCrossPlatformContext:
            //0xA70 

            return getCrossPlatformContext(Raw, buffer, threadId);
        }

        #endregion
        #region GetAvxExtendedContext

        //TTD::Replay::Cursor::GetAvxExtendedContext(TTD::ThreadId)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr GetAvxExtendedContextDelegate(
            [In] IntPtr @this,
            [In] IntPtr buffer,
            [In] ThreadId threadId);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetAvxExtendedContextDelegate getAvxExtendedContext;

        public IntPtr GetAvxExtendedContext(IntPtr buffer, ThreadId threadId)
        {
            InitDelegate(ref getAvxExtendedContext, vtbl->GetAvxExtendedContext);

            return getAvxExtendedContext(Raw, buffer, threadId);
        }

        #endregion
        #region GetModuleCount

        //TTD::Replay::Cursor::GetModuleCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetModuleCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleCountDelegate getModuleCount;

        public long ModuleCount
        {
            get
            {
                InitDelegate(ref getModuleCount, vtbl->GetModuleCount);

                return getModuleCount(Raw);
            }
        }

        #endregion
        #region GetModuleList

        //TTD::Replay::Cursor::GetModuleList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ModuleInstance* GetModuleListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleListDelegate getModuleList;

        public ModuleInstance[] ModuleList
        {
            get
            {
                var moduleCount = ModuleCount;
                var moduleList = GetModuleList();

                var results = new ModuleInstance[moduleCount];

                for (var i = 0; i < moduleCount; i++)
                    results[i] = moduleList[i];

                return results;
            }
        }

        public ModuleInstance* GetModuleList()
        {
            InitDelegate(ref getModuleList, vtbl->GetModuleList);

            return getModuleList(Raw);
        }

        #endregion
        #region GetThreadCount

        //TTD::Replay::Cursor::GetThreadCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetThreadCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadCountDelegate getThreadCount;

        public long ThreadCount
        {
            get
            {
                InitDelegate(ref getThreadCount, vtbl->GetThreadCount);

                return getThreadCount(Raw);
            }
        }

        #endregion
        #region GetThreadList

        //TTD::Replay::Cursor::GetThreadList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ActiveThreadInfo* GetThreadListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadListDelegate getThreadList;

        public ActiveThreadInfo[] ThreadList
        {
            get
            {
                var threadCount = ThreadCount;
                var threadList = GetThreadList();

                var results = new ActiveThreadInfo[threadCount];

                for (var i = 0; i < threadCount; i++)
                    results[i] = threadList[i];

                return results;
            }
        }

        public ActiveThreadInfo* GetThreadList()
        {
            InitDelegate(ref getThreadList, vtbl->GetThreadList);

            return getThreadList(Raw);
        }

        #endregion
        #region EventMask

        //TTD::Replay::Cursor::GetEventMask(void)
        //TTD::Replay::Cursor::SetEventMask(TTD::Replay::EventMask)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate EventMask GetEventMaskDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEventMaskDelegate getEventMask;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetEventMaskDelegate(
            [In] IntPtr @this,
            [In] EventMask eventMask);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetEventMaskDelegate setEventMask;

        public EventMask EventMask
        {
            get
            {
                InitDelegate(ref getEventMask, vtbl->GetEventMask);

                return getEventMask(Raw);
            }
            set
            {
                InitDelegate(ref setEventMask, vtbl->SetEventMask);

                setEventMask(Raw, value);
            }
        }

        #endregion
        #region GapKindMask

        //TTD::Replay::Cursor::GetGapKindMask(void)
        //TTD::Replay::Cursor::SetGapKindMask(TTD::Replay::GapKindMask)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate GapKindMask GetGapKindMaskDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetGapKindMaskDelegate getGapKindMask;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetGapKindMaskDelegate(
            [In] IntPtr @this,
            [In] GapKindMask gapKindMask);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetGapKindMaskDelegate setGapKindMask;

        public GapKindMask GapKindMask
        {
            get
            {
                InitDelegate(ref getGapKindMask, vtbl->GetGapKindMask);

                return getGapKindMask(Raw);
            }
            set
            {
                InitDelegate(ref setGapKindMask, vtbl->SetGapKindMask);

                setGapKindMask(Raw, value);
            }
        }

        #endregion
        #region GapEventMask

        //TTD::Replay::Cursor::GetGapEventMask(void)
        //TTD::Replay::Cursor::SetGapEventMask(TTD::Replay::GapEventMask)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate GapEventMask GetGapEventMaskDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetGapEventMaskDelegate getGapEventMask;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetGapEventMaskDelegate(
            [In] IntPtr @this,
            [In] GapEventMask gapEventMask);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetGapEventMaskDelegate setGapEventMask;

        public GapEventMask GapEventMask
        {
            get
            {
                InitDelegate(ref getGapEventMask, vtbl->GetGapEventMask);

                return getGapEventMask(Raw);
            }
            set
            {
                InitDelegate(ref setGapEventMask, vtbl->SetGapEventMask);

                setGapEventMask(Raw, value);
            }
        }

        #endregion
        #region ExceptionMask

        //TTD::Replay::Cursor::GetExceptionMask(void)
        //TTD::Replay::Cursor::SetExceptionMask(TTD::Replay::ExceptionMask)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ExceptionMask GetExceptionMaskDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExceptionMaskDelegate getExceptionMask;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetExceptionMaskDelegate(
            [In] IntPtr @this,
            [In] ExceptionMask exceptionMask);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetExceptionMaskDelegate setExceptionMask;

        public ExceptionMask ExceptionMask
        {
            get
            {
                InitDelegate(ref getExceptionMask, vtbl->GetExceptionMask);

                return getExceptionMask(Raw);
            }
            set
            {
                InitDelegate(ref setExceptionMask, vtbl->SetExceptionMask);

                setExceptionMask(Raw, value);
            }
        }

        #endregion
        #region ReplayFlags

        //TTD::Replay::Cursor::GetReplayFlags(void)
        //TTD::Replay::Cursor::SetReplayFlags(TTD::Replay::ReplayFlags)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ReplayFlags GetReplayFlagsDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetReplayFlagsDelegate getReplayFlags;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetReplayFlagsDelegate(
            [In] IntPtr @this,
            [In] ReplayFlags replayFlags);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetReplayFlagsDelegate setReplayFlags;

        public ReplayFlags ReplayFlags
        {
            get
            {
                InitDelegate(ref getReplayFlags, vtbl->GetReplayFlags);

                return getReplayFlags(Raw);
            }
            set
            {
                InitDelegate(ref setReplayFlags, vtbl->SetReplayFlags);

                setReplayFlags(Raw, value);
            }
        }

        #endregion
        #region AddMemoryWatchpoint

        //TTD::Replay::Cursor::AddMemoryWatchpoint(TTD::Replay::MemoryWatchpointData const &)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate bool AddMemoryWatchpointDelegate(
            [In] IntPtr @this,
            [In] IntPtr memoryWatchpointData);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddMemoryWatchpointDelegate addMemoryWatchpoint;

        public bool AddMemoryWatchpoint(MemoryWatchpointData memoryWatchpointData)
        {
            InitDelegate(ref addMemoryWatchpoint, vtbl->AddMemoryWatchpoint);

            //I don't know whether the data gets modified
            var local = memoryWatchpointData;
            var result = addMemoryWatchpoint(Raw, (IntPtr) (&local));
            Debug.Assert(memoryWatchpointData.Equals(local)); //If this value is modified, we need to return it to the caller
            return result;
        }

        #endregion
        #region RemoveMemoryWatchpoint

        //TTD::Replay::Cursor::RemoveMemoryWatchpoint(TTD::Replay::MemoryWatchpointData const &)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate bool RemoveMemoryWatchpointDelegate(
            [In] IntPtr @this,
            [In] IntPtr memoryWatchpointData);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveMemoryWatchpointDelegate removeMemoryWatchpoint;

        public bool RemoveMemoryWatchpoint(MemoryWatchpointData memoryWatchpointData)
        {
            InitDelegate(ref removeMemoryWatchpoint, vtbl->RemoveMemoryWatchpoint);

            //I don't know whether the data gets modified
            var local = memoryWatchpointData;
            var result = removeMemoryWatchpoint(Raw, (IntPtr) (&memoryWatchpointData));
            Debug.Assert(memoryWatchpointData.Equals(local)); //If this value is modified, we need to return it to the caller
            return result;
        }

        #endregion
        #region AddPositionWatchpoint

        //TTD::Replay::Cursor::AddPositionWatchpoint(TTD::Replay::PositionWatchpointData const &)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate bool AddPositionWatchpointDelegate(
            [In] IntPtr @this,
            [In] IntPtr positionWatchpointData); //PositionWatchpointData. Don't know what this is yet

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddPositionWatchpointDelegate addPositionWatchpoint;

        public bool AddPositionWatchpoint(PositionWatchpointData positionWatchpointData)
        {
            InitDelegate(ref addPositionWatchpoint, vtbl->AddPositionWatchpoint);

            //I don't know whether the data gets modified
            var local = positionWatchpointData;
            var result = addPositionWatchpoint(Raw, (IntPtr) (&local));
            Debug.Assert(positionWatchpointData.Equals(local)); //If this value is modified, we need to return it to the caller
            return result;
        }

        #endregion
        #region RemovePositionWatchpoint

        //TTD::Replay::Cursor::RemovePositionWatchpoint(TTD::Replay::PositionWatchpointData const &)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate bool RemovePositionWatchpointDelegate(
            [In] IntPtr @this,
            [In] IntPtr positionWatchpointData); //PositionWatchpointData. Don't know what this is yet

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemovePositionWatchpointDelegate removePositionWatchpoint;

        public bool RemovePositionWatchpoint(PositionWatchpointData positionWatchpointData)
        {
            InitDelegate(ref removePositionWatchpoint, vtbl->RemovePositionWatchpoint);

            //I don't know whether the data gets modified
            var local = positionWatchpointData;
            var result = removePositionWatchpoint(Raw, (IntPtr) (&local));
            Debug.Assert(positionWatchpointData.Equals(local)); //If this value is modified, we need to return it to the caller
            return result;
        }

        #endregion
        #region Clear

        //TTD::Replay::Cursor::Clear(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void ClearDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ClearDelegate clear;

        public void Clear()
        {
            InitDelegate(ref clear, vtbl->Clear);

            clear(Raw);
        }

        #endregion
        #region SetPosition

        //TTD::Replay::Cursor::SetPosition(TTD::Replay::Position const &)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetPositionDelegate(
            [In] IntPtr @this,
            [In] Position position);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetPositionDelegate setPosition;

        public void SetPosition(Position position)
        {
            InitDelegate(ref setPosition, vtbl->SetPosition);

            setPosition(Raw, position);
        }

        #endregion
        #region SetPositionOnThread

        //TTD::Replay::Cursor::SetPositionOnThread(TTD::Replay::UniqueThreadId,TTD::Replay::Position const &)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetPositionOnThreadDelegate(
            [In] IntPtr @this,
            [In] UniqueThreadId threadId,
            [In] Position position);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetPositionOnThreadDelegate setPositionOnThread;

        public void SetPositionOnThread(UniqueThreadId threadId, Position position)
        {
            InitDelegate(ref setPositionOnThread, vtbl->SetPositionOnThread);

            setPositionOnThread(Raw, threadId, position);
        }

        #endregion
        #region SetMemoryWatchpointCallback

        //TTD::Replay::Cursor::SetMemoryWatchpointCallback(bool (*const)(unsigned __int64,TTD::Replay::ICursorView::MemoryWatchpointResult const &,TTD::Replay::IThreadView const *),unsigned __int64)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetMemoryWatchpointCallbackDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] MemoryWatchpointCallbackRaw callback,
            [In] long context);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetMemoryWatchpointCallbackDelegate setMemoryWatchpointCallback;

        public unsafe void SetMemoryWatchpointCallback(MemoryWatchpointCallback callback, long context = default)
        {
            InitDelegate(ref setMemoryWatchpointCallback, vtbl->SetMemoryWatchpointCallback);

            MemoryWatchpointCallbackRaw raw = null;

            if (callback != null)
            {
                raw = (a, b, c) =>
                {
                    var threadView = c == default ? null : new ThreadView(c);

                    return callback(a, b, threadView);
                };
            }

            lastSetMemoryWatchpointCallback = raw;

            setMemoryWatchpointCallback(Raw, raw, context);
        }

        #endregion
        #region SetPositionWatchpointCallback

        //TTD::Replay::Cursor::SetPositionWatchpointCallback(bool (*const)(unsigned __int64,TTD::Replay::Position const &,TTD::Replay::IThreadView const *),unsigned __int64)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetPositionWatchpointCallbackDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] PositionWatchpointCallbackRaw callback,
            [In] long _unknown);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetPositionWatchpointCallbackDelegate setPositionWatchpointCallback;

        public void SetPositionWatchpointCallback(PositionWatchpointCallback callback, long _unknown) //addr_ret?
        {
            InitDelegate(ref setPositionWatchpointCallback, vtbl->SetPositionWatchpointCallback);

            PositionWatchpointCallbackRaw raw = null;

            if (callback != null)
            {
                raw = (a, b, c) =>
                {
                    var threadView = c == default ? null : new ThreadView(c);

                    return callback(a, b, threadView);
                };
            }

            lastSetPositionWatchpointCallback = raw;

            setPositionWatchpointCallback(Raw, raw, _unknown);
        }

        #endregion
        #region SetGapEventCallback

        //TTD::Replay::Cursor::SetGapEventCallback(bool (*const)(unsigned __int64,TTD::Replay::GapKind,TTD::Replay::GapEventType,TTD::Replay::IThreadView const *),unsigned __int64)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetGapEventCallbackDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] GapEventCallbackRaw callback,
            [In] long _unknown);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetGapEventCallbackDelegate setGapEventCallback;

        public void SetGapEventCallback(GapEventCallback callback, long _unknown)
        {
            InitDelegate(ref setGapEventCallback, vtbl->SetGapEventCallback);

            GapEventCallbackRaw raw = null;

            if (callback != null)
            {
                raw = (a, b, c, d) =>
                {
                    var threadView = d == default ? null : new ThreadView(d);

                    return callback(a, b, c, threadView);
                };
            }

            lastSetGapEventCallback = raw;

            setGapEventCallback(Raw, raw, _unknown);
        }

        #endregion
        #region SetThreadContinuityBreakCallback

        //TTD::Replay::Cursor::SetThreadContinuityBreakCallback(void (*const)(unsigned __int64),unsigned __int64)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetThreadContinuityBreakCallbackDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] ThreadContinuityBreakCallback callback,
            [In] long _unknown);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetThreadContinuityBreakCallbackDelegate setThreadContinuityBreakCallback;

        public void SetThreadContinuityBreakCallback(ThreadContinuityBreakCallback callback, long _unknown)
        {
            InitDelegate(ref setThreadContinuityBreakCallback, vtbl->SetThreadContinuityBreakCallback);

            lastSetThreadContinuityBreakCallback = callback;

            setThreadContinuityBreakCallback(Raw, callback, _unknown);
        }

        #endregion
        #region SetReplayProgressCallback

        //TTD::Replay::Cursor::SetReplayProgressCallback(void (*const)(unsigned __int64,TTD::Replay::Position const &),unsigned __int64)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetReplayProgressCallbackDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] ReplayProgressCallback callback,
            [In] long _unknown);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetReplayProgressCallbackDelegate setReplayProgressCallback;

        public void SetReplayProgressCallback(ReplayProgressCallback callback, long _unknown)
        {
            InitDelegate(ref setReplayProgressCallback, vtbl->SetReplayProgressCallback);

            lastSetReplayProgressCallback = callback;

            setReplayProgressCallback(Raw, callback, _unknown);
        }

        #endregion
        #region SetFallbackCallback

        //TTD::Replay::Cursor::SetFallbackCallback(void (*const)(unsigned __int64,bool,Nirvana::GuestAddress,unsigned __int64,TTD::Replay::IThreadView const *),unsigned __int64)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetFallbackCallbackDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] FallbackCallbackRaw callback,
            [In] long _unknown);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetFallbackCallbackDelegate setFallbackCallback;

        public void SetFallbackCallback(FallbackCallback callback, long _unknown)
        {
            InitDelegate(ref setFallbackCallback, vtbl->SetFallbackCallback);

            FallbackCallbackRaw raw = null;

            if (callback != null)
            {
                raw = (a, b, c, d, e) =>
                {
                    var threadView = e == default ? null : new ThreadView(e);

                    callback(a, b, c, d, threadView);
                };
            }

            lastSetFallbackCallback = raw;

            setFallbackCallback(Raw, raw, _unknown);
        }

        #endregion
        #region SetCallReturnCallback

        //TTD::Replay::Cursor::SetCallReturnCallback(void (*const)(unsigned __int64,Nirvana::GuestAddress,Nirvana::GuestAddress,TTD::Replay::IThreadView const *),unsigned __int64)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetCallReturnCallbackDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] CallReturnCallbackRaw callback,
            [In] long context);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetCallReturnCallbackDelegate setCallReturnCallback;

        public void SetCallReturnCallback(CallReturnCallback callback, long context = default)
        {
            InitDelegate(ref setCallReturnCallback, vtbl->SetCallReturnCallback);

            CallReturnCallbackRaw raw = null;

            if (callback != null)
            {
                raw = (a, b, c, d) =>
                {
                    var threadView = d == default ? null : new ThreadView(d);

                    callback(a, b, c, threadView);
                };
            }

            lastSetCallReturnCallback = raw;

            setCallReturnCallback(Raw, raw, context);
        }

        #endregion
        #region SetIndirectJumpCallback

        //TTD::Replay::Cursor::SetIndirectJumpCallback(void (*const)(unsigned __int64,Nirvana::GuestAddress,TTD::Replay::IThreadView const *),unsigned __int64)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetIndirectJumpCallbackDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] IndirectJumpCallbackRaw callback,
            [In] long context);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetIndirectJumpCallbackDelegate setIndirectJumpCallback;

        public void SetIndirectJumpCallback(IndirectJumpCallback callback, long context = default)
        {
            InitDelegate(ref setIndirectJumpCallback, vtbl->SetIndirectJumpCallback);

            IndirectJumpCallbackRaw raw = null;

            if (callback != null)
            {
                raw = (a, b, c) =>
                {
                    var threadView = c == default ? null : new ThreadView(c);

                    callback(a, b, threadView);
                };
            }

            lastSetIndirectJumpCallback = raw;

            setIndirectJumpCallback(Raw, raw, context);
        }

        #endregion
        #region SetRegisterChangedCallback

        //TTD::Replay::Cursor::SetRegisterChangedCallback(void (*const)(unsigned __int64,uchar,void const *,void const *,unsigned __int64,TTD::Replay::IThreadView const *),unsigned __int64)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SetRegisterChangedCallbackDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] RegisterChangedCallbackRaw callback,
            [In] long context);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetRegisterChangedCallbackDelegate setRegisterChangedCallback;

        public void SetRegisterChangedCallback(RegisterChangedCallback callback, long context = default)
        {
            InitDelegate(ref setRegisterChangedCallback, vtbl->SetRegisterChangedCallback);

            RegisterChangedCallbackRaw raw = null;

            if (callback != null)
            {
                raw = (a, b, c, d, e, f) =>
                {
                    var threadView = f == default ? null : new ThreadView(f);

                    callback(a, b, c, d, e, threadView);
                };
            }

            lastSetRegisterChangedCallback = raw;

            setRegisterChangedCallback(Raw, raw, context);
        }

        #endregion
        #region ReplayForward

        //TTD::Replay::Cursor::ReplayForward(TTD::Replay::Position,TTD::Replay::StepCount)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr ReplayForwardDelegate(
            [In] IntPtr @this,
            [In] IntPtr replayResult,
            [In] IntPtr replayUntil,
            [In] StepCount stepCount);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReplayForwardDelegate replayForward;

        public ReplayResult ReplayForward(Position replayUntil, StepCount stepCount)
        {
            //Based on my analysis of dbgeng!TtdTargetInfo::WaitForEvent and TTDAnalyze.dll, ReplayResult is not set on input,
            //and only contains junk

            InitDelegate(ref replayForward, vtbl->ReplayForward);

            ReplayResult result = new ReplayResult();
            var local = replayUntil;
            replayForward(Raw, (IntPtr) (&result), (IntPtr) (&local), stepCount);
            Debug.Assert(local.Equals(replayUntil));
            return result;
        }

        #endregion
        #region ReplayBackward

        //TTD::Replay::Cursor::ReplayBackward(TTD::Replay::Position,TTD::Replay::StepCount)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr ReplayBackwardDelegate(
            [In] IntPtr @this,
            [In] IntPtr replayResult,
            [In] IntPtr replayUntil,
            [In] StepCount stepCount);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReplayBackwardDelegate replayBackward;

        public ReplayResult ReplayBackward(Position replayUntil, StepCount stepCount)
        {
            InitDelegate(ref replayBackward, vtbl->ReplayBackward);

            var local = replayUntil;
            ReplayResult result = new ReplayResult();
            replayBackward(Raw, (IntPtr) (&result), (IntPtr) (&local), stepCount);
            Debug.Assert(local.Equals(replayUntil));
            return result;
        }

        #endregion
        #region InterruptReplay

        //TTD::Replay::Cursor::InterruptReplay(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void InterruptReplayDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private InterruptReplayDelegate interruptReplay;

        public void InterruptReplay()
        {
            InitDelegate(ref interruptReplay, vtbl->InterruptReplay);

            interruptReplay(Raw);
        }

        #endregion
        #region GetInternals

        //TTD::Replay::ReplayEngine::GetInternals(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr GetInternalsDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetInternalsDelegate getInternals;

        #endregion
        #region GetInternalData

        //TTD::Replay::Cursor::GetInternalData(TTD::Replay::ICursorView::InternalDataId,void *,unsigned __int64)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetInternalDataDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetInternalDataDelegate getInternalData;

        public long GetInternalData(InternalDataId internalDataId, IntPtr _unknown1, long _unknown2)
        {
            InitDelegate(ref getInternalData, vtbl->GetInternalData);

            return getInternalData(Raw);
        }

        #endregion
        #region Destroy

        //TTD::Replay::Cursor::Destroy(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void DestroyDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DestroyDelegate destroy;

        //It's not clear to me whether or not you should call Destroy() as soon as you are done with your cursor. TTD's DbgModel never seems to call Destroy and calls NewCursor all over the place. I also don't know
        //whether the ReplayEngine will clean up all its cursors when it's free'd. As such, for now neither ReplayEngine or Cursor are IDisposable
        public void Destroy()
        {
            InitDelegate(ref destroy, vtbl->Destroy);

            destroy(Raw);
        }

        #endregion

        public Cursor(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(CursorVtbl**) raw;
        }
    }
}
