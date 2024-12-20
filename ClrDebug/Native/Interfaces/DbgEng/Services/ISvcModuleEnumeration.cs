using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("20D4BA1D-BE37-4DC4-9F6A-90E3C373200E")]
    [ComImport]
    public interface ISvcModuleEnumeration
    {
        /// <summary>
        /// Finds a module by a unique key. The interpretation and semantic meaning of the key is specific to the service which provides this.<para/>
        /// This may be the base address of the module.
        /// </summary>
        [PreserveSig]
        HRESULT FindModule(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In] long moduleKey,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule targetModule);

        /// <summary>
        /// Finds a module by an address.
        /// </summary>
        [PreserveSig]
        HRESULT FindModuleAtAddress(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In] long moduleAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule targetModule);

        /// <summary>
        /// Returns an enumerator object which is capable of enumerating all modules in the given process and creating an ISvcModule for them.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateModules(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModuleEnumerator targetModuleEnumerator);
    }
}
