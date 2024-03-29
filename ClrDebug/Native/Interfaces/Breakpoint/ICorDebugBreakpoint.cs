﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Represents a breakpoint in a function, or a watch point on a value.
    /// </summary>
    /// <remarks>
    /// Breakpoints do not directly support conditional expressions. If such functionality is desired, a debugger must
    /// implement it on top of <see cref="ICorDebugBreakpoint"/>. The <see cref="ICorDebugFunctionBreakpoint"/> interface extends <see cref="ICorDebugBreakpoint"/>
    /// to support breakpoints within functions.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCAE8-8A68-11D2-983C-0000F808342D")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugBreakpoint
    {
        /// <summary>
        /// Sets the active state of this <see cref="ICorDebugBreakpoint"/>.
        /// </summary>
        /// <param name="bActive">[in] Set this value to true to specify the state as active; otherwise, set this value to false.</param>
        [PreserveSig]
        HRESULT Activate(
            [In, MarshalAs(UnmanagedType.Bool)] bool bActive);

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugBreakpoint"/> is active.
        /// </summary>
        /// <param name="pbActive">[out] true if this breakpoint is active; otherwise, false.</param>
        [PreserveSig]
        HRESULT IsActive(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbActive);
    }
}
