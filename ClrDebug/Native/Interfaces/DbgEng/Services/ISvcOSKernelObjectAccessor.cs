using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: Various enumeration services (process enumeration services, thread enumeration services,. module enumeration services, etc...).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8E18CBC7-B80A-4C42-A10D-A56E17A555CE")]
    [ComImport]
    public interface ISvcOSKernelObjectAccessor
    {
        /// <summary>
        /// From the address of a kernel object as returned from ISvcOSKernelObject::GetAssociatedKernelObject, return the ISvc* interface (* = Process, Thread, Module, etc...) for that object.<para/>
        /// The given address must be valid in the default address context.
        /// </summary>
        [PreserveSig]
        HRESULT GetObjectFromAssociatedKernelObject(
            [In] long kernelObjectAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out object serviceObject);
    }
}
