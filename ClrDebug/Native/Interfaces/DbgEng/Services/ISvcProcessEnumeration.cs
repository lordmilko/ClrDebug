using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3CFA6328-A170-4D90-BCE2-C9FDB898C1F5")]
    [ComImport]
    public interface ISvcProcessEnumeration
    {
        /// <summary>
        /// Finds a process by a unique key. The interpretation and semantic meaning of the key is specific to the service which provides this.<para/>
        /// For Windows Kernel mode, this may be a service which returns o an ISvcProcess from a target EPROCESS pointer. For user mode, it might be the process ID.
        /// </summary>
        [PreserveSig]
        HRESULT FindProcess(
            [In] long processKey,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess targetProcess);

        /// <summary>
        /// Returns an enumerator object which is capable of enumerating all processes on the target and creating an ISvcProcess for them.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateProcesses(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcessEnumerator targetProcessEnumerator);
    }
}
