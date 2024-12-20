using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_OS_KERNELINFRASTRUCTURE.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C809D0B1-4563-4577-BFDC-AF951FCE5308")]
    [ComImport]
    public interface ISvcOSKernelTypes
    {
        /// <summary>
        /// If the kernel describes the notion of processes from a process enumerator and such objects have an object in the kernel associated with them, that object is of this type.<para/>
        /// For Windows, this would be EPROCESS. A return of E_NOT_SET indicates that no such type exists.
        /// </summary>
        [PreserveSig]
        HRESULT GetProcessType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppProcessType);

        /// <summary>
        /// If the kernel describes the notion of threads from a thread enumerator and such objects have an object in the kernel associated with them, that object is of this type.<para/>
        /// For Windows, this would be ETHREAD. A return of E_NOT_SET indicates that no such type exists.
        /// </summary>
        [PreserveSig]
        HRESULT GetThreadType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppThreadType);

        /// <summary>
        /// If the kernel describes the notion of a module (SO / DLL / driver) from a module enumerator and such objects have an object in the kernel associated with them, that object is of this type.<para/>
        /// A return of E_NOT_SET indicates that no such type exists.
        /// </summary>
        [PreserveSig]
        HRESULT GetModuleType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppModuleType);
    }
}
