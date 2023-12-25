using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("271498C2-4085-4766-BC3A-7F8ED188A173")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataFrame
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
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataAppDomain appDomain);

        [PreserveSig]
        HRESULT GetNumArguments(
            [Out] out int numArgs);

        //ClrDataFrame::GetArgumentByIndex contains a bug wherein it has an if statement that is entered
        //if ((bufLen && name) || nameLen), however it then goes ahead and sets name[0] = 0 when
        //m_methodDesc->IsNoMetadata() returns true. In normal debugging, it will catch this exception for you,
        //but in mixed mode debugging, you will see this access violation
        [PreserveSig]
        HRESULT GetArgumentByIndex(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue arg,
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] name);

        [PreserveSig]
        HRESULT GetNumLocalVariables(
            [Out] out int numLocals);

        [PreserveSig]
        HRESULT GetLocalVariableByIndex(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue localVariable,
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] name);

        [PreserveSig]
        HRESULT GetCodeName(
            [In] int flags, //Unused, must be 0
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf);

        [PreserveSig]
        HRESULT GetMethodInstance(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodInstance method);

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
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance typeArg);
    }
}
