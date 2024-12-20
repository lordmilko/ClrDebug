using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: [Optional] Module enumeration service. The ISvcPrimaryModules (and derivative) interface(s) may optionally be provided on the module enumeration service to indicate key modules of a process.<para/>
    /// Typically, this is used to determine the main executable image of a given process.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("04E3E600-9A10-48DF-A618-775B3E36A740")]
    [ComImport]
    public interface ISvcPrimaryModules
    {
        /// <summary>
        /// Finds the main executable module for the given process. This is the executable image which started the given process.<para/>
        /// For a non-process context (e.g.: a kernel), this may be defined as the kernel image.
        /// </summary>
        [PreserveSig]
        HRESULT FindExecutableModule(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule executableModule);
    }
}
