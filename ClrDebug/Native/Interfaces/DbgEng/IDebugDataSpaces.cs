using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("88f7dfab-3ea7-4c3a-aefb-c4e8106173aa")]
    [ComImport]
    public interface IDebugDataSpaces
    {
        [PreserveSig]
        HRESULT ReadVirtual(
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        HRESULT WriteVirtual(
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        HRESULT SearchVirtual(
            [In] ulong Offset,
            [In] ulong Length,
            [In] IntPtr Pattern,
            [In] uint PatternSize,
            [In] uint PatternGranularity,
            [Out] out ulong MatchOffset);

        [PreserveSig]
        HRESULT ReadVirtualUncached(
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        HRESULT WriteVirtualUncached(
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        HRESULT ReadPointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ulong[] Ptrs);

        [PreserveSig]
        HRESULT WritePointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [In, MarshalAs(UnmanagedType.LPArray)] ulong[] Ptrs);

        [PreserveSig]
        HRESULT ReadPhysical(
            [In] ulong Offset,
            [Out] IntPtr buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        HRESULT WritePhysical(
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        HRESULT ReadControl(
            [In] uint Processor,
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        HRESULT WriteControl(
            [In] uint Processor,
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        HRESULT ReadIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        HRESULT WriteIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        HRESULT ReadMsr(
            [In] uint Msr,
            [Out] out ulong MsrValue);

        [PreserveSig]
        HRESULT WriteMsr(
            [In] uint Msr,
            [In] ulong MsrValue);

        [PreserveSig]
        HRESULT ReadBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        HRESULT WriteBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        HRESULT CheckLowMemory();

        [PreserveSig]
        HRESULT ReadDebuggerData(
            [In] uint Index,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

        [PreserveSig]
        HRESULT ReadProcessorSystemData(
            [In] uint Processor,
            [In] DEBUG_DATA Index,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);
    }
}
