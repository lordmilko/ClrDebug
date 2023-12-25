using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("90B8FCC3-7251-4B0A-AE3D-5C13A67EC9AA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSDacInterface10
    {
        [PreserveSig]
        HRESULT GetObjectComWrappersData(
            [In] CLRDATA_ADDRESS objAddr,
            [Out] out CLRDATA_ADDRESS rcw,
            [In] int count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CLRDATA_ADDRESS[] mowList,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT IsComWrappersCCW(
            [In] CLRDATA_ADDRESS ccw,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isComWrappersCCW);

        [PreserveSig]
        HRESULT GetComWrappersCCWData(
            [In] CLRDATA_ADDRESS ccw,
            [Out] out CLRDATA_ADDRESS managedObject,
            [Out] out int refCount);

        [PreserveSig]
        HRESULT IsComWrappersRCW(
            [In] CLRDATA_ADDRESS rcw,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isComWrappersRCW);

        [PreserveSig]
        HRESULT GetComWrappersRCWData(
            [In] CLRDATA_ADDRESS rcw,
            [Out] out CLRDATA_ADDRESS identity);
    }
}
