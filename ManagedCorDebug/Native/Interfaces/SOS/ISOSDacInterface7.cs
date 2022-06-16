using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("c1020dde-fe98-4536-a53b-f35a74c327eb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface7
    {
        [PreserveSig]
        HRESULT GetPendingReJITID(
            CLRDATA_ADDRESS methodDesc,
            out int pRejitId);

        [PreserveSig]
        HRESULT GetReJITInformation(
            CLRDATA_ADDRESS methodDesc,
            int rejitId,
            out DacpReJitData2 pRejitData);

        [PreserveSig]
        HRESULT GetProfilerModifiedILInformation(
            CLRDATA_ADDRESS methodDesc,
            out DacpProfilerILData pILData);

        [PreserveSig]
        HRESULT GetMethodsWithProfilerModifiedIL(
            CLRDATA_ADDRESS mod,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] methodDescs,
            int cMethodDescs,
            out int pcMethodDescs);
    }
}
