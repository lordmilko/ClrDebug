using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines basic information about a particular process. This interface is optional to implement by any implementation of ISvcProcess.<para/>
    /// Not every provider implements this.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3A0957C5-A583-4CE1-ACC4-DFE9CACE0CF0")]
    [ComImport]
    public interface ISvcProcessBasicInformation
    {
        /// <summary>
        /// Gets the name of the process. This may or may not be the same as the name of the main executable (or may be truncated) depending on the underlying platform.<para/>
        /// An implementation for a process which does not have a name will return E_NOT_SET.
        /// </summary>
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string processName);

        /// <summary>
        /// Gets the start arguments of the process. An implementation for a process which does not have available arguments will return E_NOT_SET.
        /// </summary>
        [PreserveSig]
        HRESULT GetArguments(
            [Out, MarshalAs(UnmanagedType.BStr)] out string processArguments);

        /// <summary>
        /// Gets the PID of the parent process. An implementation for a process which does not have an available parent ID will return E_NOT_SET.
        /// </summary>
        [PreserveSig]
        HRESULT GetParentId(
            [Out] out long parentId);
    }
}
