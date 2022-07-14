using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("c12f35a9-e55c-4520-a894-b3dc5165dfce")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface8
    {
        [PreserveSig]
        HRESULT GetNumberGenerations(
            [Out] out int pGenerations);

        [PreserveSig]
        HRESULT GetGenerationTable(
            [In] int cGenerations,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DacpGenerationData[] pGenerationData,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetFinalizationFillPointers(
            [In] int cFillPointers,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] CLRDATA_ADDRESS[] pFinalizationFillPointers,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetGenerationTableSvr(
            [In] CLRDATA_ADDRESS heapAddr,
            [In] int cGenerations,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DacpGenerationData[] pGenerationData,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetFinalizationFillPointersSvr(
            [In] CLRDATA_ADDRESS heapAddr,
            [In] int cFillPointers,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CLRDATA_ADDRESS[] pFinalizationFillPointers,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetAssemblyLoadContext(
            [In] CLRDATA_ADDRESS methodTable,
            [Out] out CLRDATA_ADDRESS assemblyLoadContext);
    }
}
