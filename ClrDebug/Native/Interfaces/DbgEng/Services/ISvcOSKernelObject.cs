using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E14E5358-56DD-4C71-98F8-EDED11398426")]
    [ComImport]
    public interface ISvcOSKernelObject
    {
        [PreserveSig]
        HRESULT GetAssociatedKernelObject(
            [Out] out long kernelObjectAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressContext kernelAddressContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule kernelModule,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol kernelObjectType);
    }
}
