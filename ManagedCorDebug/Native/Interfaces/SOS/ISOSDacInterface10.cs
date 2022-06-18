using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("90B8FCC3-7251-4B0A-AE3D-5C13A67EC9AA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface10
    {
        [PreserveSig]
        HRESULT GetObjectComWrappersData(
            [In] CLRDATA_ADDRESS objAddr,
            [Out] out CLRDATA_ADDRESS rcw,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] mowList,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT IsComWrappersCCW(
            [In] CLRDATA_ADDRESS ccw,
            [Out] out int isComWrappersCCW);

        [PreserveSig]
        HRESULT GetComWrappersCCWData(
            [In] CLRDATA_ADDRESS ccw,
            [Out] out CLRDATA_ADDRESS managedObject,
            [Out] out int refCount);

        [PreserveSig]
        HRESULT IsComWrappersRCW(
            [In] CLRDATA_ADDRESS rcw,
            [Out] out int isComWrappersRCW);

        [PreserveSig]
        HRESULT GetComWrappersRCWData(
            [In] CLRDATA_ADDRESS rcw,
            [Out] out CLRDATA_ADDRESS identity);
    }
}
