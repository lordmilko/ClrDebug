using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("d98ada1f-29e9-4ef5-a6c0-e53349883212")]
    [ComImport]
    public interface IDebugDataSpaces4 : IDebugDataSpaces3
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
        new HRESULT ReadImageNtHeaders(
            [In] ulong ImageBase,
            [Out] IntPtr Headers); //IMAGE_NT_HEADERS64

        [PreserveSig]
        new HRESULT ReadTagged(
            [In, MarshalAs(UnmanagedType.LPStruct)]
            Guid Tag,
            [In] uint Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint TotalSize);

        [PreserveSig]
        new HRESULT StartEnumTagged(
            [Out] out ulong Handle);

        [PreserveSig]
        new HRESULT GetNextTagged(
            [In] ulong Handle,
            [Out] out Guid Tag,
            [Out] out uint Size);

        [PreserveSig]
        new HRESULT EndEnumTagged(
            [In] ulong Handle);

        #endregion
        #region IDebugDataSpaces4

        [PreserveSig]
        HRESULT GetOffsetInformation(
            [In] DEBUG_DATA_SPACE Space,
            [In] DEBUG_OFFSINFO Which,
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint InfoSize);

        [PreserveSig]
        HRESULT GetNextDifferentlyValidOffsetVirtual(
            [In] ulong Offset,
            [Out] out ulong NextOffset);

        [PreserveSig]
        HRESULT GetValidRegionVirtual(
            [In] ulong Base,
            [In] uint Size,
            [Out] out ulong ValidBase,
            [Out] out uint ValidSize);

        [PreserveSig]
        HRESULT SearchVirtual2(
            [In] ulong Offset,
            [In] ulong Length,
            [In] DEBUG_VSEARCH Flags,
            [In] IntPtr Buffer,
            [In] uint PatternSize,
            [In] uint PatternGranularity,
            [Out] out ulong MatchOffset);

        [PreserveSig]
        HRESULT ReadMultiByteStringVirtual(
            [In] ulong Offset,
            [In] uint MaxBytes,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringBytes);

        [PreserveSig]
        HRESULT ReadMultiByteStringVirtualWide(
            [In] ulong Offset,
            [In] uint MaxBytes,
            [In] CODE_PAGE CodePage,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringBytes);

        [PreserveSig]
        HRESULT ReadUnicodeStringVirtual(
            [In] ulong Offset,
            [In] uint MaxBytes,
            [In] CODE_PAGE CodePage,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringBytes);

        [PreserveSig]
        HRESULT ReadUnicodeStringVirtualWide(
            [In] ulong Offset,
            [In] uint MaxBytes,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringBytes);

        [PreserveSig]
        HRESULT ReadPhysical2(
            [In] ulong Offset,
            [In] DEBUG_PHYSICAL Flags,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        HRESULT WritePhysical2(
            [In] ulong Offset,
            [In] DEBUG_PHYSICAL Flags,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        #endregion
    }
}
