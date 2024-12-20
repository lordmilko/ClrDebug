using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Notes - All implementations of ISvcLinuxSignalInformation must also implement ISvcExceptionInformation.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("DE815F6F-5824-4555-A010-286791BC79AD")]
    [ComImport]
    public interface ISvcLinuxSignalInformation
    {
        /// <summary>
        /// Gets the Linux signal number associated with the signal represented by this interface.
        /// </summary>
        [PreserveSig]
        int GetSignalNumber();

        /// <summary>
        /// Gets the errno associated with this signal (if applicable; otherwise 0).
        /// </summary>
        [PreserveSig]
        int GetErrorNumber();

        /// <summary>
        /// Gets the signal code associated with this signal.
        /// </summary>
        [PreserveSig]
        int GetSignalCode();

        /// <summary>
        /// Gets the source PID for the origin of the signal if such information is included within the signal record. Otherwise, E_NOT_SET is returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetSourcePid(
            [Out] out long sourcePid);
    }
}
