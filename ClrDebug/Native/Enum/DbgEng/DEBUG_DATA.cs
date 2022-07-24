namespace ClrDebug.DbgEng
{
    //The members of this struct that re designed for use with ReadDebuggerData
    //are also defined in the KDDEBUGGER_DATA64 structure in wdbgexts.h which also
    //shows the type of each item. The values of theitems from KernBase on refer to the offset of that item
    //within the KDDEBUGGER_DATA64 structure
    public enum DEBUG_DATA : uint
    {
        // Indices for ReadProcessorSystemData.
        KPCR_OFFSET = 0,
        KPRCB_OFFSET = 1,
        KTHREAD_OFFSET = 2,
        BASE_TRANSLATION_VIRTUAL_OFFSET = 3,
        PROCESSOR_IDENTIFICATION = 4,
        PROCESSOR_SPEED = 5,

        // Indices for ReadDebuggerData interface

        /// <summary>
        /// Returns the base address of the kernel image. ULONG64 (<see langword="long"/>).
        /// </summary>
        KernBase = 24,

        /// <summary>
        /// Returns the address of the kernel function BreakpointWithStatusInstruction. ULONG64 (<see langword="long"/>).
        /// </summary>
        BreakpointWithStatusAddr = 32,

        /// <summary>
        /// Returns the address of saved context record during a bugcheck. It is only valid after a bugcheck. ULONG64 (<see langword="long"/>).
        /// </summary>
        SavedContextAddr = 40,

        /// <summary>
        /// Returns the address of the kernel function KiCallUserMode. ULONG64 (<see langword="long"/>).
        /// </summary>
        KiCallUserModeAddr = 56,

        /// <summary>
        /// Returns the kernel variable KeUserCallbackDispatcher. ULONG64 (<see langword="long"/>).
        /// </summary>
        KeUserCallbackDispatcherAddr = 64,

        /// <summary>
        /// Returns the address of the kernel variable PsLoadedModuleList. ULONG64 (<see langword="long"/>).
        /// </summary>
        PsLoadedModuleListAddr = 72,

        /// <summary>
        /// Returns the address of the kernel variable PsActiveProcessHead. ULONG64 (<see langword="long"/>).
        /// </summary>
        PsActiveProcessHeadAddr = 80,

        /// <summary>
        /// Returns the address of the kernel variable PspCidTable. ULONG64 (<see langword="long"/>).
        /// </summary>
        PspCidTableAddr = 88,

        /// <summary>
        /// Returns the address of the kernel variable ExpSystemResourcesList. ULONG64 (<see langword="long"/>).
        /// </summary>
        ExpSystemResourcesListAddr = 96,

        /// <summary>
        /// Returns the address of the kernel variable ExpPagedPoolDescriptor. ULONG64 (<see langword="long"/>).
        /// </summary>
        ExpPagedPoolDescriptorAddr = 104,

        /// <summary>
        /// Returns the address of the kernel variable ExpNumberOfPagedPools. ULONG64 (<see langword="long"/>).
        /// </summary>
        ExpNumberOfPagedPoolsAddr = 112,

        /// <summary>
        /// Returns the address of the kernel variable KeTimeIncrement. ULONG64 (<see langword="long"/>).
        /// </summary>
        KeTimeIncrementAddr = 120,

        /// <summary>
        /// Returns the address of the kernel variable KeBugCheckCallbackListHead. ULONG64 (<see langword="long"/>).
        /// </summary>
        KeBugCheckCallbackListHeadAddr = 128,

        /// <summary>
        /// Returns the kernel variable KiBugCheckData. ULONG64 (<see langword="long"/>).
        /// </summary>
        KiBugcheckDataAddr = 136,

        /// <summary>
        /// Returns the address of the kernel variable IopErrorLogListHead. ULONG64 (<see langword="long"/>).
        /// </summary>
        IopErrorLogListHeadAddr = 144,

        /// <summary>
        /// Returns the address of the kernel variable ObpRootDirectoryObject. ULONG64 (<see langword="long"/>).
        /// </summary>
        ObpRootDirectoryObjectAddr = 152,

        /// <summary>
        /// Returns the address of the kernel variable ObpTypeObjectType. ULONG64 (<see langword="long"/>).
        /// </summary>
        ObpTypeObjectTypeAddr = 160,

        /// <summary>
        /// Returns the address of the kernel variable MmSystemCacheStart. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSystemCacheStartAddr = 168,

        /// <summary>
        /// Returns the address of the kernel variable MmSystemCacheEnd. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSystemCacheEndAddr = 176,

        /// <summary>
        /// Returns the address of the kernel variable MmSystemCacheWs. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSystemCacheWsAddr = 184,

        /// <summary>
        /// Returns the address of the kernel variable MmPfnDatabase. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmPfnDatabaseAddr = 192,

        /// <summary>
        /// Returns the kernel variable MmSystemPtesStart. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSystemPtesStartAddr = 200,

        /// <summary>
        /// Returns the kernel variable MmSystemPtesEnd. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSystemPtesEndAddr = 208,

        /// <summary>
        /// Returns the address of the kernel variable MmSubsectionBase. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSubsectionBaseAddr = 216,

        /// <summary>
        /// Returns the address of the kernel variable MmNumberOfPagingFiles. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmNumberOfPagingFilesAddr = 224,

        /// <summary>
        /// Returns the address of the kernel variable MmLowestPhysicalPage. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmLowestPhysicalPageAddr = 232,

        /// <summary>
        /// Returns the address of the kernel variable MmHighestPhysicalPage. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmHighestPhysicalPageAddr = 240,

        /// <summary>
        /// Returns the address of the kernel variable MmNumberOfPhysicalPages. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmNumberOfPhysicalPagesAddr = 248,

        /// <summary>
        /// Returns the address of the kernel variable MmMaximumNonPagedPoolInBytes. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmMaximumNonPagedPoolInBytesAddr = 256,

        /// <summary>
        /// Returns the address of the kernel variable MmNonPagedSystemStart. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmNonPagedSystemStartAddr = 264,

        /// <summary>
        /// Returns the address of the kernel variable MmNonPagedPoolStart. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmNonPagedPoolStartAddr = 272,

        /// <summary>
        /// Returns the address of the kernel variable MmNonPagedPoolEnd. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmNonPagedPoolEndAddr = 280,

        /// <summary>
        /// Returns the address of the kernel variable MmPagedPoolStart. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmPagedPoolStartAddr = 288,

        /// <summary>
        /// Returns the address of the kernel variable MmPagedPoolEnd. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmPagedPoolEndAddr = 296,

        /// <summary>
        /// Returns the address of the kernel variable MmPagedPoolInfo. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmPagedPoolInformationAddr = 304,

        /// <summary>
        /// Returns the page size. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmPageSize = 312,

        /// <summary>
        /// Returns the address of the kernel variable MmSizeOfPagedPoolInBytes. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSizeOfPagedPoolInBytesAddr = 320,

        /// <summary>
        /// Returns the address of the kernel variable MmTotalCommitLimit. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmTotalCommitLimitAddr = 328,

        /// <summary>
        /// Returns the address of the kernel variable MmTotalCommittedPages. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmTotalCommittedPagesAddr = 336,

        /// <summary>
        /// Returns the address of the kernel variable MmSharedCommit. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSharedCommitAddr = 344,

        /// <summary>
        /// Returns the address of the kernel variable MmDriverCommit. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmDriverCommitAddr = 352,

        /// <summary>
        /// Returns the address of the kernel variable MmProcessCommit. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmProcessCommitAddr = 360,

        /// <summary>
        /// Returns the address of the kernel variable MmPagedPoolCommit. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmPagedPoolCommitAddr = 368,

        /// <summary>
        /// Returns the address of the kernel variable MmExtendedCommit. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmExtendedCommitAddr = 376,

        /// <summary>
        /// Returns the address of the kernel variable MmZeroedPageListHead. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmZeroedPageListHeadAddr = 384,

        /// <summary>
        /// Returns the address of the kernel variable MmFreePageListHead. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmFreePageListHeadAddr = 392,

        /// <summary>
        /// Returns the address of the kernel variable MmStandbyPageListHead. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmStandbyPageListHeadAddr = 400,

        /// <summary>
        /// Returns the address of the kernel variable MmModifiedPageListHead. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmModifiedPageListHeadAddr = 408,

        /// <summary>
        /// Returns the address of the kernel variable MmModifiedNoWritePageListHead. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmModifiedNoWritePageListHeadAddr = 416,

        /// <summary>
        /// Returns the address of the kernel variable MmAvailablePages. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmAvailablePagesAddr = 424,

        /// <summary>
        /// Returns the address of the kernel variable MmResidentAvailablePages. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmResidentAvailablePagesAddr = 432,

        /// <summary>
        /// Returns the address of the kernel variable PoolTrackTable. ULONG64 (<see langword="long"/>).
        /// </summary>
        PoolTrackTableAddr = 440,

        /// <summary>
        /// Returns the address of the kernel variable NonPagedPoolDescriptor. ULONG64 (<see langword="long"/>).
        /// </summary>
        NonPagedPoolDescriptorAddr = 448,

        /// <summary>
        /// Returns the address of the kernel variable MmHighestUserAddress. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmHighestUserAddressAddr = 456,

        /// <summary>
        /// Returns the address of the kernel variable MmSystemRangeStart. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSystemRangeStartAddr = 464,

        /// <summary>
        /// Returns the address of the kernel variable MmUserProbeAddress. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmUserProbeAddressAddr = 472,

        /// <summary>
        /// Returns the kernel variable KdPrintDefaultCircularBuffer. ULONG64 (<see langword="long"/>).
        /// </summary>
        KdPrintCircularBufferAddr = 480,

        /// <summary>
        /// Returns the address of the end of the array KdPrintDefaultCircularBuffer ULONG64 (<see langword="long"/>).
        /// </summary>
        KdPrintCircularBufferEndAddr = 488,

        /// <summary>
        /// Returns the address of the kernel variable KdPrintWritePointer. ULONG64 (<see langword="long"/>).
        /// </summary>
        KdPrintWritePointerAddr = 496,

        /// <summary>
        /// Returns the address of the kernel variable KdPrintRolloverCount. ULONG64 (<see langword="long"/>).
        /// </summary>
        KdPrintRolloverCountAddr = 504,

        /// <summary>
        /// Returns the address of the kernel variable MmLoadedUserImageList. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmLoadedUserImageListAddr = 512,

        /// <summary>
        /// Returns the address of the kernel variable NtBuildLab. ULONG64 (<see langword="long"/>).
        /// </summary>
        NtBuildLabAddr = 520,

        /// <summary>
        /// (Itanium only) Returns the address of the kernel function KiNormalSystemCall. ULONG64 (<see langword="long"/>).
        /// </summary>
        KiNormalSystemCall = 528,

        /// <summary>
        /// Returns the kernel variable KiProcessorBlock. ULONG64 (<see langword="long"/>).
        /// </summary>
        KiProcessorBlockAddr = 536,

        /// <summary>
        /// Returns the address of the kernel variable MmUnloadedDrivers. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmUnloadedDriversAddr = 544,

        /// <summary>
        /// Returns the address of the kernel variable MmLastUnloadedDriver. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmLastUnloadedDriverAddr = 552,

        /// <summary>
        /// Returns the address of the kernel variable VerifierTriageActionTaken. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmTriageActionTakenAddr = 560,

        /// <summary>
        /// Returns the address of the kernel variable MmSpecialPoolTag. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSpecialPoolTagAddr = 568,

        /// <summary>
        /// Returns the address of the kernel variable KernelVerifier. ULONG64 (<see langword="long"/>).
        /// </summary>
        KernelVerifierAddr = 576,

        /// <summary>
        /// Returns the address of the kernel variable MmVerifierData. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmVerifierDataAddr = 584,

        /// <summary>
        /// Returns the address of the kernel variable MmAllocatedNonPagedPool. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmAllocatedNonPagedPoolAddr = 592,

        /// <summary>
        /// Returns the address of the kernel variable MmPeakCommitment. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmPeakCommitmentAddr = 600,

        /// <summary>
        /// Returns the address of the kernel variable MmTotalCommitLimitMaximum. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmTotalCommitLimitMaximumAddr = 608,

        /// <summary>
        /// Returns the address of the kernel variable CmNtCSDVersion. ULONG64 (<see langword="long"/>).
        /// </summary>
        CmNtCSDVersionAddr = 616,

        /// <summary>
        /// Returns the address of the kernel variable MmPhysicalMemoryBlock. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmPhysicalMemoryBlockAddr = 624,

        /// <summary>
        /// Returns the address of the kernel variable MmSessionBase. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSessionBase = 632,

        /// <summary>
        /// Returns the address of the kernel variable MmSessionSize. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSessionSize = 640,

        /// <summary>
        /// (Itanium only) Returns the address of the kernel variable MmSystemParentTablePage. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmSystemParentTablePage = 648,

        /// <summary>
        /// Returns the address of the kernel variable MmVirtualTranslationBase. ULONG64 (<see langword="long"/>).
        /// </summary>
        MmVirtualTranslationBase = 656,

        /// <summary>
        /// Returns the offset of the NextProcessor field in the KTHREAD structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetKThreadNextProcessor = 664,

        /// <summary>
        /// Returns the offset of the Teb field in the KTHREAD structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetKThreadTeb = 666,

        /// <summary>
        /// Returns the offset of the KernelStack field in the KTHREAD structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetKThreadKernelStack = 668,

        /// <summary>
        /// Returns the offset of the InitialStack field in the KTHREAD structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetKThreadInitialStack = 670,

        /// <summary>
        /// Returns the offset of the ApcState.Process field in the KTHREAD structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetKThreadApcProcess = 672,

        /// <summary>
        /// Returns the offset of the State field in the KTHREAD structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetKThreadState = 674,

        /// <summary>
        /// (Itanium only) Returns the offset of the InitialBStore field in the KTHREAD structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetKThreadBStore = 676,

        /// <summary>
        /// (Itanium only) Returns the offset of the BStoreLimit field in the KTHREAD structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetKThreadBStoreLimit = 678,

        /// <summary>
        /// Returns the size of the EPROCESS structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        SizeEProcess = 680,

        /// <summary>
        /// Returns the offset of the Peb field in the EPROCESS structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetEprocessPeb = 682,

        /// <summary>
        /// Returns the offset of the InheritedFromUniqueProcessId field in the EPROCESS structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetEprocessParentCID = 684,

        /// <summary>
        /// Returns the offset of the DirectoryTableBase field in the EPROCESS structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetEprocessDirectoryTableBase = 686,

        /// <summary>
        /// Returns the size of the KPRCB structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        SizePrcb = 688,

        /// <summary>
        /// Returns the offset of the DpcRoutineActive field in the KPRCB structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetPrcbDpcRoutine = 690,

        /// <summary>
        /// Returns the offset of the CurrentThread field in the KPRCB structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetPrcbCurrentThread = 692,

        /// <summary>
        /// Returns the offset of the MHz field in the KPRCB structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetPrcbMhz = 694,

        /// <summary>
        /// For Itanium processors: Returns the offset of the ProcessorModel field in the KPRCB structure. USHORT (<see langword="ushort"/>).<para/>
        /// For all other processors: Returns the offset of the CpuType field in the KPRCB structure.
        /// </summary>
        OffsetPrcbCpuType = 696,

        /// <summary>
        /// For Itanium processors: Returns the offset of the ProcessorVendorString field in the KPRCB structure. USHORT (<see langword="ushort"/>).<para/>
        /// For all other processors: Returns the offset of the VendorString field in the KPRCB structure.
        /// </summary>
        OffsetPrcbVendorString = 698,

        /// <summary>
        /// Returns the offset of the ProcessorState.ContextFrame field in the KPRCB structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetPrcbProcessorState = 700,

        /// <summary>
        /// Returns the offset of the Number field in the KPRCB structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        OffsetPrcbNumber = 702,

        /// <summary>
        /// Returns the size of the ETHREAD structure. USHORT (<see langword="ushort"/>).
        /// </summary>
        SizeEThread = 704,

        /// <summary>
        /// Returns the address of the kernel variable KdPrintCircularBuffer. ULONG64 (<see langword="long"/>).
        /// </summary>
        KdPrintCircularBufferPtrAddr = 712,

        /// <summary>
        /// Returns the address of the kernel variable KdPrintBufferSize. ULONG64 (<see langword="long"/>).
        /// </summary>
        KdPrintBufferSizeAddr = 720,

        MmBadPagesDetected = 800,
        EtwpDebuggerData = 816,

        /// <summary>
        /// Returns TRUE when the target system has PAE enabled. Returns FALSE otherwise. BOOLEAN (<see langword="byte"/>).
        /// </summary>
        PaeEnabled = 100000,

        /// <summary>
        /// Returns the address in the target of the shared user-mode structure, KUSER_SHARED_DATA. ULONG64 (<see langword="long"/>).<para/>
        /// The KUSER_SHARED_DATA structure is defined in ntddk.h (in the Windows Driver Kit) and ntexapi.h (in the Windows SDK).<para/>
        /// Some of the information contained in this structure is displayed by the debugger extension !kuser.
        /// </summary>
        SharedUserData = 100008,

        /// <summary>
        /// Returns the value of the NtProductType field in the shared user-mode page. ULONG (<see cref="VER_NT"/>).<para/>
        /// This value should be interpreted the same way as the wProductType field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.
        /// </summary>
        ProductType = 100016,

        /// <summary>
        /// Returns the value of the SuiteMask field in the shared user-mode page. ULONG (<see cref="VER_SUITE"/>).<para/>
        /// This value should be interpreted the same way as the wSuiteMask field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.
        /// </summary>
        SuiteMask = 100024,

        /// <summary>
        /// Returns the status of the writer of the dump file. This value is operating system and dump file type specific. ULONG (<see langword="int"/>).
        /// </summary>
        DumpWriterStatus = 100032,

        DumpFormatVersion = 100040,
        DumpWriterVersion = 100048,
        DumpPowerState = 100056,
        DumpMmStorage = 100064,
        DumpAttributes = 100072,
    }
}
