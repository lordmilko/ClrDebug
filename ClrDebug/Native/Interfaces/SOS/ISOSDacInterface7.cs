using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("c1020dde-fe98-4536-a53b-f35a74c327eb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface7
    {
        [PreserveSig]
        HRESULT GetPendingReJITID(
            [In] CLRDATA_ADDRESS methodDesc,
            [Out] out int pRejitId);

        [PreserveSig]
        HRESULT GetReJITInformation(
            [In] CLRDATA_ADDRESS methodDesc,
            [In] int rejitId,
            [Out] out DacpReJitData2 pRejitData);

        [PreserveSig]
        HRESULT GetProfilerModifiedILInformation(
            [In] CLRDATA_ADDRESS methodDesc,
            [Out] out DacpProfilerILData pILData);

        [PreserveSig]
        HRESULT GetMethodsWithProfilerModifiedIL(
            [In] CLRDATA_ADDRESS mod,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] methodDescs,
            [In] int cMethodDescs,
            [Out] out int pcMethodDescs);
    }
}
