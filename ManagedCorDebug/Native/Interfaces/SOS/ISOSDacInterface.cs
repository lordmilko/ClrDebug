using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public delegate void MODULEMAPTRAVERSE(int index, CLRDATA_ADDRESS methodTable, IntPtr token);
    public delegate void DUMPEHINFO(uint clauseIndex, uint totalClauses, ref DACEHInfo pEHInfo, IntPtr token);
    public delegate void VISITHEAP(CLRDATA_ADDRESS blockData, long blockSize, bool blockIsCurrentBlock);
    public delegate void VISITRCWFORCLEANUP(CLRDATA_ADDRESS RCW, CLRDATA_ADDRESS Context, CLRDATA_ADDRESS Thread, bool bIsFreeThreaded, IntPtr token);

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

        [PreserveSig]
        HRESULT GetAppDomainList(
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] values,
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
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] values,
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
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] modules,
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

        [PreserveSig]
        HRESULT GetMethodDescData(
            [In] CLRDATA_ADDRESS methodDesc,
            [In] CLRDATA_ADDRESS ip,
            [Out] out DacpMethodDescData data,
            [In] int cRevertedRejitVersions,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpReJitData[] rgRevertedRejitData,
            [Out] out int pcNeededRevertedRejitData);

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
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpJitManagerInfo[] managers,
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
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] heaps,
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
            [In, MarshalAs(UnmanagedType.LPArray)] int[] types,
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
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpJitCodeHeapInfo[] codeHeaps,
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
            [Out] IntPtr phModule);

        [PreserveSig]
        HRESULT GetRCWData(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpRCWData data);

        [PreserveSig]
        HRESULT GetRCWInterfaces(
            [In] CLRDATA_ADDRESS rcw,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpCOMInterfacePointerData[] interfaces,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetCCWData(
            [In] CLRDATA_ADDRESS ccw,
            [Out] out DacpCCWData data);

        [PreserveSig]
        HRESULT GetCCWInterfaces(
            [In] CLRDATA_ADDRESS ccw,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpCOMInterfacePointerData[] interfaces,
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
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] values,
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
