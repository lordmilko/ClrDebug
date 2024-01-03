using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugBreakpoint"/> interface to provide access to specific values.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCAEB-8A68-11D2-983C-0000F808342D")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugValueBreakpoint : ICorDebugBreakpoint
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Sets the active state of this <see cref="ICorDebugBreakpoint"/>.
        /// </summary>
        /// <param name="bActive">[in] Set this value to true to specify the state as active; otherwise, set this value to false.</param>
        [PreserveSig]
        new HRESULT Activate(
            [In, MarshalAs(UnmanagedType.Bool)] bool bActive);

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugBreakpoint"/> is active.
        /// </summary>
        /// <param name="pbActive">[out] true if this breakpoint is active; otherwise, false.</param>
        [PreserveSig]
        new HRESULT IsActive(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbActive);
#endif

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugValue"/> object that represents the value of the object on which the breakpoint is set.
        /// </summary>
        /// <param name="ppValue">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object.</param>
        [PreserveSig]
        HRESULT GetValue(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
    }
}
