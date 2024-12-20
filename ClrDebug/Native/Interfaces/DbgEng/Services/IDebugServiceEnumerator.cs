using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Enumerates all of the services in a container.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("71BE9D83-969F-428B-A28D-3A439D61FDE9")]
    [ComImport]
    public interface IDebugServiceEnumerator
    {
        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Gets the next service in the container and the service GUID under which it was registered.
        /// </summary>
        [PreserveSig]
        HRESULT GetNext(
            [Out] out Guid serviceGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer service);
    }
}
