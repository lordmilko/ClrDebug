using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_DISASSEMBLER. The ISvcBasicDisassembly interface is required on every disassembler. It provides basic textual disassembly from memory or a provided buffer.<para/>
    /// More complicated disassembly interfaces may be provided to allow introspection of instruction types, operands, registers, etc...
    /// </summary>
    public class SvcBasicDisassembly : ComObject<ISvcBasicDisassembly>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcBasicDisassembly"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcBasicDisassembly(ISvcBasicDisassembly raw) : base(raw)
        {
        }

        #region ISvcBasicDisassembly
        #region GetInstructionDisassemblyText

        /// <summary>
        /// For an instruction/bundle at 'address' in a given address context (and with a given instructionNumber within the bundle), perform a disassembly and return a textual representation of the machine instruction.<para/>
        /// If the given instruction/bundle address is in the middle of an instruction/bundle and the diassembler is capable of correcting for that, the actual instruction/bundle address may be returned in 'startAddress'.<para/>
        /// For non-bundled architectures - On input, instructionNumber should always be zero - On output, byteCount is the size in bytes of the instruction - On output, instructionCount is one For bundled architectures - On input, instructionNumber should be within (0, instructionsInBundle].<para/>
        /// The initial call should always provide 0 for the instructionNumber. - On output, byteCount is the size in bytes of the bundle - On output, instructionCount is the number of instructions within the bundle.
        /// </summary>
        public GetInstructionDisassemblyTextResult GetInstructionDisassemblyText(ISvcAddressContext addressContext, long address, long instructionNumber)
        {
            GetInstructionDisassemblyTextResult result;
            TryGetInstructionDisassemblyText(addressContext, address, instructionNumber, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// For an instruction/bundle at 'address' in a given address context (and with a given instructionNumber within the bundle), perform a disassembly and return a textual representation of the machine instruction.<para/>
        /// If the given instruction/bundle address is in the middle of an instruction/bundle and the diassembler is capable of correcting for that, the actual instruction/bundle address may be returned in 'startAddress'.<para/>
        /// For non-bundled architectures - On input, instructionNumber should always be zero - On output, byteCount is the size in bytes of the instruction - On output, instructionCount is one For bundled architectures - On input, instructionNumber should be within (0, instructionsInBundle].<para/>
        /// The initial call should always provide 0 for the instructionNumber. - On output, byteCount is the size in bytes of the bundle - On output, instructionCount is the number of instructions within the bundle.
        /// </summary>
        public HRESULT TryGetInstructionDisassemblyText(ISvcAddressContext addressContext, long address, long instructionNumber, out GetInstructionDisassemblyTextResult result)
        {
            /*HRESULT GetInstructionDisassemblyText(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long address,
            [In] long instructionNumber,
            [Out, MarshalAs(UnmanagedType.BStr)] out string disassembledInstruction,
            [Out] out long byteCount,
            [Out] out long instructionCount,
            [Out] out long startAddress);*/
            string disassembledInstruction;
            long byteCount;
            long instructionCount;
            long startAddress;
            HRESULT hr = Raw.GetInstructionDisassemblyText(addressContext, address, instructionNumber, out disassembledInstruction, out byteCount, out instructionCount, out startAddress);

            if (hr == HRESULT.S_OK)
                result = new GetInstructionDisassemblyTextResult(disassembledInstruction, byteCount, instructionCount, startAddress);
            else
                result = default(GetInstructionDisassemblyTextResult);

            return hr;
        }

        #endregion
        #region GetInstructionDisassemblyTextForBuffer

        /// <summary>
        /// For an instruction/bundle within a memory buffer, perform a disassembly and return a textual representation of the machine instruction.<para/>
        /// Otherwise, this operates as GetInstructionDisassemblyText with a few caveats - An implementation of ISvcBasicDisassembly may legally E_NOTIMPL this method.<para/>
        /// - Most frequently, 'addressContext and address' are nullptr/0. In such cases, the disassembler may not symbolicate the instruction.<para/>
        /// - If 'addressContext/address' are not nullptr, the disassembler may utilize the image/symbol provider to symbolicate the instruction.<para/>
        /// - Even if 'addressContext/address' are not nullptr, the disassembler must read the instruction/bundle bytes from the given buffer and never utilize a memory service to read (or delegate to the GetInstructionDisassemblyText method).
        /// </summary>
        public GetInstructionDisassemblyTextForBufferResult GetInstructionDisassemblyTextForBuffer(IntPtr buffer, long bufferSize, ISvcAddressContext addressContext, long address, long instructionNumber)
        {
            GetInstructionDisassemblyTextForBufferResult result;
            TryGetInstructionDisassemblyTextForBuffer(buffer, bufferSize, addressContext, address, instructionNumber, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// For an instruction/bundle within a memory buffer, perform a disassembly and return a textual representation of the machine instruction.<para/>
        /// Otherwise, this operates as GetInstructionDisassemblyText with a few caveats - An implementation of ISvcBasicDisassembly may legally E_NOTIMPL this method.<para/>
        /// - Most frequently, 'addressContext and address' are nullptr/0. In such cases, the disassembler may not symbolicate the instruction.<para/>
        /// - If 'addressContext/address' are not nullptr, the disassembler may utilize the image/symbol provider to symbolicate the instruction.<para/>
        /// - Even if 'addressContext/address' are not nullptr, the disassembler must read the instruction/bundle bytes from the given buffer and never utilize a memory service to read (or delegate to the GetInstructionDisassemblyText method).
        /// </summary>
        public HRESULT TryGetInstructionDisassemblyTextForBuffer(IntPtr buffer, long bufferSize, ISvcAddressContext addressContext, long address, long instructionNumber, out GetInstructionDisassemblyTextForBufferResult result)
        {
            /*HRESULT GetInstructionDisassemblyTextForBuffer(
            [In] IntPtr buffer,
            [In] long bufferSize,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long address,
            [In] long instructionNumber,
            [Out, MarshalAs(UnmanagedType.BStr)] out string disassembledInstruction,
            [Out] out long byteCount,
            [Out] out long instructionCount,
            [Out] out long startAddress);*/
            string disassembledInstruction;
            long byteCount;
            long instructionCount;
            long startAddress;
            HRESULT hr = Raw.GetInstructionDisassemblyTextForBuffer(buffer, bufferSize, addressContext, address, instructionNumber, out disassembledInstruction, out byteCount, out instructionCount, out startAddress);

            if (hr == HRESULT.S_OK)
                result = new GetInstructionDisassemblyTextForBufferResult(disassembledInstruction, byteCount, instructionCount, startAddress);
            else
                result = default(GetInstructionDisassemblyTextForBufferResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
