using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    [Guid("271498C2-4085-4766-BC3A-7F8ED188A173")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataFrame
    {
        [PreserveSig]
        HRESULT GetFrameType(
            [Out] out CLRDataSimpleFrameType simpleType,
            [Out] out CLRDataDetailedFrameType detailedType);

        [PreserveSig]
        HRESULT GetContext(
            [In] ContextFlags contextFlags,
            [In] int contextBufSize,
            [Out] out int contextSize,
            [Out] IntPtr contextBuf);

        [PreserveSig]
        HRESULT GetAppDomain(
            [Out] out IXCLRDataAppDomain appDomain);

        [PreserveSig]
        HRESULT GetNumArguments(
            [Out] out int numArgs);

        [PreserveSig]
        HRESULT GetArgumentByIndex(
            [In] int index,
            [Out] out IXCLRDataValue arg,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);

        [PreserveSig]
        HRESULT GetNumLocalVariables(
            [Out] out int numLocals);

        [PreserveSig]
        HRESULT GetLocalVariableByIndex(
            [In] int index,
            [Out] out IXCLRDataValue localVariable,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);

        [PreserveSig]
        HRESULT GetCodeName(
            [In] int flags, //Unused, must be 0
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);

        [PreserveSig]
        HRESULT GetMethodInstance(
            [Out] out IXCLRDataMethodInstance method);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        [PreserveSig]
        HRESULT GetNumTypeArguments(
            [Out] out int numTypeArgs);

        [PreserveSig]
        HRESULT GetTypeArgumentByIndex(
            [In] int index,
            [Out] out IXCLRDataTypeInstance typeArg);
    }
}
