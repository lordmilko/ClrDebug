using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugBreakpoint"/> interface to provide access to specific values.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCAEB-8A68-11D2-983C-0000F808342D")]
    [ComImport]
    public interface ICorDebugValueBreakpoint : ICorDebugBreakpoint
    {
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

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugValue"/> object that represents the value of the object on which the breakpoint is set.
        /// </summary>
        /// <param name="ppValue">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetValue(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
    }
}
