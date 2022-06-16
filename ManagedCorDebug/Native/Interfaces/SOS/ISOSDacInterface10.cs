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
            CLRDATA_ADDRESS objAddr,
            out CLRDATA_ADDRESS rcw,
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] mowList,
            out int pNeeded);

        [PreserveSig]
        HRESULT IsComWrappersCCW(
            CLRDATA_ADDRESS ccw,
            out int isComWrappersCCW);

        [PreserveSig]
        HRESULT GetComWrappersCCWData(
            CLRDATA_ADDRESS ccw,
            out CLRDATA_ADDRESS managedObject,
            out int refCount);

        [PreserveSig]
        HRESULT IsComWrappersRCW(
            CLRDATA_ADDRESS rcw,
            out int isComWrappersRCW);

        [PreserveSig]
        HRESULT GetComWrappersRCWData(
            CLRDATA_ADDRESS rcw,
            out CLRDATA_ADDRESS identity);
    }
}
