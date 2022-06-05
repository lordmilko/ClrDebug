using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugDebugEvent"/> interface to support module-level events.
    /// </summary>
    /// <remarks>
    /// The <see cref="CorDebugDebugEventKind"/> and <see cref="CorDebugDebugEventKind"/> event types implement this interface.
    /// </remarks>
    [Guid("51A15E8D-9FFF-4864-9B87-F4FBDEA747A2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugModuleDebugEvent : ICorDebugDebugEvent
    {
        /// <summary>
        /// Indicates what kind of event this ICorDebugDebugEvent object represents.
        /// </summary>
        /// <param name="pDebugEventKind">A pointer to a <see cref="CorDebugDebugEventKind"/> enumeration member that indicates the type of event.</param>
        /// <remarks>
        /// Based on the value of pDebugEventKind, you can call QueryInterface to get a more precise debug event interface
        /// that has additional data.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetEventKind(out CorDebugDebugEventKind pDebugEventKind);

        /// <summary>
        /// Gets the thread on which the event occurred.
        /// </summary>
        /// <param name="ppThread">[out] A pointer to the address of an ICorDebugThread object that represents the thread on which the event occurred.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        /// <summary>
        /// Gets the merged module that was just loaded or unloaded.
        /// </summary>
        /// <param name="ppModule">[out] A pointer to the address of an ICorDebugModule object that represents the merged module that was just loaded or unloaded.</param>
        /// <remarks>
        /// You can call the <see cref="ICorDebugDebugEvent.GetEventKind"/> method to determine whether the module was loaded
        /// or unloaded.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);
    }
}