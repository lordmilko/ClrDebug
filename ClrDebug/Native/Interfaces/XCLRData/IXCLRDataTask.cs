using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("A5B0BEEA-EC62-4618-8012-A24FFC23934C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataTask
    {
        [PreserveSig]
        HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataProcess process);

        [PreserveSig]
        HRESULT GetCurrentAppDomain(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataAppDomain appDomain);

        [PreserveSig]
        HRESULT GetUniqueID(
            [Out] out long id);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out CLRDataTaskFlag flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTask task);

        [PreserveSig]
        HRESULT GetManagedObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT GetDesiredExecutionState(
            [Out] out int state);

        [PreserveSig]
        HRESULT SetDesiredExecutionState(
            [In] int state);

        [PreserveSig]
        HRESULT CreateStackWalk(
            [In] CLRDataSimpleFrameType flags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataStackWalk stackWalk);

        [PreserveSig]
        HRESULT GetOSThreadID(
            [Out] out int id);

        [PreserveSig]
        HRESULT GetContext(
            [In] ContextFlags contextFlags,
            [In] int contextBufSize,
            [Out] out int contextSize,
            [Out] IntPtr contextBuf);

        [PreserveSig]
        HRESULT SetContext(
            [In] int contextSize,
            [In] IntPtr context);

        [PreserveSig]
        HRESULT GetCurrentExceptionState(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataExceptionState exception);

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
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] name);

        [PreserveSig]
        HRESULT GetLastExceptionState(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataExceptionState exception);
    }
}
