using System.Runtime.InteropServices;

namespace ManagedCorDebug
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
            int cGenerations,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpGenerationData[] pGenerationData,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetFinalizationFillPointers(
            int cFillPointers,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] pFinalizationFillPointers,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetGenerationTableSvr(
            CLRDATA_ADDRESS heapAddr,
            int cGenerations,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpGenerationData[] pGenerationData,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetFinalizationFillPointersSvr(
            CLRDATA_ADDRESS heapAddr,
            int cFillPointers,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] pFinalizationFillPointers,
            [Out] out int pNeeded);

        [PreserveSig]
        HRESULT GetAssemblyLoadContext(
            CLRDATA_ADDRESS methodTable,
            [Out] out CLRDATA_ADDRESS assemblyLoadContext);
    }
}
