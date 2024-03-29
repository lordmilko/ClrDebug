﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Controls custom debugger notifications.
    /// </summary>
    /// <remarks>
    /// This interface logically extends the <see cref="ICorDebugProcess"/> and <see cref="ICorDebugProcess2"/> interfaces.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2EE06488-C0D4-42B1-B26D-F3795EF606FB")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugProcess3
    {
        /// <summary>
        /// Enables and disables custom debugger notifications of the specified type.
        /// </summary>
        /// <param name="pClass">[in] The type that specifies custom debugger notifications.</param>
        /// <param name="fEnable">[in] true to enable custom debugger notifications; false to disable notifications. The default value is false.</param>
        /// <remarks>
        /// When fEnable is set to true, calls to the <see cref="Debugger.NotifyOfCrossThreadDependency"/> method trigger an
        /// <see cref="ICorDebugManagedCallback3.CustomNotification"/> callback. Notifications are disabled by default; therefore,
        /// the debugger must specify any notification types it knows about and wants to handle. Because the <see cref="ICorDebug"/>
        /// class is scoped by application domain, the debugger must call SetEnableCustomNotification for every application
        /// domain in the process if it wants to receive the notification across the entire process. Starting with the .NET
        /// Framework 4, the only supported notification is a cross-thread dependency notification.
        /// </remarks>
        [PreserveSig]
        HRESULT SetEnableCustomNotification(
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugClass pClass,
            [In, MarshalAs(UnmanagedType.Bool)] bool fEnable);
    }
}
