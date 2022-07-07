using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1656afa9-19c6-4e3a-97e7-5dc9160cf9c4")]
    [ComImport]
    public interface IDebugRegisters2 : IDebugRegisters
    {
        #region IDebugRegisters

        [PreserveSig]
        new HRESULT GetNumberRegisters(
            [Out] out uint Number);

        [PreserveSig]
        new HRESULT GetDescription(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out DEBUG_REGISTER_DESCRIPTION Desc);

        [PreserveSig]
        new HRESULT GetIndexByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint Index);

        [PreserveSig]
        new HRESULT GetValue(
            [In] uint Register,
            [Out] out DEBUG_VALUE Value);

        [PreserveSig]
        new HRESULT SetValue(
            [In] uint Register,
            [In] DEBUG_VALUE Value);

        [PreserveSig]
        new HRESULT GetValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[] Indices,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] Values);

        [PreserveSig]
        new HRESULT SetValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)]
            uint[] Indices,
            [In] uint Start,
            [In, MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] Values);

        [PreserveSig]
        new HRESULT OutputRegisters(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_REGISTERS Flags);

        [PreserveSig]
        new HRESULT GetInstructionOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT GetStackOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT GetFrameOffset(
            [Out] out ulong Offset);

        #endregion
        #region IDebugRegisters2

        [PreserveSig]
        HRESULT GetDescriptionWide(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out DEBUG_REGISTER_DESCRIPTION Desc);

        [PreserveSig]
        HRESULT GetIndexByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out uint Index);

        [PreserveSig]
        HRESULT GetNumberPseudoRegisters(
            [Out] out uint Number);

        [PreserveSig]
        HRESULT GetPseudoDescription(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong TypeModule,
            [Out] out uint TypeId);

        [PreserveSig]
        HRESULT GetPseudoDescriptionWide(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong TypeModule,
            [Out] out uint TypeId);

        [PreserveSig]
        HRESULT GetPseudoIndexByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint Index);

        [PreserveSig]
        HRESULT GetPseudoIndexByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out uint Index);

        [PreserveSig]
        HRESULT GetPseudoValues(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)]
            uint[] Indices,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] Values);

        [PreserveSig]
        HRESULT SetPseudoValues(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)]
            uint[] Indices,
            [In] uint Start,
            [In, MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] Values);

        [PreserveSig]
        HRESULT GetValues2(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)]
            uint[] Indices,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] Values);

        [PreserveSig]
        HRESULT SetValues2(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)]
            uint[] Indices,
            [In] uint Start,
            [In, MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] Values);

        [PreserveSig]
        HRESULT OutputRegisters2(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_REGSRC Source,
            [In] DEBUG_REGISTERS Flags);

        [PreserveSig]
        HRESULT GetInstructionOffset2(
            [In] DEBUG_REGSRC Source,
            [Out] out ulong Offset);

        [PreserveSig]
        HRESULT GetStackOffset2(
            [In] DEBUG_REGSRC Source,
            [Out] out ulong Offset);

        [PreserveSig]
        HRESULT GetFrameOffset2(
            [In] DEBUG_REGSRC Source,
            [Out] out ulong Offset);

        #endregion
    }
}
