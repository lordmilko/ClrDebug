using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("3176A8ED-597B-4F54-A71F-83695C6A8C5E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSDacInterface13
    {
        [PreserveSig]
        HRESULT TraverseLoaderHeap(
            [In] CLRDATA_ADDRESS loaderHeapAddr,
            [In] LoaderHeapKind kind,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITHEAP pCallback);

        [PreserveSig]
        HRESULT GetDomainLoaderAllocator(
            [In] CLRDATA_ADDRESS domainAddress,
            [Out] out CLRDATA_ADDRESS pLoaderAllocator);

        [PreserveSig]
        HRESULT GetLoaderAllocatorHeapNames(
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 0)] string[] ppNames,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetLoaderAllocatorHeaps(
            [In] CLRDATA_ADDRESS loaderAllocator,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CLRDATA_ADDRESS[] pLoaderHeaps,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] LoaderHeapKind[] pKinds,
            [Out] int pNeeded);

        [PreserveSig]
        HRESULT GetHandleTableMemoryRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISOSMemoryEnum ppEnum);

        [PreserveSig]
        HRESULT GetGCBookkeepingMemoryRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISOSMemoryEnum ppEnum);

        [PreserveSig]
        HRESULT GetGCFreeRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISOSMemoryEnum ppEnum);

        [PreserveSig]
        HRESULT LockedFlush();
    }
}
