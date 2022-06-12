using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a stack frame of Microsoft intermediate language (MSIL) code. This interface is a subclass of the <see cref="ICorDebugFrame"/> interface.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugILFrame"/> interface is a specialized <see cref="ICorDebugFrame"/> interface. It is used either for MSIL code frames
    /// or for just-in-time (JIT) compiled frames. The JIT-compiled frames implement both the <see cref="ICorDebugILFrame"/> interface
    /// and the <see cref="ICorDebugNativeFrame"/> interface.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("03E26311-4F76-11D3-88C6-006097945418")]
    [ComImport]
    public interface ICorDebugILFrame : ICorDebugFrame
    {
        /// <summary>
        /// Gets a pointer to the chain this frame is a part of.
        /// </summary>
        /// <param name="ppChain">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the chain containing this frame.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetChain([MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);

        /// <summary>
        /// Gets a pointer to the code associated with this stack frame.
        /// </summary>
        /// <param name="ppCode">[out] A pointer to the address of an <see cref="ICorDebugCode"/> object that represents the code associated with this frame.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCode([MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

        /// <summary>
        /// Gets the function that contains the code associated with this stack frame.
        /// </summary>
        /// <param name="ppFunction">[out] A pointer to the address of an <see cref="ICorDebugFunction"/> object that represents the function containing the code associated with this stack frame.</param>
        /// <remarks>
        /// The GetFunction method may fail if the frame is not associated with any particular function.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetFunction([MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        /// <summary>
        /// Gets the metadata token for the function that contains the code associated with this stack frame.
        /// </summary>
        /// <param name="pToken">[out] A pointer to an <see cref="mdMethodDef"/> token that references the metadata for the function.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetFunctionToken(out mdMethodDef pToken);

        /// <summary>
        /// Gets the absolute address range of this stack frame.
        /// </summary>
        /// <param name="pStart">[out] A pointer to a <see cref="CORDB_ADDRESS"/> that specifies the starting address of the stack frame represented by this <see cref="ICorDebugFrame"/> object.</param>
        /// <param name="pEnd">[out] A pointer to a <see cref="CORDB_ADDRESS"/> that specifies the ending address of the stack frame represented by this <see cref="ICorDebugFrame"/> object.</param>
        /// <remarks>
        /// The address range of the stack is useful for piecing together interleaved stack traces gathered from multiple debugging
        /// engines. The numeric range provides no information about the contents of the stack frame. It is meaningful only
        /// for comparison of stack frame locations.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetStackRange(out CORDB_ADDRESS pStart, out CORDB_ADDRESS pEnd);

        /// <summary>
        /// Gets a pointer to the <see cref="ICorDebugFrame"/> object in the current chain that called this frame.
        /// </summary>
        /// <param name="ppFrame">[out] A pointer to the address of an <see cref="ICorDebugFrame"/> object that represents the calling frame. This value is null if the called frame is the outermost frame in the current chain.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCaller([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);

        /// <summary>
        /// Gets a pointer to the <see cref="ICorDebugFrame"/> object in the current chain that this frame called.
        /// </summary>
        /// <param name="ppFrame">[out] A pointer to the address of an <see cref="ICorDebugFrame"/> object that represents the called frame. This value is null if the calling frame is the innermost frame in the current chain.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCallee([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);

        /// <summary>
        /// Gets a stepper that allows the debugger to perform stepping operations relative to this <see cref="ICorDebugFrame"/>.
        /// </summary>
        /// <param name="ppStepper">[out] A pointer to the address of an <see cref="ICorDebugStepper"/> object that allows the debugger to perform stepping operations relative to the current frame.</param>
        /// <remarks>
        /// If the frame is not active, the stepper object will typically have to return to the frame before the step is completed.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CreateStepper([MarshalAs(UnmanagedType.Interface)] out ICorDebugStepper ppStepper);

        /// <summary>
        /// Gets the value of the instruction pointer and a bitwise combination value that describes how the value of the instruction pointer was obtained.
        /// </summary>
        /// <param name="pnOffset">[out] The value of the instruction pointer.</param>
        /// <param name="pMappingResult">[out] A pointer to a bitwise combination of the <see cref="CorDebugMappingResult"/> enumeration values that describe how the value of the instruction pointer was obtained.</param>
        /// <remarks>
        /// The value of the instruction pointer is the stack frame's offset into the function's Microsoft intermediate language
        /// (MSIL) code. If the stack frame is active, this address is the next instruction to execute. If the stack frame
        /// is not active, this address is the next instruction to execute when the stack frame is reactivated. If this frame
        /// is a just-in-time (JIT) compiled frame, the value of the instruction pointer will be determined by mapping backwards
        /// from the actual native instruction pointer, so the value may be only approximate.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetIP(out int pnOffset, out CorDebugMappingResult pMappingResult);

        /// <summary>
        /// Sets the instruction pointer to the specified offset location in the Microsoft intermediate language (MSIL) code.
        /// </summary>
        /// <param name="nOffset">The offset location in the MSIL code.</param>
        /// <remarks>
        /// Calls to SetIP immediately invalidate all frames and chains for the current thread. If the debugger needs frame
        /// information after a call to SetIP, it must perform a new stack trace. <see cref="ICorDebug"/> will attempt to keep
        /// the stack frame in a valid state. However, even if the frame is in a valid state, there still may be problems such
        /// as uninitialized local variables. The caller is responsible for ensuring the coherency of the running program.
        /// On 64-bit platforms, the instruction pointer cannot be moved out of a catch or finally block. If SetIP is called
        /// to make such a move on a 64-bit platform, it will return an <see cref="HRESULT"/> indicating failure.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetIP([In] int nOffset);

        /// <summary>
        /// Gets an enumerator for the local variables in this frame.
        /// </summary>
        /// <param name="ppValueEnum">[out] A pointer to the address of an <see cref="ICorDebugValueEnum"/> object that is the enumerator for the local variables in this frame.</param>
        /// <remarks>
        /// EnumerateLocalVariables gets an enumerator that can list the local variables available in the call frame that is
        /// represented by this <see cref="ICorDebugILFrame"/> object. The list may not include all of the local variables in the running
        /// function, because some of them may not be active.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateLocalVariables([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueEnum ppValueEnum);

        /// <summary>
        /// Gets the value of the specified local variable in this Microsoft intermediate language (MSIL) stack frame.
        /// </summary>
        /// <param name="dwIndex">[in] The index of the local variable in this MSIL stack frame.</param>
        /// <param name="ppValue">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the retrieved value.</param>
        /// <remarks>
        /// The GetLocalVariable method can be used either in an MSIL stack frame or in a just-in-time (JIT) compiled frame.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLocalVariable([In] int dwIndex, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// Gets an enumerator for the arguments in this frame.
        /// </summary>
        /// <param name="ppValueEnum">[out] A pointer to the address of an <see cref="ICorDebugValueEnum"/> object that is the enumerator for the arguments in this frame.</param>
        /// <remarks>
        /// EnumerateArguments gets an enumerator that can list the arguments available in the call frame that is represented
        /// by this <see cref="ICorDebugILFrame"/> object. The list will include arguments that are vararg (that is, a variable number of
        /// arguments) as well as arguments that are not vararg.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateArguments([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueEnum ppValueEnum);

        /// <summary>
        /// Gets the value of the specified argument in this Microsoft intermediate language (MSIL) stack frame.
        /// </summary>
        /// <param name="dwIndex">[in] The index of the argument in this MSIL stack frame.</param>
        /// <param name="ppValue">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the retrieved value.</param>
        /// <remarks>
        /// The GetArgument method can be used either in an MSIL stack frame or in a just-in-time (JIT) compiled frame.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetArgument([In] int dwIndex, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// This method has not been implemented.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetStackDepth(out int pDepth);

        /// <summary>
        /// This method has not been implemented.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetStackValue([In] int dwIndex, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// Gets an <see cref="HRESULT"/> that indicates whether it is safe to set the instruction pointer to the specified offset location in Microsoft Intermediate Language (MSIL) code.
        /// </summary>
        /// <param name="nOffset">[in] The desired setting for the instruction pointer.</param>
        /// <remarks>
        /// Use the CanSetIP method before calling the <see cref="SetIP"/> method. If CanSetIP returns any <see cref="HRESULT"/> other than
        /// S_OK, you can still invoke <see cref="SetIP"/>, but there is no guarantee that the debugger will continue the
        /// safe and correct execution of the code being debugged.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CanSetIP([In] int nOffset);
    }
}