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
            out DacpThreadStoreData data);

        [PreserveSig]
        HRESULT GetAppDomainStoreData(
            out DacpAppDomainStoreData data);

        [PreserveSig]
        HRESULT GetAppDomainList(
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] values,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetAppDomainData(
            CLRDATA_ADDRESS addr,
            out DacpAppDomainData data);

        [PreserveSig]
        HRESULT GetAppDomainName(
            CLRDATA_ADDRESS addr,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetDomainFromContext(
            CLRDATA_ADDRESS context,
            out CLRDATA_ADDRESS domain);

        [PreserveSig]
        HRESULT GetAssemblyList(
            CLRDATA_ADDRESS appDomain,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] values,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetAssemblyData(
            CLRDATA_ADDRESS baseDomainPtr,
            CLRDATA_ADDRESS assembly,
            out DacpAssemblyData data);

        [PreserveSig]
        HRESULT GetAssemblyName(
            CLRDATA_ADDRESS assembly,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetModule(
            CLRDATA_ADDRESS addr,
            out IXCLRDataModule mod);

        [PreserveSig]
        HRESULT GetModuleData(
            CLRDATA_ADDRESS moduleAddr,
            out DacpModuleData data);

        [PreserveSig]
        HRESULT TraverseModuleMap(
            ModuleMapType mmt,
            CLRDATA_ADDRESS moduleAddr,
            [MarshalAs(UnmanagedType.FunctionPtr)] MODULEMAPTRAVERSE pCallback,
            IntPtr token);

        [PreserveSig]
        HRESULT GetAssemblyModuleList(
            CLRDATA_ADDRESS assembly,
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] modules,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetILForModule(
            CLRDATA_ADDRESS moduleAddr,
            int rva,
            out CLRDATA_ADDRESS il);

        [PreserveSig]
        HRESULT GetThreadData(
            CLRDATA_ADDRESS thread,
            out DacpThreadData data);

        [PreserveSig]
        HRESULT GetThreadFromThinlockID(
            int thinLockId,
            out CLRDATA_ADDRESS pThread);

        [PreserveSig]
        HRESULT GetStackLimits(
            CLRDATA_ADDRESS threadPtr,
            out CLRDATA_ADDRESS lower,
            out CLRDATA_ADDRESS upper,
            out CLRDATA_ADDRESS fp);

        [PreserveSig]
        HRESULT GetMethodDescData(
            CLRDATA_ADDRESS methodDesc,
            CLRDATA_ADDRESS ip,
            out DacpMethodDescData data,
            int cRevertedRejitVersions,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpReJitData[] rgRevertedRejitData,
            out int pcNeededRevertedRejitData);

        [PreserveSig]
        HRESULT GetMethodDescPtrFromIP(
            CLRDATA_ADDRESS ip,
            out CLRDATA_ADDRESS ppMD);

        [PreserveSig]
        HRESULT GetMethodDescName(
            CLRDATA_ADDRESS methodDesc,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetMethodDescPtrFromFrame(
            CLRDATA_ADDRESS frameAddr,
            out CLRDATA_ADDRESS ppMD);

        [PreserveSig]
        HRESULT GetMethodDescFromToken(
            CLRDATA_ADDRESS moduleAddr,
            mdToken token,
            out CLRDATA_ADDRESS methodDesc);

        [PreserveSig]
        HRESULT GetMethodDescTransparencyData(
            CLRDATA_ADDRESS methodDesc,
            out DacpMethodDescTransparencyData data);

        [PreserveSig]
        HRESULT GetCodeHeaderData(
            CLRDATA_ADDRESS ip,
            out DacpCodeHeaderData data);

        [PreserveSig]
        HRESULT GetJitManagerList(
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpJitManagerInfo[] managers,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetJitHelperFunctionName(
            CLRDATA_ADDRESS ip,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetJumpThunkTarget(
            IntPtr ctx,
            out CLRDATA_ADDRESS targetIP,
            out CLRDATA_ADDRESS targetMD);

        [PreserveSig]
        HRESULT GetThreadpoolData(
            out DacpThreadpoolData data);

        [PreserveSig]
        HRESULT GetWorkRequestData(
            CLRDATA_ADDRESS addrWorkRequest,
            out DacpWorkRequestData data);

        [PreserveSig]
        HRESULT GetHillClimbingLogEntry(
            CLRDATA_ADDRESS addr,
            out DacpHillClimbingLogEntry data);

        [PreserveSig]
        HRESULT GetObjectData(
            CLRDATA_ADDRESS objAddr,
            out DacpObjectData data);

        [PreserveSig]
        HRESULT GetObjectStringData(
            CLRDATA_ADDRESS obj,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder stringData,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetObjectClassName(
            CLRDATA_ADDRESS obj,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder className,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetMethodTableName(
            CLRDATA_ADDRESS mt,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder mtName,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetMethodTableData(
            CLRDATA_ADDRESS mt,
            out DacpMethodTableData data);

        [PreserveSig]
        HRESULT GetMethodTableSlot(
            CLRDATA_ADDRESS mt,
            int slot,
            out CLRDATA_ADDRESS value);

        [PreserveSig]
        HRESULT GetMethodTableFieldData(
            CLRDATA_ADDRESS mt,
            out DacpMethodTableFieldData data);

        [PreserveSig]
        HRESULT GetMethodTableTransparencyData(
            CLRDATA_ADDRESS mt,
            out DacpMethodTableTransparencyData data);

        [PreserveSig]
        HRESULT GetMethodTableForEEClass(
            CLRDATA_ADDRESS eeClass,
            out CLRDATA_ADDRESS value);

        [PreserveSig]
        HRESULT GetFieldDescData(
            CLRDATA_ADDRESS fieldDesc,
            out DacpFieldDescData data);

        [PreserveSig]
        HRESULT GetFrameName(
            CLRDATA_ADDRESS vtable,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder frameName,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetPEFileBase(
            CLRDATA_ADDRESS addr,
            out CLRDATA_ADDRESS _base);

        [PreserveSig]
        HRESULT GetPEFileName(
            CLRDATA_ADDRESS addr,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder fileName,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetGCHeapData(
            out DacpGcHeapData data);

        [PreserveSig]
        HRESULT GetGCHeapList(
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] heaps,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetGCHeapDetails(
            CLRDATA_ADDRESS heap,
            out DacpGcHeapDetails details);

        [PreserveSig]
        HRESULT GetGCHeapStaticData(
            out DacpGcHeapDetails data);

        [PreserveSig]
        HRESULT GetHeapSegmentData(
            CLRDATA_ADDRESS seg,
            out DacpHeapSegmentData data);

        [PreserveSig]
        HRESULT GetOOMData(
            CLRDATA_ADDRESS oomAddr,
            out DacpOomData data);

        [PreserveSig]
        HRESULT GetOOMStaticData(
            out DacpOomData data);

        [PreserveSig]
        HRESULT GetHeapAnalyzeData(
            CLRDATA_ADDRESS addr,
            out DacpGcHeapAnalyzeData data);

        [PreserveSig]
        HRESULT GetHeapAnalyzeStaticData(
            out DacpGcHeapAnalyzeData data);

        [PreserveSig]
        HRESULT GetDomainLocalModuleData(
            CLRDATA_ADDRESS addr,
            out DacpDomainLocalModuleData data);

        [PreserveSig]
        HRESULT GetDomainLocalModuleDataFromAppDomain(
            CLRDATA_ADDRESS appDomainAddr,
            int moduleID,
            out DacpDomainLocalModuleData data);

        [PreserveSig]
        HRESULT GetDomainLocalModuleDataFromModule(
            CLRDATA_ADDRESS moduleAddr,
            out DacpDomainLocalModuleData data);

        [PreserveSig]
        HRESULT GetThreadLocalModuleData(
            CLRDATA_ADDRESS thread,
            int index,
            out DacpThreadLocalModuleData data);

        [PreserveSig]
        HRESULT GetSyncBlockData(
            int number,
            out DacpSyncBlockData data);

        [PreserveSig]
        HRESULT GetSyncBlockCleanupData(
            CLRDATA_ADDRESS addr,
            out DacpSyncBlockCleanupData data);

        [PreserveSig]
        HRESULT GetHandleEnum(
            out ISOSHandleEnum ppHandleEnum);

        [PreserveSig]
        HRESULT GetHandleEnumForTypes(
            [In, MarshalAs(UnmanagedType.LPArray)] int[] types,
            int count,
            out ISOSHandleEnum ppHandleEnum);

        [PreserveSig]
        HRESULT GetHandleEnumForGC(
            int gen,
            out ISOSHandleEnum ppHandleEnum);

        [PreserveSig]
        HRESULT TraverseEHInfo(
            CLRDATA_ADDRESS ip,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] DUMPEHINFO pCallback,
            IntPtr token);

        [PreserveSig]
        HRESULT GetNestedExceptionData(
            CLRDATA_ADDRESS exception,
            out CLRDATA_ADDRESS exceptionObject,
            out CLRDATA_ADDRESS nextNestedException);

        [PreserveSig]
        HRESULT GetStressLogAddress(
            out CLRDATA_ADDRESS stressLog);

        [PreserveSig]
        HRESULT TraverseLoaderHeap(
            CLRDATA_ADDRESS loaderHeapAddr,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITHEAP pCallback);

        [PreserveSig]
        HRESULT GetCodeHeapList(
            CLRDATA_ADDRESS jitManager,
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpJitCodeHeapInfo[] codeHeaps,
            out int pNeeded);

        [PreserveSig]
        HRESULT TraverseVirtCallStubHeap(
            CLRDATA_ADDRESS pAppDomain,
            VCSHeapType heaptype,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITHEAP pCallback);

        [PreserveSig]
        HRESULT GetUsefulGlobals(
            out DacpUsefulGlobalsData data);

        [PreserveSig]
        HRESULT GetClrWatsonBuckets(
            CLRDATA_ADDRESS thread,
            IntPtr pGenericModeBlock);

        [PreserveSig]
        HRESULT GetTLSIndex(
            out int pIndex);

        [PreserveSig]
        HRESULT GetDacModuleHandle(
            out long phModule);

        [PreserveSig]
        HRESULT GetRCWData(
            CLRDATA_ADDRESS addr,
            out DacpRCWData data);

        [PreserveSig]
        HRESULT GetRCWInterfaces(
            CLRDATA_ADDRESS rcw,
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpCOMInterfacePointerData[] interfaces,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetCCWData(
            CLRDATA_ADDRESS ccw,
            out DacpCCWData data);

        [PreserveSig]
        HRESULT GetCCWInterfaces(
            CLRDATA_ADDRESS ccw,
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpCOMInterfacePointerData[] interfaces,
            out int pNeeded);

        [PreserveSig]
        HRESULT TraverseRCWCleanupList(
            CLRDATA_ADDRESS cleanupListPtr,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITRCWFORCLEANUP pCallback,
            IntPtr token);

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
            CLRDATA_ADDRESS thread,
            out DacpAllocData data);

        [PreserveSig]
        HRESULT GetHeapAllocData(
            int count,
            out DacpGenerationAllocData data,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetFailedAssemblyList(
            CLRDATA_ADDRESS appDomain,
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] values,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetPrivateBinPaths(
            CLRDATA_ADDRESS appDomain,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder paths,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetAssemblyLocation(
            CLRDATA_ADDRESS assembly,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder location,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetAppDomainConfigFile(
            CLRDATA_ADDRESS appDomain,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder configFile,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetApplicationBase(
            CLRDATA_ADDRESS appDomain,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder _base,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetFailedAssemblyData(
            CLRDATA_ADDRESS assembly,
            out int pContext,
            out HRESULT pResult);

        [PreserveSig]
        HRESULT GetFailedAssemblyLocation(
            CLRDATA_ADDRESS assesmbly,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder location,
            out int pNeeded);

        [PreserveSig]
        HRESULT GetFailedAssemblyDisplayName(
            CLRDATA_ADDRESS assembly,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            out int pNeeded);
    }
}
