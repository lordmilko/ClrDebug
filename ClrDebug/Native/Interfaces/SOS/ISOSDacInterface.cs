using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    public delegate void MODULEMAPTRAVERSE(
        int index,
        CLRDATA_ADDRESS methodTable,
        IntPtr token);

    public delegate void DUMPEHINFO(
        int clauseIndex,
        int totalClauses,
        ref DACEHInfo pEHInfo,
        IntPtr token);

    public delegate void VISITHEAP(
        CLRDATA_ADDRESS blockData,
        long blockSize,
        bool blockIsCurrentBlock);

    public delegate void VISITRCWFORCLEANUP(
        CLRDATA_ADDRESS RCW,
        CLRDATA_ADDRESS Context,
        CLRDATA_ADDRESS Thread,
        bool bIsFreeThreaded,
        IntPtr token);

    /// <summary>
    /// Provides helper methods to access data from SOS.
    /// </summary>
    /// <remarks>
    /// This interface lives inside the runtime and is not exposed through any headers or library files. However, it's
    /// a COM interface that derives from IUnknown with GUID 436f00f2-b42a-4b9f-870c-e73db66ae930 that can be obtained
    /// through the usual COM mechanisms.
    /// </remarks>
    [Guid("436f00f2-b42a-4b9f-870c-e73db66ae930")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface
    {
        [PreserveSig]
        HRESULT GetThreadStoreData(
            [Out] out DacpThreadStoreData data);

        [PreserveSig]
        HRESULT GetAppDomainStoreData(
            [Out] out DacpAppDomainStoreData data);

        /// <summary>
        /// Gets the addresses of all AppDomains present in a process, excluding the System and Shared AppDomains.
        /// </summary>
        /// <param name="count">The size of the values array. The number of active AppDomains can be retrieved from <see cref="GetAppDomainStoreData"/>.</param>
        /// <param name="values">The array to store the addresses of returned AppDomains.</param>
        /// <param name="pNeeded">The number of items that were inserted into <paramref name="values"/>.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetAppDomainList(
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] CLRDATA_ADDRESS[] values,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetAppDomainData(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpAppDomainData data);

        [PreserveSig]
        HRESULT GetAppDomainName(
            [In] CLRDATA_ADDRESS addr,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetDomainFromContext(
            [In] CLRDATA_ADDRESS context,
            [Out] out CLRDATA_ADDRESS domain);

        [PreserveSig]
        HRESULT GetAssemblyList(
            [In] CLRDATA_ADDRESS appDomain,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CLRDATA_ADDRESS[] values,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetAssemblyData(
            [In] CLRDATA_ADDRESS baseDomainPtr,
            [In] CLRDATA_ADDRESS assembly,
            [Out] out DacpAssemblyData data);

        [PreserveSig]
        HRESULT GetAssemblyName(
            [In] CLRDATA_ADDRESS assembly,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetModule(
            [In] CLRDATA_ADDRESS addr,
            [Out] out IXCLRDataModule mod);

        /// <summary>
        /// Fetches the data corresponding to the module loaded at a given address.
        /// </summary>
        /// <param name="moduleAddr">[in] The address of the module to retrieve information for.</param>
        /// <param name="data">[out] The <see cref="DacpModuleData"/> to hold the information of the loaded module.</param>
        /// <remarks>
        /// The provided method is part of the ISOSDacInterface interface and corresponds to the 14th slot of the virtual method
        /// table.
        /// </remarks>
        [PreserveSig]
        HRESULT GetModuleData(
            [In] CLRDATA_ADDRESS moduleAddr,
            [Out] out DacpModuleData data);

        [PreserveSig]
        HRESULT TraverseModuleMap(
            [In] ModuleMapType mmt,
            [In] CLRDATA_ADDRESS moduleAddr,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] MODULEMAPTRAVERSE pCallback,
            [In] IntPtr token);

        [PreserveSig]
        HRESULT GetAssemblyModuleList(
            [In] CLRDATA_ADDRESS assembly,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CLRDATA_ADDRESS[] modules,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetILForModule(
            [In] CLRDATA_ADDRESS moduleAddr,
            [In] int rva,
            [Out] out CLRDATA_ADDRESS il);

        [PreserveSig]
        HRESULT GetThreadData(
            [In] CLRDATA_ADDRESS thread,
            [Out] out DacpThreadData data);

        [PreserveSig]
        HRESULT GetThreadFromThinlockID(
            [In] int thinLockId,
            [Out] out CLRDATA_ADDRESS pThread);

        [PreserveSig]
        HRESULT GetStackLimits(
            [In] CLRDATA_ADDRESS threadPtr,
            [Out] out CLRDATA_ADDRESS lower,
            [Out] out CLRDATA_ADDRESS upper,
            [Out] out CLRDATA_ADDRESS fp);

        /// <summary>
        /// Gets the data for the given MethodDesc pointer.
        /// </summary>
        /// <param name="methodDesc">[in] The address of the MethodDesc.</param>
        /// <param name="ip">[in] The IP address of the method.</param>
        /// <param name="data">[out] The data associated with the MethodDesc as returned from the internal APIs.</param>
        /// <param name="cRevertedRejitVersions">[out] The number of reverted rejit versions.</param>
        /// <param name="rgRevertedRejitData">[out] The data associated with the reverted rejit versions as returned from the internal APIs.</param>
        /// <param name="pcNeededRevertedRejitData">[out] The number of bytes required to store the data associated with the reverted ReJit versions.</param>
        /// <remarks>
        /// The provided method is part of the ISOSDacInterface interface and corresponds to the 21st slot of the virtual method
        /// table. To be able to use them, Markdig.Syntax.Inlines.CodeInline must be defined as a 64-bit unsigned integer.
        /// </remarks>
        [PreserveSig]
        HRESULT GetMethodDescData(
            [In] CLRDATA_ADDRESS methodDesc,
            [In] CLRDATA_ADDRESS ip,
            [Out] out DacpMethodDescData data,
            [In] int cRevertedRejitVersions,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DacpReJitData[] rgRevertedRejitData,
            [Out] out int pcNeededRevertedRejitData);

        /// <summary>
        /// Retrieves the pointer of the MethodDesc corresponding the method containing the given native instruction address.
        /// </summary>
        /// <param name="ip">[in] An address within the method at run time.</param>
        /// <param name="ppMD">[out] The address of the MethodDesc for the particular method.</param>
        /// <remarks>
        /// The provided method is part of the <see cref="ISOSDacInterface"/> and corresponds to the 22nd slot of the virtual
        /// method table.
        /// </remarks>
        [PreserveSig]
        HRESULT GetMethodDescPtrFromIP(
            [In] CLRDATA_ADDRESS ip,
            [Out] out CLRDATA_ADDRESS ppMD);

        [PreserveSig]
        HRESULT GetMethodDescName(
            [In] CLRDATA_ADDRESS methodDesc,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetMethodDescPtrFromFrame(
            [In] CLRDATA_ADDRESS frameAddr,
            [Out] out CLRDATA_ADDRESS ppMD);

        [PreserveSig]
        HRESULT GetMethodDescFromToken(
            [In] CLRDATA_ADDRESS moduleAddr,
            [In] mdToken token,
            [Out] out CLRDATA_ADDRESS methodDesc);

        [PreserveSig]
        HRESULT GetMethodDescTransparencyData(
            [In] CLRDATA_ADDRESS methodDesc,
            [Out] out DacpMethodDescTransparencyData data);

        [PreserveSig]
        HRESULT GetCodeHeaderData(
            [In] CLRDATA_ADDRESS ip,
            [Out] out DacpCodeHeaderData data);

        [PreserveSig]
        HRESULT GetJitManagerList(
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DacpJitManagerInfo[] managers,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetJitHelperFunctionName(
            [In] CLRDATA_ADDRESS ip,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetJumpThunkTarget(
            [In] IntPtr ctx,
            [Out] out CLRDATA_ADDRESS targetIP,
            [Out] out CLRDATA_ADDRESS targetMD);

        [PreserveSig]
        HRESULT GetThreadpoolData(
            [Out] out DacpThreadpoolData data);

        [PreserveSig]
        HRESULT GetWorkRequestData(
            [In] CLRDATA_ADDRESS addrWorkRequest,
            [Out] out DacpWorkRequestData data);

        [PreserveSig]
        HRESULT GetHillClimbingLogEntry(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpHillClimbingLogEntry data);

        [PreserveSig]
        HRESULT GetObjectData(
            [In] CLRDATA_ADDRESS objAddr,
            [Out] out DacpObjectData data);

        [PreserveSig]
        HRESULT GetObjectStringData(
            [In] CLRDATA_ADDRESS obj,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder stringData,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetObjectClassName(
            [In] CLRDATA_ADDRESS obj,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder className,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetMethodTableName(
            [In] CLRDATA_ADDRESS mt,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder mtName,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetMethodTableData(
            [In] CLRDATA_ADDRESS mt,
            [Out] out DacpMethodTableData data);

        [PreserveSig]
        HRESULT GetMethodTableSlot(
            [In] CLRDATA_ADDRESS mt,
            [In] int slot,
            [Out] out CLRDATA_ADDRESS value);

        [PreserveSig]
        HRESULT GetMethodTableFieldData(
            [In] CLRDATA_ADDRESS mt,
            [Out] out DacpMethodTableFieldData data);

        [PreserveSig]
        HRESULT GetMethodTableTransparencyData(
            [In] CLRDATA_ADDRESS mt,
            [Out] out DacpMethodTableTransparencyData data);

        [PreserveSig]
        HRESULT GetMethodTableForEEClass(
            [In] CLRDATA_ADDRESS eeClass,
            [Out] out CLRDATA_ADDRESS value);

        [PreserveSig]
        HRESULT GetFieldDescData(
            [In] CLRDATA_ADDRESS fieldDesc,
            [Out] out DacpFieldDescData data);

        [PreserveSig]
        HRESULT GetFrameName(
            [In] CLRDATA_ADDRESS vtable,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder frameName,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetPEFileBase(
            [In] CLRDATA_ADDRESS addr,
            [Out] out CLRDATA_ADDRESS _base);

        [PreserveSig]
        HRESULT GetPEFileName(
            [In] CLRDATA_ADDRESS addr,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder fileName,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetGCHeapData(
            [Out] out DacpGcHeapData data);

        [PreserveSig]
        HRESULT GetGCHeapList(
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] CLRDATA_ADDRESS[] heaps,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetGCHeapDetails(
            [In] CLRDATA_ADDRESS heap,
            [Out] out DacpGcHeapDetails details);

        [PreserveSig]
        HRESULT GetGCHeapStaticData(
            [Out] out DacpGcHeapDetails data);

        [PreserveSig]
        HRESULT GetHeapSegmentData(
            [In] CLRDATA_ADDRESS seg,
            [Out] out DacpHeapSegmentData data);

        [PreserveSig]
        HRESULT GetOOMData(
            [In] CLRDATA_ADDRESS oomAddr,
            [Out] out DacpOomData data);

        [PreserveSig]
        HRESULT GetOOMStaticData(
            [Out] out DacpOomData data);

        [PreserveSig]
        HRESULT GetHeapAnalyzeData(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpGcHeapAnalyzeData data);

        [PreserveSig]
        HRESULT GetHeapAnalyzeStaticData(
            [Out] out DacpGcHeapAnalyzeData data);

        [PreserveSig]
        HRESULT GetDomainLocalModuleData(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpDomainLocalModuleData data);

        [PreserveSig]
        HRESULT GetDomainLocalModuleDataFromAppDomain(
            [In] CLRDATA_ADDRESS appDomainAddr,
            [In] int moduleID,
            [Out] out DacpDomainLocalModuleData data);

        [PreserveSig]
        HRESULT GetDomainLocalModuleDataFromModule(
            [In] CLRDATA_ADDRESS moduleAddr,
            [Out] out DacpDomainLocalModuleData data);

        [PreserveSig]
        HRESULT GetThreadLocalModuleData(
            [In] CLRDATA_ADDRESS thread,
            [In] int index,
            [Out] out DacpThreadLocalModuleData data);

        [PreserveSig]
        HRESULT GetSyncBlockData(
            [In] int number,
            [Out] out DacpSyncBlockData data);

        [PreserveSig]
        HRESULT GetSyncBlockCleanupData(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpSyncBlockCleanupData data);

        [PreserveSig]
        HRESULT GetHandleEnum(
            [Out] out ISOSHandleEnum ppHandleEnum);

        [PreserveSig]
        HRESULT GetHandleEnumForTypes(
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] types,
            [In] int count,
            [Out] out ISOSHandleEnum ppHandleEnum);

        [PreserveSig]
        HRESULT GetHandleEnumForGC(
            [In] int gen,
            [Out] out ISOSHandleEnum ppHandleEnum);

        [PreserveSig]
        HRESULT TraverseEHInfo(
            [In] CLRDATA_ADDRESS ip,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] DUMPEHINFO pCallback,
            [In] IntPtr token);

        [PreserveSig]
        HRESULT GetNestedExceptionData(
            [In] CLRDATA_ADDRESS exception,
            [Out] out CLRDATA_ADDRESS exceptionObject,
            [Out] out CLRDATA_ADDRESS nextNestedException);

        [PreserveSig]
        HRESULT GetStressLogAddress(
            [Out] out CLRDATA_ADDRESS stressLog);

        [PreserveSig]
        HRESULT TraverseLoaderHeap(
            [In] CLRDATA_ADDRESS loaderHeapAddr,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITHEAP pCallback);

        [PreserveSig]
        HRESULT GetCodeHeapList(
            [In] CLRDATA_ADDRESS jitManager,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DacpJitCodeHeapInfo[] codeHeaps,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT TraverseVirtCallStubHeap(
            [In] CLRDATA_ADDRESS pAppDomain,
            [In] VCSHeapType heaptype,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITHEAP pCallback);

        [PreserveSig]
        HRESULT GetUsefulGlobals(
            [Out] out DacpUsefulGlobalsData data);

        [PreserveSig]
        HRESULT GetClrWatsonBuckets(
            [In] CLRDATA_ADDRESS thread,
            [In] IntPtr pGenericModeBlock);

        [PreserveSig]
        HRESULT GetTLSIndex(
            [Out] out int pIndex);

        [PreserveSig]
        HRESULT GetDacModuleHandle(
            [Out] out IntPtr phModule);

        [PreserveSig]
        HRESULT GetRCWData(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpRCWData data);

        [PreserveSig]
        HRESULT GetRCWInterfaces(
            [In] CLRDATA_ADDRESS rcw,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DacpCOMInterfacePointerData[] interfaces,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetCCWData(
            [In] CLRDATA_ADDRESS ccw,
            [Out] out DacpCCWData data);

        [PreserveSig]
        HRESULT GetCCWInterfaces(
            [In] CLRDATA_ADDRESS ccw,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DacpCOMInterfacePointerData[] interfaces,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT TraverseRCWCleanupList(
            [In] CLRDATA_ADDRESS cleanupListPtr,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITRCWFORCLEANUP pCallback,
            [In] IntPtr token);

        [PreserveSig]
        HRESULT GetStackReferences(
            [In] int osThreadID,
            [Out] out ISOSStackRefEnum ppEnum);

        [PreserveSig]
        HRESULT GetRegisterName(
            [In] int regName,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder buffer,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetThreadAllocData(
            [In] CLRDATA_ADDRESS thread,
            [Out] out DacpAllocData data);

        [PreserveSig]
        HRESULT GetHeapAllocData(
            [In] int count,
            [Out] out DacpGenerationAllocData data,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetFailedAssemblyList(
            [In] CLRDATA_ADDRESS appDomain,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CLRDATA_ADDRESS[] values,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetPrivateBinPaths(
            [In] CLRDATA_ADDRESS appDomain,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder paths,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetAssemblyLocation(
            [In] CLRDATA_ADDRESS assembly,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder location,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetAppDomainConfigFile(
            [In] CLRDATA_ADDRESS appDomain,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder configFile,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetApplicationBase(
            [In] CLRDATA_ADDRESS appDomain,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder _base,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetFailedAssemblyData(
            [In] CLRDATA_ADDRESS assembly,
            [Out] out int pContext,
            [Out] out HRESULT pResult);

        [PreserveSig]
        HRESULT GetFailedAssemblyLocation(
            [In] CLRDATA_ADDRESS assesmbly,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder location,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetFailedAssemblyDisplayName(
            [In] CLRDATA_ADDRESS assembly,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            [Out] out int pNeeded);
    }
}
