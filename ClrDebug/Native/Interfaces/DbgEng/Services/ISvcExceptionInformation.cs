using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8FCC28B1-3ADA-4876-A6D4-7BF9543DE30B")]
    [ComImport]
    public interface ISvcExceptionInformation
    {
        /// <summary>
        /// Gets the kind of exception this represents.
        /// </summary>
        [PreserveSig]
        HRESULT GetExceptionKind(
            [Out] out SvcExceptionKind pExceptionKind);

        /// <summary>
        /// Gets the address associated with the exception. Some exceptions (e.g.: Win32 exceptions and Linux fault type signals) have an address associated with them and some don't.<para/>
        /// This method will return E_NOT_SET if an address is unavailable for the exceptional event.
        /// </summary>
        [PreserveSig]
        HRESULT GetAddress(
            [Out] out long pSignalAddress);

        /// <summary>
        /// Gets the register context associated with the signal. This may legitimately return E_NOT_SET in many (particularly post-mortem) cases.
        /// </summary>
        [PreserveSig]
        HRESULT GetContext(
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);

        /// <summary>
        /// Gets the execution unit on which the exceptional event occurred.
        /// </summary>
        [PreserveSig]
        HRESULT GetExecutionUnit(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit executionUnit);

        /// <summary>
        /// Gets the size of any data structure associated with this exception (e.g.: an EXCEPTION_RECORD64, a siginfo_t, or whatever a specific architecture/platform define) If there is no available data associated, 0 is returned.<para/>
        /// It is entirely optional for a given implementation to provide this.
        /// </summary>
        [PreserveSig]
        long GetDataRecordSize();

        /// <summary>
        /// Fills a supplied buffer with a copy of the canonicalized data record for this given exception type. If no such record is defined, GetDataRecordSize will return 0 and this method will return E_NOTIMPL.<para/>
        /// If there is no available data associated, E_NOTIMPL is returned. It is entirely optional for a given implementation to provide this.<para/>
        /// Each given exception kind has a specific interface (e.g.: ISvcLinuxSignalInformation) which provides more detailed information based on potentially parsing the given data record.<para/>
        /// The vast majority of consumers should rely on those interfaces and not try to get the underlying data record that a service provider understands.
        /// </summary>
        [PreserveSig]
        HRESULT FillDataRecord(
            [In] long bufferSize,
            [Out] IntPtr buffer,
            [Out] out long bytesWritten);
    }
}
