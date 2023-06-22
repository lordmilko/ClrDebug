using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides access to specific modules. This interface is a subclass of the <see cref="ICorDebugBreakpoint"/> interface.
    /// </summary>
    [Guid("CC7BCAEA-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugModuleBreakpoint : ICorDebugBreakpoint
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Sets the active state of this <see cref="ICorDebugBreakpoint"/>.
        /// </summary>
        /// <param name="bActive">[in] Set this value to true to specify the state as active; otherwise, set this value to false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Activate(
            [In, MarshalAs(UnmanagedType.Bool)] bool bActive);

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugBreakpoint"/> is active.
        /// </summary>
        /// <param name="pbActive">[out] true if this breakpoint is active; otherwise, false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT IsActive(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbActive);
#endif

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugModule"/> that references the module in which this breakpoint is set.
        /// </summary>
        /// <param name="ppModule">[out] A pointer to the address of an <see cref="ICorDebugModule"/> interface that references the module in which the breakpoint is set.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);
    }
}
