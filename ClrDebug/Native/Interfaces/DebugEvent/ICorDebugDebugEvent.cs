using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Defines the base interface from which all <see cref="ICorDebug"/> debug events derive.
    /// </summary>
    /// <remarks>
    /// The following interfaces are derived from the <see cref="ICorDebugDebugEvent"/> interface:
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("41BD395D-DE99-48F1-BF7A-CC0F44A6D281")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugDebugEvent
    {
        /// <summary>
        /// Indicates what kind of event this <see cref="ICorDebugDebugEvent"/> object represents.
        /// </summary>
        /// <param name="pDebugEventKind">A pointer to a <see cref="CorDebugDebugEventKind"/> enumeration member that indicates the type of event.</param>
        /// <remarks>
        /// Based on the value of pDebugEventKind, you can call QueryInterface to get a more precise debug event interface
        /// that has additional data.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetEventKind(
            [Out] out CorDebugDebugEventKind pDebugEventKind);

        /// <summary>
        /// Gets the thread on which the event occurred.
        /// </summary>
        /// <param name="ppThread">[out] A pointer to the address of an <see cref="ICorDebugThread"/> object that represents the thread on which the event occurred.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);
    }
}
