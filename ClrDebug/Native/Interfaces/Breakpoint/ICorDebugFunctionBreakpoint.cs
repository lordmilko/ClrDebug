﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugBreakpoint"/> interface to support breakpoints within functions.
    /// </summary>
    [Guid("CC7BCAE9-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugFunctionBreakpoint : ICorDebugBreakpoint
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
        /// Gets an interface pointer to an <see cref="ICorDebugFunction"/> that references the function in which the breakpoint is set.
        /// </summary>
        /// <param name="ppFunction">[out] A pointer to the address of the function in which the breakpoint is set.</param>
        [PreserveSig]
        HRESULT GetFunction(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        /// <summary>
        /// Gets the offset of the breakpoint within the function.
        /// </summary>
        /// <param name="pnOffset">[out] A pointer to the offset of the breakpoint.</param>
        [PreserveSig]
        HRESULT GetOffset(
            [Out] out int pnOffset);
    }
}
