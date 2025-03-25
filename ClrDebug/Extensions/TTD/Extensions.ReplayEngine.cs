using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.TTD
{
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public unsafe delegate void BuildIndexCallback([In] IntPtr context, IndexBuildProgressType* b);

    public unsafe class ReplayEngine
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReplayEngineVtbl* vtbl;

        #region UnsafeAsInterface

        //TTD::Replay::ReplayEngine::UnsafeAsInterface(_GUID const &)
        //TTD::Replay::ReplayEngine::UnsafeAsInterface(_GUID const &)

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
        #region GetPebAddress

        //TTD::Replay::ReplayEngine::GetPebAddress(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate GuestAddress GetPebAddressDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPebAddressDelegate getPebAddress;

        public GuestAddress PebAddress
        {
            get
            {
                InitDelegate(ref getPebAddress, vtbl->GetPebAddress);

                return getPebAddress(Raw);
            }
        }

        #endregion
        #region GetSystemInfo

        //TTD::Replay::ReplayEngine::GetSystemInfo(void)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate SystemInfo* GetSystemInfoDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSystemInfoDelegate getSystemInfo;

        public SystemInfo* SystemInfo
        {
            get
            {
                InitDelegate(ref getSystemInfo, vtbl->GetSystemInfo);

                return getSystemInfo(Raw);
            }
        }

        #endregion
        #region GetFirstPosition

        //TTD::Replay::ReplayEngine::GetFirstPosition(void)
        //TTD::Replay::ReplayEngine::GetFirstPosition(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate Position* GetFirstPositionDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFirstPositionDelegate getFirstPosition;

        public Position FirstPosition
        {
            get
            {
                InitDelegate(ref getFirstPosition, vtbl->GetFirstPosition);

                return *getFirstPosition(Raw);
            }
        }

        #endregion
        #region GetLastPosition

        //TTD::Replay::ReplayEngine::GetLastPosition(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate Position* GetLastPositionDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLastPositionDelegate getLastPosition;

        public Position LastPosition
        {
            get
            {
                InitDelegate(ref getLastPosition, vtbl->GetLastPosition);

                return *getLastPosition(Raw);
            }
        }

        #endregion
        #region GetRecordingType

        //TTD::Replay::ReplayEngine::GetRecordingType(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate RecordingType GetRecordingTypeDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetRecordingTypeDelegate getRecordingType;

        public RecordingType RecordingType
        {
            get
            {
                InitDelegate(ref getRecordingType, vtbl->GetRecordingType);

                return getRecordingType(Raw);
            }
        }

        #endregion
        #region GetThreadInfo

        //TTD::Replay::ReplayEngine::GetThreadInfo(TTD::Replay::UniqueThreadId)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ThreadInfo* GetThreadInfoDelegate(
            [In] IntPtr @this,
            [In] UniqueThreadId threadId);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadInfoDelegate getThreadInfo;

        public ThreadInfo* GetThreadInfo(UniqueThreadId threadId)
        {
            InitDelegate(ref getThreadInfo, vtbl->GetThreadInfo);

            return getThreadInfo(Raw, threadId);
        }

        #endregion
        #region GetThreadCount

        //TTD::Replay::ReplayEngine::GetThreadCount(void)

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

        //TTD::Replay::ReplayEngine::GetThreadList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ThreadInfo* GetThreadListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadListDelegate getThreadList;

        public ThreadInfo[] ThreadList
        {
            get
            {
                //todo: i dont think this is returning the right value
                var numThreads = ThreadCount;
                var threadList = GetThreadList();

                var results = new ThreadInfo[numThreads];

                for (var i = 0; i < numThreads; i++)
                    results[i] = threadList[i];

                return results;
            }
        }

        public ThreadInfo* GetThreadList()
        {
            InitDelegate(ref getThreadList, vtbl->GetThreadList);

            return getThreadList(Raw);
        }

        #endregion
        #region GetThreadFirstPositionIndex

        //TTD::Replay::ReplayEngine::GetThreadFirstPositionIndex(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetThreadFirstPositionIndexDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadFirstPositionIndexDelegate getThreadFirstPositionIndex;

        public long ThreadFirstPositionIndex
        {
            get
            {
                InitDelegate(ref getThreadFirstPositionIndex, vtbl->GetThreadFirstPositionIndex);

                return getThreadFirstPositionIndex(Raw);
            }
        }

        #endregion
        #region GetThreadLastPositionIndex

        //TTD::Replay::ReplayEngine::GetThreadLastPositionIndex(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetThreadLastPositionIndexDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadLastPositionIndexDelegate getThreadLastPositionIndex;

        public long ThreadLastPositionIndex
        {
            get
            {
                InitDelegate(ref getThreadLastPositionIndex, vtbl->GetThreadLastPositionIndex);

                return getThreadLastPositionIndex(Raw);
            }
        }

        #endregion
        #region GetThreadLifetimeFirstPositionIndex

        //TTD::Replay::ReplayEngine::GetThreadLifetimeFirstPositionIndex(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetThreadLifetimeFirstPositionIndexDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadLifetimeFirstPositionIndexDelegate getThreadLifetimeFirstPositionIndex;

        public long ThreadLifetimeFirstPositionIndex
        {
            get
            {
                InitDelegate(ref getThreadLifetimeFirstPositionIndex, vtbl->GetThreadLifetimeFirstPositionIndex);

                return getThreadLifetimeFirstPositionIndex(Raw);
            }
        }

        #endregion
        #region GetThreadLifetimeLastPositionIndex

        //TTD::Replay::ReplayEngine::GetThreadLifetimeLastPositionIndex(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetThreadLifetimeLastPositionIndexDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadLifetimeLastPositionIndexDelegate getThreadLifetimeLastPositionIndex;

        public long ThreadLifetimeLastPositionIndex
        {
            get
            {
                InitDelegate(ref getThreadLifetimeLastPositionIndex, vtbl->GetThreadLifetimeLastPositionIndex);

                return getThreadLifetimeLastPositionIndex(Raw);
            }
        }

        #endregion
        #region GetThreadCreatedEventCount

        //TTD::Replay::ReplayEngine::GetThreadCreatedEventCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetThreadCreatedEventCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadCreatedEventCountDelegate getThreadCreatedEventCount;

        public long ThreadCreatedEventCount
        {
            get
            {
                InitDelegate(ref getThreadCreatedEventCount, vtbl->GetThreadCreatedEventCount);

                return getThreadCreatedEventCount(Raw);
            }
        }

        #endregion
        #region GetThreadCreatedEventList

        //TTD::Replay::ReplayEngine::GetThreadCreatedEventList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ThreadCreatedEvent* GetThreadCreatedEventListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadCreatedEventListDelegate getThreadCreatedEventList;

        public ThreadCreatedEvent[] ThreadCreatedEventList
        {
            get
            {
                var numEvents = ThreadCreatedEventCount;
                var eventList = GetThreadCreatedEventList();

                var results = new ThreadCreatedEvent[numEvents];

                for (var i = 0; i < numEvents; i++)
                    results[i] = eventList[i];

                return results;
            }
        }

        public ThreadCreatedEvent* GetThreadCreatedEventList()
        {
            InitDelegate(ref getThreadCreatedEventList, vtbl->GetThreadCreatedEventList);

            return getThreadCreatedEventList(Raw);
        }

        #endregion
        #region GetThreadTerminatedEventCount

        //TTD::Replay::ReplayEngine::GetThreadTerminatedEventCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetThreadTerminatedEventCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadTerminatedEventCountDelegate getThreadTerminatedEventCount;

        public long ThreadTerminatedEventCount
        {
            get
            {
                InitDelegate(ref getThreadTerminatedEventCount, vtbl->GetThreadTerminatedEventCount);

                return getThreadTerminatedEventCount(Raw);
            }
        }

        #endregion
        #region GetThreadTerminatedEventList

        //TTD::Replay::ReplayEngine::GetThreadTerminatedEventList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ThreadTerminatedEvent* GetThreadTerminatedEventListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadTerminatedEventListDelegate getThreadTerminatedEventList;

        public ThreadTerminatedEvent[] ThreadTerminatedEventList
        {
            get
            {
                var numEvents = ThreadTerminatedEventCount;
                var eventList = GetThreadTerminatedEventList();

                var results = new ThreadTerminatedEvent[numEvents];

                for (var i = 0; i < numEvents; i++)
                    results[i] = eventList[i];

                return results;
            }
        }

        public ThreadTerminatedEvent* GetThreadTerminatedEventList()
        {
            InitDelegate(ref getThreadTerminatedEventList, vtbl->GetThreadTerminatedEventList);

            return getThreadTerminatedEventList(Raw);
        }

        #endregion
        #region GetModuleCount

        //TTD::Replay::ReplayEngine::GetModuleCount(void)

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

        //TTD::Replay::ReplayEngine::GetModuleList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate Module* GetModuleListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleListDelegate getModuleList;

        public Module[] ModuleList
        {
            get
            {
                var numModules = ModuleCount;
                var moduleList = GetModuleList();

                var results = new Module[numModules];

                for (var i = 0; i < numModules; i++)
                    results[i] = moduleList[i];

                return results;
            }
        }

        public Module* GetModuleList()
        {
            InitDelegate(ref getModuleList, vtbl->GetModuleList);

            return getModuleList(Raw);
        }

        #endregion
        #region GetModuleInstanceCount

        //TTD::Replay::ReplayEngine::GetModuleInstanceCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetModuleInstanceCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleInstanceCountDelegate getModuleInstanceCount;

        public long ModuleInstanceCount
        {
            get
            {
                InitDelegate(ref getModuleInstanceCount, vtbl->GetModuleInstanceCount);

                return getModuleInstanceCount(Raw);
            }
        }

        #endregion
        #region GetModuleInstanceList

        //TTD::Replay::ReplayEngine::GetModuleInstanceList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ModuleInstance* GetModuleInstanceListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleInstanceListDelegate getModuleInstanceList;

        public ModuleInstance[] ModuleInstanceList
        {
            get
            {
                var numModuleInstances = ModuleInstanceCount;
                var moduleInstanceList = GetModuleInstanceList();

                var results = new ModuleInstance[numModuleInstances];

                for (var i = 0; i < numModuleInstances; i++)
                    results[i] = moduleInstanceList[i];

                return results;
            }
        }

        public ModuleInstance* GetModuleInstanceList()
        {
            InitDelegate(ref getModuleInstanceList, vtbl->GetModuleInstanceList);

            return getModuleInstanceList(Raw);
        }

        #endregion
        #region GetModuleInstanceUnloadIndex

        //TTD::Replay::ReplayEngine::GetModuleInstanceUnloadIndex(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetModuleInstanceUnloadIndexDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleInstanceUnloadIndexDelegate getModuleInstanceUnloadIndex;

        public long ModuleInstanceUnloadIndex
        {
            get
            {
                InitDelegate(ref getModuleInstanceUnloadIndex, vtbl->GetModuleInstanceUnloadIndex);

                return getModuleInstanceUnloadIndex(Raw);
            }
        }

        #endregion
        #region GetModuleLoadedEventCount

        //TTD::Replay::ReplayEngine::GetModuleLoadedEventCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetModuleLoadedEventCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleLoadedEventCountDelegate getModuleLoadedEventCount;

        public long ModuleLoadedEventCount
        {
            get
            {
                InitDelegate(ref getModuleLoadedEventCount, vtbl->GetModuleLoadedEventCount);

                return getModuleLoadedEventCount(Raw);
            }
        }

        #endregion
        #region GetModuleLoadedEventList

        //TTD::Replay::ReplayEngine::GetModuleLoadedEventList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ModuleLoadedEvent* GetModuleLoadedEventListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleLoadedEventListDelegate getModuleLoadedEventList;

        public ModuleLoadedEvent[] ModuleLoadedEventList
        {
            get
            {
                var numEvents = ModuleLoadedEventCount;
                var eventList = GetModuleLoadedEventList();

                var results = new ModuleLoadedEvent[numEvents];

                for (var i = 0; i < numEvents; i++)
                    results[i] = eventList[i];

                return results;
            }
        }

        public ModuleLoadedEvent* GetModuleLoadedEventList()
        {
            InitDelegate(ref getModuleLoadedEventList, vtbl->GetModuleLoadedEventList);

            return getModuleLoadedEventList(Raw);
        }

        #endregion
        #region GetModuleUnloadedEventCount

        //TTD::Replay::ReplayEngine::GetModuleUnloadedEventCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetModuleUnloadedEventCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleUnloadedEventCountDelegate getModuleUnloadedEventCount;

        public long ModuleUnloadedEventCount
        {
            get
            {
                InitDelegate(ref getModuleUnloadedEventCount, vtbl->GetModuleUnloadedEventCount);

                return getModuleUnloadedEventCount(Raw);
            }
        }

        #endregion
        #region GetModuleUnloadedEventList

        //TTD::Replay::ReplayEngine::GetModuleUnloadedEventList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ModuleUnloadedEvent* GetModuleUnloadedEventListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleUnloadedEventListDelegate getModuleUnloadedEventList;

        public ModuleUnloadedEvent[] ModuleUnloadedEventList
        {
            get
            {
                var numEvents = ModuleUnloadedEventCount;
                var eventList = GetModuleUnloadedEventList();

                var results = new ModuleUnloadedEvent[numEvents];

                for (var i = 0; i < numEvents; i++)
                    results[i] = eventList[i];

                return results;
            }
        }

        public ModuleUnloadedEvent* GetModuleUnloadedEventList()
        {
            InitDelegate(ref getModuleUnloadedEventList, vtbl->GetModuleUnloadedEventList);

            return getModuleUnloadedEventList(Raw);
        }

        #endregion
        #region GetExceptionEventCount

        //TTD::Replay::ReplayEngine::GetExceptionEventCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetExceptionEventCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExceptionEventCountDelegate getExceptionEventCount;

        public long ExceptionEventCount
        {
            get
            {
                InitDelegate(ref getExceptionEventCount, vtbl->GetExceptionEventCount);

                return getExceptionEventCount(Raw);
            }
        }

        #endregion
        #region GetExceptionEventList

        //TTD::Replay::ReplayEngine::GetExceptionEventList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ExceptionEvent* GetExceptionEventListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExceptionEventListDelegate getExceptionEventList;

        public ExceptionEvent[] ExceptionEventList
        {
            get
            {
                var numEvents = ExceptionEventCount;
                var eventList = GetExceptionEventList();

                var results = new ExceptionEvent[numEvents];

                for (var i = 0; i < numEvents; i++)
                    results[i] = eventList[i];

                return results;
            }
        }

        public ExceptionEvent* GetExceptionEventList()
        {
            InitDelegate(ref getExceptionEventList, vtbl->GetExceptionEventList);

            return getExceptionEventList(Raw);
        }

        #endregion
        #region GetExceptionAtOrAfterPosition

        //TTD::Replay::ReplayEngine::GetExceptionAtOrAfterPosition(TTD::Replay::Position const &)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ExceptionEvent* GetExceptionAtOrAfterPositionDelegate(
            [In] IntPtr @this,
            [In] Position position);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExceptionAtOrAfterPositionDelegate getExceptionAtOrAfterPosition;

        public ExceptionEvent* GetExceptionAtOrAfterPosition(Position position)
        {
            InitDelegate(ref getExceptionAtOrAfterPosition, vtbl->GetExceptionAtOrAfterPosition);

            return getExceptionAtOrAfterPosition(Raw, position);
        }

        #endregion
        #region GetKeyframeCount

        //TTD::Replay::ReplayEngine::GetKeyframeCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetKeyframeCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetKeyframeCountDelegate getKeyframeCount;

        public long KeyframeCount
        {
            get
            {
                InitDelegate(ref getKeyframeCount, vtbl->GetKeyframeCount);

                return getKeyframeCount(Raw);
            }
        }

        #endregion
        #region GetKeyframeList

        //TTD::Replay::ReplayEngine::GetKeyframeList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate Position* GetKeyframeListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetKeyframeListDelegate getKeyframeList;

        public Position[] KeyframeList
        {
            get
            {
                var numKeyframes = KeyframeCount;
                var keyframeList = GetKeyframeList();

                var results = new Position[numKeyframes];

                for (var i = 0; i < numKeyframes; i++)
                    results[i] = keyframeList[i];

                return results;
            }
        }

        public Position* GetKeyframeList()
        {
            InitDelegate(ref getKeyframeList, vtbl->GetKeyframeList);

            return getKeyframeList(Raw);
        }

        #endregion
        #region GetRecordClientCount

        //TTD::Replay::ReplayEngine::GetRecordClientCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetRecordClientCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetRecordClientCountDelegate getRecordClientCount;

        public long RecordClientCount
        {
            get
            {
                InitDelegate(ref getRecordClientCount, vtbl->GetRecordClientCount);

                return getRecordClientCount(Raw);
            }
        }

        #endregion
        #region GetRecordClientList

        //TTD::Replay::ReplayEngine::GetRecordClientList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate RecordClient* GetRecordClientListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetRecordClientListDelegate getRecordClientList;

        public RecordClient* RecordClientList
        {
            get
            {
                InitDelegate(ref getRecordClientList, vtbl->GetRecordClientList);

                return getRecordClientList(Raw);
            }
        }

        #endregion
        #region GetRecordClient

        //TTD::Replay::ReplayEngine::GetRecordClient(TTD::RecordClientId)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate RecordClient GetRecordClientDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetRecordClientDelegate getRecordClient;

        public RecordClient GetRecordClient()
        {
            InitDelegate(ref getRecordClient, vtbl->GetRecordClient);

            return getRecordClient(Raw);
        }

        #endregion
        #region GetCustomEventCount

        //TTD::Replay::ReplayEngine::GetCustomEventCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetCustomEventCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCustomEventCountDelegate getCustomEventCount;

        public long CustomEventCount
        {
            get
            {
                InitDelegate(ref getCustomEventCount, vtbl->GetCustomEventCount);

                return getCustomEventCount(Raw);
            }
        }

        #endregion
        #region GetCustomEventList

        //TTD::Replay::ReplayEngine::GetCustomEventList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate CustomEvent* GetCustomEventListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCustomEventListDelegate getCustomEventList;

        public CustomEvent* CustomEventList
        {
            get
            {
                InitDelegate(ref getCustomEventList, vtbl->GetCustomEventList);

                return getCustomEventList(Raw);
            }
        }

        #endregion
        #region GetActivityCount

        //TTD::Replay::ReplayEngine::GetActivityCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetActivityCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetActivityCountDelegate getActivityCount;

        public long ActivityCount
        {
            get
            {
                InitDelegate(ref getActivityCount, vtbl->GetActivityCount);

                return getActivityCount(Raw);
            }
        }

        #endregion
        #region GetActivityList

        //TTD::Replay::ReplayEngine::GetActivityList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate Activity* GetActivityListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetActivityListDelegate getActivityList;

        public Activity[] ActivityList
        {
            get
            {
                var numActivities = ActivityCount;
                var activityList = GetActivityList();

                var results = new Activity[numActivities];

                for (var i = 0; i < numActivities; i++)
                    results[i] = activityList[i];

                return results;
            }
        }

        public Activity* GetActivityList()
        {
            InitDelegate(ref getActivityList, vtbl->GetActivityList);

            return getActivityList(Raw);
        }

        #endregion
        #region GetIslandCount

        //TTD::Replay::ReplayEngine::GetIslandCount(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetIslandCountDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetIslandCountDelegate getIslandCount;

        public long IslandCount
        {
            get
            {
                InitDelegate(ref getIslandCount, vtbl->GetIslandCount);

                return getIslandCount(Raw);
            }
        }

        #endregion
        #region GetIslandList

        //TTD::Replay::ReplayEngine::GetIslandList(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate Island* GetIslandListDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetIslandListDelegate getIslandList;

        public Island* IslandList
        {
            get
            {
                InitDelegate(ref getIslandList, vtbl->GetIslandList);

                return getIslandList(Raw);
            }
        }

        #endregion
        #region NewCursor

        //TTD::Replay::ReplayEngine::NewCursor(_GUID const &)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr NewCursorDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private NewCursorDelegate newCursor;

        public Cursor NewCursor(Guid guid)
        {
            InitDelegate(ref newCursor, vtbl->NewCursor);

            var result = newCursor(Raw, guid);

            return new Cursor(result);
        }

        #endregion
        #region BuildIndex

        //TTD::Replay::ReplayEngine::BuildIndex(void (*)(void const *,TTD::Replay::IndexBuildProgressType const *),void const *,TTD::Replay::IndexBuildFlags)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IndexStatus BuildIndexDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] BuildIndexCallback callback,
            [In] IntPtr context,
            [In] IndexBuildFlags flags);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private BuildIndexDelegate buildIndex;

        public IndexStatus BuildIndex(BuildIndexCallback callback, IntPtr _unknown1, IndexBuildFlags flags)
        {
            InitDelegate(ref buildIndex, vtbl->BuildIndex);

            GC.KeepAlive(callback);

            return buildIndex(Raw, callback, _unknown1, flags);
        }

        #endregion
        #region GetIndexStatus

        //TTD::Replay::ReplayEngine::GetIndexStatus(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IndexStatus GetIndexStatusDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetIndexStatusDelegate getIndexStatus;

        public IndexStatus IndexStatus
        {
            get
            {
                InitDelegate(ref getIndexStatus, vtbl->GetIndexStatus);

                return getIndexStatus(Raw);
            }
        }

        #endregion
        #region GetIndexFileStats

        //TTD::Replay::ReplayEngine::GetIndexFileStats(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr GetIndexFileStatsDelegate(
            [In] IntPtr @this,
            [In] IntPtr buffer);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetIndexFileStatsDelegate getIndexFileStats;

        public byte[] IndexFileStats
        {
            get
            {
                //Currently this function just memsets the buffer to all 0's

                InitDelegate(ref getIndexFileStats, vtbl->GetIndexFileStats);

                var buffer = new byte[208];

                fixed (byte* p = buffer)
                {
                    getIndexFileStats(Raw, (IntPtr) p);
                }

                return buffer;
            }
        }

        #endregion
        #region RegisterDebugModeAndLogging

        //TTD::Replay::ReplayEngine::RegisterDebugModeAndLogging(TTD::Replay::DebugModeType,TTD::ErrorReporting *)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void RegisterDebugModeAndLoggingDelegate(
            [In] IntPtr @this,
            [In] DebugModeType debugModeType,
            [In] IntPtr pErrorReporting);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RegisterDebugModeAndLoggingDelegate registerDebugModeAndLogging;

        public void RegisterDebugModeAndLogging(DebugModeType debugModeType, ErrorReporting pErrorReporting)
        {
            InitDelegate(ref registerDebugModeAndLogging, vtbl->RegisterDebugModeAndLogging);

            registerDebugModeAndLogging(Raw, debugModeType, pErrorReporting.This);
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
        #region

        //TTD::Replay::ReplayEngine::Destroy(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void DestroyDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DestroyDelegate destroy;

        public void Destroy()
        {
            InitDelegate(ref destroy, vtbl->Destroy);

            destroy(Raw);
        }

        #endregion
        #region Initialize

        //TTD::Replay::ReplayEngine::Initialize(wchar_t const *)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate bool InitializeDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPWStr)] string filePath);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private InitializeDelegate initialize;

        public void Initialize(string filePath) =>
            TryInitialize(filePath).ThrowOnNotOK();

        public HRESULT TryInitialize(string filePath)
        {
            InitDelegate(ref initialize, vtbl->Initialize);

            if (!initialize(Raw, filePath))
                return (HRESULT) Marshal.GetHRForLastWin32Error();

            return HRESULT.S_OK;
        }

        #endregion

        public ReplayEngine(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(ReplayEngineVtbl**) raw;
        }
    }
}
