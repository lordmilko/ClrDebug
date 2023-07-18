using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Serves as the general interface for publishing information about processes and information about the application domains in those processes.
    /// </summary>
    [Guid("9613A0E7-5A68-11D3-8F84-00A0C9B4D50C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorPublish
    {
        /// <summary>
        /// Gets an enumerator for the managed processes running on this computer.
        /// </summary>
        /// <param name="Type">A value of the <see cref="COR_PUB_ENUMPROCESS"/> enumeration that specifies the type of process to be retrieved.<para/>
        /// In the current version, only COR_PUB_MANAGEDONLY is valid.</param>
        /// <param name="ppIEnum">A pointer to the address of an <see cref="ICorPublishProcessEnum"/> instance that is the enumerator of the processes.</param>
        /// <remarks>
        /// The enumerator's collection of processes is based on a snapshot of the processes that are running when the EnumProcesses
        /// method is called. The enumerator will not include any processes that terminate before or start after EnumProcesses
        /// is called. The EnumProcesses method may be called more than once on this <see cref="ICorPublish"/> instance to
        /// create a new up-to-date collection of processes. Existing collections will not be affected by subsequent calls
        /// of the EnumProcesses method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumProcesses(
            [In] COR_PUB_ENUMPROCESS Type,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishProcessEnum ppIEnum);

        /// <summary>
        /// Gets an <see cref="ICorPublishProcess"/> instance that represents the process with the specified identifier.
        /// </summary>
        /// <param name="pid">[in] The identifier of the process.</param>
        /// <param name="ppProcess">[out] A pointer to the address of an ICorPublishProcess instance that represents the process.</param>
        /// <remarks>
        /// GetProcess fails if the process doesn't exist, or isn't a managed process that can be debugged by the current user.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetProcess(
            [In] int pid,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishProcess ppProcess);
    }
}
