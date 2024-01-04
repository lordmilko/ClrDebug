using System;

namespace ClrDebug.DbgEng
{
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

        public GetInstructionDisassemblyTextResult GetInstructionDisassemblyText(ISvcAddressContext addressContext, long address, long instructionNumber)
        {
            GetInstructionDisassemblyTextResult result;
            TryGetInstructionDisassemblyText(addressContext, address, instructionNumber, out result).ThrowDbgEngNotOK();

            return result;
        }

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

        public GetInstructionDisassemblyTextForBufferResult GetInstructionDisassemblyTextForBuffer(IntPtr buffer, long bufferSize, ISvcAddressContext addressContext, long address, long instructionNumber)
        {
            GetInstructionDisassemblyTextForBufferResult result;
            TryGetInstructionDisassemblyTextForBuffer(buffer, bufferSize, addressContext, address, instructionNumber, out result).ThrowDbgEngNotOK();

            return result;
        }

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
