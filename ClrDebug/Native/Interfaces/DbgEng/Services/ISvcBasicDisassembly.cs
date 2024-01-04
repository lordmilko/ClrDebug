using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FAFCA4B4-66DA-4AC0-86B6-AAC5C2498BC6")]
    [ComImport]
    public interface ISvcBasicDisassembly
    {
        [PreserveSig]
        HRESULT GetInstructionDisassemblyText(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long address,
            [In] long instructionNumber,
            [Out, MarshalAs(UnmanagedType.BStr)] out string disassembledInstruction,
            [Out] out long byteCount,
            [Out] out long instructionCount,
            [Out] out long startAddress);
        
        [PreserveSig]
        HRESULT GetInstructionDisassemblyTextForBuffer(
            [In] IntPtr buffer,
            [In] long bufferSize,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long address,
            [In] long instructionNumber,
            [Out, MarshalAs(UnmanagedType.BStr)] out string disassembledInstruction,
            [Out] out long byteCount,
            [Out] out long instructionCount,
            [Out] out long startAddress);
    }
}
