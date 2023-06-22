using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugDebugEvent"/> interface to support exception events.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugExceptionDebugEvent"/> interface is implemented by the following event types:
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("AF79EC94-4752-419C-A626-5FB1CC1A5AB7")]
    [ComImport]
    public interface ICorDebugExceptionDebugEvent : ICorDebugDebugEvent
    {
#if !GENERATED_MARSHALLING
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
        new HRESULT GetEventKind(
            [Out] out CorDebugDebugEventKind pDebugEventKind);

        /// <summary>
        /// Gets the thread on which the event occurred.
        /// </summary>
        /// <param name="ppThread">[out] A pointer to the address of an <see cref="ICorDebugThread"/> object that represents the thread on which the event occurred.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);
#endif

        /// <summary>
        /// Gets the stack pointer for this exception debug event.
        /// </summary>
        /// <param name="pStackPointer">[out] A pointer to the address of the stack pointer for this exception debug event. See the Remarks section for more information.</param>
        /// <remarks>
        /// The meaning of this stack pointer depends on the event type, as shown in the following table. The event type is
        /// available from the <see cref="ICorDebugDebugEvent.GetEventKind"/> method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetStackPointer(
            [Out] out CORDB_ADDRESS pStackPointer);

        /// <summary>
        /// Gets the native instruction pointer for this exception debug event.
        /// </summary>
        /// <param name="pIP">[out] A pointer to the instruction pointer for this exception debug event. See the Remarks section for more information.</param>
        /// <remarks>
        /// The meaning of this instruction pointer depends on the event type, as shown in the following table. The event type
        /// is available from the <see cref="ICorDebugDebugEvent.GetEventKind"/> method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetNativeIP(
            [Out] out CORDB_ADDRESS pIP);

        /// <summary>
        /// Gets a flag that indicates whether the exception can be intercepted.
        /// </summary>
        /// <param name="pdwFlags">[out] A pointer to a <see cref="CorDebugExceptionFlags"/> value that indicates whether the exception can be intercepted.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFlags(
            [Out] out CorDebugExceptionFlags pdwFlags);
    }
}
