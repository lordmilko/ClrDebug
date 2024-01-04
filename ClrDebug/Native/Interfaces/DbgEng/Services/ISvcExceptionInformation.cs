using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8FCC28B1-3ADA-4876-A6D4-7BF9543DE30B")]
    [ComImport]
    public interface ISvcExceptionInformation
    {
        [PreserveSig]
        HRESULT GetExceptionKind(
            [Out] out SvcExceptionKind pExceptionKind);
        
        [PreserveSig]
        HRESULT GetAddress(
            [Out] out long pSignalAddress);
        
        [PreserveSig]
        HRESULT GetContext(
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);
        
        [PreserveSig]
        HRESULT GetExecutionUnit(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit executionUnit);
        
        [PreserveSig]
        long GetDataRecordSize();
        
        [PreserveSig]
        HRESULT FillDataRecord(
            [In] long bufferSize,
            [Out] IntPtr buffer,
            [Out] out long bytesWritten);
    }
}
