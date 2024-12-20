using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_DISASSEMBLER. The ISvcBasicDisassembly interface is required on every disassembler. It provides basic textual disassembly from memory or a provided buffer.<para/>
    /// More complicated disassembly interfaces may be provided to allow introspection of instruction types, operands, registers, etc...
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FAFCA4B4-66DA-4AC0-86B6-AAC5C2498BC6")]
    [ComImport]
    public interface ISvcBasicDisassembly
    {
        /// <summary>
        /// For an instruction/bundle at 'address' in a given address context (and with a given instructionNumber within the bundle), perform a disassembly and return a textual representation of the machine instruction.<para/>
        /// If the given instruction/bundle address is in the middle of an instruction/bundle and the diassembler is capable of correcting for that, the actual instruction/bundle address may be returned in 'startAddress'.<para/>
        /// For non-bundled architectures - On input, instructionNumber should always be zero - On output, byteCount is the size in bytes of the instruction - On output, instructionCount is one For bundled architectures - On input, instructionNumber should be within (0, instructionsInBundle].<para/>
        /// The initial call should always provide 0 for the instructionNumber. - On output, byteCount is the size in bytes of the bundle - On output, instructionCount is the number of instructions within the bundle.
        /// </summary>
        [PreserveSig]
        HRESULT GetInstructionDisassemblyText(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long address,
            [In] long instructionNumber,
            [Out, MarshalAs(UnmanagedType.BStr)] out string disassembledInstruction,
            [Out] out long byteCount,
            [Out] out long instructionCount,
            [Out] out long startAddress);

        /// <summary>
        /// For an instruction/bundle within a memory buffer, perform a disassembly and return a textual representation of the machine instruction.<para/>
        /// Otherwise, this operates as GetInstructionDisassemblyText with a few caveats - An implementation of ISvcBasicDisassembly may legally E_NOTIMPL this method.<para/>
        /// - Most frequently, 'addressContext and address' are nullptr/0. In such cases, the disassembler may not symbolicate the instruction.<para/>
        /// - If 'addressContext/address' are not nullptr, the disassembler may utilize the image/symbol provider to symbolicate the instruction.<para/>
        /// - Even if 'addressContext/address' are not nullptr, the disassembler must read the instruction/bundle bytes from the given buffer and never utilize a memory service to read (or delegate to the GetInstructionDisassemblyText method).
        /// </summary>
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
