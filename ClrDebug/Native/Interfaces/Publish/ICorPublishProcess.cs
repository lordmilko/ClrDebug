using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that access information to be displayed about a process.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("18D87AF1-5A6A-11D3-8F84-00A0C9B4D50C")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorPublishProcess
    {
        /// <summary>
        /// Gets a value that indicates whether the process referenced by this <see cref="ICorPublishProcess"/> is known to have managed code.
        /// </summary>
        /// <param name="pbManaged">[out] A pointer to a Boolean value that indicates whether the process has managed code. The value is true if the process has managed code; otherwise, false.</param>
        /// <remarks>
        /// Since the current version of ICorPublishProcess allows access only to processes that have managed code, IsManaged
        /// always returns true.
        /// </remarks>
        [PreserveSig]
        HRESULT IsManaged(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbManaged);

        /// <summary>
        /// Gets an enumerator for the application domains in the process that is referenced by this <see cref="ICorPublishProcess"/>.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the address of an <see cref="ICorPublishAppDomainEnum"/> instance that allows iteration through the collection of application domains in this process.</param>
        /// <remarks>
        /// The list of application domains is based on a snapshot of the application domains that exist when the EnumAppDomains
        /// method is called. This method may be called more than once to create a new up-to-date list. Existing lists will
        /// not be affected by subsequent calls of this method. If the process has been terminated, EnumAppDomains will fail
        /// with an HRESULT value of CORDBG_E_PROCESS_TERMINATED.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumAppDomains(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishAppDomainEnum ppEnum);

        /// <summary>
        /// Gets the operating system identifier for this process.
        /// </summary>
        /// <param name="pid">[out] A pointer to the identifier of the process represented by this <see cref="ICorPublishProcess"/> object.</param>
        [PreserveSig]
        HRESULT GetProcessID(
            [Out] out int pid);

        /// <summary>
        /// Gets the full path of the executable for the process referenced by this <see cref="ICorPublishProcess"/>.
        /// </summary>
        /// <param name="cchName">[in] The size of the szName array.</param>
        /// <param name="pcchName">[out] The number of wide characters returned in the szName array.</param>
        /// <param name="szName">[out] An array to store the name, including the full path, of the executable. The name is null-terminated.</param>
        [PreserveSig]
        HRESULT GetDisplayName(
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);
    }
}
