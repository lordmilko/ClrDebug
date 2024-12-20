using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A4D4186A-CA0E-483B-BB2A-A83F9D3F3115")]
    [ComImport]
    public interface ISvcThreadEnumeration
    {
        /// <summary>
        /// Finds a thread by a unique key. The interpretation and semantic meaning of the key is specific to the service which provides this.<para/>
        /// For Windows Kernel mode, this may be a service which returns o an ISvcThread from a target ETHREAD pointer. For user mode, it might be the thread ID.
        /// </summary>
        [PreserveSig]
        HRESULT FindThread(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In] long threadKey,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread targetThread);

        /// <summary>
        /// Returns an enumerator object which is capable of enumerating all processes on the target and creating an ISvcProcess for them.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateThreads(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThreadEnumerator targetThreadEnumerator);
    }
}
