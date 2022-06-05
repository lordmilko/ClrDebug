using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a runtime-internal frame on the stack. This interface is a subclass of the ICorDebugFrame interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B92CC7F7-9D2D-45C4-BC2B-621FCC9DFBF4")]
    [ComImport]
    public interface ICorDebugInternalFrame : ICorDebugFrame
    {
        /// <summary>
        /// Gets a pointer to the chain this frame is a part of.
        /// </summary>
        /// <param name="ppChain">[out] A pointer to the address of an ICorDebugChain object that represents the chain containing this frame.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetChain([MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);

        /// <summary>
        /// Gets a pointer to the code associated with this stack frame.
        /// </summary>
        /// <param name="ppCode">[out] A pointer to the address of an ICorDebugCode object that represents the code associated with this frame.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCode([MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

        /// <summary>
        /// Gets the function that contains the code associated with this stack frame.
        /// </summary>
        /// <param name="ppFunction">[out] A pointer to the address of an ICorDebugFunction object that represents the function containing the code associated with this stack frame.</param>
        /// <remarks>
        /// The GetFunction method may fail if the frame is not associated with any particular function.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetFunction([MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        /// <summary>
        /// Gets the metadata token for the function that contains the code associated with this stack frame.
        /// </summary>
        /// <param name="pToken">[out] A pointer to an mdMethodDef token that references the metadata for the function.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetFunctionToken(out uint pToken);

        /// <summary>
        /// Gets the absolute address range of this stack frame.
        /// </summary>
        /// <param name="pStart">[out] A pointer to a CORDB_ADDRESS that specifies the starting address of the stack frame represented by this ICorDebugFrame object.</param>
        /// <param name="pEnd">[out] A pointer to a CORDB_ADDRESS that specifies the ending address of the stack frame represented by this ICorDebugFrame object.</param>
        /// <remarks>
        /// The address range of the stack is useful for piecing together interleaved stack traces gathered from multiple debugging
        /// engines. The numeric range provides no information about the contents of the stack frame. It is meaningful only
        /// for comparison of stack frame locations.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetStackRange(out ulong pStart, out ulong pEnd);

        /// <summary>
        /// Gets a pointer to the ICorDebugFrame object in the current chain that called this frame.
        /// </summary>
        /// <param name="ppFrame">[out] A pointer to the address of an ICorDebugFrame object that represents the calling frame. This value is null if the called frame is the outermost frame in the current chain.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCaller([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);

        /// <summary>
        /// Gets a pointer to the ICorDebugFrame object in the current chain that this frame called.
        /// </summary>
        /// <param name="ppFrame">[out] A pointer to the address of an ICorDebugFrame object that represents the called frame. This value is null if the calling frame is the innermost frame in the current chain.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCallee([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);

        /// <summary>
        /// Gets a stepper that allows the debugger to perform stepping operations relative to this ICorDebugFrame.
        /// </summary>
        /// <param name="ppStepper">[out] A pointer to the address of an ICorDebugStepper object that allows the debugger to perform stepping operations relative to the current frame.</param>
        /// <remarks>
        /// If the frame is not active, the stepper object will typically have to return to the frame before the step is completed.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CreateStepper([MarshalAs(UnmanagedType.Interface)] out ICorDebugStepper ppStepper);

        /// <summary>
        /// Gets the type of this internal frame.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the CorDebugInternalFrameType enumeration that indicates the type of internal frame represented by this ICorDebugInternalFrame object.</param>
        /// <remarks>
        /// The internal frame type will never be STUBFRAME_NONE. Debuggers should gracefully ignore unrecognized internal
        /// frame types.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFrameType(out CorDebugInternalFrameType pType);
    }
}