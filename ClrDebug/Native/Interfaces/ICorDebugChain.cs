using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents a segment of a physical or logical call stack.
    /// </summary>
    /// <remarks>
    /// The stack frames in a chain occupy contiguous stack space and share the same thread and context. A chain may represent
    /// either managed or unmanaged code chains. An empty <see cref="ICorDebugChain"/> instance represents an unmanaged code chain.
    /// </remarks>
    [Guid("CC7BCAEE-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugChain
    {
        /// <summary>
        /// Gets the physical thread this call chain is part of.
        /// </summary>
        /// <param name="ppThread">[out] A pointer to an <see cref="ICorDebugThread"/> object that represents the physical thread this call chain is part of.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThread([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        /// <summary>
        /// Gets the address range of the stack segment for this chain.
        /// </summary>
        /// <param name="pStart">[out] A pointer to a <see cref="CORDB_ADDRESS"/> value that is the starting address of the stack segment.</param>
        /// <param name="pEnd">[out] A pointer to a <see cref="CORDB_ADDRESS"/> value that is the ending address of the stack segment.</param>
        /// <remarks>
        /// The numeric range is meaningful only for comparison of stack frame locations. You cannot make any assumptions about
        /// what is actually stored on the stack.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetStackRange([Out] out CORDB_ADDRESS pStart, [Out] out CORDB_ADDRESS pEnd);

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetContext([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugContext ppContext);

        /// <summary>
        /// Gets the chain that called this chain.
        /// </summary>
        /// <param name="ppChain">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the calling chain. If this chain was spontaneously called (as would be the case if this chain or the debugger initialized the call stack), ppChain will be null.</param>
        /// <remarks>
        /// The calling chain may be on a different thread, if the call was marshalled across threads.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCaller([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);

        /// <summary>
        /// Gets the chain that was called by this chain.
        /// </summary>
        /// <param name="ppChain">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the called chain. If this chain is currently executing (that is, if this chain is not waiting for a called chain to return), ppChain will be null.</param>
        /// <remarks>
        /// This chain will wait for the called chain to return before it resumes execution. The called chain may be on another
        /// thread in the case of cross-thread marshalled calls.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCallee([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);

        /// <summary>
        /// Gets the previous chain of frames for the thread.
        /// </summary>
        /// <param name="ppChain">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the previous chain of frames for this thread.<para/>
        /// If this chain is the first chain, ppChain is null.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetPrevious([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);

        /// <summary>
        /// Gets the next chain of frames for the thread.
        /// </summary>
        /// <param name="ppChain">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the next chain of frames for the thread.<para/>
        /// If this chain is the last chain, ppChain is null.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetNext([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);

        /// <summary>
        /// Gets a value that indicates whether this chain is running managed code.
        /// </summary>
        /// <param name="pManaged">[out] true if this chain is running managed code; otherwise, false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsManaged([Out] out int pManaged);

        /// <summary>
        /// Gets an enumerator that contains all the managed stack frames in the chain, starting with the most recent frame.
        /// </summary>
        /// <param name="ppFrames">[out] A pointer to the address of an <see cref="ICorDebugFrameEnum"/> object that is the enumerator for the stack frames.</param>
        /// <remarks>
        /// The chain represents the physical call stack for the thread. The EnumerateFrames method should be called only for
        /// managed chains. The debugging API does not provide methods for obtaining frames contained in unmanaged chains.
        /// The debugger must use other means to obtain this information.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateFrames([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFrameEnum ppFrames);

        /// <summary>
        /// Gets the active (that is, most recent) frame on the chain.
        /// </summary>
        /// <param name="ppFrame">[out] A pointer to the address of an <see cref="ICorDebugFrame"/> object that represents the active (that is, most recent) frame on the chain.</param>
        /// <remarks>
        /// If no managed stack frame is available, ppFrame is set to null. If the active frame is not available, the call
        /// will succeed and ppFrame will be null. Active frames will not be available for chains initiated due to CHAIN_ENTER_UNMANAGED,
        /// and for some chains initiated due to CHAIN_CLASS_INIT. See the <see cref="CorDebugChainReason"/> enumeration.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetActiveFrame([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);

        /// <summary>
        /// Gets the register set for the active part of this chain.
        /// </summary>
        /// <param name="ppRegisters">[out] A pointer to the address of an <see cref="ICorDebugRegisterSet"/> object that represents the register set for the active part of this chain.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRegisterSet([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugRegisterSet ppRegisters);

        /// <summary>
        /// Gets the reason for the genesis of this calling chain.
        /// </summary>
        /// <param name="pReason">[out] A pointer to a value (a bitwise combination) of the <see cref="CorDebugChainReason"/> enumeration that indicates the reason for the genesis of this calling chain.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetReason([Out] out CorDebugChainReason pReason);
    }
}