using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCAF4-8A68-11D2-983C-0000F808342D")]
    [ComImport]
    public interface ICorDebugCode
    {
        /// <summary>
        /// Gets a value that indicates whether this "ICorDebugCode" represents code that was compiled in Microsoft intermediate language (MSIL).
        /// </summary>
        /// <param name="pbIL">[out] true if this <see cref="ICorDebugCode"/> represents code that was compiled in MSIL; otherwise, false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsIL(
            [Out] out bool pbIL);

        /// <summary>
        /// Gets the "ICorDebugFunction" associated with this "ICorDebugCode".
        /// </summary>
        /// <param name="ppFunction">[out] A pointer to the address of the function.</param>
        /// <remarks>
        /// <see cref="ICorDebugCode"/> and <see cref="ICorDebugFunction"/> maintain a one-to-one relationship.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFunction(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        /// <summary>
        /// Gets the relative virtual address (RVA) of the code segment that this "ICorDebugCode" interface represents.
        /// </summary>
        /// <param name="pStart">[out] A pointer to the RVA of the code segment.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAddress(
            [Out] out CORDB_ADDRESS pStart);

        /// <summary>
        /// Gets the size, in bytes, of the binary code represented by this "ICorDebugCode".
        /// </summary>
        /// <param name="pcBytes">[out] A pointer to the size, in bytes, of the binary code that this <see cref="ICorDebugCode"/> object represents.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSize(
            [Out] out int pcBytes);

        /// <summary>
        /// Creates a breakpoint in this code segment at the specified offset.
        /// </summary>
        /// <param name="offset">[in] The offset at which to create the breakpoint.</param>
        /// <param name="ppBreakpoint">[out] A pointer to the address of an "ICorDebugFunctionBreakpoint" object that represents the breakpoint.</param>
        /// <remarks>
        /// Before the breakpoint is active, it must be added to the process object. If this code is Microsoft intermediate
        /// language (MSIL) code, and there is a just-in-time (JIT)-compiled, native version of the code, the breakpoint will
        /// be applied in the JIT-compiled code as well. (The same is true if the code is JIT-compiled later.)
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateBreakpoint(
            [In] int offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunctionBreakpoint ppBreakpoint);

        /// <summary>
        /// Gets all the code for the specified function, formatted for disassembly. This method has been deprecated in the .NET Framework version 2.0.<para/>
        /// Use <see cref="ICorDebugCode2.GetCodeChunks"/> instead.
        /// </summary>
        /// <param name="startOffset">[in] The offset of the beginning of the function.</param>
        /// <param name="endOffset">[in] The offset of the end of the function.</param>
        /// <param name="cBufferAlloc">[in] The size of the buffer array into which the code will be returned.</param>
        /// <param name="buffer">[out] The array into which the code will be returned.</param>
        /// <param name="pcBufferSize">[out] The number of bytes returned.</param>
        /// <remarks>
        /// If the function's code has been divided into multiple chunks, they are concatenated in order of increasing native
        /// offset. Instruction boundaries are not checked.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCode(
            [In] int startOffset,
            [In] int endOffset,
            [In] int cBufferAlloc,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2), Out] byte[] buffer,
            [Out] out int pcBufferSize);

        /// <summary>
        /// Gets the one-based number that identifies the version of the code that this "ICorDebugCode" represents.
        /// </summary>
        /// <param name="nVersion">[out] A pointer to the version number of the code.</param>
        /// <remarks>
        /// The version number is incremented each time an edit-and-continue (EnC) operation is performed on the code.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVersionNumber(
            [Out] out int nVersion);

        /// <summary>
        /// Gets an array of "COR_DEBUG_IL_TO_NATIVE_MAP" instances that represent mappings from Microsoft intermediate language (MSIL) offsets to native offsets.
        /// </summary>
        /// <param name="cMap">[in] The size of the map array.</param>
        /// <param name="pcMap">[out] A pointer to the actual number of elements returned in the map array.</param>
        /// <param name="map">[out] An array of <see cref="COR_DEBUG_IL_TO_NATIVE_MAP"/> structures, each of which represents a mapping from an MSIL offset to a native offset.<para/>
        /// There is no ordering to the array of elements returned.</param>
        /// <remarks>
        /// The GetILToNativeMapping method returns meaningful results only if this "ICorDebugCode" instance represents native
        /// code that was just-in-time (JIT) compiled from MSIL code.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetILToNativeMapping(
            [In] int cMap,
            [Out] out int pcMap,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Out] COR_DEBUG_IL_TO_NATIVE_MAP[] map);

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetEnCRemapSequencePoints(
            [In] int cMap,
            [Out] out int pcMap,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Out] int[] offsets);
    }
}
