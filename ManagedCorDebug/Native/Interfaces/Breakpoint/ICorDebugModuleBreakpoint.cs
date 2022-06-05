using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides access to specific modules. This interface is a subclass of the ICorDebugBreakpoint interface.
    /// </summary>
    [Guid("CC7BCAEA-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugModuleBreakpoint : ICorDebugBreakpoint
    {
        /// <summary>
        /// Sets the active state of this ICorDebugBreakpoint.
        /// </summary>
        /// <param name="bActive">[in] Set this value to true to specify the state as active; otherwise, set this value to false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Activate([In] int bActive);

        /// <summary>
        /// Gets a value that indicates whether this ICorDebugBreakpoint is active.
        /// </summary>
        /// <param name="pbActive">[out] true if this breakpoint is active; otherwise, false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT IsActive(out int pbActive);

        /// <summary>
        /// Gets an interface pointer to an "ICorDebugModule" that references the module in which this breakpoint is set.
        /// </summary>
        /// <param name="ppModule">[out] A pointer to the address of an ICorDebugModule interface that references the module in which the breakpoint is set.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);
    }
}