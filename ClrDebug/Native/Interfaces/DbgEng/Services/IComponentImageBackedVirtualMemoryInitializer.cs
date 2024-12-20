using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2AD7F2CB-E309-4D5D-B97D-41436360B7D1")]
    [ComImport]
    public interface IComponentImageBackedVirtualMemoryInitializer
    {
        /// <summary>
        /// Initializes the image backed virtual memory service with an underlying virtual memory service. The given service must support ISvcMemoryAccess and *SHOULD* implement ISvcMemoryInformation.<para/>
        /// If the underlying service does not support ISvcMemoryInformation, the image backed virtual memory service will operate in pass through mode only.<para/>
        /// If no pUnderlyingVirtualMemoryService is provided as 'nullptr' or the initializer is not called before the component is inserted into the service container, it will stack on top of whatever virtual memory service is already in the service container.<para/>
        /// 'projectNonFileMappedBytesAsZero' indicates whether bytes attributable to the image which are not contained in the underlying virtual memory service *OR* the image file itself should be provided by this service.<para/>
        /// Such bytes would be things which are zero initialized (or uninitialized) but allocated by a loader (e.g.: the .bss segment).
        /// </summary>
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer pUnderlyingVirtualMemoryService,
            [In, MarshalAs(UnmanagedType.U1)] bool projectNonFileMappedBytes);
    }
}
