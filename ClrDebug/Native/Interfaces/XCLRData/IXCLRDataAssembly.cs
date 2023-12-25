using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("2FA17588-43C2-46ab-9B51-C8F01E39C9AC")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataAssembly
    {
        [PreserveSig]
        HRESULT StartEnumModules(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumModule(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule mod);

        [PreserveSig]
        HRESULT EndEnumModules(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetName(
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] name);

        [PreserveSig]
        HRESULT GetFileName(
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] name);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out CLRDataAssemblyFlag flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataAssembly assembly);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        [PreserveSig]
        HRESULT StartEnumAppDomains(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumAppDomain(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataAppDomain appDomain);

        [PreserveSig]
        HRESULT EndEnumAppDomains(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetDisplayName(
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] name);
    }
}
