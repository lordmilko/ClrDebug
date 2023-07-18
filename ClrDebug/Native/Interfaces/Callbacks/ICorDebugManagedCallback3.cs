using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides a callback method that indicates that an enabled custom debugger notification has been raised.
    /// </summary>
    /// <remarks>
    /// This interface is a logical extension of the <see cref="ICorDebugManagedCallback"/> and <see cref="ICorDebugManagedCallback2"/>
    /// interfaces.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("264EA0FC-2591-49AA-868E-835E6515323F")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugManagedCallback3
    {
        /// <summary>
        /// Indicates that a custom debugger notification has been raised.
        /// </summary>
        /// <param name="pThread">[in] A pointer to the thread that raised the notification.</param>
        /// <param name="pAppDomain">[in] A pointer to the application domain that contains the thread that raised the notification.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                        |
        /// | ------- | ---------------------------------- |
        /// | S_OK    | The method completed successfully. |
        /// </returns>
        /// <remarks>
        /// A subsequent call to the <see cref="ICorDebugThread4.GetCurrentCustomDebuggerNotification"/> method retrieves the
        /// thread object that was passed to the <see cref="Debugger.NotifyOfCrossThreadDependency"/> method. The thread object's
        /// type must have been previously enabled by calling the <see cref="ICorDebugProcess3.SetEnableCustomNotification"/>
        /// method. The debugger can read type-specific parameters from the fields of the thread object, and can store responses
        /// into fields. The <see cref="ICorDebug"/> interface imposes no policy on the types of notifications or their contents,
        /// and the semantics of the notifications are strictly a contract between debuggers, applications, and the .NET Framework.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CustomNotification(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugAppDomain pAppDomain);
    }
}
