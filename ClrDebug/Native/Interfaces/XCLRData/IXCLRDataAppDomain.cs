using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("7CA04601-C702-4670-A63C-FA44F7DA7BD5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataAppDomain
    {
        [PreserveSig]
        HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataProcess process);

        [PreserveSig]
        HRESULT GetName(
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] name);

        [PreserveSig]
        HRESULT GetUniqueID(
            [Out] out long id);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out CLRDataAppDomainFlag flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataAppDomain appDomain);

        [PreserveSig]
        HRESULT GetManagedObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);
    }
}
