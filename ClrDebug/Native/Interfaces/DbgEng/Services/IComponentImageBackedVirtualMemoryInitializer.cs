using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2AD7F2CB-E309-4D5D-B97D-41436360B7D1")]
    [ComImport]
    public interface IComponentImageBackedVirtualMemoryInitializer
    {
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer pUnderlyingVirtualMemoryService,
            [In, MarshalAs(UnmanagedType.U1)] bool projectNonFileMappedBytes);
    }
}
