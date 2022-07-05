using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    [Guid("7CA04601-C702-4670-A63C-FA44F7DA7BD5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataAppDomain
    {
        [PreserveSig]
        HRESULT GetProcess(
            [Out] out IXCLRDataProcess process);

        [PreserveSig]
        HRESULT GetName(
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);

        [PreserveSig]
        HRESULT GetUniqueID(
            [Out] out long id);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out CLRDataAppDomainFlag flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In] IXCLRDataAppDomain appDomain);

        [PreserveSig]
        HRESULT GetManagedObject(
            [Out] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);
    }
}
