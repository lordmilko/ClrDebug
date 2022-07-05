using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    [Guid("A5B0BEEA-EC62-4618-8012-A24FFC23934C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataTask
    {
        [PreserveSig]
        HRESULT GetProcess(
            [Out] out IXCLRDataProcess process);

        [PreserveSig]
        HRESULT GetCurrentAppDomain(
            [Out] out IXCLRDataAppDomain appDomain);

        [PreserveSig]
        HRESULT GetUniqueID(
            [Out] out long id);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out CLRDataTaskFlag flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In] IXCLRDataTask task);

        [PreserveSig]
        HRESULT GetManagedObject(
            [Out] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT GetDesiredExecutionState(
            [Out] out int state);

        [PreserveSig]
        HRESULT SetDesiredExecutionState(
            [In] int state);

        [PreserveSig]
        HRESULT CreateStackWalk(
            [In] CLRDataSimpleFrameType flags,
            [Out] out IXCLRDataStackWalk stackWalk);

        [PreserveSig]
        HRESULT GetOSThreadID(
            [Out] out int id);

        [PreserveSig]
        HRESULT GetContext(
            [In] int contextFlags,
            [In] int contextBufSize,
            [Out] out int contextSize,
            [Out] IntPtr contextBuf);

        [PreserveSig]
        HRESULT SetContext(
            [In] int contextSize,
            [In] IntPtr context);

        [PreserveSig]
        HRESULT GetCurrentExceptionState(
            [Out] out IXCLRDataExceptionState exception);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        [PreserveSig]
        HRESULT GetName(
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);

        [PreserveSig]
        HRESULT GetLastExceptionState(
            [Out] out IXCLRDataExceptionState exception);
    }
}
