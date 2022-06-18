using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("E59D8D22-ADA7-49a2-89B5-A415AFCFC95F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataStackWalk
    {
        [PreserveSig]
        HRESULT GetContext(
            [In] int contextFlags,
            [In] int contextBufSize,
            [Out] out int contextSize,
            [In, Out] ref IntPtr contextBuf);

        [PreserveSig]
        HRESULT SetContext(
            [In] int contextSize,
            [In] IntPtr context);

        [PreserveSig]
        HRESULT Next();

        [PreserveSig]
        HRESULT GetStackSizeSkipped(
            [Out] out long stackSizeSkipped);

        [PreserveSig]
        HRESULT GetFrameType(
            [Out] out CLRDataSimpleFrameType simpleType,
            [Out] out CLRDataDetailedFrameType detailedType);

        [PreserveSig]
        HRESULT GetFrame(
            [Out] out IXCLRDataFrame frame);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [In, Out] ref IntPtr outBuffer);

        [PreserveSig]
        HRESULT SetContext2(
            [In] int flags,
            [In] int contextSize,
            [In] IntPtr context);
    }
}
