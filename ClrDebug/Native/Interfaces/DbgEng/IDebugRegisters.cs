using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("ce289126-9e84-45a7-937e-67bb18691493")]
    [ComImport]
    public interface IDebugRegisters
    {
        [PreserveSig]
        HRESULT GetNumberRegisters(
            [Out] out uint Number);

        [PreserveSig]
        HRESULT GetDescription(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out DEBUG_REGISTER_DESCRIPTION Desc);

        [PreserveSig]
        HRESULT GetIndexByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint Index);

        [PreserveSig]
        HRESULT GetValue(
            [In] uint Register,
            [Out] out DEBUG_VALUE Value);

        [PreserveSig]
        HRESULT SetValue(
            [In] uint Register,
            [In] DEBUG_VALUE Value);

        [PreserveSig]
        HRESULT GetValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[] Indices,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] Values);

        [PreserveSig]
        HRESULT SetValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[] Indices,
            [In] uint Start,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] Values);

        [PreserveSig]
        HRESULT OutputRegisters(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_REGISTERS Flags);

        [PreserveSig]
        HRESULT GetInstructionOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        HRESULT GetStackOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        HRESULT GetFrameOffset(
            [Out] out ulong Offset);
    }
}
