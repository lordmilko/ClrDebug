using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("23f79d6c-8aaf-4f7c-a607-9995f5407e63")]
    [ComImport]
    public interface IDebugDataSpaces3 : IDebugDataSpaces2
    {
        #region IDebugDataSpaces

        [PreserveSig]
        new HRESULT ReadVirtual(
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        new HRESULT WriteVirtual(
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        new HRESULT SearchVirtual(
            [In] ulong Offset,
            [In] ulong Length,
            [In] IntPtr Pattern,
            [In] uint PatternSize,
            [In] uint PatternGranularity,
            [Out] out ulong MatchOffset);

        [PreserveSig]
        new HRESULT ReadVirtualUncached(
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        new HRESULT WriteVirtualUncached(
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        new HRESULT ReadPointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ulong[] Ptrs);

        [PreserveSig]
        new HRESULT WritePointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [In, MarshalAs(UnmanagedType.LPArray)] ulong[] Ptrs);

        [PreserveSig]
        new HRESULT ReadPhysical(
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        new HRESULT WritePhysical(
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        new HRESULT ReadControl(
            [In] uint Processor,
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        new HRESULT WriteControl(
            [In] uint Processor,
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        new HRESULT ReadIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        new HRESULT WriteIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        new HRESULT ReadMsr(
            [In] uint Msr,
            [Out] out ulong MsrValue);

        [PreserveSig]
        new HRESULT WriteMsr(
            [In] uint Msr,
            [In] ulong MsrValue);

        [PreserveSig]
        new HRESULT ReadBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        new HRESULT WriteBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        new HRESULT CheckLowMemory();

        [PreserveSig]
        new HRESULT ReadDebuggerData(
            [In] uint Index,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

        [PreserveSig]
        new HRESULT ReadProcessorSystemData(
            [In] uint Processor,
            [In] DEBUG_DATA Index,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

        #endregion
        #region IDebugDataSpaces2

        [PreserveSig]
        new HRESULT VirtualToPhysical(
            [In] ulong Virtual,
            [Out] out ulong Physical);

        [PreserveSig]
        new HRESULT GetVirtualTranslationPhysicalOffsets(
            [In] ulong Virtual,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            ulong[] Offsets,
            [In] uint OffsetsSize,
            [Out] out uint Levels);

        [PreserveSig]
        new HRESULT ReadHandleData(
            [In] ulong Handle,
            [In] DEBUG_HANDLE_DATA_TYPE DataType,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

        [PreserveSig]
        new HRESULT FillVirtual(
            [In] ulong Start,
            [In] uint Size,
            [In] IntPtr Buffer,
            [In] uint PatternSize,
            [Out] out uint Filled);

        [PreserveSig]
        new HRESULT FillPhysical(
            [In] ulong Start,
            [In] uint Size,
            [In] IntPtr Buffer,
            [In] uint PatternSize,
            [Out] out uint Filled);

        [PreserveSig]
        new HRESULT QueryVirtual(
            [In] ulong Offset,
            [Out] IntPtr Info); //MEMORY_BASIC_INFORMATION64

        #endregion
        #region IDebugDataSpaces3

        [PreserveSig]
        HRESULT ReadImageNtHeaders(
            [In] ulong ImageBase,
            [Out] IntPtr Headers); //IMAGE_NT_HEADERS64

        [PreserveSig]
        HRESULT ReadTagged(
            [In, MarshalAs(UnmanagedType.LPStruct)]
            Guid Tag,
            [In] uint Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint TotalSize);

        [PreserveSig]
        HRESULT StartEnumTagged(
            [Out] out ulong Handle);

        [PreserveSig]
        HRESULT GetNextTagged(
            [In] ulong Handle,
            [Out] out Guid Tag,
            [Out] out uint Size);

        [PreserveSig]
        HRESULT EndEnumTagged(
            [In] ulong Handle);

        #endregion
    }
}
