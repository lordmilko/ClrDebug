using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a means of accessing or identifying aspects of a process. Note that this represents a process whether that is a user mode process or a kernel mode process.<para/>
    /// This interface is intended to be a minimal core of information about a process. Further ISvcProcess* interfaces can be added to provide further functionality.<para/>
    /// @NOTE: For now, this is likely to be very tied to ProcessInfo (user mode) or the implicit process data (kernel mode).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B45C31AD-8149-4EA9-9DB8-F4468D710A36")]
    [ComImport]
    public interface ISvcProcess
    {
        /// <summary>
        /// Gets the unique "per-target" process key. The interpretation of this key is dependent upon the service which provides this interface.<para/>
        /// For Windows Kernel, this may be the address of an EPROCESS in the target. For Windows User, this may be the PID.
        /// </summary>
        [PreserveSig]
        HRESULT GetKey(
            [Out] out long processKey);

        /// <summary>
        /// Gets the process' ID as defined by the underlying platform. This may or may not be the same value as returned from GetKey.
        /// </summary>
        [PreserveSig]
        HRESULT GetId(
            [Out] out long processId);
    }
}
