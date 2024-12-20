using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: Various objects (processes, threads, modules, etc...). If an object is exposed by an enumerator for a kernel and has an associated construct in the kernel, this can map the conceptual object to a physical structure in the kernel.<para/>
    /// Its presence is optional.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E14E5358-56DD-4C71-98F8-EDED11398426")]
    [ComImport]
    public interface ISvcOSKernelObject
    {
        /// <summary>
        /// For any given object, this gets an object in the kernel that is used to manage such object.
        /// </summary>
        [PreserveSig]
        HRESULT GetAssociatedKernelObject(
            [Out] out long kernelObjectAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressContext kernelAddressContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule kernelModule,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol kernelObjectType);
    }
}
