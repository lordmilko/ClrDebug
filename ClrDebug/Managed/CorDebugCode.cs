﻿using System;
using System.Diagnostics;
using System.Linq;

namespace ClrDebug
{
    /// <summary>
    /// Represents a segment of either Microsoft intermediate language (MSIL) code or native code.
    /// </summary>
    /// <remarks>
    /// <see cref="ICorDebugCode"/> can represent either MSIL or native code. An "ICorDebugFunction" object that represents MSIL code
    /// can have either zero or one <see cref="ICorDebugCode"/> objects associated with it. An "ICorDebugFunction" object that represents
    /// native code can have any number of <see cref="ICorDebugCode"/> objects associated with it.
    /// </remarks>
    public class CorDebugCode : ComObject<ICorDebugCode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugCode"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugCode(ICorDebugCode raw) : base(raw)
        {
        }

        #region ICorDebugCode
        #region IsIL

        /// <summary>
        /// Gets a value that indicates whether this "ICorDebugCode" represents code that was compiled in Microsoft intermediate language (MSIL).
        /// </summary>
        public bool IsIL
        {
            get
            {
                bool pbIL;
                TryIsIL(out pbIL).ThrowOnNotOK();

                return pbIL;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this "ICorDebugCode" represents code that was compiled in Microsoft intermediate language (MSIL).
        /// </summary>
        /// <param name="pbIL">[out] true if this <see cref="ICorDebugCode"/> represents code that was compiled in MSIL; otherwise, false.</param>
        public HRESULT TryIsIL(out bool pbIL)
        {
            /*HRESULT IsIL(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbIL);*/
            return Raw.IsIL(out pbIL);
        }

        #endregion
        #region Function

        /// <summary>
        /// Gets the "ICorDebugFunction" associated with this "ICorDebugCode".
        /// </summary>
        public CorDebugFunction Function
        {
            get
            {
                CorDebugFunction ppFunctionResult;
                TryGetFunction(out ppFunctionResult).ThrowOnNotOK();

                return ppFunctionResult;
            }
        }

        /// <summary>
        /// Gets the "ICorDebugFunction" associated with this "ICorDebugCode".
        /// </summary>
        /// <param name="ppFunctionResult">[out] A pointer to the address of the function.</param>
        /// <remarks>
        /// <see cref="ICorDebugCode"/> and <see cref="ICorDebugFunction"/> maintain a one-to-one relationship.
        /// </remarks>
        public HRESULT TryGetFunction(out CorDebugFunction ppFunctionResult)
        {
            /*HRESULT GetFunction(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);*/
            ICorDebugFunction ppFunction;
            HRESULT hr = Raw.GetFunction(out ppFunction);

            if (hr == HRESULT.S_OK)
                ppFunctionResult = ppFunction == null ? null : new CorDebugFunction(ppFunction);
            else
                ppFunctionResult = default(CorDebugFunction);

            return hr;
        }

        #endregion
        #region Address

        /// <summary>
        /// Gets the relative virtual address (RVA) of the code segment that this "ICorDebugCode" interface represents.
        /// </summary>
        public CORDB_ADDRESS Address
        {
            get
            {
                CORDB_ADDRESS pStart;
                TryGetAddress(out pStart).ThrowOnNotOK();

                return pStart;
            }
        }

        /// <summary>
        /// Gets the relative virtual address (RVA) of the code segment that this "ICorDebugCode" interface represents.
        /// </summary>
        /// <param name="pStart">[out] A pointer to the RVA of the code segment.</param>
        public HRESULT TryGetAddress(out CORDB_ADDRESS pStart)
        {
            /*HRESULT GetAddress(
            [Out] out CORDB_ADDRESS pStart);*/
            return Raw.GetAddress(out pStart);
        }

        #endregion
        #region Size

        /// <summary>
        /// Gets the size, in bytes, of the binary code represented by this "ICorDebugCode".
        /// </summary>
        public int Size
        {
            get
            {
                int pcBytes;
                TryGetSize(out pcBytes).ThrowOnNotOK();

                return pcBytes;
            }
        }

        /// <summary>
        /// Gets the size, in bytes, of the binary code represented by this "ICorDebugCode".
        /// </summary>
        /// <param name="pcBytes">[out] A pointer to the size, in bytes, of the binary code that this <see cref="ICorDebugCode"/> object represents.</param>
        public HRESULT TryGetSize(out int pcBytes)
        {
            /*HRESULT GetSize(
            [Out] out int pcBytes);*/
            return Raw.GetSize(out pcBytes);
        }

        #endregion
        #region VersionNumber

        /// <summary>
        /// Gets the one-based number that identifies the version of the code that this "ICorDebugCode" represents.
        /// </summary>
        public int VersionNumber
        {
            get
            {
                int nVersion;
                TryGetVersionNumber(out nVersion).ThrowOnNotOK();

                return nVersion;
            }
        }

        /// <summary>
        /// Gets the one-based number that identifies the version of the code that this "ICorDebugCode" represents.
        /// </summary>
        /// <param name="nVersion">[out] A pointer to the version number of the code.</param>
        /// <remarks>
        /// The version number is incremented each time an edit-and-continue (EnC) operation is performed on the code.
        /// </remarks>
        public HRESULT TryGetVersionNumber(out int nVersion)
        {
            /*HRESULT GetVersionNumber(
            [Out] out int nVersion);*/
            return Raw.GetVersionNumber(out nVersion);
        }

        #endregion
        #region ILToNativeMapping

        /// <summary>
        /// Gets an array of "COR_DEBUG_IL_TO_NATIVE_MAP" instances that represent mappings from Microsoft intermediate language (MSIL) offsets to native offsets.
        /// </summary>
        public COR_DEBUG_IL_TO_NATIVE_MAP[] ILToNativeMapping
        {
            get
            {
                COR_DEBUG_IL_TO_NATIVE_MAP[] map;
                TryGetILToNativeMapping(out map).ThrowOnNotOK();

                return map;
            }
        }

        /// <summary>
        /// Gets an array of "COR_DEBUG_IL_TO_NATIVE_MAP" instances that represent mappings from Microsoft intermediate language (MSIL) offsets to native offsets.
        /// </summary>
        /// <param name="map">[out] An array of <see cref="COR_DEBUG_IL_TO_NATIVE_MAP"/> structures, each of which represents a mapping from an MSIL offset to a native offset.<para/>
        /// There is no ordering to the array of elements returned.</param>
        /// <remarks>
        /// The GetILToNativeMapping method returns meaningful results only if this "ICorDebugCode" instance represents native
        /// code that was just-in-time (JIT) compiled from MSIL code.
        /// </remarks>
        public HRESULT TryGetILToNativeMapping(out COR_DEBUG_IL_TO_NATIVE_MAP[] map)
        {
            /*HRESULT GetILToNativeMapping(
            [In] int cMap,
            [Out] out int pcMap,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), SRI.Out] COR_DEBUG_IL_TO_NATIVE_MAP[] map);*/
            int cMap = 0;
            int pcMap;
            map = null;
            HRESULT hr = Raw.GetILToNativeMapping(cMap, out pcMap, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cMap = pcMap;
            map = new COR_DEBUG_IL_TO_NATIVE_MAP[cMap];
            hr = Raw.GetILToNativeMapping(cMap, out pcMap, map);
            fail:
            return hr;
        }

        #endregion
        #region EnCRemapSequencePoints

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        public int[] EnCRemapSequencePoints
        {
            get
            {
                int[] offsets;
                TryGetEnCRemapSequencePoints(out offsets).ThrowOnNotOK();

                return offsets;
            }
        }

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        public HRESULT TryGetEnCRemapSequencePoints(out int[] offsets)
        {
            /*HRESULT GetEnCRemapSequencePoints(
            [In] int cMap,
            [Out] out int pcMap,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), SRI.Out] int[] offsets);*/
            int cMap = 0;
            int pcMap;
            offsets = null;
            HRESULT hr = Raw.GetEnCRemapSequencePoints(cMap, out pcMap, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cMap = pcMap;
            offsets = new int[cMap];
            hr = Raw.GetEnCRemapSequencePoints(cMap, out pcMap, offsets);
            fail:
            return hr;
        }

        #endregion
        #region CreateBreakpoint

        /// <summary>
        /// Creates a breakpoint in this code segment at the specified offset.
        /// </summary>
        /// <param name="offset">[in] The offset at which to create the breakpoint.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugFunctionBreakpoint" object that represents the breakpoint.</returns>
        /// <remarks>
        /// Before the breakpoint is active, it must be added to the process object. If this code is Microsoft intermediate
        /// language (MSIL) code, and there is a just-in-time (JIT)-compiled, native version of the code, the breakpoint will
        /// be applied in the JIT-compiled code as well. (The same is true if the code is JIT-compiled later.)
        /// </remarks>
        public CorDebugFunctionBreakpoint CreateBreakpoint(int offset)
        {
            CorDebugFunctionBreakpoint ppBreakpointResult;
            TryCreateBreakpoint(offset, out ppBreakpointResult).ThrowOnNotOK();

            return ppBreakpointResult;
        }

        /// <summary>
        /// Creates a breakpoint in this code segment at the specified offset.
        /// </summary>
        /// <param name="offset">[in] The offset at which to create the breakpoint.</param>
        /// <param name="ppBreakpointResult">[out] A pointer to the address of an "ICorDebugFunctionBreakpoint" object that represents the breakpoint.</param>
        /// <remarks>
        /// Before the breakpoint is active, it must be added to the process object. If this code is Microsoft intermediate
        /// language (MSIL) code, and there is a just-in-time (JIT)-compiled, native version of the code, the breakpoint will
        /// be applied in the JIT-compiled code as well. (The same is true if the code is JIT-compiled later.)
        /// </remarks>
        public HRESULT TryCreateBreakpoint(int offset, out CorDebugFunctionBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateBreakpoint(
            [In] int offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunctionBreakpoint ppBreakpoint);*/
            ICorDebugFunctionBreakpoint ppBreakpoint;
            HRESULT hr = Raw.CreateBreakpoint(offset, out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = ppBreakpoint == null ? null : new CorDebugFunctionBreakpoint(ppBreakpoint);
            else
                ppBreakpointResult = default(CorDebugFunctionBreakpoint);

            return hr;
        }

        #endregion
        #region GetCode

        /// <summary>
        /// Gets all the code for the specified function, formatted for disassembly. This method has been deprecated in the .NET Framework version 2.0.<para/>
        /// Use <see cref="CodeChunks"/> instead.
        /// </summary>
        /// <param name="startOffset">[in] The offset of the beginning of the function.</param>
        /// <param name="endOffset">[in] The offset of the end of the function.</param>
        /// <param name="cBufferAlloc">[in] The size of the buffer array into which the code will be returned.</param>
        /// <returns>[out] The array into which the code will be returned.</returns>
        /// <remarks>
        /// If the function's code has been divided into multiple chunks, they are concatenated in order of increasing native
        /// offset. Instruction boundaries are not checked.
        /// </remarks>
        public byte[] GetCode(int startOffset, int endOffset, int cBufferAlloc)
        {
            byte[] buffer;
            TryGetCode(startOffset, endOffset, cBufferAlloc, out buffer).ThrowOnNotOK();

            return buffer;
        }

        /// <summary>
        /// Gets all the code for the specified function, formatted for disassembly. This method has been deprecated in the .NET Framework version 2.0.<para/>
        /// Use <see cref="CodeChunks"/> instead.
        /// </summary>
        /// <param name="startOffset">[in] The offset of the beginning of the function.</param>
        /// <param name="endOffset">[in] The offset of the end of the function.</param>
        /// <param name="cBufferAlloc">[in] The size of the buffer array into which the code will be returned.</param>
        /// <param name="buffer">[out] The array into which the code will be returned.</param>
        /// <remarks>
        /// If the function's code has been divided into multiple chunks, they are concatenated in order of increasing native
        /// offset. Instruction boundaries are not checked.
        /// </remarks>
        public HRESULT TryGetCode(int startOffset, int endOffset, int cBufferAlloc, out byte[] buffer)
        {
            /*HRESULT GetCode(
            [In] int startOffset,
            [In] int endOffset,
            [In] int cBufferAlloc,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2), SRI.Out] byte[] buffer,
            [Out] out int pcBufferSize);*/
            buffer = new byte[cBufferAlloc];
            int pcBufferSize;
            HRESULT hr = Raw.GetCode(startOffset, endOffset, cBufferAlloc, buffer, out pcBufferSize);

            if (cBufferAlloc != pcBufferSize)
                Array.Resize(ref buffer, pcBufferSize);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugCode2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugCode2 Raw2 => (ICorDebugCode2) Raw;

        #region CodeChunks

        /// <summary>
        /// Gets the chunks of code that this code object is composed of.
        /// </summary>
        public CodeChunkInfo[] CodeChunks
        {
            get
            {
                CodeChunkInfo[] chunks;
                TryGetCodeChunks(out chunks).ThrowOnNotOK();

                return chunks;
            }
        }

        /// <summary>
        /// Gets the chunks of code that this code object is composed of.
        /// </summary>
        /// <param name="chunks">[out] An array of "CodeChunkInfo" structures, each of which represents a single chunk of code. If the value of cbufSize is 0, this parameter can be null.</param>
        /// <remarks>
        /// The code chunks will never overlap, and they will follow the order in which they would have been concatenated by
        /// <see cref="GetCode"/>. A Microsoft intermediate language (MSIL) code object in the .NET Framework
        /// version 2.0 will comprise a single code chunk.
        /// </remarks>
        public HRESULT TryGetCodeChunks(out CodeChunkInfo[] chunks)
        {
            /*HRESULT GetCodeChunks(
            [In] int cbufSize,
            [Out] out int pcnumChunks,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), SRI.Out] CodeChunkInfo[] chunks);*/
            int cbufSize = 0;
            int pcnumChunks;
            chunks = null;
            HRESULT hr = Raw2.GetCodeChunks(cbufSize, out pcnumChunks, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cbufSize = pcnumChunks;
            chunks = new CodeChunkInfo[cbufSize];
            hr = Raw2.GetCodeChunks(cbufSize, out pcnumChunks, chunks);
            fail:
            return hr;
        }

        #endregion
        #region CompilerFlags

        /// <summary>
        /// Gets the flags that specify the conditions under which this code object was either just-in-time (JIT) compiled or generated using the native image generator (Ngen.exe).
        /// </summary>
        public CorDebugJITCompilerFlags CompilerFlags
        {
            get
            {
                CorDebugJITCompilerFlags pdwFlags;
                TryGetCompilerFlags(out pdwFlags).ThrowOnNotOK();

                return pdwFlags;
            }
        }

        /// <summary>
        /// Gets the flags that specify the conditions under which this code object was either just-in-time (JIT) compiled or generated using the native image generator (Ngen.exe).
        /// </summary>
        /// <param name="pdwFlags">[out] A pointer to a value of the <see cref="CorDebugJITCompilerFlags"/> enumeration that specifies the behavior of the JIT compiler or the native image generator.</param>
        public HRESULT TryGetCompilerFlags(out CorDebugJITCompilerFlags pdwFlags)
        {
            /*HRESULT GetCompilerFlags(
            [Out] out CorDebugJITCompilerFlags pdwFlags);*/
            return Raw2.GetCompilerFlags(out pdwFlags);
        }

        #endregion
        #endregion
        #region ICorDebugCode3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugCode3 Raw3 => (ICorDebugCode3) Raw;

        #region GetReturnValueLiveOffset

        /// <summary>
        /// For a specified IL offset, gets the native offsets where a breakpoint should be placed so that the debugger can obtain the return value from a function.
        /// </summary>
        /// <param name="ilOffset">The IL offset. It must be a function call site or the function call will fail.</param>
        /// <returns>An array of native offsets. Typically, pOffsets contains a single offset, although a single IL instruction can map to multiple map to multiple CALL assembly instructions.</returns>
        /// <remarks>
        /// This method is used along with the <see cref="CorDebugILFrame.GetReturnValueForILOffset"/> method to get the
        /// return value of a method that returns a reference type. Passing an IL offset to a function call site to this method
        /// returns one or more native offsets. The debugger can then set breakpoints on these native offsets in the function.
        /// When the debugger hits one of the breakpoints, you can then pass the same IL offset that you passed to this method
        /// to the <see cref="CorDebugILFrame.GetReturnValueForILOffset"/> method to get the return value. The debugger should
        /// then clear all the breakpoints that it set. The function returns the <see cref="HRESULT"/> values shown in the following table.
        /// The <see cref="GetReturnValueLiveOffset"/> method is available only on x86-based and AMD64 systems.
        /// </remarks>
        public int[] GetReturnValueLiveOffset(int ilOffset)
        {
            int[] pOffsets;
            TryGetReturnValueLiveOffset(ilOffset, out pOffsets).ThrowOnNotOK();

            return pOffsets;
        }

        /// <summary>
        /// For a specified IL offset, gets the native offsets where a breakpoint should be placed so that the debugger can obtain the return value from a function.
        /// </summary>
        /// <param name="ilOffset">The IL offset. It must be a function call site or the function call will fail.</param>
        /// <param name="pOffsets">An array of native offsets. Typically, pOffsets contains a single offset, although a single IL instruction can map to multiple map to multiple CALL assembly instructions.</param>
        /// <remarks>
        /// This method is used along with the <see cref="CorDebugILFrame.GetReturnValueForILOffset"/> method to get the
        /// return value of a method that returns a reference type. Passing an IL offset to a function call site to this method
        /// returns one or more native offsets. The debugger can then set breakpoints on these native offsets in the function.
        /// When the debugger hits one of the breakpoints, you can then pass the same IL offset that you passed to this method
        /// to the <see cref="CorDebugILFrame.GetReturnValueForILOffset"/> method to get the return value. The debugger should
        /// then clear all the breakpoints that it set. The function returns the <see cref="HRESULT"/> values shown in the following table.
        /// The <see cref="GetReturnValueLiveOffset"/> method is available only on x86-based and AMD64 systems.
        /// </remarks>
        public HRESULT TryGetReturnValueLiveOffset(int ilOffset, out int[] pOffsets)
        {
            /*HRESULT GetReturnValueLiveOffset(
            [In] int ilOffset,
            [In] int bufferSize,
            [Out] out int pFetched,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] pOffsets);*/
            int bufferSize = 0;
            int pFetched;
            pOffsets = null;
            HRESULT hr = Raw3.GetReturnValueLiveOffset(ilOffset, bufferSize, out pFetched, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = pFetched;
            pOffsets = new int[bufferSize];
            hr = Raw3.GetReturnValueLiveOffset(ilOffset, bufferSize, out pFetched, pOffsets);
            fail:
            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugCode4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugCode4 Raw4 => (ICorDebugCode4) Raw;

        #region EnumerateVariableHomes

        /// <summary>
        /// Gets an enumerator to the local variables and arguments in a function.
        /// </summary>
        public CorDebugVariableHome[] VariableHomes => EnumerateVariableHomes().ToArray();

        /// <summary>
        /// Gets an enumerator to the local variables and arguments in a function.
        /// </summary>
        /// <returns>A pointer to the address of an <see cref="ICorDebugVariableHomeEnum"/> interface object that is an enumerator for the local variables and arguments in a function.</returns>
        /// <remarks>
        /// The <see cref="ICorDebugVariableHomeEnum"/> interface object is a standard enumerator derived from the "ICorDebugEnum"
        /// interface that allows you to enumerate <see cref="ICorDebugVariableHome"/> objects. The collection may include
        /// multiple <see cref="ICorDebugVariableHome"/> objects for the same slot or argument index if they have different
        /// homes at different points in the function.
        /// </remarks>
        public CorDebugVariableHomeEnum EnumerateVariableHomes()
        {
            CorDebugVariableHomeEnum ppEnumResult;
            TryEnumerateVariableHomes(out ppEnumResult).ThrowOnNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// Gets an enumerator to the local variables and arguments in a function.
        /// </summary>
        /// <param name="ppEnumResult">A pointer to the address of an <see cref="ICorDebugVariableHomeEnum"/> interface object that is an enumerator for the local variables and arguments in a function.</param>
        /// <remarks>
        /// The <see cref="ICorDebugVariableHomeEnum"/> interface object is a standard enumerator derived from the "ICorDebugEnum"
        /// interface that allows you to enumerate <see cref="ICorDebugVariableHome"/> objects. The collection may include
        /// multiple <see cref="ICorDebugVariableHome"/> objects for the same slot or argument index if they have different
        /// homes at different points in the function.
        /// </remarks>
        public HRESULT TryEnumerateVariableHomes(out CorDebugVariableHomeEnum ppEnumResult)
        {
            /*HRESULT EnumerateVariableHomes(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugVariableHomeEnum ppEnum);*/
            ICorDebugVariableHomeEnum ppEnum;
            HRESULT hr = Raw4.EnumerateVariableHomes(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new CorDebugVariableHomeEnum(ppEnum);
            else
                ppEnumResult = default(CorDebugVariableHomeEnum);

            return hr;
        }

        #endregion
        #endregion
    }
}
