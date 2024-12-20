using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_MACHINE (where applicable). The ISvcMachineDebug interface is provided only for configurations which are debugging at a hardware or kernel level where the debug primitives are in terms of processors and their contexts rather than threads and processes.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("59C0BA4E-84E8-4A2E-8874-83DF03E3CFF5")]
    [ComImport]
    public interface ISvcMachineDebug
    {
        /// <summary>
        /// If a default address context is available, this returns it. The machine implementor can decide what constitues a defualt address context.<para/>
        /// If automatic kernel discovery is to take place this must be an address context in which that can occur.
        /// </summary>
        [PreserveSig]
        HRESULT GetDefaultAddressContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressContext defaultAddressContext);

        /// <summary>
        /// ; Returns the number of processors on the machine.
        /// </summary>
        [PreserveSig]
        long GetNumberOfProcessors();

        /// <summary>
        /// Gets an interface for the given processor.
        /// </summary>
        [PreserveSig]
        HRESULT GetProcessor(
            [In] long processorNumber,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit processor);
    }
}
